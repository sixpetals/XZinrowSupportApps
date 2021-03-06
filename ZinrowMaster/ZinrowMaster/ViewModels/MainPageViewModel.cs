﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace ZinrowMaster.ViewModels {
    public class MainPageViewModel : BindableBase, INavigationAware {
        private string _title;
        public string Title {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public MainPageViewModel(INavigationService navigationService) {

        }

        public MainPageViewModel() {

        }

        public void OnNavigatedFrom(INavigationParameters parameters) {

        }

        public void OnNavigatingTo(INavigationParameters parameters) {

        }

        public void OnNavigatedTo(INavigationParameters parameters) {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}
