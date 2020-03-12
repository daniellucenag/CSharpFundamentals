using System;

namespace GradeBook
{
    public class Statistcs
    {
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }
        public double Low;
        public double High;
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var g when g >= 90.0:
                        return 'A';                        
                    case var g when g >= 80.0:
                        return 'B';
                    case var g when g >= 70.0:
                        return 'C';
                    case var g when g >= 60.0:
                        return 'D';
                    default:
                        return 'F';
                }
            }
        }

        public double Sum;
        public int Count;

        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            Low = Math.Min(number, Low);
            High = Math.Max(number, High);
        }

        public Statistcs()
        {
            Sum = 0.0;
            Count = 0;
            Low = double.MaxValue;
            High = double.MinValue;
        }
    }
}