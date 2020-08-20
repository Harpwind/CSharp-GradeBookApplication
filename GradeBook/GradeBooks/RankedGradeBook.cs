using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool weight) : base(name, weight)
        {
            Type = GradeBookType.Ranked;
        }

        public override void CalculateStatistics()
        {

            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }

        public override char GetLetterGrade(double averageGrade)
        {
            var noOfStudents = Students.Count;
            
            if (noOfStudents < 5)
                throw new InvalidOperationException("Must have at least 5 students for Ranked Grade");

            int twentyPercentiles = noOfStudents / 5;

            var twentyPercentilesGrade = Students[twentyPercentiles -1].AverageGrade;

            if (averageGrade >= twentyPercentilesGrade)
                return 'A';

            twentyPercentilesGrade = Students[2 * twentyPercentiles -1].AverageGrade;

            if (averageGrade >= twentyPercentilesGrade)
                return 'B';

            twentyPercentilesGrade = Students[3 * twentyPercentiles -1].AverageGrade;

            if (averageGrade >= twentyPercentilesGrade)
                return 'C';

            twentyPercentilesGrade = Students[4 * twentyPercentiles -1].AverageGrade;

            if (averageGrade >= twentyPercentilesGrade)
                return 'D';


            return 'F';
        }
    }
}
