using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZinrowMaster.Services {
    public interface IMusicPlayer {
        Task PlayAsync(string title);
        void Stop();
    }
}
