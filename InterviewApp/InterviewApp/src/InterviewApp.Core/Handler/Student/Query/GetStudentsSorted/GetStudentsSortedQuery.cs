using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InterviewApp.Core.Interfaces;
using MediatR;

namespace InterviewApp.Core.Handler.Student.Query.GetStudentsSorted
{
    public class GetStudentsSortedQuery : IRequest<ResponseModel<GetStudentsSortedResponse>>
    {
        public GetStudentsSortedRequest Request { get; set; }
        public GetStudentsSortedQuery(GetStudentsSortedRequest request)
        {
            Request = request;
        }
    }

    public class GetStudentsHandler : IRequestHandler<GetStudentsSortedQuery, ResponseModel<GetStudentsSortedResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;

        public GetStudentsHandler(IStudentService service, IMapper mapper)
        {
            _studentService = service;
            _mapper = mapper;
        }

        public async Task<ResponseModel<GetStudentsSortedResponse>> Handle(GetStudentsSortedQuery request, CancellationToken cancellationToken)
        {
            var response = await _studentService.GetStudentSorted();
            var result = _mapper.Map<IEnumerable<StudentSortedModel>>(response);
            return ResponseModel<GetStudentsSortedResponse>.Success(new GetStudentsSortedResponse() { Students = result });
        }
    }
}
