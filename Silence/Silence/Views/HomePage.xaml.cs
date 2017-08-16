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

namespace Silence.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private string clientId = "1710970235613527";
        HomeListViewModel aux = new HomeListViewModel();
        FacebookModel facebookModel = new FacebookModel();
        public ObservableCollection<HomeListViewModel> elements { get; set; }
        public HomePage()
        {
            
            InitializeComponent();
           
            var viewModel = new HomeListViewModel();
            facebookModel = new FacebookModel();
            BindingContext = viewModel;


            TvList.IsPullToRefreshEnabled = true;
            TvList.RefreshCommand = viewModel.RefreshCommand;
            TvList.SetBinding(ListView.IsRefreshingProperty, nameof(viewModel.IsBusy));

            elements = new ObservableCollection<HomeListViewModel>();
            elements.Add(new HomeListViewModel { Name= "Televisão 1", Type ="emissão", Url = "http://192.168.1.64:8080", Image ="tv.png", index = 0});
            elements.Add(new HomeListViewModel { Name = "Televisão 2", Type = "emissão", Url = "http://192.168.1.64:7070", Image = "tv.png", index = 1});
            elements.Add(new HomeListViewModel { Name = "Televisão 3", Type = "emissão", Url = "http://192.168.1.64:6060", Image = "tv.png", index = 2});
            TvList.ItemsSource = elements;
            
        }
        private void ButtonFace_Clicked(object sender, EventArgs e)
        {
          //  facebookModel.loginFacebook(Content);
            var apiRequest = "https://www.facebook.com/v2.10/dialog/oauth?client_id="
                  + clientId
                  + "&display=popup&response_type=token&redirect_uri=https://www.facebook.com/connect/login_success.html";
            var webView = new WebView
            {
                Source = apiRequest,
               HeightRequest=1
            };
            webView.Navigated += WebViewOnNavigated;
            Content = webView;
        }
        private async void WebViewOnNavigated(object sender, WebNavigatedEventArgs e)
        {
            var accessToken = ExtractAccessTokenFromUrl(e.Url);
            if (accessToken != null)
            {
                await GetFacebookProfileAsync(accessToken);
            }
        }

        public async Task GetFacebookProfileAsync(string accessToken)
        {
            var requestUrl = "https://graph.facebook.com/v2.7/me/"
                           + "?fields=name,picture,devices"
                           + "&access_token=" + accessToken;
            var httpClient = new HttpClient();
            var userAgent = await httpClient.GetStringAsync(requestUrl);

        }

        private string ExtractAccessTokenFromUrl(string url)
        {
            if (url.Contains("access_Token") && url.Contains("expires_in="))
            {
                var at = url.Replace("https://www.facebook.com/connect/login_success.html#access_token=", "");

#pragma warning disable CS0618 // Type or member is obsolete
#pragma warning disable CS0612 // Type or member is obsolete
                if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
#pragma warning restore CS0612 // Type or member is obsolete
#pragma warning restore CS0618 // Type or member is obsolete
                {
                    at = url.Replace("https://www.facebook.com/connect/login_success.html#access_token=", "");
                }
                var accessToken = at.Remove(at.IndexOf("&expires_in="));
                return accessToken;
            }
            return string.Empty;
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