using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SpaceController.Contracts.Services;
using SpaceController.Models;
using SpaceController.ViewModels.Base;
using SpaceController.ViewModels.Templates;

namespace SpaceController.ViewModels
{
    public class SightingsListViewModel : BaseViewModel
    {
        private ObservableCollection<SightingTemplateViewModel> sightings;

        public SightingsListViewModel(INavigationService navigationService) : base(navigationService)
        {
            sightings = new ObservableCollection<SightingTemplateViewModel>();
        }

        public ObservableCollection<SightingTemplateViewModel> Sightings
        {
            get => sightings;
            set
            {
                sightings = value;
                OnPropertyChanged();
            }
        }

        public async override Task InitializeAsync(object parameter)
        {
            var tempFakeSighting = new SightingTemplateViewModel(navigationService);
            var s1 = new Sighting { Date = DateTime.Now, ObservatoryCode = "ob_35634" };
            await tempFakeSighting.InitializeAsync(s1);

            Sightings.Add(tempFakeSighting);
        }
    }
}
