﻿namespace Training.Api.BusinessLayer.DTO
{
    using System;

    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}