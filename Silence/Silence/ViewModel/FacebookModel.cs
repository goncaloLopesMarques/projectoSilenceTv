using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Silence.ViewModel
{
    class FacebookModel
    {
       
        private string clientId = "1710970235613527";
        public FacebookModel()
        {
   
        }
        public void loginFacebook(View content)
        {
            var apiRequest = "https://www.facebook.com/v2.10/dialog/oauth?client_id="
                   + clientId
                   + "&display=popup&response_type=token&redirect_uri=https://www.facebook.com/connect/login_success.html";
            var webView = new WebView
            {
                Source = apiRequest,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            webView.Navigated += WebViewOnNavigated;
            content = webView;
        }

        private async void WebViewOnNavigated(object sender, WebNavigatedEventArgs e)
        {
            var accessToken = ExtractAccessTokenFromUrl(e.Url);
            if(accessToken != null)
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
            if(url.Contains("access_Token")&& url.Contains("expires_in=")){
                var at = url.Replace("https://www.facebook.com/connect/login_success.html#access_token=", "");

                if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
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
