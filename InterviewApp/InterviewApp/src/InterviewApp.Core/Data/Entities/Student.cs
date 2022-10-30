using System;
using InterviewApp.SharedKernel;
using InterviewApp.SharedKernel.Interfaces;

namespace InterviewApp.Core.Data.Entities
{
    public class Student : BaseEntity, IAggregateRoot
    {
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
    }
}
