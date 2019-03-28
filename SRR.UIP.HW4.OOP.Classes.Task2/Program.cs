using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW4.OOP.Classes.Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker[] teamOfWorkers = new Worker[]{
                new Worker("newbie"),
                new Worker("profi"),
                new Worker("master")
            };
            Device[] taskDevices = new Device[]
            {
                new Device(5),
                new Device(11),
                new Device(7)
            };
            //initial state
            WorkingPlace devicesPlant = new WorkingPlace(teamOfWorkers, taskDevices);
            devicesPlant.IntroduceTeam();
            devicesPlant.ShowAllDevices();
            //after one shift of working
            devicesPlant.WorkOneShift();
            devicesPlant.ShowAllDevices();
            //after dismissing one worker and working one shift
            devicesPlant.RemoveOneWorker();
            devicesPlant.IntroduceTeam();
            devicesPlant.WorkOneShift();
            devicesPlant.ShowAllDevices();
            //after hiring one worker and working till task completion
            devicesPlant.AddOneWorker(new Worker());
            devicesPlant.IntroduceTeam();
            
            while (!devicesPlant.IsJobDone)
            {
                devicesPlant.WorkOneShift();
                devicesPlant.ShowAllDevices();
            }

            Console.ReadLine();
        }
    }
}
