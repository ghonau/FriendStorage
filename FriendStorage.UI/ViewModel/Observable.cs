using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FriendStorage.UI.ViewModel
{
    public class Observable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        
        
        // OnPropertyChanged is an event raiser we will call this once the property has changed 
        // So we can raise the event via this method. 
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var propertyChangedEvent = PropertyChanged; 
            if(propertyChangedEvent != null) 
            { 
                propertyChangedEvent(this, new PropertyChangedEventArgs(propertyName));
            }

        }
    }
}
