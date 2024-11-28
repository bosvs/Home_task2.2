using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2._2
{
    internal class Manager : Worker
    {
        private Random random = new Random();
        public Manager(string Name) : base(Name)
        {
            this.Position = "Manager";
        }
        public Manager(double WorkDay) : base("")
        {
            this.WorkDay = WorkDay;
            this.Position = "Manager";
        }
        public Manager(string Name, double WorkDay) : base(Name)
        {
            this.WorkDay = WorkDay;
            this.Position = "Manager";
        }
        public override void FillWorkDay()
        {
            for (int i = 0; i < random.Next(1, 11); i++)
            {
                Call();
            }

            Relax();

            for (int i = 0; i < random.Next(1, 6); i++)
            {
                Call();
            }
        }
    }
}
