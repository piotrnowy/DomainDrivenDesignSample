using MediatR;
using UserManagement.Domain.User.UpdateParameters;

namespace UserManagement.Application.Handlers.UpdateEmail
{
    public record UpdateEmailCommand(Guid UserId, string NewEmail) : IRequest<Unit>;

    public class UpdateEmailCommandHandler : IRequestHandler<UpdateEmailCommand, Unit>
    {
        private readonly IUserService _userService;

        public UpdateEmailCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Unit> Handle(UpdateEmailCommand request, CancellationToken cancellationToken)
        {

            await _userService.UpdateEmail(request.UserId, new UpdateEmailDto(request.NewEmail));
            return Unit.Value;
        }
    }
}
