using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewApp.Web.Api
{
    /// <summary>
    /// If your API controllers will use a consistent route convention and the [ApiController] attribute (they should)
    /// then it's a good idea to define and use a common base controller class like this one.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : Controller
    {
        protected OkObjectResult ReturnObject<T>(T data, bool isSuccess = true, string message = null)
        {
            var responseModel = new ResponseModel<T>(data) { IsSuccess = isSuccess, Message = message };
            return Ok(responseModel);
        }

        protected OkObjectResult ReturnSuccess(string message = null)
        {
            var responseModel = new ResponseModel { IsSuccess = true, Message = message };
            return Ok(responseModel);
        }
        protected OkObjectResult ReturnFailure(string message = null)
        {
            var responseModel = new ResponseModel { IsSuccess = false, Message = message };
            return Ok(responseModel);
        }


        private IMediator _mediator;

        /// <summary>
        /// common Mediator object
        /// </summary>
        private IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        /// <summary>
        /// Base method for all commands
        /// </summary>
        /// <param name="command"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        protected async Task<TResult> CommandAsync<TResult>(IRequest<TResult> command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// base method for all queries
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        protected async Task<TResult> QueryAsync<TResult>(IRequest<TResult> query)
        {
            return await Mediator.Send(query);
        }
    }
}