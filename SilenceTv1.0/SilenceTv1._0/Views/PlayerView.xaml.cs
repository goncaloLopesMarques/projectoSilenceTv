using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.MediaManager;

namespace SilenceTv1._0.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class PlayerView : ContentPage
    {
       
        public PlayerView()
        {
            InitializeComponent();
            
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            // await CrossMediaManager.Current.Play("http://www.montemagno.com/sample.mp3");
             DependencyService.Get<ISoundPlayer>().Play();
          
          
       
        }
    }
}