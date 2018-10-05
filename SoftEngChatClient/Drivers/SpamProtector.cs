using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SoftEngChatClient.Drivers
{
    class SpamProtector
    {
        private int spam;

        public SpamProtector()
        {
            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Elapsed += new ElapsedEventHandler(SpamTimerElapsed);
            timer.Enabled = true;
        }

        private void SpamTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (spam >= 0)
            {
                spam--;
            }
        }

        public void SpamAppend()
        {
            spam++;
        }

        public bool IsNotSpamming()
        {
            if (spam > 5)
            {
                return false;
            }
            else return true;
        }
    }
}
