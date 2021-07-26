using System.Threading.Tasks;
using SpaceController.Contracts.Services;
using Xamarin.Forms;

namespace SpaceController.ViewModels.Base
{
    public class BaseViewModel : BindableObject
    {
        private bool isBusy;
        protected readonly INavigationService navigationService;

        public BaseViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

        public virtual Task InitializeAsync(object parameter)
        {
            return Task.FromResult(false);
        }
    }
}
