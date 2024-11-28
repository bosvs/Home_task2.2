using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2._2
{
    public abstract class Worker
    {
        private string _name; 
        private string _position; 
        private double _workDay; 

        public string Name 
        {
            get { return _name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _name = value;
                else
                    _name = "NOname";
            }
        }

        public string Position 
        {
            get { return _position; }
            set { _position = value; }
        }

        public double WorkDay 
        {
            get { return _workDay; }
            set
            {
                if (value < 0)
                    _workDay = 0;
                else if (value > 24)
                    _workDay = 24;
                else
                    _workDay = value;
            }
        }

        public Worker(string Name)
        {
            this.Name = Name;
        }
        public void Call()
        {
            Console.WriteLine($"{Name} phones to someone");
        }
        public void WriteCode()
        {
            Console.WriteLine($"{Name} is coding project.");
        }
        public void Relax()
        {
            Console.WriteLine($"{Name} relaxes.");
        }
        public abstract void FillWorkDay();
    }
}
