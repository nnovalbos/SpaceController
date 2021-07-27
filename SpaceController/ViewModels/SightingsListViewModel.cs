using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SpaceController.Common;
using SpaceController.Contracts.Services;
using SpaceController.Models;
using SpaceController.ViewModels.Base;
using SpaceController.ViewModels.Templates;
using Xamarin.Forms.Internals;

namespace SpaceController.ViewModels
{
    public class SightingsListViewModel : BaseViewModel
    {
        private ObservableCollection<SightingTemplateViewModel> sightings;
        private readonly ISightingsService sightingsService;

        public SightingsListViewModel(INavigationService navigationService,
            ISightingsService sightingsService) : base(navigationService)
        {
            this.sightingsService = sightingsService;
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
            IsBusy = true;
            var allSightings = await sightingsService.GetAllSightingsAsync(Data.txtData);
            CreateViewModels(allSightings);
            IsBusy = false;
        }

        private void CreateViewModels(IList<Sighting> sightings)
        {
            sightings.ForEach(async s =>
            {
                    var vm = new SightingTemplateViewModel(navigationService);
                    await vm.InitializeAsync(s);
                    Sightings.Add(vm);
            });
        }
    }
}
