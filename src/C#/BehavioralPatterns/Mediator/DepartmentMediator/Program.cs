using System;
using System.Collections.Generic;

namespace DepartmentMediator
{
    public interface IDepartmentGroupMediator
    {
        void RegisterUser(User user);

        void SendAcknowledgement(string message, User user);

        void SendMultipleAcknowledgements(string message, User user);
    }

    public class DepartmentGroupMediator : IDepartmentGroupMediator
    {
        private readonly List<User> usersInDepartmentGroup = new List<User>();

        public void RegisterUser(User user)
        {
            usersInDepartmentGroup.Add(user);
        }

        public void SendAcknowledgement(string message, User user)
        {
            user.ReceiveAcknowledgement(message, user);
        }

        public void SendMultipleAcknowledgements(string message, User user)
        {
            foreach (var userInDepartmentGroup in usersInDepartmentGroup)
            {
                if (userInDepartmentGroup.Department == user.Department && !userInDepartmentGroup.IsExaminer)
                {
                    userInDepartmentGroup.ReceiveAcknowledgement(message, userInDepartmentGroup);
                }
            }
        }
    }

    public abstract class User
    {
        protected IDepartmentGroupMediator departmentGroupMediator;

        public User(IDepartmentGroupMediator departmentGroupMediator, string name, string department, bool isExaminer)
        {
            this.departmentGroupMediator = departmentGroupMediator;
            Name = name;
            Department = department;
            IsExaminer = isExaminer;
        }

        public string Name { get; set; }

        public string Department { get; set; }

        public bool IsExaminer { get; private set; }

        public abstract void SendAcknowledgement(string message, User user);

        public abstract void SendNoticeToStudents(string message, User user);

        public abstract void ReceiveAcknowledgement(string message, User user);

        public abstract void RegisterSubjects(string[] subjects, User user);
    }

    public class SchoolMember : User
    {
        public SchoolMember(IDepartmentGroupMediator departmentGroupMediator, string name, string department, bool isExaminer)
            : base(departmentGroupMediator, name, department, isExaminer)
        {

        }

        public override void ReceiveAcknowledgement(string message, User user)
        {
            Console.WriteLine($"{user.Name} : Received Message: {message}");
        }

        public override void RegisterSubjects(string[] subjects, User user)
        {
            Console.WriteLine($"{Name} : Submitting Subjects: {subjects.Length} subjects submitted to the department of {Department} \n");
            string acknowledgementMessage = $"{subjects.Length} subjects submitted by {Name} and Received by {user.Name}";
            departmentGroupMediator.SendAcknowledgement(acknowledgementMessage, user);
        }

        public override void SendAcknowledgement(string message, User user)
        {
            Console.WriteLine($"{Name} : Sending Message : {message} \n");
            departmentGroupMediator.SendAcknowledgement(message, user);
        }

        public override void SendNoticeToStudents(string message, User user)
        {
            Console.WriteLine($"{Name} : Sending Message : {message} \n");
            departmentGroupMediator.SendMultipleAcknowledgements(message, user);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            IDepartmentGroupMediator departmentMediator = new DepartmentGroupMediator();

            User firstStudent = new SchoolMember(departmentMediator, "Bob", "Information Technologies", false);
            User secondStudent = new SchoolMember(departmentMediator, "Mary", "Mechanics", false);
            User thirdStudent = new SchoolMember(departmentMediator, "Frank", "Mechanics", false);

            User firstExaminer = new SchoolMember(departmentMediator, "Philip", "Information Technologies", true);
            User secondExaminer = new SchoolMember(departmentMediator, "Sarah", "Mechanics", true);

            List<User> usersToRegister = new List<User>
            {
                firstStudent,
                secondStudent,
                thirdStudent,
                firstExaminer,
                secondExaminer
            };

            foreach (var userToRegister in usersToRegister)
            {
                departmentMediator.RegisterUser(userToRegister);
            }

            firstStudent.SendAcknowledgement("Hello sir, I would like to register my class subjects today", firstExaminer);
            Console.WriteLine();
            secondExaminer.SendNoticeToStudents("June 30th is the deadline to submit all class subjects ", secondExaminer);
            Console.WriteLine();

            firstExaminer.SendAcknowledgement("Go ahead, its about time you did", firstStudent);
            thirdStudent.SendAcknowledgement("Alright. I'll be submitting mine right away", secondExaminer);

            string[] computerSystemsAndTechnologiesSubjects = { "Java", "C#", "Python", "MS SQL" };
            firstStudent.RegisterSubjects(computerSystemsAndTechnologiesSubjects, firstExaminer);

            string[] mechanicsSubjects = { "English", "CAD", "Mathematics" };
            thirdStudent.RegisterSubjects(mechanicsSubjects, secondExaminer);
        }
    }
}
