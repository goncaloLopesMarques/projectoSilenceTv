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
        private String aux;
        private int toogleImage = 0;
        private Button btnPlay;
        private HomePage homeAux;
        private HomeListViewModel model;

        public PlayerView(HomeListViewModel selectedItem)
        {
            InitializeComponent();
            homeAux = new HomePage();
            model = selectedItem;
            Emissor.Text = model.Name;
            SwipeableImage.SwipedLeft += (sender, args) => {
                if (model == homeAux.lastElement)
                {
                    return;
                }
                else
                {
                    var indexaux = model.index;
                    indexaux +=1;
                    model = homeAux.elements.ElementAt(indexaux);
                }
                Emissor.Text = model.Name;
            };
            SwipeableImage.SwipedRight += (sender, args) => {
                if (model == homeAux.firstElement)
                {
                    return;
                }
                else
                {
                    var indexaux = model.index;
                    indexaux-=1;
                    model = homeAux.elements.ElementAt(indexaux);
                }

                Emissor.Text = model.Name;
            };

            aux = model.Url;
            btnPlay = playBtn;

           
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