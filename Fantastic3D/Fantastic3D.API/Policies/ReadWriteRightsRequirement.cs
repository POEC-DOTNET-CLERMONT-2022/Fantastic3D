using Microsoft.AspNetCore.Authorization;

namespace Fantastic3D.API.Policies
{
    public class ReadWriteRightsRequirement :
        AuthorizationHandler<ReadWriteRightsRequirement>,
        IAuthorizationRequirement
    {
        protected override Task HandleRequirementAsync(
       AuthorizationHandlerContext context, ReadWriteRightsRequirement requirement)
        {
            var user = context.User;
            var userIsAnonymous = user?.Identity == null || !user.Identities.Any(i => i.IsAuthenticated);
            if (!userIsAnonymous)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
