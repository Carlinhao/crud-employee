﻿namespace employers.domain.Requests
{
    public class CreateUserRequest
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
    }
}