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
using Xamarin.Forms;
using SilenceTv1._0.Droid;
using Android.Media;

[assembly: Dependency(typeof(AudioImplementation))]

namespace SilenceTv1._0.Droid
{
    class AudioImplementation : ISoundPlayer
    {
        private MediaPlayer mediaPlayer;
        

        public AudioImplementation() { }
     
        public void Play()
        {
            //https://www.ssaurel.com/tmp/mymusic.mp3
            mediaPlayer = new MediaPlayer();
            mediaPlayer.SetAudioStreamType(Stream.Music);
            mediaPlayer.SetDataSource("http://192.168.1.169:8080");
            mediaPlayer.Prepare();
            mediaPlayer.Start();
        }
    }
}

   