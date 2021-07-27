using System;
using System.Threading.Tasks;
using SpaceController.Contracts.Services;
using SpaceController.Contracts.Utils;
using SpaceController.Models;
using SpaceController.ViewModels.Base;

namespace SpaceController.ViewModels
{
    public class SightingDetailViewModel : BaseViewModel
    {
        public SightingDetailViewModel(INavigationService navigationService) : base(navigationService)
        {
            IsBusy = true;
            Sighting = new Sighting();
        }

        public string DeviceCode => Sighting.DeviceCode;

        public DateTime Date => Sighting.DateAndTime;

        public string ObservatoryCode => Sighting.ObservatoryCode;

        public Sighting Sighting
        {
            get; private set;
        }

        public IDrawable Listener { get; set; } 


        public override Task InitializeAsync(object parameter)
        {
            Sighting = parameter as Sighting;
            Listener?.Draw();
            IsBusy = false;
            return base.InitializeAsync(parameter);
        }

        public void RefreshViewElements()
        {
            OnPropertyChanged(nameof(DeviceCode));
            OnPropertyChanged(nameof(ObservatoryCode));
            OnPropertyChanged(nameof(Date));
        }
    }
}