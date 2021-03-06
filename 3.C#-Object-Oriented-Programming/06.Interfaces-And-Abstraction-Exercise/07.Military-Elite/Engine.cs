using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private ICollection<ISoldier> soldiers;

        private Engine()
        {
            soldiers = new List<ISoldier>();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command = string.Empty;

            while ((command = reader.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string soldierType = commandArgs[0];
                int ID = int.Parse(commandArgs[1]);
                string firstName = commandArgs[2];
                string lastName = commandArgs[3];

                ISoldier soldier = null;

                if (soldierType == "Private")
                {
                    soldier = AddPrivate(commandArgs, ID, firstName, lastName);
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    soldier = AddGeneral(commandArgs, ID, firstName, lastName);
                }
                else if (soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(commandArgs[4]);
                    string corps = commandArgs[5];

                    try
                    {
                        soldier = CreateEngineer(commandArgs, ID, firstName, lastName, salary, corps);
                    }
                    catch (InvalidCorpsException ice)
                    {
                        continue;
                    }
                }
                else if (soldierType == "Commando")
                {
                    decimal salary = decimal.Parse(commandArgs[4]);
                    string corps = commandArgs[5];

                    try
                    {
                        ICommando commando = new Commando(ID, firstName, lastName, salary, corps);

                        string[] missionArgs = commandArgs.Skip(6).ToArray();

                        for (int i = 0; i < missionArgs.Length; i+=2)
                        {
                            try
                            {
                                soldier = GetCommando(commando, missionArgs, i);
                            }
                            catch (InvalidMissionStateException imse)
                            {
                                continue;
                            }
 
                        }
                    }
                    catch (InvalidCorpsException ice)
                    {
                        continue;
                        throw;
                    }
                }
                else if (soldierType == "Spy")
                {
                    int codeNumber = int.Parse(commandArgs[4]);

                    soldier = new Spy(ID, firstName, lastName, codeNumber);
                }

                if (soldier != null)
                {
                    soldiers.Add(soldier);
                }
            }

            foreach (var soldier in soldiers)
            {
                writer.WriteLine(soldier.ToString());
            }
        }

        private static ISoldier GetCommando(ICommando commando, string[] missionArgs, int i)
        {
            ISoldier soldier;
            string missionCodeName = missionArgs[i];
            string missionState = missionArgs[i + 1];

            IMission mission = new Mission(missionCodeName, missionState);

            commando.AddMission(mission);

            soldier = commando;
            return soldier;
        }

        private static ISoldier CreateEngineer(string[] commandArgs, int ID, string firstName, string lastName, decimal salary, string corps)
        {
            ISoldier soldier;
            IEngineer engineer = new Engineer(ID, firstName, lastName, salary, corps);

            string[] repairArgs = commandArgs.Skip(6).ToArray();

            for (int i = 0; i < repairArgs.Length; i += 2)
            {
                string partName = repairArgs[i];
                int hoursWorked = int.Parse(repairArgs[i + 1]);

                IRepair repair = new Repair(partName, hoursWorked);

                engineer.AddRepair(repair);
            }

            soldier = engineer;
            return soldier;
        }

        private ISoldier AddGeneral(string[] commandArgs, int ID, string firstName, string lastName)
        {
            ISoldier soldier;
            decimal salary = decimal.Parse(commandArgs[4]);

            LieutenantGeneral general = new LieutenantGeneral(ID, firstName, lastName, salary);

            foreach (var item in commandArgs.Skip(5))
            {
                ISoldier privateToAdd = soldiers.First(s => s.ID == int.Parse(item));

                general.AddPrivate(privateToAdd);
            }

            soldier = general;
            return soldier;
        }

        private static ISoldier AddPrivate(string[] commandArgs, int ID, string firstName, string lastName)
        {
            ISoldier soldier;
            decimal salary = decimal.Parse(commandArgs[4]);

            soldier = new Private(ID, firstName, lastName, salary);
            return soldier;
        }
    }
}
