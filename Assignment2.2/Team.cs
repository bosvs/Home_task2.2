using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2._2
{
     public class Team
    {
        public string TeamName { get; private set; }
        public List<Worker> Members { get; private set; }

        public Team(string name, List<Worker> members)
        {
            TeamName = name;
            Members = members;
        }

        public void TeamInfo()
        {
            Console.WriteLine($"Title of the team - {TeamName}\n");
            if (Members.Count > 0)
            {
                Console.WriteLine($"Members {TeamName}: ");
                foreach (Worker member in Members)
                {
                    Console.WriteLine($"    * {member.Name} - {member.Position} - {member.WorkDay};");
                }
                if (Members.Count > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Team {TeamName} is actively working as follows:");
                    foreach (Worker member in Members)
                    {
                        member.FillWorkDay();
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"Team {TeamName} has no activity yet because there are no members added.");
                }
            }
            else
            {
                Console.WriteLine($"{TeamName} - doesn't have members yet.");
            }
               
        }
    }

}

