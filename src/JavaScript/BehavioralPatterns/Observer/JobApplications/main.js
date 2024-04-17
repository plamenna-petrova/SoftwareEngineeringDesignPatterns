
class Application {
    constructor(jobId, applicantName) {
        this.JobId = jobId;
        this.ApplicantName = applicantName;
    }
}

class HRSpecialist {
    constructor(name) {
        this.Name = name;
        this.Applications = [];
        this.disposable = null;
    }

    subscribe(applicationHandler) {
        this.disposable = applicationHandler.subscribe(this);
    }

    unsubscribe() {
        this.disposable.dispose();
        this.Applications = [];
    }

    listApplications() {
        if (this.Applications.length > 0) {
            this.Applications.forEach(application => {
                console.log(`Hey, ${this.Name}! ${application.ApplicantName} has just applied for job No. ${application.JobId}`);
            });
        } else {
            console.log(`Hey, ${this.Name}! No applications yet.`);
        }
    }

    onCompleted() {
        console.log(`Hey, ${this.Name}! We are not accepting any more applications`);
    }

    onError(exception) {
        // called by the application handler if any exception is raised
    }

    onNext(nextApplication) {
        this.Applications.push(nextApplication);
    }
}

class ApplicationHandler {
    constructor() {
        this.applicationObservers = [];
        this.Applications = [];
    }

    subscribe(applicationObserver) {
        if (!this.applicationObservers.includes(applicationObserver)) {
            this.applicationObservers.push(applicationObserver);

            this.Applications.forEach(application => {
                applicationObserver.onNext(application);
            });
        }

        return new UnSubscriber(this.applicationObservers, applicationObserver);
    }

    addApplication(application) {
        this.Applications.push(application);

        this.applicationObservers.forEach(applicationObserver => {
            applicationObserver.onNext(application);
        });
    }

    closeApplication() {
        this.applicationObservers.forEach(applicationObserver => {
            applicationObserver.onCompleted();
        });

        this.applicationObservers = [];
    }
}

class UnSubscriber {
    constructor(applicationObservers, applicationObserver) {
        this.applicationObservers = applicationObservers;
        this.applicationObserver = applicationObserver;
    }

    dispose() {
        const applicationObserverToDisposeIndex = this.applicationObservers.indexOf(this.applicationObserver);

        if (applicationObserverToDisposeIndex !== -1) {
            this.applicationObservers.splice(applicationObserverToDisposeIndex, 1);
        }
    }
}

const firstHRSpecialist = new HRSpecialist("Bill");
const secondHRSpecialist = new HRSpecialist("John");

const applicationHandler = new ApplicationHandler();

firstHRSpecialist.subscribe(applicationHandler);
secondHRSpecialist.subscribe(applicationHandler);

applicationHandler.addApplication(new Application(1, "Jacob"));
applicationHandler.addApplication(new Application(2, "Dave"));

firstHRSpecialist.listApplications();
secondHRSpecialist.listApplications();

firstHRSpecialist.unsubscribe();

console.log();
console.log(`${firstHRSpecialist.Name} unsubscribed`);
console.log();

applicationHandler.addApplication(new Application(3, "Sofia"));

firstHRSpecialist.listApplications();
secondHRSpecialist.listApplications();

console.log();

applicationHandler.closeApplication();