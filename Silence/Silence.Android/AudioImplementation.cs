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
using Com.Google.Android.Exoplayer2.Trackselection;
using Com.Google.Android.Exoplayer2;
using Uri = Android.Net.Uri;
using Com.Google.Android.Exoplayer2.Upstream;
using Com.Google.Android.Exoplayer2.Extractor;
using Com.Google.Android.Exoplayer2.Source;
using Java.Net;
using Android.Util;
using Java.IO;
using Silence.Views;

[assembly: Dependency(typeof(AudioImplementation))]
namespace Silence.Droid
{
    class AudioImplementation : ISound
    {
        //Components do exoPlayer
        public TrackSelector trackSelector;
        Handler handler;
        ILoadControl loadControl;
        Context context = Android.App.Application.Context;
        public SimpleExoPlayer exoPlayer;
        Uri audioUri;
        DefaultHttpDataSourceFactory dataSourceFactory;
        IExtractorsFactory extractor;
        IMediaSource audioSource;
        private DefaultAllocator allocator;
        public long DEFAULT_BUFFER_FOR_PLAYBACK_AFTER_REBUFFER_MS { get; private set; }
        
        //fim da defenição de variaveis

        public AudioImplementation() { }

        public void Initializer(string aux)
          {
            allocator = new DefaultAllocator(true,500);
            handler = new Handler();
            trackSelector = new DefaultTrackSelector();
            loadControl = new DefaultLoadControl(allocator, 500, 550, 250, DEFAULT_BUFFER_FOR_PLAYBACK_AFTER_REBUFFER_MS);
            exoPlayer = ExoPlayerFactory.NewSimpleInstance(context, trackSelector, loadControl);
            audioUri = Uri.Parse(aux);
            dataSourceFactory = new DefaultHttpDataSourceFactory("SilenceTvAudioPlayer");
            extractor = new DefaultExtractorsFactory();
            audioSource = new ExtractorMediaSource(audioUri, dataSourceFactory, extractor, null, null);
            
        }
     
        public void Play(String aux)
        { 
            if (exoPlayer == null)
            {
                Initializer(aux);
            }
            else
            {
                if (exoPlayer.PlayWhenReady == false)
                {
                    try
                    {
                        
                        exoPlayer.Prepare(audioSource);
                        exoPlayer.PlayWhenReady = true;
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("Unable to start playback: " + ex);
                    }
                }
                else
                {
                    exoPlayer.PlayWhenReady = false;
                }
            }
        }

        public void Pause()
        {
            if (exoPlayer == null)
            {
                return;
            }
            else {
                exoPlayer.PlayWhenReady = false;
            }
        }

        public async void RecordAudio(String aux)
        {
            try
            {
                int count;
                URL url = new URL(aux);
                URLConnection conexion = url.OpenConnection();
                await conexion.ConnectAsync();
                InputStream input = new BufferedInputStream(url.OpenStream());
                OutputStream output = new FileOutputStream("/sdcard/teste.mp3");

                byte[] data = new byte[1024];
                long total = 0;
                while ((count = input.Read(data)) != -1)
                {
                    total += count;
                    output.Write(data, 0, count);
                }
                output.Flush();
                output.Close();
                input.Close();
            }
            catch(Exception ex)
            {
                System.Console.WriteLine("Unable to start playback: " + ex);
            }
           
        }

        public void StopStreamOnSwiping()
        {

            if (exoPlayer == null) {
                return;
            }
            else
            {
                exoPlayer.Stop();
                exoPlayer = null;
            }
        }
    }
}