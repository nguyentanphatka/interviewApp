using System.Collections.Generic;
using System.Threading.Tasks;
using InterviewApp.Core.Data.Entities;
using InterviewApp.Core.Handler.Student.Command.AddStudents;

namespace InterviewApp.Core.Interfaces
{
    public interface IStudentService
    {
        #region Query

        Task<IEnumerable<Student>> GetStudents();
        Task<IEnumerable<Student>> GetStudentSorted();

        #endregion

        #region Command

        Task<bool> AddStudents(List<InsertStudentsModel> students);
        Task<bool> DeleteStudents();

        #endregion
    }
}
