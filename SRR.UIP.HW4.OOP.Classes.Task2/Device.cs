using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW4.OOP.Classes.Task2
{
    class Device
    {
        public string[] AttachedDetails { get; private set; }

        public Device(int numberOfDetails)
        {
            string[] placesForDetails = new string[numberOfDetails];
            for(int i = 0; i < numberOfDetails; i++)
            {
                placesForDetails[i] = "-";
            }
            this.AttachedDetails = placesForDetails;
        }

        public bool IsCompleted
        {
            get
            {
                int detailsCount = 0;
                foreach (var detail in AttachedDetails)
                {
                    if (detail == "+")
                    {
                        detailsCount++;
                    }
                }
                return detailsCount == AttachedDetails.Length;
            }
        }

        public void ShowDevice()
        {
            Console.Write("[");
            foreach (var detail in AttachedDetails)
            {
                Console.Write($"{detail}");
            }
            Console.Write("]");
        }
    
        public void PushDetail()
        {
            for(int i = 0; i < AttachedDetails.Length; i++)
            {
                if (AttachedDetails[i] == "-")
                {
                    AttachedDetails[i] = "+";
                    break;
                }
            }
        }
    }
}
