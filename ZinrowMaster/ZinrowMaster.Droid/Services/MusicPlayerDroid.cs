using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ZinrowMaster.Services;
using ZinrowMaster.Droid.Services;
using Android.Media;
using System.Threading.Tasks;

[assembly: Dependency(typeof(MusicPlayerDroid))]

namespace ZinrowMaster.Droid.Services {
    public class MusicPlayerDroid : IMusicPlayer {
        MediaPlayer player = null;

        private async Task StartPlayerAsync(string title) {
            var resourceId = (int)typeof(Resource.Raw).GetField(title).GetValue(null);

            await Task.Run(() => {
                if (player == null) {
                    player = new MediaPlayer();
                    player.SetAudioStreamType(Stream.Music);

                    player = MediaPlayer.Create(
                                global::Android.App.Application.Context,
                                resourceId
                            );
                    player.Looping = true;
                    player.Start();
                } else {
                    if (player.IsPlaying == true) {
                        player.Pause();
                    } else {
                        player.Start();
                    }
                }
            });
        }

        private void StopPlayer() {
            if ((player != null)) {
                if (player.IsPlaying) {
                    player.Stop();
                }
                player.Release();
                player = null;
            }
        }

        public async Task PlayAsync(string title) {
            await StartPlayerAsync(title);
        }

        public void Stop() {
            StopPlayer();
        }
    }
}