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

        public ModelWrapper(T model) 
        {
            if (model == null) throw new ArgumentNullException("model");
            Model = model ; 
        }
        protected void SetValue<TValue>(TValue value, [CallerMemberName] string propertyName = null)
        {
            var propertyInfo = Model.GetType().GetProperty(propertyName);
            var currentValue = propertyInfo.GetValue(Model);
            if (Equals(currentValue, value)) { return; }
            propertyInfo.SetValue(Model, value);
            OnPropertyChanged(propertyName);
        }
        protected TValue GetValue<TValue>([CallerMemberName] string propertyName = null)
        {
            var propertyInfo = Model.GetType().GetProperty(propertyName);
            var currentValue = propertyInfo.GetValue(Model);
            return (TValue)currentValue; 
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
