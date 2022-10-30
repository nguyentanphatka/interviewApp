using System;
using Ardalis.Specification;

namespace InterviewApp.Core.Specifications
{
    public class GetAllStudentSpec : Specification<Data.Entities.Student>, ISingleResultSpecification
    {
        public GetAllStudentSpec()
        {
            return;
        }
    }
}