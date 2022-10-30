using System.Threading;
using System.Threading.Tasks;
using InterviewApp.Core.Interfaces;
using MediatR;

namespace InterviewApp.Core.Handler.Student.Command.DeleteStudents
{
    public class DeleteStudentsCommand : IRequest<ResponseModel<DeleteStudentsResponse>>
    {
        public DeleteStudentsRequest Request { get; set; }
        public DeleteStudentsCommand(DeleteStudentsRequest request)
        {
            Request = request;
        }
    }

    public class DeleteStudentsHandler : IRequestHandler<DeleteStudentsCommand, ResponseModel<DeleteStudentsResponse>>
    {
        private readonly IStudentService _studentService;
        
        public DeleteStudentsHandler(IStudentService service)
        {
            _studentService = service;
        }

        public async Task<ResponseModel<DeleteStudentsResponse>> Handle(DeleteStudentsCommand request, CancellationToken cancellationToken)
        {
            var result = await _studentService.DeleteStudents();
            if(result)
                return ResponseModel<DeleteStudentsResponse>.Success(new DeleteStudentsResponse(){});
            return ResponseModel<DeleteStudentsResponse>.Fail("Invalid request data.");
        }
    }
}
