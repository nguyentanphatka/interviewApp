using System;

namespace InterviewApp.Core.Handler.Student.Query.GetStudentsSorted
{
    public class StudentSortedModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }

        public static StudentSortedModel FromStudent(Data.Entities.Student item)
        {
            return new StudentSortedModel
            {
                Id = item.Id,
                FullName = item.FullName,
                DOB = item.DOB
            };
        }
    }
}
