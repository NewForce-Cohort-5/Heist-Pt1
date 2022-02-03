using System;
using System.Collections.Generic;
using System.Linq;

namespace heist
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TeamMember> Team = new List<TeamMember>();
            TeamMember inputTeamMember = new TeamMember();
            int TeamSkillTotal = 0;
            int BankLevel = 0;

            Console.WriteLine("Plan your heist!");
            Console.WriteLine("----------------");
            Console.WriteLine("Please enter your bank difficulty level.");
            BankLevel = Int32.Parse(Console.ReadLine());

            //bool to cause while loop to break
            bool AddTeamMate = true;
            while (AddTeamMate)
            {
                //conditional
                Console.WriteLine("What's the team member's name?");
                inputTeamMember.Name = Console.ReadLine();

                // while loop will continue until name is blank
                if (inputTeamMember.Name != "")
                {
                    Console.WriteLine("What's the team member's skill level?");
                    inputTeamMember.SkillLevel = Int32.Parse(Console.ReadLine());
                    // Console.WriteLine("Please enter a skill level from 1-100");
                    Console.WriteLine("What's team member's courage level? 0.0 - 2.0");
                    inputTeamMember.CourageFactor = Double.Parse(Console.ReadLine());
                    //Console.WriteLine("Please enter a decimal for your courage factor. 0.0 - 2.0");
                    // Console.WriteLine($"Your team member's name is {inputTeamMember.Name}. They're skill level is {inputTeamMember.SkillLevel} and their courage level is {inputTeamMember.CourageFactor}");

                    TeamMember newMember = new TeamMember()
                    {
                        Name = inputTeamMember.Name,
                        SkillLevel = inputTeamMember.SkillLevel,
                        CourageFactor = inputTeamMember.CourageFactor
                    };
                    Team.Add(newMember);
                    inputTeamMember.SkillLevel = 0;
                    int x = Team.Count;
                    // Team.ForEach(member => Console.WriteLine($"# of Team Members: {x}"));
                }
                else
                {
                    Console.WriteLine("How many trial runs would you like to do?");
                    string response = Console.ReadLine();
                    int parsedResponse = Int32.Parse(response);
                    int success = 0;
                    int failure = 0;
                    for (int i = 0; i < parsedResponse; i++)
                    {
                        int RandomNumber = new Random().Next(-10, 10);

                        TeamSkillTotal = Team.Sum(member => member.SkillLevel);
                        if (TeamSkillTotal + RandomNumber > BankLevel)
                        {
                            success++;
                        }
                        else
                        {
                           failure++;
                        }
                    }
                    //report Team vs Bank --- how many times succeeded how many times lost
                    Console.WriteLine($@"
                    Team Skill Level: {TeamSkillTotal}
                    Bank Difficulty Level: {BankLevel}
                    Successes: {success}
                    Failures: {failure}");
                    break;
                }
            }



        }

    }
}
