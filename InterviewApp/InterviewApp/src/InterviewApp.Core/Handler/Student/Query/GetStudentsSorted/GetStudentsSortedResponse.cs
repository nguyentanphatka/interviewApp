using System.Collections.Generic;

namespace InterviewApp.Core.Handler.Student.Query.GetStudentsSorted
{
    public class GetStudentsSortedResponse
    {
        public IEnumerable<StudentSortedModel> Students { get; set; }
    }
}
