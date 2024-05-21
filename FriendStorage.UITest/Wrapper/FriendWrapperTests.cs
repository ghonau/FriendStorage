using FriendStorage.Model;
using FriendStorage.UI.Wrapper;
using Windows.ApplicationModel.VoiceCommands;

namespace FriendStorage.UITest.Wrapper
{
    public class FriendWrapperTests : FriendBaseTests
    {

        [Fact]
        public void ShouldContainModelInModelProperty()
        {
            var wrapper = new FriendWrapper(_friend);
            Assert.Equal(_friend, wrapper.Model);

        }

        [Fact]
        public void ShouldThrowNullExceptionIfModelIsNull()
        {

            var exception = Assert.Throws<ArgumentNullException>(() => new FriendWrapper(null));
            Assert.Equal("model", exception.ParamName);
        }

        [Fact]
        public void ShouldThrowArgumentExceptionIfAddressIsNull()
        {
            var expectedMessage = "Address cannot be null"; 
            _friend.Address = null; 
            var exceptoin =  Assert.Throws<ArgumentException>(() => new FriendWrapper(_friend));
            Assert.Equal(expectedMessage, exceptoin.Message); 

        }

        [Fact]
        public void ShouldThrowArgumentExceptionIfEmailsCollectionIsNull()
        {
            var expectedMessage = "Emails cannot be null";
            _friend.Emails = null;
            var exceptoin = Assert.Throws<ArgumentException>(() => new FriendWrapper(_friend));
            Assert.Equal(expectedMessage, exceptoin.Message);

        }

        [Fact]
        public void ShouldGetValueFromUnderlyingModelProperty()
        {
            var wrapper = new FriendWrapper(_friend);
            Assert.Equal(_friend.FirstName, wrapper.FirstName);
        }

        [Fact]
        public void ShouldSetValueOfUnderlyingModelProperty()
        {
            var wrapped = new FriendWrapper(_friend);
            wrapped.FirstName = "Reza";
            Assert.Equal("Reza", _friend.FirstName);
        }
    }
}