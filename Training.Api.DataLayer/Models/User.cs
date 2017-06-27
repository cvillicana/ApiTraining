using System;
using System.Collections.Generic;

namespace Training.Api.DataLayer.Models
{
    public partial class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
    }
}
