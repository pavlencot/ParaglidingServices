﻿using Microsoft.AspNetCore.Identity;
using System;

namespace ParaglidingServices.Domain.Entities.Auth
{
    public class User : IdentityUser<long>
    {
        public long PilotId { get; set; }
        public Pilot Pilot { get; set; }
        public long OrganizerId { get; set; }
        public Organizer Organizer { get; set; }

        public User()
        {

        }

    }
}
