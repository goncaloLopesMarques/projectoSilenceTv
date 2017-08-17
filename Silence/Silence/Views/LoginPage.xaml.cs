using Newtonsoft.Json;
using Silence.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Silence.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        FacebookModel faceModel;
        WebView webView;
        private string clientId = "1710970235613527";

        public LoginPage()
        {
            InitializeComponent();
            faceModel = new FacebookModel();
            webView = new WebView();
        }

        private void ButtonSkip_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new MainPage();
        }

        private void ButtonFaceBook_Clicked(object sender, EventArgs e)
        {
            var apiRequest = "https://www.facebook.com/dialog/oauth?client_id="
                  + clientId
                  + "&display=popup&response_type=token&redirect_uri=https://www.facebook.com/connect/login_success.html";
            webView.Source = apiRequest;
            webView.HeightRequest = 1;
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
                           + "?fields=name"
                           + "&access_token=" + accessToken;
            try
            {
                var httpClient = new HttpClient();
                var userAgent = await httpClient.GetStringAsync(requestUrl);
                fillLabels(userAgent);
            }
            catch (Exception wex)
            {
                System.Diagnostics.Debug.WriteLine(wex);
            }
        }
        private void fillLabels(string userAgent)
        {
            FacebookProfile fb = JsonConvert.DeserializeObject<FacebookProfile>(userAgent);
            FacebookModel.Instance.ListLogin.Add(fb);
            webView.IsVisible = false;
            webView = null;
            Application.Current.MainPage = new MainPage();
        }
        private string ExtractAccessTokenFromUrl(string url)
        {
            if (url.Contains("access_token") && url.Contains("expires_in"))

            {
                var at = url.Replace("https://www.facebook.com/connect/login_success.html#access_token=", "");

                if (Device.RuntimePlatform == Device.WinPhone || Device.RuntimePlatform == Device.Windows)
                {
                    at = url.Replace("https://www.facebook.com/connect/login_success.html#access_token=", "");
                }
                var accessToken = at.Remove(at.IndexOf("&expires_in="));
                return accessToken;
            }
            return string.Empty;
        }
    }
}