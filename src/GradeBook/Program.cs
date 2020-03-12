using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Daniel's Grade Book");

            EnterGrades(book);

            Statistcs statistcs = book.GetStatistics();

            Console.WriteLine($"The lowest grade is {statistcs.Low}");
            Console.WriteLine($"The average grade is {statistcs.Average:N1}");
            Console.WriteLine($"The highest grade is {statistcs.High}");
            Console.WriteLine($"The Letter grade is {statistcs.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Pease, provide a grade number or 'q' to quit ");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}