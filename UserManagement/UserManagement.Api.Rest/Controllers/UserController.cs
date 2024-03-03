using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Api.Rest.Dtos;
using UserManagement.Application.Handlers.GetUserListBySearchPhrase;
using UserManagement.Application.Handlers.UpdateEmail;

namespace UserManagement.Api.Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] GetUsersListRequestDto getUsersListRequestDto)
        {
            var query = new GetUserListBySearchPhraseQuery() { SearchPhrase = getUsersListRequestDto.SearchPhrase };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmail([FromBody] UpdateEmailRequestDto updateEmailRequestDto)
        {
            var command = new UpdateEmailCommand(updateEmailRequestDto.Id, updateEmailRequestDto.Email);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
