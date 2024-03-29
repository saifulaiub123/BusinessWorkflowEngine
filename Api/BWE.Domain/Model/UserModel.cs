﻿
namespace BWE.Domain.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int StatusId { get; set; }
        public List<int> Roles { get; set; }
    }
}
