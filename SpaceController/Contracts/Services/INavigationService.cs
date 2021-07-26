using System;
using System.Threading.Tasks;
using SpaceController.ViewModels.Base;

namespace SpaceController.Contracts.Services
{
    public interface INavigationService
    {
        Task InitializeAsync();

        Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel;
    }
}
