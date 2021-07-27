using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpaceController.Contracts.Services;
using SpaceController.ViewModels;
using SpaceController.ViewModels.Base;
using SpaceController.Views;
using Xamarin.Forms;

namespace SpaceController.Services
{
    public class NavigationService : INavigationService
    {
        private readonly Dictionary<Type, Type> mappingViewModelToView;

        public NavigationService()
        {
            mappingViewModelToView = new Dictionary<Type, Type>();
            CreateMappings();
        }

        public async Task InitializeAsync()
        {
            Application.Current.MainPage = new Page();
            await NavigateToAsync<SightingsListViewModel>();
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            return CustomNavigateToAsync(typeof(TViewModel), null);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
            return CustomNavigateToAsync(typeof(TViewModel), parameter);
        }

        public async Task CloseModalView()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }

        private async Task CustomNavigateToAsync(Type viewModelType, object parameter)
        {
            var page = CreatePage(viewModelType, parameter);

            if (page is SightingsListView)
            {
                var nv = new NavigationPage(page);
                nv.Style = (Style)Application.Current.Resources["NavigationBarStyle"];
                Application.Current.MainPage = nv;

            }
            else if (page is SightingDetailView)
            {
                await Application.Current.MainPage.Navigation.PushAsync(page);
            }
            else
            {
                throw new NotSupportedException();
            }

            await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
        }

        private Page CreatePage(Type viewModelType, object parameter)
        {
            Type pageType = mappingViewModelToView[viewModelType];
            if (pageType == null) throw new Exception($"No page for view model:{viewModelType}");

            Page page = Activator.CreateInstance(pageType) as Page;
            return page;
        }

        private void CreateMappings()
        {
            mappingViewModelToView.Add(typeof(SightingDetailViewModel), typeof(SightingDetailView));
            mappingViewModelToView.Add(typeof(SightingsListViewModel), typeof(SightingsListView));
        }
    }
}
