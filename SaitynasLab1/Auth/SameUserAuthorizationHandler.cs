using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SaitynasLab1.Auth.Model;

namespace SaitynasLab1.Auth
{
    public class SameUserAuthorizationHandler: AuthorizationHandler<SameUserRequirement, IUserOwnedResource>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            SameUserRequirement requirement, IUserOwnedResource resource)
        {
            if (context.User.IsInRole(SaitynasUserRoles.Admin) || context.User.FindFirst(CustomClaims.UserId).Value == resource.UserId)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }

    public record SameUserRequirement : IAuthorizationRequirement;
}
