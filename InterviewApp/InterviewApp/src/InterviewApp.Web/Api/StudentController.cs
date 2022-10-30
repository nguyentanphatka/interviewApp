using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using InterviewApp.Core.Handler.Student.Command.AddStudents;
using InterviewApp.Core.Handler.Student.Command.DeleteStudents;
using InterviewApp.Core.Handler.Student.Query.GetStudents;
using InterviewApp.Core.Handler.Student.Query.GetStudentsSorted;
using InterviewApp.SharedKernel;

namespace InterviewApp.Web.Api
{
    public class StudentController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("/GetAll")]
        public async Task<IActionResult> GetAllStudents()
        {
            var response = await QueryAsync(new GetStudentsQuery(new GetStudentsRequest()));
            return Ok(response);
        }

        [HttpGet("/GetAllSorted")]
        public async Task<IActionResult> GetAllStudentsSorted()
        {
            var response = await QueryAsync(new GetStudentsSortedQuery(new GetStudentsSortedRequest()));
            return Ok(response);
        }
        [HttpPost("/AddStudents")]
        public async Task<IActionResult> AddStudents([FromBody] AddStudentsRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await CommandAsync(new AddStudentsCommand(request));
            return Ok(response);
        }

        [HttpPost("/DeleteStudents")]
        public async Task<IActionResult> AddStudents([FromBody] DeleteStudentsRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await CommandAsync(new DeleteStudentsCommand(request));
            return Ok(response);
        }
    }
}
