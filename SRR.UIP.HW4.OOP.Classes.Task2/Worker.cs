using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW4.OOP.Classes.Task2
{
    class Worker
    {
        public string Qualification { get; private set; }

        public Worker() : this("newbie") {}
        public Worker(string qualification)
        {
            string[] qualificationNames = new string[3]
            {
                "newbie",
                "profi",
                "master"
            };
            if (!String.IsNullOrEmpty(qualification))
            {
                foreach (var qualificationName in qualificationNames)
                {
                    if (qualification.Equals(qualificationName))
                    {
                        this.Qualification = qualification;
                        return;
                    }
                }  
            }
            this.Qualification = "newbie";
            
        }
        public void AttachDetailToDevice(Device handledDevice)
        {
            if (handledDevice.IsCompleted)
            {
               // Console.WriteLine("Give me the next device!");
                return;
            }
            int result = 0;
            switch (this.Qualification)
            {
                case "newbie":
                    result = 1;
                    break;
                case "profi":
                    result = 3;
                    break;
                case "master":
                    result = 5;
                    break;
                default:
                    Console.WriteLine("Worker is not competent");
                    result = 0;
                    break;
            }
            for (int i = 0; i < result; i++)
            {
                if (!handledDevice.IsCompleted)
                {
                    handledDevice.PushDetail();
                }
                else
                {
                    //Console.WriteLine($"Device is ready!");
                    break;
                }
            }
        }
    }
}
