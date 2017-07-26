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
        private MediaRecorder recorder;
        

        public AudioImplementation() { }

       

        public void Initializer()
        {
            mediaPlayer = new MediaPlayer();
            mediaPlayer.SetAudioStreamType(Stream.Music);
            
            
        }

        public void Play(string aux)
        {
            if (mediaPlayer == null)
            {
                Initializer();
            }
            try
            {
                mediaPlayer.SetDataSource(aux);
                mediaPlayer.Prepare();
                mediaPlayer.Start();
            }
            catch (Exception ex)
            {
                //unable to start playback log error
                Console.WriteLine("Unable to start playback: " + ex);
            }
        }

        public void RecordAudio()
        {
            string audioFilePath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/teste.3gp";


            if (recorder == null)
            {
                try
                {
                    MediaRecorder recorder = new MediaRecorder();
                    recorder.SetAudioSource(AudioSource.Mic);
                    recorder.SetOutputFormat(OutputFormat.ThreeGpp);
                    recorder.SetAudioEncoder(AudioEncoder.AmrNb);
                    recorder.SetOutputFile(audioFilePath);
                    recorder.Prepare();
                    recorder.Start();   // Recording is now started }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unable to record: " + ex);
                }
            }
            else
            {
                try
                {
                    recorder.Stop();
                    recorder.Reset();   // You can reuse the object by going back to setAudioSource() step
                    recorder.Release(); // Now the object cannot be reused
                } catch (Exception ex1) {
                    Console.WriteLine("Unable stop record: " + ex1);
                }
               
            }
        }
    }
}