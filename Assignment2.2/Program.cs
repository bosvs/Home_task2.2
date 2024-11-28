using Assignment2._2;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            List<Worker> workers = new List<Worker>();
            List<Team> teamList = new List<Team>();

            bool continueRunning = true;

            while (continueRunning)
            {
                if (teamList.Count > 0)
                    Console.WriteLine();

                Console.Write("Would you like to create a new team? (yes/no): ");
                string response = GetValidResponse(new string[] { "yes", "no" });
                if (response == "no")
                {
                    continueRunning = false;
                    break;
                }
                else
                {
                    Console.Write("Enter the new team's name: ");
                    string newTeamName = GetValidResponse();
                    Console.WriteLine();
                    workers = AddNewMembers(newTeamName);
                    teamList.Add(new Team(newTeamName, workers));
                    Console.WriteLine();
                    teamList.Last().TeamInfo();
                    Console.WriteLine();
                }
            }

            if (teamList.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Goodbye!");
            }
            else
            {
                foreach (Team team in teamList)
                {
                    if (team.Members.Count > 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"In team {team.TeamName}, the workday looks like this: ");
                        foreach (Worker member in team.Members)
                        {
                            member.FillWorkDay();
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Team {team.TeamName} has no members yet.");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Goodbye!");
            }
        }

        private static string GetValidResponse()
        {
            string input = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(input))
            {
                Console.Write("Invalid input. Please try again: ");
                input = Console.ReadLine();
            }

            return input;
        }
        private static List<Worker> AddNewMembers(string teamName)
        {
            List<Worker> newMembers = new List<Worker>();
            Console.Write($"Would you like to add a new member to the team \"{teamName}\"? (yes/no): ");
            string response = GetValidResponse(new string[] { "yes", "no" });

            if (response == "no")
                return newMembers;
            else
            {
                while (response == "yes")
                {
                    Console.Write("Enter the type of worker (developer/manager): ");
                    string workerType = GetValidResponse(new string[] { "developer", "manager" });

                    Console.Write("Enter the worker's name: ");
                    string workerName = Console.ReadLine();

                    if (workerType == "developer")
                        newMembers.Add(new Developer(workerName));
                    else
                        newMembers.Add(new Manager(workerName));

                    Console.WriteLine();
                    Console.Write($"Would you like to add another member to the team \"{teamName}\"? (yes/no): ");
                    response = GetValidResponse(new string[] { "yes", "no" });
                }
            }

            return newMembers;
        }

        private static string GetValidResponse(string[] validAnswers)
        {
            string input = Console.ReadLine().ToLower();
            bool isValid = validAnswers.Contains(input);

            while (!isValid)
            {
                Console.Write("Invalid input. Please try again: ");
                input = Console.ReadLine().ToLower();
                isValid = validAnswers.Contains(input);
            }

            return input;
        }
    }
}
