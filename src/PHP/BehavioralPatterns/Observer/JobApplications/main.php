<?php

interface IObserver {
    public function subscribe($applicationHandler);

    public function unsubscribe();

    public function onCompleted();

    public function onError($exception);

    public function onNext($application);
}

interface IObservable {
    public function subscribe($observers);
}

class Application {
    public int $jobId;
    public string $applicantName;

    public function __construct($jobId, $applicantName) {
        $this->jobId = $jobId;
        $this->applicantName = $applicantName;
    }
}

class HRSpecialist implements IObserver {
    private $disposable;

    public string $name;

    public array $applications = [];

    public function __construct($name) {
        $this->name = $name;
    }

    public function listApplications(): void
    {
        if (!empty($this->applications)) {
            foreach ($this->applications as $application) {
                echo "Hey, {$this->name}! {$application->applicantName} has just applied for job No. {$application->jobId}\n";
            }
        } else {
            echo "Hey, {$this->name}! No applications yet.\n";
        }
    }

    public function subscribe($applicationHandler): void
    {
        $this->disposable = $applicationHandler->subscribe($this);
    }

    public function unsubscribe(): void
    {
        $this->disposable->dispose();
        $this->applications = [];
    }

    public function onCompleted(): void
    {
        echo "Hey, {$this->name}! We are not accepting any more applications\n";
    }

    public function onError($exception) {
        // called by the application handler if any exception is raised
    }

    public function onNext($nextApplication): void
    {
        $this->applications[] = $nextApplication;
    }
}

class ApplicationHandler implements IObservable {
    private array $applicationObservers = [];
    public array $applications = [];

    public function subscribe($applicationObserver): UnSubscriber
    {
        if (!in_array($applicationObserver, $this->applicationObservers)) {
            $this->applicationObservers[] = $applicationObserver;

            foreach ($this->applications as $application) {
                $applicationObserver->onNext($application);
            }
        }

        return new UnSubscriber($this->applicationObservers, $applicationObserver);
    }

    public function addApplication($application): void
    {
        $this->applications[] = $application;

        foreach ($this->applicationObservers as $applicationObserver) {
            $applicationObserver->onNext($application);
        }
    }

    public function closeApplication(): void
    {
        foreach ($this->applicationObservers as $applicationObserver) {
            $applicationObserver->onCompleted();
        }

        $this->applicationObservers = [];
    }
}

class UnSubscriber {
    private array $applicationObservers;
    private IObserver $applicationObserver;

    public function __construct($applicationObservers, $applicationObserver) {
        $this->applicationObservers = $applicationObservers;
        $this->applicationObserver = $applicationObserver;
    }

    public function dispose(): void
    {
        $key = array_search($this->applicationObserver, $this->applicationObservers);

        if ($key !== false) {
            unset($this->applicationObservers[$key]);
        }
    }
}

$firstHRSpecialist = new HRSpecialist("Bill");
$secondHRSpecialist = new HRSpecialist("John");

$applicationHandler = new ApplicationHandler();

$firstHRSpecialist->subscribe($applicationHandler);
$secondHRSpecialist->subscribe($applicationHandler);

$applicationHandler->addApplication(new Application(1, "Jacob"));
$applicationHandler->addApplication(new Application(2, "Dave"));

$firstHRSpecialist->listApplications();
$secondHRSpecialist->listApplications();

$firstHRSpecialist->unsubscribe();

echo "\n{$firstHRSpecialist->name} unsubscribed\n\n";

$applicationHandler->addApplication(new Application(3, "Sofia"));

$firstHRSpecialist->listApplications();
$secondHRSpecialist->listApplications();

echo "\n";

$applicationHandler->closeApplication();
