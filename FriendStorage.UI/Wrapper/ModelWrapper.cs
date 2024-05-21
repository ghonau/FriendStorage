using FriendStorage.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Converters;

namespace FriendStorage.UI.Wrapper
{
    public class ModelWrapper<T> : Observable
    {
        public T Model;
        private Dictionary<string, object> _originalValues;

        public ModelWrapper(T model) 
        {
            if (model == null) throw new ArgumentNullException("model");
            Model = model ; 
            _originalValues = new Dictionary<string, object>(); 
        }
        protected void SetValue<TValue>(TValue value, [CallerMemberName] string propertyName = null)
        {
            var propertyInfo = Model.GetType().GetProperty(propertyName);
            var currentValue = propertyInfo.GetValue(Model);
            if (Equals(currentValue, value)) { return; }
            propertyInfo.SetValue(Model, value);
            SetOriginalValue(propertyName, value); 
            OnPropertyChanged(propertyName);
        }

        private void SetOriginalValue<TValue>(string propertyName, TValue? value)
        {
            if (!_originalValues.ContainsKey(propertyName))
            {
                _originalValues.Add(propertyName, value);
            }

        }

        protected TValue GetValue<TValue>([CallerMemberName] string propertyName = null)
        {
            var propertyInfo = Model.GetType().GetProperty(propertyName);
            var currentValue = propertyInfo.GetValue(Model);
            return (TValue)currentValue; 
        }
        protected TValue GetOriginalValue<TValue>(string propertyName)
        {
            return   _originalValues.ContainsKey(propertyName) ?   (TValue)_originalValues[propertyName] : GetValue<TValue>(propertyName);  
        }
        protected void RegisterCollection<TWrapper, TModel>(ObservableCollection<TWrapper> wrapperCollection, List<TModel> modelCollection) where TWrapper : ModelWrapper<TModel>
        {
            wrapperCollection.CollectionChanged += (s, e) =>
            {
                if (e.OldItems is not null)
                {
                    foreach (var item in e.OldItems.Cast<TWrapper>())
                    {
                        modelCollection.Remove(item.Model);
                    }
                }
                if (e.NewItems is not null)
                {
                    foreach (var newItem in e.NewItems.Cast<TWrapper>())
                    {
                        modelCollection.Add(newItem.Model);
                    }
                }
            };
        }
    }
}
