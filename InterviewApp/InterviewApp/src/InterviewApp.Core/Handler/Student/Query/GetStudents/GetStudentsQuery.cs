using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InterviewApp.Core.Handler.Student.Query.GetStudentsSorted;
using InterviewApp.Core.Interfaces;
using InterviewApp.SharedKernel;
using MediatR;

namespace InterviewApp.Core.Handler.Student.Query.GetStudents
{
    public class GetStudentsQuery : IRequest<ResponseModel<GetStudentsResponse>>
    {
        public GetStudentsRequest Request { get; set; }
        public GetStudentsQuery(GetStudentsRequest request)
        {
            Request = request;
        }
    }

    public class GetStudentsHandler : IRequestHandler<GetStudentsQuery, ResponseModel<GetStudentsResponse>>
    {
        private readonly IStudentService _studentService;

        private readonly IMapper _mapper;
        public GetStudentsHandler(IStudentService service, IMapper mapper)
        {
            _studentService = service;
            _mapper = mapper;
        }

        public async Task<ResponseModel<GetStudentsResponse>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var response = await _studentService.GetStudents();
            var result = _mapper.Map<List<StudentModel>>(response);
            return ResponseModel<GetStudentsResponse>.Success(new GetStudentsResponse() { Students = result });

        }
    }
}
