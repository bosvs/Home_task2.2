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

            var teamManager = new TeamManager();
            teamManager.Run();
        }
    }

    public class TeamManager
    {
        private List<Team> teams = new List<Team>();

        public void Run()
        {
            bool continueRunning = true;

            while (continueRunning)
            {
                Console.Clear();
                Console.WriteLine("Team Management System");
                Console.WriteLine("======================");
                if (teams.Any())
                {
                    DisplayTeams();
                }

                Console.Write("Do you want to create a new team? (yes/no): ");
                string response = UserInput.GetValidResponse(new[] { "yes", "no" });

                if (response == "no")
                {
                    continueRunning = false;
                }
                else
                {
                    CreateNewTeam();
                }
            }

            Console.WriteLine("\nThank you for using the Team Management System. Goodbye!");
        }

        private void CreateNewTeam()
        {
            Console.Write("\nEnter the new team's name: ");
            string teamName = UserInput.GetNonEmptyString();
            List<Worker> workers = AddNewMembers(teamName);
            teams.Add(new Team(teamName, workers));
            Console.WriteLine($"\nTeam {teamName} created successfully!");
        }

        private List<Worker> AddNewMembers(string teamName)
        {
            var newMembers = new List<Worker>();

            while (true)
            {
                Console.Write($"\nDo you want to add a new member to the team \"{teamName}\"? (yes/no): ");
                string response = UserInput.GetValidResponse(new[] { "yes", "no" });

                if (response == "no")
                    break;

                Console.Write("Enter the type of worker (developer/manager): ");
                string workerType = UserInput.GetValidResponse(new[] { "developer", "manager" });

                Console.Write("Enter the worker's name: ");
                string workerName = UserInput.GetNonEmptyString();
                Console.Write("Enter job time of the worker: ");
                double workDay = UserInput.GetValidAnswerDouble();

                if (workerType == "developer")
                    newMembers.Add(new Developer(workerName, workDay));
                else
                    newMembers.Add(new Manager(workerName, workDay));
            }

            return newMembers;
        }

        private void DisplayTeams()
        {
            Console.WriteLine("\nCurrent Teams:");
            foreach (var team in teams)
            {
                Console.WriteLine($"- {team.TeamName}");
            }

            Console.Write("\nWould you like to see the details of any team? (yes/no): ");
            string response = UserInput.GetValidResponse(new[] { "yes", "no" });

            if (response == "yes")
            {
                Console.Write("Enter the team name: ");
                string teamName = UserInput.GetNonEmptyString();
                var team = teams.FirstOrDefault(t => t.TeamName.Equals(teamName, StringComparison.OrdinalIgnoreCase));

                if (team != null)
                {
                    team.TeamInfo();
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"\nTeam {teamName} not found.");
                }
            }
        }
    }

    public static class UserInput
    {
        public static string GetNonEmptyString()
        {
            string input;
            while (string.IsNullOrWhiteSpace(input = Console.ReadLine()))
            {
                Console.Write("Invalid input. Please try again: ");
            }
            return input;
        }

        public static string GetValidResponse(string[] validAnswers)
        {
            string input;
            while (!validAnswers.Contains(input = Console.ReadLine().ToLower()))
            {
                Console.Write("Invalid input. Please try again: ");
            }
            return input;
        }
        public static double GetValidAnswerDouble()
        {
            double result = 0;
            bool isValid = true;
            string answer = Console.ReadLine();

            if (double.TryParse(answer, out result))
            {
                isValid = double.TryParse(answer, out result);
                return result;
            }
            else
            {
                while (!isValid)
                {
                    Console.Write("Invalid input. Please try again: ");
                    answer = Console.ReadLine();
                    isValid = double.TryParse(answer, out result);
                }
            }

            return result;
        }
    }
}
