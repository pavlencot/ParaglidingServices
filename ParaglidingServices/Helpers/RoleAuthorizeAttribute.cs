using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingServices.Api.Helpers
{
    public class RoleAuthorizeAttribute : AuthorizeAttribute
	{
		public RoleAuthorizeAttribute(params string[] roles)
		{
			Roles = string.Join(',', roles);
		}
	}
}
