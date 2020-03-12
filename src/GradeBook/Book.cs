using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public class NamedObject
    {
        public string Name { get; set; }

        public NamedObject(string name)
        {
            Name = name;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistcs GetStatistics();
        string Name { get; }
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract void AddGrade(double grade);

        public abstract Statistcs GetStatistics();
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);              
            }
        }

        public override Statistcs GetStatistics()
        {
            var result = new Statistcs();
            
            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }

    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base (name)
        {
            grades = new List<double>();
            Name = name;
        }
        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override Statistcs GetStatistics()
        {
            var result = new Statistcs();
        
            for (var index = 0; index < grades.Count; index++)
            {
                result.Add(grades[index]);                
            } 
            
            return result;
        }

        private List<double> grades;
    }
}