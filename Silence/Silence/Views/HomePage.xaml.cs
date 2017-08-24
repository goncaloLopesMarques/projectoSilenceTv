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
            var viewModel = new HomeListViewModel();
            BindingContext = viewModel;
            if (FacebookModel.Instance.ListLogin.Count != 0)
            {
                nameLabel.Text = FacebookModel.Instance.ListLogin.First().name;
            }
            //defenição da listview
            TvList.IsPullToRefreshEnabled = true;
            TvList.RefreshCommand = viewModel.RefreshCommand;
            TvList.SetBinding(ListView.IsRefreshingProperty, nameof(viewModel.IsBusy));
            //preencher a listview estaticamente
            elements = new ObservableCollection<HomeListViewModel>();
            //elements.Add(new HomeListViewModel { Name= "Televisão 1", Type ="emissão", Url = "http://192.168.1.64:25565", Image ="tv.png", index = 0});
            //elements.Add(new HomeListViewModel { Name = "Televisão 2", Type = "emissão", Url = "http://192.168.1.64:25566", Image = "tv.png", index = 1});
            //elements.Add(new HomeListViewModel { Name = "Televisão 3", Type = "emissão", Url = "http://192.168.1.64:25567", Image = "tv.png", index = 2});
            //TvList.ItemsSource = elements;
            //Consumir um webserver rest
            iniciarLigacao();
        }
        private async void iniciarLigacao()
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://188.250.27.84:3000/");
                var response = await client.GetAsync("inputs/");
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var emissor = JsonConvert.DeserializeObject<List<HomeListViewModel>>(responseString);
                    TvList.ItemsSource = emissor;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("aviso", ex.Message, "ok");
            }
        }
        public ObservableCollection<HomeListViewModel> getElements()
        {
            return elements;
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