using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Silence.ViewModel;
using System.Collections.ObjectModel;

namespace Silence.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        HomeListViewModel aux = new HomeListViewModel();
        public ObservableCollection<HomeListViewModel> elements { get; set; }
        public HomePage()
        {
            InitializeComponent();
            var viewModel = new HomeListViewModel();
            BindingContext = viewModel;

            TvList.IsPullToRefreshEnabled = true;
            TvList.RefreshCommand = viewModel.RefreshCommand;
            TvList.SetBinding(ListView.IsRefreshingProperty, nameof(viewModel.IsBusy));

            elements = new ObservableCollection<HomeListViewModel>();
            elements.Add(new HomeListViewModel { Name= "Teste", Type ="Teste1", Image="tv.png" });
            elements.Add(new HomeListViewModel { Name = "Goncalo", Type = "Lopes", Image = "tv.png" });
            elements.Add(new HomeListViewModel { Name = "Pedro", Type = "Crespo", Image = "tv.png" });
            TvList.ItemsSource = elements;
    
        }
        
    }
}