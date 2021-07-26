using System;
using System.Threading.Tasks;
using System.Windows.Input;
using SpaceController.Contracts.Services;
using SpaceController.Models;
using SpaceController.ViewModels.Base;
using Xamarin.Forms;

namespace SpaceController.ViewModels.Templates
{
    public class SightingTemplateViewModel : BaseViewModel
    {
        public Sighting sighting;

        public SightingTemplateViewModel(INavigationService navigationService) : base(navigationService)
        {
            sighting = new Sighting();
        }

        #region Properties
        public string ObservatoryCode => sighting.ObservatoryCode;

        public DateTime Date => sighting.Date;

        #endregion

        #region Commands
        public ICommand ShowSightingDetailCommand => new Command(async () => await OnShowSightingDetailCommand());
        #endregion

        public override Task InitializeAsync(object parameter)
        {
            sighting = parameter as Sighting;
            DrawCell();
            return base.InitializeAsync(parameter);
        }

        private void DrawCell()
        {
            OnPropertyChanged(nameof(ObservatoryCode));
            OnPropertyChanged(nameof(Date));
        }

        private async Task OnShowSightingDetailCommand()
        {
            await navigationService.NavigateToAsync<SightingDetailViewModel>(sighting);
        }
    }
}
