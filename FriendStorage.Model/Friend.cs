using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendStorage.Model
{
    public  class Friend
    {
        public int Id { get; set; }
        public int FriendGroup { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; }   = string.Empty;
        public DateTime? Birthday { get; set; }
        public Address Address { get; set; }
        public List<FriendEmail> Emails { get; set; }   
        
    }
}
