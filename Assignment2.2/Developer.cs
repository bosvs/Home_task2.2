using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2._2
{
    internal class Developer : Worker
    {
        public Developer(string Name) : base(Name)
        {
            this.Position = "Developer";
        }
        public Developer(double WorkDay) : base("")
        {
            this.WorkDay = WorkDay;
            this.Position = "Developer";
        }
        public Developer(string Name, double WorkDay) : base(Name)
        {
            this.WorkDay = WorkDay;
            this.Position = "Developer";
        }

        public override void FillWorkDay()
        {
            WriteCode();
            Call();
            Relax();
            Relax();
            Relax();
        }
    }
}
