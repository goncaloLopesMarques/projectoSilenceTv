using Silence.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace Silence.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerView : ContentPage
    {

        //private String aux = "http://192.168.1.169:8080";
        private String aux;
        private int toogleImage = 0;
        private Button btnPlay;

        public PlayerView(HomeListViewModel selectedItem)
        {
            InitializeComponent();
            aux = selectedItem.Url;
            btnPlay = playBtn;
            var label = new Label { Text = "Emissor:"+selectedItem.Name, TextColor = Color.FromHex("#77d065"), FontSize = 20 };
             layoutLabel.Children.Add(label);

        }
        
        private void ButtonPlay_Clicked(object sender, EventArgs e)
        {
            if(toogleImage == 0)
            {
                btnPlay.Image = "pause.png";
                DependencyService.Get<ISound>().Initializer(aux);
                DependencyService.Get<ISound>().Play(aux);
                toogleImage++;
            }else if(toogleImage == 1)
            {
                btnPlay.Image = "play.png";
                DependencyService.Get<ISound>().Play(aux);
                toogleImage--;
            }
        }
        private void ButtonRecord_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<ISound>().RecordAudio(aux);
            
           

        }
    }
}