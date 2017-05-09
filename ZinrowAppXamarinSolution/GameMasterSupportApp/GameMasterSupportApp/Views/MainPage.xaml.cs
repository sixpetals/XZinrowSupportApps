using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Practices.Prism.Mvvm;

namespace GameMasterSupportApp.Views {
    public partial class MainPage : ContentPage , IView{
        public MainPage() {
            InitializeComponent();
            ViewModelLocationProvider.AutoWireViewModelChanged(this);
        }

        public object DataContext { get => this.BindingContext; set => this.BindingContext = value; }
    }
}
