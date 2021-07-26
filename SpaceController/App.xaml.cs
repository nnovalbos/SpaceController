using System;
using System.Threading.Tasks;
using SpaceController.Bootstrap;
using SpaceController.Contracts.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpaceController
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            AppContainer.RegisterDependencies();
        }

        protected async override void OnStart()
        {
            var navigationService = AppContainer.Resolve<INavigationService>();
            await navigationService.InitializeAsync();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
