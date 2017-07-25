using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Media;
using Silence.Droid;
using Xamarin.Forms;


[assembly: Dependency(typeof(AudioImplementation))]
namespace Silence.Droid
{
    class AudioImplementation : ISound
    {
        private MediaPlayer mediaPlayer;
        

        public AudioImplementation() { }

        public void Play(string aux)
        {
          
           mediaPlayer = new MediaPlayer();
           mediaPlayer.SetAudioStreamType(Stream.Music);
           mediaPlayer.SetDataSource(aux);
           mediaPlayer.PrepareAsync();
           mediaPlayer.Start(); 
        }
    }
}