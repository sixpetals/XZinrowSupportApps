using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using UIKit;
using ZinrowMaster.Services;
using Xamarin.Forms;
using ZinrowMaster.iOS.Services;
using AVFoundation;

[assembly: Dependency(typeof(MediaPlayerIOS))]

namespace ZinrowMaster.iOS.Services {
    public class MediaPlayerIOS : IMusicPlayer {
        AVAudioPlayer player = null;

        private async Task StartPlayerAsync(string title) {
            await Task.Run(() => {
                if (player == null) {
                    var url = NSUrl.FromFilename($"{title}.mp3");

                    NSError _err = null;

                    player = new AVAudioPlayer(
                                url,
                                AVFileType.MpegLayer3,
                                out _err
                             );

                    player.NumberOfLoops = -1;
                    //player.Looping = true;
                    player.PrepareToPlay();
                    player.Play();
                } else {
                    if (player.Playing == true) {
                        player.Stop();
                    } else {
                        player.Play();
                    }
                }
            });
        }

        private void StopPlayer() {
            if (player != null) {
                if (player.Playing) {
                    player.Stop();
                }
                player.Dispose();
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