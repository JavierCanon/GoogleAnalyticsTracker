using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace UserTracker
{
    public class LocalSound
    {
        public static void playTakeBreak()
        {
            using(SoundPlayer player = new SoundPlayer("TakeBreak.wav"))
            {
                player.PlaySync();
            }
        }

        public static void playBackWork()
        {
            using (SoundPlayer player = new SoundPlayer("BackWork.wav"))
            {
                player.PlaySync();
            }
        }
    }
}
