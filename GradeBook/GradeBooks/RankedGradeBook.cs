using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }

            var orderedGrades = Students.OrderByDescending(s => s.AverageGrade).Select(s => s.AverageGrade).ToList();
            int top20PercentCount = (int)Math.Round(orderedGrades.Count * 0.2);

            if (averageGrade >= orderedGrades[top20PercentCount - 1])
            {
                return 'A';
            }
            else if (averageGrade >= orderedGrades[top20PercentCount * 2 - 1])
            {
                return 'B';
            }
            else if (averageGrade >= orderedGrades[top20PercentCount * 3 - 1])
            {
                return 'C';
            }
            else if (averageGrade >= orderedGrades[top20PercentCount * 4 - 1])
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }
        
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            else
                base.CalculateStatistics();
        }
        
        
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}