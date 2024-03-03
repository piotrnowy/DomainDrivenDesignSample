using MediatR;
using UserManagement.Application.Handlers.GetUserListBySearchPhrase.Dtos;

namespace UserManagement.Application.Handlers.GetUserListBySearchPhrase
{
    public class GetUserListBySearchPhraseQuery : IRequest<GetUserListResponseDto>
    {
        public string SearchPhrase { get; set; } = string.Empty;
    }

    public class GetUserListBySearchPhraseQueryHandler : IRequestHandler<GetUserListBySearchPhraseQuery, GetUserListResponseDto>
    {
        private readonly IUserService _userService;

        public GetUserListBySearchPhraseQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetUserListResponseDto> Handle(GetUserListBySearchPhraseQuery request, CancellationToken cancellationToken)
        {
            var response = await _userService.GetUsersBySearchPhrase(request.SearchPhrase);
            
            return new GetUserListResponseDto(response);
        }
    }
}
