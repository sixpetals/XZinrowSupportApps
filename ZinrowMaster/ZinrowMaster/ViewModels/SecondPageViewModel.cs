using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace ZinrowMaster.ViewModels
{
    public class SecondPageViewModel : BindableBase
    {
        public SecondPageViewModel() {

            Plus1MinCommand = new DelegateCommand(() => {
                Sec += 60;
            });

            Plus10SecCommand = new DelegateCommand(() => {
                Sec += 10;

            });

            Minus10SecCommand = new DelegateCommand(() => {
                Sec -= 10;
            });


            Minus1MinCommand = new DelegateCommand(() => {
                Sec -= 60;
            });


            StartCommand = new DelegateCommand(() => {

            });


            StopCommand = new DelegateCommand(() => {

            });


            ResetCommand = new DelegateCommand(() => {
                Sec = 300;
            });




        }

        public ICommand Plus1MinCommand { get; }

        public ICommand Plus10SecCommand { get; }

        public ICommand Minus10SecCommand { get; }

        public ICommand Minus1MinCommand { get; }



        public ICommand StartCommand { get; }

        public ICommand StopCommand { get; }

        public ICommand ResetCommand { get; }
        

        private int _sec = 300;
        public int Sec {
            get { return _sec; }
            set {
                SetProperty(ref _sec, value);
                this.RaisePropertyChanged(nameof(SecText));
                this.RaisePropertyChanged(nameof(MinText));

            }
        }

        public string MinText { get { return (Sec / 60).ToString("00"); } }
        public string SecText { get { return (Sec % 60).ToString("00"); } }


    }
}
