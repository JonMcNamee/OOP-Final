using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace McNameeOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee();
            employee1.ID = 1111;
            employee1.fstName = "Jon";
            employee1.lstName = "McNamee";

            Employee employee2 = new Employee(5555, "Thomas", "Sankara");

            Hardware issue1 = new Hardware(1000, employee1, 1, "Printer is out of ink.", "In Progress", 0, "HP Inkjet", "ABC123");
            Software issue2 = new Software(1005, employee2, 0, "Recycle bin is only saving last 10 deleted items.", "In Progress", 0, "Windows", "10");
            Software issue3 = new Software(1010, employee1, 2, "C# does not include unit testing feature", "Reinstalled the program", 35, "Visual Studio", "2022.17.3");

            List<Issues> issues = new List<Issues>();

            issues.Add(issue1);
            issues.Add(issue2);
            issues.Add(issue3);

            //commenting out compare code, was still working on it when time was called
            int result = issue1.CompareTo(issue2);
            CompareSeverity(result, issue1, issue2);

            Console.WriteLine(issue1.ToString());
            Console.WriteLine('\n');
            Console.WriteLine(issue2.ToString());
            Console.WriteLine('\n');
            Console.WriteLine(issue3.ToString());

            Console.ReadLine();
        }
        public static void CompareSeverity(int result, Issues issue1, Issues issue2)
        {
            //compare not quite working right, returning 0 always
            if(result == -1)
            {
                Console.WriteLine($"Tracking Number {issue1.Tracking} is lower priority than Tracking Number: {issue2.Tracking}");
            }
            else if(result == 0)
            {
                Console.WriteLine($"Tracking Number {issue1.Tracking} is the same priority as Tracking Number: {issue2.Tracking}");
            }
            else if (result == 1)
            {
                Console.WriteLine($"Tracking Number {issue1.Tracking} is higher priority than Tracking Number: {issue2.Tracking}");
            }
        }

    }

    public class Employee
    {
        public int ID { get; set; }
        public string fstName { get; set; }
        public string lstName { get; set; }

        public Employee()
        {

        }

        public Employee(int inID, string inFstName, string inLstName)
        {
            ID = inID;
            fstName = inFstName;
            lstName = inLstName;
        }

        public override string ToString() =>
            String.Format("Employee ID: ", ID, '\n', "Employee Name:" , fstName, lstName, '\n');

    }

    public abstract class Issues : IComparable<Issues>
    {
        //out of time, did not finalize data being stored to meet specifications (tracking manually set at this time
        public int Tracking
        {
            get; set;
        }
        public Employee emp { get; set; }

            public int severity;
        public int Severity { get; set; }

        public int CompareTo(Issues issue)
        {
            if (this.severity > issue.severity)
            {
                return -1;
            }
            else if (this.severity < issue.severity)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public string Description { get; set; }

        public string solution;
        public string Solution
        {
            get { return solution; }
            set { solution = "In Progress"; }
        }

        public int fixTime;
        public int FixTime
        {
            get { return fixTime; }
            set
            {
                fixTime = 0;
            }
        }

        public Issues()
        {
            Tracking = 1000;

            Tracking += 5;
        }

        public Issues(int inTracking, Employee emp, int inSeverity, string inDescription, string inSolution, int inFixTime)
        {
            Tracking = inTracking;
            this.emp = emp;
            Severity = inSeverity;
            Description = inDescription;
            Solution = inSolution;
            FixTime = inFixTime;
        }

        public void CloseIssue(string solution, int fixTime)
        {
            //out of time, unable to finish method
        }

        /* Ran out of time, was editing class ToString to properly display data
        public override ToString()
        {

        }*/
    }

    public sealed class Hardware : Issues
    {
        public string Type { get; set; }
        public string ModelNum { get; set; }

        public Hardware() : base()
        {

        }

        public Hardware(int inTracking, Employee emp, int inSeverity, string inDescription, string inSolution, int inFixTime, string type, string modelNum)
            : base(inTracking, emp, inSeverity, inDescription, inSolution, inFixTime)
        {
            Type = type;
            ModelNum = modelNum;
        }
        public override string ToString() =>
            String.Format("Type of Issue: Hardware", '\n', "Tracking Number: ", Tracking, '\n',
                "Employee ID: ", emp.ID, '\n', "Employee Name: ", emp.fstName, ' ', emp.lstName, '\n',
                "Severity: ", Severity, '\n', "Description: ", Description, '\n', "Solution: ", Solution, '\n',
                "Fix Time: ", FixTime, '\n', "Type: ", Type, '\n', "Model: ", ModelNum);

    }

    public sealed class Software : Issues
    {
        public string Program { get; set; }
        public string Version { get; set; }

        public Software() : base()
        {

        }
        public Software(int inTracking, Employee emp, int inSeverity, string inDescription, string inSolution, int inFixTime, string program, string version)
            : base(inTracking, emp, inSeverity, inDescription, inSolution, inFixTime)

        {
            Program = program;
            Version = version;
        }

        public override string ToString() =>
            String.Format("Type of Issue: Software", '\n', "Tracking Number: ", Tracking, '\n',
                "Employee ID: ", emp.ID, '\n', "Employee Name: ", emp.fstName, ' ', emp.lstName, '\n',
                "Severity: ", Severity, '\n', "Description: ", Description, '\n', "Solution: ", Solution, '\n',
                "Fix Time: ", FixTime, '\n', "Program: ", Program, '\n', "Version: ", Version);

    }
}
