using Microsoft.AspNetCore.Authorization;

namespace Admin.Template.Server.Security;

public class AppAuthorizationHandler : AuthorizationHandler<AuthorizeRequirement>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        AuthorizeRequirement requirement)
    {
        context.Succeed(requirement);
        return Task.CompletedTask;
    }
}

