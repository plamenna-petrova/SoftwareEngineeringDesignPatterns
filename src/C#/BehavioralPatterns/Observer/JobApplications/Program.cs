using System;
using System.Collections.Generic;
using System.Linq;

namespace JobApplications
{
    public class Application
    {
        public Application(int jobId, string applicantName)
        {
            JobId = jobId;
            ApplicantName = applicantName;
        }

        public int JobId { get; set; }

        public string ApplicantName { get; set; }
    }

    public interface IObserver<T>
    {
        void Subscribe(ApplicationHandler applicationHandler);

        void Unsubscribe();

        void OnCompleted();

        void OnError(Exception exception);

        void OnNext(Application application);
    }

    public interface IObservable<T>
    {
        IDisposable Subscribe(IObserver<T> observers);
    }

    public class HRSpecialist : IObserver<Application>
    {
        private IDisposable disposable;

        public HRSpecialist(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public List<Application> Applications { get; set; } = new List<Application>();

        public void ListApplications()
        {
            if (Applications.Any())
            {
                foreach (var application in Applications)
                {
                    Console.WriteLine($"Hey, {Name}! {application.ApplicantName} has just applied for job No. {application.JobId}");
                }
            }
            else
            {
                Console.WriteLine($"Hey, {Name}! No applications yet.");
            }
        }

        public virtual void Subscribe(ApplicationHandler applicationHandler)
        {
            disposable = applicationHandler.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            disposable.Dispose();
            Applications.Clear();
        }

        public void OnCompleted()
        {
            Console.WriteLine($"Hey, {Name}! We are not accepting any more applications");
        }

        public void OnError(Exception exception)
        {
            // called by the application handler if any exception is raised
        }

        public void OnNext(Application nextApplication)
        {
            Applications.Add(nextApplication);
        }
    }

    public class ApplicationHandler : IObservable<Application>
    {
        private readonly List<IObserver<Application>> applicationObservers;

        public ApplicationHandler()
        {
            applicationObservers = new List<IObserver<Application>>();
            Applications = new List<Application>();
        }

        public List<Application> Applications { get; set; }

        public IDisposable Subscribe(IObserver<Application> applicationObserver)
        {
            if (!applicationObservers.Contains(applicationObserver))
            {
                applicationObservers.Add(applicationObserver);

                foreach (var application in Applications)
                {
                    applicationObserver.OnNext(application);
                }
            }

            return new UnSubscriber(applicationObservers, applicationObserver);
        }

        public void AddApplication(Application application)
        {
            Applications.Add(application);

            foreach (var applicationObserver in applicationObservers)
            {
                applicationObserver.OnNext(application);
            }
        }

        public void CloseApplication()
        {
            foreach (var applicationObserver in applicationObservers)
            {
                applicationObserver.OnCompleted();
            }

            applicationObservers.Clear();
        }
    }

    public class UnSubscriber : IDisposable
    {
        private readonly List<IObserver<Application>> applicationObservers;

        private readonly IObserver<Application> applicationObserver;

        public UnSubscriber(List<IObserver<Application>> applicationObservers, IObserver<Application> applicationObserver)
        {
            this.applicationObservers = applicationObservers;
            this.applicationObserver = applicationObserver;
        }

        public void Dispose()
        {
            if (applicationObservers.Contains(applicationObserver))
            {
                applicationObservers.Remove(applicationObserver);
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var firstHRSpecialist = new HRSpecialist("Bill");
            var secondHRSpecialist = new HRSpecialist("John");

            var applicationHandler = new ApplicationHandler();

            firstHRSpecialist.Subscribe(applicationHandler);
            secondHRSpecialist.Subscribe(applicationHandler);

            applicationHandler.AddApplication(new Application(1, "Jacob"));
            applicationHandler.AddApplication(new Application(2, "Dave"));

            firstHRSpecialist.ListApplications();
            secondHRSpecialist.ListApplications();

            firstHRSpecialist.Unsubscribe();

            Console.WriteLine();
            Console.WriteLine($"{firstHRSpecialist.Name} unsubscribed");
            Console.WriteLine();

            applicationHandler.AddApplication(new Application(3, "Sofia"));

            firstHRSpecialist.ListApplications();
            secondHRSpecialist.ListApplications();

            Console.WriteLine();

            applicationHandler.CloseApplication();
        }
    }
}
