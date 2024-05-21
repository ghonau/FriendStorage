using FriendStorage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendStorage.UITest.Wrapper
{
    public class FriendBaseTests : IDisposable
    {
        public Friend _friend;
        public FriendEmail _friendEmail; 

        public FriendBaseTests()
        {
            _friendEmail = new FriendEmail { Email = "Thomas@gmail.com" };
            _friend = new Friend
            { FirstName = "Thomas", Address = new Address(), Emails = new List<FriendEmail>
                {
                    new FriendEmail { Email = "Julia@gmail.com"},
                    _friendEmail
                } };
        }
        public void Dispose()
        {

        }
    }
}
