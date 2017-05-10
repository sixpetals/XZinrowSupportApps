using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prism.Unity;
using Xamarin.Forms;
using GameMasterSupportApp.Views;

namespace GameMasterSupportApp {
    public partial class App : PrismApplication {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }
        protected override void OnInitialized() {
            InitializeComponent();
            NavigationService.NavigateAsync("MainPage?title=Hello%20from%20Xamarin.Forms");
        }
        protected override void RegisterTypes() {
            Container.RegisterTypeForNavigation<MainPage>();
        }

    }
}
