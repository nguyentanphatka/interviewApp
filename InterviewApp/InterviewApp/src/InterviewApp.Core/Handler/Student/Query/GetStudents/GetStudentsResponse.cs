using System.Collections.Generic;

namespace InterviewApp.Core.Handler.Student.Query.GetStudents
{ 
    public class GetStudentsResponse
    {
        public IEnumerable<StudentModel> Students { get; set; }
    } 
}
