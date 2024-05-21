using FriendStorage.UI.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendStorage.UITest.Wrapper
{
    public class ChangeNotificationSimplePropertyTests : FriendBaseTests
    {
        [Fact]
        public void ShouldRaisePropertyChangedEventOnPropertyChange()
        {
            var fired = false;
            var wrapper = new FriendWrapper(_friend);
            wrapper.PropertyChanged += (s, e) =>
            {
                if(e.PropertyName == nameof(FriendWrapper.FirstName))
                {
                    fired = true;
                }
            };
            wrapper.FirstName = "Julia"; 

            Assert.True(fired); 

        }
        [Fact]
        public void ShouldNotRaisePropertyChangedEventOnPropertyChangeIfPropertyIsSetToSameValue()
        {
            var fired = false;
            var wrapper = new FriendWrapper(_friend);
            wrapper.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(FriendWrapper.FirstName))
                {
                    fired = true;
                }
            };
            wrapper.FirstName = "Thomas";

            Assert.False(fired);

        }
    }
}
