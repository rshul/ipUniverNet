using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRR.UIP.HW4.OOP.Classes.Task2
{
    class WorkingPlace
    {
        public Worker[] WorkersTeam { get; set; }
        public Device[] ProducingDevices { get; set; }
        public bool IsJobDone
        {
            get
            {
                if(this.ProducingDevices == null)
                {
                    Console.WriteLine("Task is not assigned!");
                    return true;
                }
                bool isEveryDeviceFinished = true;
                foreach (var device in this.ProducingDevices)
                {
                    if (!device.IsCompleted)
                    {
                        isEveryDeviceFinished = false;
                        break;
                    }
                }
                return isEveryDeviceFinished;
            }
        }
        public int CurrentDevice
        {
            get
            {
                if (this.ProducingDevices == null)
                {
                    Console.WriteLine("Task is not assigned!");
                    return 0;
                }
                int currentDevice = 0;
                for (int i = 0; i < this.ProducingDevices.Length; i++)
                {
                    if (!this.ProducingDevices[i].IsCompleted)
                    {
                        currentDevice = i;
                        break;
                    }
                }
                return currentDevice;

            }
        }

        public WorkingPlace()
        {
            this.WorkersTeam = null;
            this.ProducingDevices = null;
        }
        public WorkingPlace(Worker[] workersTeam, Device[] producingDevices)
        {
            this.WorkersTeam = workersTeam;
            this.ProducingDevices = producingDevices;
        }

        public void AddWorkers(Worker[] workers)
        {
            this.WorkersTeam = workers;
        }

        public void AddDevices(Device[] devices)
        {
            this.ProducingDevices = devices;
        }
        public void AddOneWorker(Worker worker)
        {
            if(this.WorkersTeam != null)
            {
                Worker[] changedWorkersTeam = new Worker[this.WorkersTeam.Length + 1];
                for (int i = 0; i < this.WorkersTeam.Length; i++)
                {
                    changedWorkersTeam[i] = this.WorkersTeam[i];
                }
                changedWorkersTeam[this.WorkersTeam.Length] = worker;
                this.WorkersTeam = changedWorkersTeam;
            }
            else
            {
                Worker[] changedWorkersTeam = new Worker[1] { worker };
                this.WorkersTeam = changedWorkersTeam;
            }
        }
        public void RemoveOneWorker()
        {
            if (this.WorkersTeam != null)
            {
                if(this.WorkersTeam.Length == 1)
                {
                    this.WorkersTeam = null;
                }
                else
                {
                    Worker[] changedWorkersTeam = new Worker[this.WorkersTeam.Length - 1];
                    for (int i = 0; i < this.WorkersTeam.Length - 1; i++)
                    {
                        changedWorkersTeam[i] = this.WorkersTeam[i];
                    }
                    this.WorkersTeam = changedWorkersTeam;
                }
            }
        }

        public void IntroduceTeam()
        {

            if (this.WorkersTeam != null)
            {
                Console.WriteLine();
                for (int i = 0; i < this.WorkersTeam.Length; i++)
                {
                    Console.Write($"Worker[{i}]-{this.WorkersTeam[i].Qualification}; ");
                }
                
            }
            else
            {
                Console.WriteLine("Working place is empty!");
            }
        }
        public void ShowAllDevices()
        {
            if (this.ProducingDevices != null)
            {
                Console.WriteLine();
                for (int i = 0; i < this.ProducingDevices.Length; i++)
                {
                    Console.Write($"device{i} ");
                    this.ProducingDevices[i].ShowDevice();
                }
            }
            else
            {
                Console.WriteLine("There is no devices to produce!");
            }
        }
        public void WorkOneShift()
        {
            if (this.WorkersTeam != null && this.ProducingDevices != null)
            {
                int nextDevice = this.CurrentDevice;
                foreach (var worker in this.WorkersTeam)
                {
                    if (this.IsJobDone)
                    {
                        break;
                    }

                    worker.AttachDetail(this.ProducingDevices[nextDevice]);

                    if (this.ProducingDevices[nextDevice].IsCompleted && this.ProducingDevices.Length - 1 > nextDevice)
                    {
                        nextDevice++;
                    }

                }

            }
        }
    }
}
