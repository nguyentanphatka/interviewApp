using System.Threading;
using System.Threading.Tasks;
using InterviewApp.Core.Interfaces;
using MediatR;

namespace InterviewApp.Core.Handler.Student.Command.AddStudents
{
    public class AddStudentsCommand : IRequest<ResponseModel<AddStudentsResponse>>
    {
        public AddStudentsRequest Request { get; set; }
        public AddStudentsCommand(AddStudentsRequest request)
        {
            Request = request;
        }
    }

    public class AddStudentsHandler : IRequestHandler<AddStudentsCommand, ResponseModel<AddStudentsResponse>>
    {
        private readonly IStudentService _studentService;
        
        public AddStudentsHandler(IStudentService service)
        {
            _studentService = service;
        }

        public async Task<ResponseModel<AddStudentsResponse>> Handle(AddStudentsCommand request, CancellationToken cancellationToken)
        {
            var result = await _studentService.AddStudents(request.Request.Students);
            if(result)
                return ResponseModel<AddStudentsResponse>.Success(new AddStudentsResponse(){});
            return ResponseModel<AddStudentsResponse>.Fail("Invalid request data.");
        }
    }
}
