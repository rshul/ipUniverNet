using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW6.OOP.Inheritance.Task1
{
    class Player:Device
    {
        public string[] PlaybackFormats { get; private set; }
        public Player(string name, int powerConsumption, string[] playbackFormats):base(name, powerConsumption)
        {
            this.PlaybackFormats = playbackFormats;
        }
        public override string GetDescription()
        {
            string pbFormats = "";
            foreach (var pbFormat in this.PlaybackFormats)
            {
                pbFormats += pbFormat + " ";
            }
            return base.GetDescription() + ", "+ pbFormats;
        }
    }
}
