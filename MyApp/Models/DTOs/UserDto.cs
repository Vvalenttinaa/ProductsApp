﻿namespace MyApp.Models.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string SecondName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;

    }
}
