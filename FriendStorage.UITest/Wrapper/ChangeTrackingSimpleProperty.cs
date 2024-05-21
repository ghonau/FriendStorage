using FriendStorage.UI.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendStorage.UITest.Wrapper
{
    public class ChangeTrackingSimpleProperty : FriendBaseTests
    {
        [Fact]
        public void ShouldStoreOriginalValue()
        {
            var wrapper = new FriendWrapper(_friend);
            Assert.Equal("Thomas", wrapper.FirstNameOriginalValue);
            wrapper.FirstName = "Julia"; 
            Assert.Equal(wrapper.FirstName, wrapper.FirstNameOriginalValue);
        }
    }
}
