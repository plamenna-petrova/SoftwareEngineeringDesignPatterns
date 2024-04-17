import java.util.ArrayList;
import java.util.List;

interface IObserver<T> {
    void subscribe(ApplicationHandler applicationHandler);

    void unsubscribe();

    void onCompleted();

    void onError(Exception exception);

    void onNext(Application application);
}

interface IObservable<T> {
    void subscribe(IObserver<T> observers);
}

class Application {
    private final int jobId;
    private final String applicantName;

    public Application(int jobId, String applicantName) {
        this.jobId = jobId;
        this.applicantName = applicantName;
    }

    public int getJobId() {
        return jobId;
    }

    public String getApplicantName() {
        return applicantName;
    }
}

class HRSpecialist implements IObserver<Application> {
    private final String name;
    private final List<Application> applications = new ArrayList<>();
    private IDisposable disposable;

    public HRSpecialist(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    public void listApplications() {
        if (!applications.isEmpty()) {
            for (Application application : applications) {
                System.out.printf("Hey, %s! %s has just applied for job No. %d%n", name, application.getApplicantName(), application.getJobId());
            }
        } else {
            System.out.printf("Hey, %s! No applications yet.%n", name);
        }
    }

    @Override
    public void subscribe(ApplicationHandler applicationHandler) {
        disposable = applicationHandler.subscribe(this);
    }

    @Override
    public void unsubscribe() {
        disposable.dispose();
        applications.clear();
    }

    @Override
    public void onCompleted() {
        System.out.printf("Hey, %s! We are not accepting any more applications%n", name);
    }

    @Override
    public void onError(Exception exception) {
        // called by the application handler if any exception is raised
    }

    @Override
    public void onNext(Application nextApplication) {
        applications.add(nextApplication);
    }
}

interface IDisposable {
    void dispose();
}

class ApplicationHandler implements IObservable<Application> {
    private final List<IObserver<Application>> applicationObservers = new ArrayList<>();
    private final List<Application> applications = new ArrayList<>();

    @Override
    public void subscribe(IObserver<Application> applicationObserver) {
        if (!applicationObservers.contains(applicationObserver)) {
            applicationObservers.add(applicationObserver);
            for (Application application : applications) {
                applicationObserver.onNext(application);
            }
        }
    }

    public IDisposable subscribe(HRSpecialist applicationObserver) {
        subscribe((IObserver<Application>) applicationObserver);
        return () -> applicationObservers.remove(applicationObserver);
    }

    public void addApplication(Application application) {
        applications.add(application);
        for (IObserver<Application> applicationObserver : applicationObservers) {
            applicationObserver.onNext(application);
        }
    }

    public void closeApplication() {
        for (IObserver<Application> applicationObserver : applicationObservers) {
            applicationObserver.onCompleted();
        }
        applicationObservers.clear();
    }
}

public class Main {
    public static void main(String[] args) {
        HRSpecialist firstHRSpecialist = new HRSpecialist("Bill");
        HRSpecialist secondHRSpecialist = new HRSpecialist("John");

        ApplicationHandler applicationHandler = new ApplicationHandler();

        firstHRSpecialist.subscribe(applicationHandler);
        secondHRSpecialist.subscribe(applicationHandler);

        applicationHandler.addApplication(new Application(1, "Jacob"));
        applicationHandler.addApplication(new Application(2, "Dave"));

        firstHRSpecialist.listApplications();
        secondHRSpecialist.listApplications();

        firstHRSpecialist.unsubscribe();

        System.out.println();
        System.out.println(firstHRSpecialist.getName() + " unsubscribed");
        System.out.println();

        applicationHandler.addApplication(new Application(3, "Sofia"));

        firstHRSpecialist.listApplications();
        secondHRSpecialist.listApplications();

        System.out.println();

        applicationHandler.closeApplication();
    }
}