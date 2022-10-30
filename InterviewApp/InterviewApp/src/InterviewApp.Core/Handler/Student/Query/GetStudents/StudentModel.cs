using System;
using AutoMapper;

namespace InterviewApp.Core.Handler.Student.Query.GetStudents
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }

        public static StudentModel FromStudent(Data.Entities.Student item)
        {
            return new StudentModel
            {
                Id = item.Id,
                FullName = item.FullName,
                DOB = item.DOB
            };
        }
    }
}
