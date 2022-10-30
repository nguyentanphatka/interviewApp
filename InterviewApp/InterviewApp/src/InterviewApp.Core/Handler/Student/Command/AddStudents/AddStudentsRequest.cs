using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InterviewApp.Core.Handler.Student.Command.AddStudents
{
    public class AddStudentsRequest
    {
        [Required, MinLength(30, ErrorMessage = "Min length of list students is 30.")]
        public List<InsertStudentsModel> Students { get; set; }
    }
}
