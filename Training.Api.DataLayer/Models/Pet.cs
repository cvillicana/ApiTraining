using System;
using System.Collections.Generic;

namespace Training.Api.DataLayer.Models
{
    public partial class Pet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
