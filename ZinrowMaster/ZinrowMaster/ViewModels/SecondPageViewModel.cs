using Amoenus.PclTimer;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using ZinrowMaster.Services;
using DependencyService = Xamarin.Forms.DependencyService;

namespace ZinrowMaster.ViewModels
{
    public class SecondPageViewModel : BindableBase, INavigationAware {

        private CountDownTimer _timer;

        private readonly IMusicPlayer _musicPlayer;

        public SecondPageViewModel(IMusicPlayer musicPlayer) {
            _musicPlayer = musicPlayer;

            _timer = new CountDownTimer(TimeSpan.FromSeconds(300));
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.IntervalPassed += _timer_IntervalPassed;

            Plus1MinCommand = new DelegateCommand(() => {
                _timer.CurrentTime.Add(TimeSpan.FromMinutes(1));
                UpdateTimer();
            });

            Plus10SecCommand = new DelegateCommand(() => {
                _timer.CurrentTime.Add(TimeSpan.FromSeconds(10));
                UpdateTimer();

            });

            Minus10SecCommand = new DelegateCommand(() => {
                _timer.CurrentTime.Subtract(TimeSpan.FromSeconds(10));
                UpdateTimer();
            });


            Minus1MinCommand = new DelegateCommand(() => {
                _timer.CurrentTime.Subtract(TimeSpan.FromMinutes(1));
                UpdateTimer();
            });


            StartTimerCommand = new DelegateCommand(() => {
                _timer.Start();
                UpdateTimer();
            });


            StopTimerCommand = new DelegateCommand(() => {
                _timer.Stop();
                UpdateTimer();
            });


            ResetTimerCommand = new DelegateCommand(() => {
                _timer.Reset();
                UpdateTimer();
            });


            BGM1Command = new DelegateCommand(() => {
                _musicPlayer.PlayAsync("openingBGM"); 
            });

        }

        private void _timer_IntervalPassed(object sender, EventArgs e) {
            UpdateTimer();
        }

        private void UpdateTimer() {
            Sec = (int)_timer.CurrentTime.TotalSeconds;
        }

        public void OnNavigatedFrom(NavigationParameters parameters) {

        }

        public void OnNavigatedTo(NavigationParameters parameters) {

        }

        public void OnNavigatingTo(NavigationParameters parameters) {

        }

        public ICommand BGM1Command { get; }

        public ICommand Plus1MinCommand { get; }

        public ICommand Plus10SecCommand { get; }

        public ICommand Minus10SecCommand { get; }

        public ICommand Minus1MinCommand { get; }



        public ICommand StartTimerCommand { get; }

        public ICommand StopTimerCommand { get; }

        public ICommand ResetTimerCommand { get; }
        

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
