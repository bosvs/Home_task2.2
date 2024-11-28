using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2._2
{
    internal class Team
    {
        public string TeamName;
        public List<Worker> Members = new List<Worker>();

        public Team(string teamName)
        {
            this.TeamName = teamName;
        }
        public Team(string teamName, List<Worker> members)
        {
            this.TeamName = teamName;
            if (members.Count > 0)
            {
                this.Members = members;
            }
           
        }
        public void AddMembers(Worker member)
        {
            this.Members.Add(member);
        }
        public void AddMembers(List<Worker> members)
        {
            foreach (Worker member in members)
            {
                this.Members.Add(member);
            }
        }
        public void TeamInfo()
        {
            Console.WriteLine($"Title of the team - {TeamName}");
            if (Members.Count > 0)
            {
                Console.WriteLine($"Members {TeamName}: ");
                foreach (Worker member in Members)
                {
                    Console.WriteLine($"    * {member.Name} - {member.Position} - {member.WorkDay};");
                }
            }
            else
                Console.WriteLine($"{TeamName} The team doesn't exist yet.");
        }
    }
}

