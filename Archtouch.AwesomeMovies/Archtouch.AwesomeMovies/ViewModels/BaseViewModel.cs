﻿using Prism.Mvvm;
using Prism.Navigation;
using System;

namespace Archtouch.AwesomeMovies.ViewModels
{
    public abstract class BaseViewModel : BindableBase, INavigationAware
    {
        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set => SetProperty(ref _isBusy, value);
        }

        public BaseViewModel()
        {
            IsBusy = false;
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
            
        }
    }
}