using SpaceController.Contracts.Utils;
using SpaceController.ViewModels;
using Xamarin.Forms;

namespace SpaceController.Views
{
    public partial class SightingDetailView : ContentPage, IDrawable
    {
        public SightingDetailView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var vm = BindingContext as SightingDetailViewModel;
            vm.Listener = this;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            var vm = BindingContext as SightingDetailViewModel;
            vm.Listener = null;
        }

        public void Draw()
        {
            var vm = BindingContext as SightingDetailViewModel;

            Grid laserMatrix = new Grid
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(10),
                ColumnSpacing = 0,
                RowSpacing = 0
            };

            laserMatrix.RowDefinitions.Add(new RowDefinition());
            laserMatrix.ColumnDefinitions.Add(new ColumnDefinition());
            var matrixIndex = 0;

            for (int rowIndex = 0; rowIndex < vm.Sighting.DeviceResolution.Rows; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < vm.Sighting.DeviceResolution.Colums; columnIndex++)
                {
                    var primaryColor = (Color)Application.Current.Resources["PrimaryColor"];
                    var backGroundColor = vm.Sighting.DeviceMatrix[matrixIndex].Equals('1') ? primaryColor : Color.White;

                    var cell = new StackLayout
                    {
                        BackgroundColor = primaryColor,
                        Padding = new Thickness(1, 1, 1, 1)
                    };

                    var boxView = new BoxView
                    {
                        BackgroundColor = backGroundColor
                    };

                    cell.Children.Add(boxView);

                    laserMatrix.Children.Add(cell, columnIndex, rowIndex);
                    matrixIndex++;
                }
            }

            mainLayout.Children.Add(laserMatrix);

            vm.RefreshViewElements();
        }
    }
}
