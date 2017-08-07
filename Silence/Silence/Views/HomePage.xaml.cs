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
            elements.Add(new HomeListViewModel { Name= "Player1", Type ="emissão", Url = "http://192.168.1.64:8080", Image ="tv.png", index = 0});
            elements.Add(new HomeListViewModel { Name = "Player2", Type = "emissão", Url = "http://192.168.1.64:7070", Image = "tv.png", index = 1});
            elements.Add(new HomeListViewModel { Name = "Player3", Type = "emissão", Url = "http://192.168.1.64:6060", Image = "tv.png", index = 2});
            TvList.ItemsSource = elements;
            
        }
       
        public HomeListViewModel getListFirstChild()
        {
            return elements.ElementAt(0);
        }
        public HomeListViewModel firstElement
        {
            get { return elements.First(); }
            
        }
        public HomeListViewModel lastElement
        {
            get { return elements.Last(); }

        }
    }
}