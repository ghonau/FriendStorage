﻿using FriendStorage.Model;
using FriendStorage.UI.ViewModel;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FriendStorage.UI.Wrapper
{
    public class FriendWrapper : ModelWrapper<Friend>
    {



        public int Id
        {
            get
            {
                return GetValue<int>();
            }
            set
            {
                SetValue(value);
            }
        }
        public int FriendGroupId
        {
            get
            {
                return GetValue<int>();
            }
            set
            {
                SetValue(value);
            }
        }
        public string FirstName
        {
            get
            {
                return GetValue<String>();  
            }
            set
            {
                SetValue(value); 
            }
        }

        public string LastName
        {
            get
            {
                return GetValue<String>();
            }
            set
            {
                SetValue(value);
            }
        }

        public DateTime? Birthday
        {
            get
            {
                return GetValue<DateTime?>();
            }
            set
            {
                SetValue(value);
            }
        }
        public bool IsDeveloper
        {
            get
            {
                return GetValue<bool>();    
            }
            set
            {
                SetValue(value);
            }
        }
        public ObservableCollection<FriendEmailWrapper> Emails { get; private set;  }
        public AddressWrapper Address
        {
            get; private set;
        }
        public FriendWrapper(Friend model ):base (model)
        {
            InitializeComplextProperties(model);
            InitializeCollectionProperties(model); 
        }

        private void InitializeCollectionProperties(Friend model)
        {
            if (model.Emails is null)
                throw new ArgumentException("Emails cannot be null");
            Emails = new ObservableCollection<FriendEmailWrapper>(Model.Emails.Select(e => new FriendEmailWrapper(e)));

            RegisterCollection(Emails, model.Emails);
        }

       

        private void InitializeComplextProperties(Friend model)
        {
            if (model.Address is null)
                throw new ArgumentException("Address cannot be null"); 
            Address = new AddressWrapper(model.Address); 
        }
    }
}