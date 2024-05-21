using FriendStorage.UI.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendStorage.UITest.Wrapper
{
    public class ChangeNotificationCollectionPropertyTests : FriendBaseTests
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
        public void ShouldInitializeEmailsProperty()
        {

            var wrapper = new FriendWrapper(_friend);
            Assert.NotNull(wrapper.Emails);

            CheckIfModelEmailsCollectionIsInSync(wrapper);

        }
        [Fact]
        public void ShouldBeInSyncAfterAddingEmail()
        {
            _friend.Emails.Remove(_friendEmail);
            var wrapper = new FriendWrapper(_friend);
            wrapper.Emails.Add(new FriendEmailWrapper(_friendEmail));
            CheckIfModelEmailsCollectionIsInSync(wrapper); 
        }

        [Fact]
        public void ShouldBeInSyncAfterRemovingEmail()
        {
            
            var wrapper = new FriendWrapper(_friend);
            var emailToRemove = wrapper.Emails.Single(ew => ew.Model == _friendEmail); 
            wrapper.Emails.Remove(emailToRemove);            
            CheckIfModelEmailsCollectionIsInSync(wrapper);
        }

        private void CheckIfModelEmailsCollectionIsInSync(FriendWrapper wrapper)
        {
            Assert.Equal(wrapper.Emails.Count, _friend.Emails.Count);
            Assert.All<FriendEmailWrapper>(wrapper.Emails, (email) => _friend.Emails.Any(item => item.Email == email.Email));
        }
    }
}
