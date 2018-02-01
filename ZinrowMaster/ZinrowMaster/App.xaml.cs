using Prism.Unity;
using ZinrowMaster.Views;
using Xamarin.Forms;
using Prism;
using Prism.Ioc;

namespace ZinrowMaster {
    public partial class App : PrismApplication {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized() {
            InitializeComponent();

            NavigationService.NavigateAsync("NavigationPage/MainPage?title=Hello%20from%20Xamarin.Forms");
        }

        protected override void RegisterTypes(IContainerRegistry registry) {
            registry.RegisterForNavigation<NavigationPage>();
            registry.RegisterForNavigation<MainPage>();
            registry.RegisterForNavigation<SecondPage>();
        }
    }
}
