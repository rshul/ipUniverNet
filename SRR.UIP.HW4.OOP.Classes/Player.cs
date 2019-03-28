using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW4.OOP.Classes.Task1
{
    class Player
    {
        public string Name { get; private set; }
        public int PowerConsumption { get; private set; }
        public string[] PlaybackFormats { get; private set; }

        public Player(string name, int powerConsumption, string[] playbackFormats)
        {
            this.Name = name;
            this.PowerConsumption = powerConsumption;
            this.PlaybackFormats = playbackFormats;
        }

        public string GetDescription()
        {
            string pbFormats = "";
            foreach (var pbFormat in this.PlaybackFormats)
            {
                pbFormats += pbFormat + " ";
            }
            return $"Player {this.Name}, power consumtion {this.PowerConsumption}, playback formats {pbFormats}";
        }

    }
}
