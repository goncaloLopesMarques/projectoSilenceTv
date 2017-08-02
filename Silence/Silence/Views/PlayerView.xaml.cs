using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Silence.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerView : ContentPage
    {
        
        private String aux = "http://192.168.1.169:8080";
       
        public PlayerView()
        {
            InitializeComponent();
        }
        private void ButtonPlay_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<ISound>().Initializer(aux);
            DependencyService.Get<ISound>().Play(aux);
        }
        private void ButtonPause_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<ISound>().Pause();
        }
        private void ButtonRecord_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<ISound>().RecordAudio(aux);
        }
    }
}