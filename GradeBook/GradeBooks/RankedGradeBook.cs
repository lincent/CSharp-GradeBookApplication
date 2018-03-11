using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            int twentyPercent = (int)Math.Ceiling(Students.Count / 5.0);

            var order = Students.OrderByDescending(s => s.AverageGrade).Select(s => s.AverageGrade).ToList();

            if (order[twentyPercent - 1] <= averageGrade)
            {
                return 'A';
            }
            else if (order[(twentyPercent * 2) - 1] <= averageGrade)
            {
                return 'B';
            }
            else if (order[(twentyPercent * 3) - 1] <= averageGrade)
            {
                return 'C';
            }
            else if (order[(twentyPercent * 4) - 1] <= averageGrade)
            {
                return 'D';
            }

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count() < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count() < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}
