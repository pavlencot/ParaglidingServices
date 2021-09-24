﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParaglidingServices.Domain.Enums;

namespace ParaglidingServices.Domain.Entities
{
    public class Client : BaseEntity
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTimeOffset? DateOfBirth { get; set; }
        public virtual IEnumerable<Booking> Bookings { get; set; }

        public Client()
        {

        }

        public Client(string phoneNumber, string email, DateTimeOffset? dateOfBirth)
        {
            PhoneNumber = phoneNumber;
            Email = email;
            DateOfBirth = dateOfBirth;
        }
    }
}