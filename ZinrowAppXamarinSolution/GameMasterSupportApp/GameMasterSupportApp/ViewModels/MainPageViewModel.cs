using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameMasterSupportApp.ViewModels {
    public class MainPageViewModel : BindableBase{
        private string timerText;

        public string TimerText {
            get { return this.timerText; }
            set { this.SetProperty(ref this.timerText, value); }
        }

        public ICommand HelloCommand { get; private set; }
    }
}
