using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Silence.ViewModel;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;

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
            DisplayAlert("Alerta", "Bem vindo a Silence TVapp "+FacebookModel.Instance.ListLogin.First().name, "OK");

            var viewModel = new HomeListViewModel();
            BindingContext = viewModel;
            nameLabel.Text = FacebookModel.Instance.ListLogin.First().name;

            TvList.IsPullToRefreshEnabled = true;
            TvList.RefreshCommand = viewModel.RefreshCommand;
            TvList.SetBinding(ListView.IsRefreshingProperty, nameof(viewModel.IsBusy));

            elements = new ObservableCollection<HomeListViewModel>();
            elements.Add(new HomeListViewModel { Name= "Televisão 1", Type ="emissão", Url = "http://192.168.1.64:8080", Image ="tv.png", index = 0});
            elements.Add(new HomeListViewModel { Name = "Televisão 2", Type = "emissão", Url = "http://192.168.1.64:7070", Image = "tv.png", index = 1});
            elements.Add(new HomeListViewModel { Name = "Televisão 3", Type = "emissão", Url = "http://192.168.1.64:6060", Image = "tv.png", index = 2});
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