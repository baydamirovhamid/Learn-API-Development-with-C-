﻿namespace DotnetAPI.Dtos
{
    public partial class UserForRegistrationDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

        public UserForRegistrationDto()
        {
            if (Email == null)
            {
                Email = " ";

            }
            if (FirstName == null)
            {
                FirstName = "";
            }

            if (LastName == null)
            {
                FirstName = "";
            }

            if (Email == null)
            {
                FirstName = "";
            }

            if (Gender == null)
            {
                FirstName = "";
            }

            if (Password == null)
            {
                Password = " ";

            }

            if (PasswordConfirm == null)
            {
                PasswordConfirm = " ";

            }
        }
    }
}

