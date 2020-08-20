using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
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
