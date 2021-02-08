using System;
using System.Collections.Generic;
using System.Text;

namespace CardCost.Core.Entities
{
    public class AccessUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Token { get; set; }
    }
}
