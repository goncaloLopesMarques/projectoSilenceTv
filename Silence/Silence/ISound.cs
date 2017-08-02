using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silence
{
   public interface ISound
    {
        void Play(String aux);
        void Initializer(String aux);
        void Pause();
        void RecordAudio(String aux);
    }
   
}
