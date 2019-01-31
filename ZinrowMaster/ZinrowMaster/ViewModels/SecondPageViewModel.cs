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

        public SecondPageViewModel() {
            _musicPlayer = DependencyService.Get<IMusicPlayer>();

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

            BGMStopCommand = new DelegateCommand(() => {
                _musicPlayer.Stop();
            });

            BGMOpeningCommand = new DelegateCommand(() => {
                _musicPlayer.Stop();
                _musicPlayer.PlayAsync("openingBGM");
            });

            BGMRoleCommand = new DelegateCommand(() => {
                _musicPlayer.Stop();
                _musicPlayer.PlayAsync("confirmBGM");
            });

            BGMMorningCommand = new DelegateCommand(() => {
                _musicPlayer.Stop();
                _musicPlayer.PlayAsync("morningBGM");
            });
            BGMDayTimeCommand = new DelegateCommand(() => {
                _musicPlayer.Stop();
                _musicPlayer.PlayAsync("discussionBGM");
            });

            BGMVoteCommand = new DelegateCommand(() => {
                _musicPlayer.Stop();
                _musicPlayer.PlayAsync("voteBGM");
            });

            BGMExecuteCommand = new DelegateCommand(() => {
                _musicPlayer.Stop();
                _musicPlayer.PlayAsync("executionBGM");
            });

            BGMNightCommand = new DelegateCommand(() => {
                _musicPlayer.Stop();
                _musicPlayer.PlayAsync("nightBGM");
            });


            BGMVillagerWinCommand = new DelegateCommand(() => {
                _musicPlayer.Stop();
                _musicPlayer.PlayAsync("victoryBGM_villagers");
            });

            BGMWerewolfWinCommand = new DelegateCommand(() => {
                _musicPlayer.Stop();
                _musicPlayer.PlayAsync("victoryBGM_werewolf");
            });

            BGMThirdPartyWinCommand = new DelegateCommand(() => {
                _musicPlayer.Stop();
                _musicPlayer.PlayAsync("victoryBGM_3rdParty");
            });
        

        }

        private void _timer_IntervalPassed(object sender, EventArgs e) {
            UpdateTimer();
        }

        private void UpdateTimer() {
            Sec = (int)_timer.CurrentTime.TotalSeconds;
        }

        public void OnNavigatedFrom(INavigationParameters parameters) {

        }

        public void OnNavigatedTo(INavigationParameters parameters) {

        }

        public void OnNavigatingTo(INavigationParameters parameters) {

        }



        public ICommand BGMStopCommand { get; }

        public ICommand BGMOpeningCommand { get; }

        public ICommand BGMRoleCommand { get; }


        public ICommand BGMMorningCommand { get; }

        public ICommand BGMDayTimeCommand { get; }



        public ICommand BGMVoteCommand { get; }

        public ICommand BGMExecuteCommand { get; }

        public ICommand BGMNightCommand { get; }


        public ICommand BGMVillagerWinCommand { get; }

        public ICommand BGMWerewolfWinCommand { get; }

        public ICommand BGMThirdPartyWinCommand { get; }





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
