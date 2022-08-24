using System;
using ProfessorsDetails;
using Students;

namespace DAY_16_TASK2
{
    class Program
    {
        static void Main(string[] args)
        {
            studentsDetails student = new studentsDetails();
            Professor professor = new Professor();
            string repeat = "Y";
            while(repeat == "Y" || repeat == "y")
            {
                Console.WriteLine("Press 1 to enter and show students details");
                Console.WriteLine("Press 2 to enter and show professors details");

                int keypress = int.Parse(Console.ReadLine());

                switch (keypress)
                {
                    case 1:
                        Console.WriteLine("Enter student name");
                        student.name = Console.ReadLine();

                        Console.WriteLine("Enter student ID");
                        student.stuid = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter student's branch");
                        student.branch = Console.ReadLine();

                        Console.WriteLine("Enter student's email");
                        student.email = Console.ReadLine();

                        student.showDetails();
                        break;

                    case 2:
                        Console.WriteLine("Enter name");
                        professor.name = Console.ReadLine();

                        Console.WriteLine("Enter id");
                        professor.profId = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the subject");
                        professor.subject = Console.ReadLine();

                        Console.WriteLine("Enter email");
                        professor.email = Console.ReadLine();

                        professor.showDetails();

                        break;
                }
                Console.WriteLine("Do you want to repeat? Y or N");
                repeat = Console.ReadLine();
            }
            



        }
    }
}
