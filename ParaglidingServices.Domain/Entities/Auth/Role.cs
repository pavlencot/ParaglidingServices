using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ParaglidingServices.Domain.Entities.Auth
{
    public class Role : IdentityRole<long>
    {
        public Role()
        {

        }
        public Role(string name) : base(name)
        {

        }
    }
}
