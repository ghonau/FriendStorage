using FriendStorage.UI.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendStorage.UITest.Wrapper
{
    public class ChangePropertyComplextPropertyTests : FriendBaseTests
    {
        [Fact]
        public void ShouldInitializeAddressProperty () { 
            var wrapper = new FriendWrapper (_friend);
            Assert.NotNull (wrapper.Address);
            Assert.Equal(_friend.Address, wrapper.Address.Model);
        }

    }
}
