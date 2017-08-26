using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Silence.UWP;
using Plugin.MediaManager;

[assembly: Xamarin.Forms.Dependency(typeof(AudioImplementation))]
namespace Silence.UWP
{
    class AudioImplementation : ISound
    {

        public AudioImplementation() { }

        public void Initializer(string aux)
        {

        }

        public async void Pause()
        {
            await CrossMediaManager.Current.Stop();
        }

        public async void Play(string aux)
        {
            await CrossMediaManager.Current.Play("http://192.168.1.85:8080");

        }

        public void RecordAudio(string aux)
        {
            throw new NotImplementedException();
        }

        public void StopStreamOnSwiping()
        {
            throw new NotImplementedException();
        }
    }
}
