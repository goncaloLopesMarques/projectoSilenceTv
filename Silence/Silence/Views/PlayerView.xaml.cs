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
                    DependencyService.Get<ISound>().StopStreamOnSwiping();
                    var indexaux = model.index;
                    indexaux +=1;
                    model = homeAux.elements.ElementAt(indexaux);
                    btnPlay.Image = "play.png";
                    toogleImage = 0;

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
                    DependencyService.Get<ISound>().StopStreamOnSwiping();
                    var indexaux = model.index;
                    indexaux-=1;
                    model = homeAux.elements.ElementAt(indexaux);
                    btnPlay.Image = "play.png";
                    toogleImage = 0;
                }

                Emissor.Text = model.Name;
            };

            
            btnPlay = playBtn;

           
        }
       

        private void ButtonPlay_Clicked(object sender, EventArgs e)
        {
            if(toogleImage == 0)
            {
                btnPlay.Image = "stop.png";
                DependencyService.Get<ISound>().Initializer(model.Url);
                DependencyService.Get<ISound>().Play(model.Url);
                toogleImage++;
            }else if(toogleImage == 1)
            {
                btnPlay.Image = "play.png";
                DependencyService.Get<ISound>().Play(model.Url);
                toogleImage--;
            }
        }
        private void ButtonRecord_Clicked(object sender, EventArgs e)
        {
          //  DependencyService.Get<ISound>().RecordAudio(aux);
            
           

        }
    }
}