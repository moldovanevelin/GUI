using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using SZTGUI_GYAK04.Helpers;
using SZTGUI_GYAK04.Models;
using SZTGUI_GYAK04.Services;
namespace SZTGUI_GYAK04.Logic
{
    public class AthleteLogic : IAthleteLogic
    {

        IList<Athlete> athletes;
        IList<Athlete> competition;
        IAthleteDataService athleteData;
        IMessenger messenger;
        JsonFileName userInput;
        public AthleteLogic(IMessenger messenger, IAthleteDataService athleteData)
        {
            this.messenger = messenger;            
            this.athleteData = athleteData;
        }
        public void SetupCollections(IList<Athlete> athletes, IList<Athlete> competition, JsonFileName userInput)
        {
            this.athletes = athletes;
            this.competition = competition;
            this.userInput = userInput;
        }

        public void AddToAthletes(Athlete athlete)
        {
            if (athlete.Permission)
            {
                competition.Add(athlete.GetCopy());
                messenger.Send("Athlete added", "AthleteInfo");
            }
        }
        public void Easter()
        {
            string url = "https://youtu.be/dQw4w9WgXcQ";
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            };
            Process.Start(psi);
        }
        public void RemoveFromAthletes(Athlete athlete)
        {
            competition.Remove(athlete);
            messenger.Send("Athlete removed", "AthleteInfo");
        }
        public void ShowAthleteData(Athlete athlete)
        {
            athleteData.ShowData(athlete);
        }
        public void Save(string userInput)
        {
            if (userInput == null || !userInput.EndsWith(".json"))
            {
                var json = JsonSerializer.Serialize(competition);
                File.WriteAllText("Comp_040723.json", json);
                messenger.Send("Competition saved", "CompetitionInfo");
            }
            else
            {
                var json = JsonSerializer.Serialize(competition);
                File.WriteAllText($"{userInput}", json);
                messenger.Send("Competition saved", "CompetitionInfo");
            }
        }
        public void Load(ObservableCollection<Athlete> athletes)
        {
            athletes.Add(new Athlete()
            {
                Name = "Antonio Brown",
                Record = 8,
                RecordThisYear = 10,
                Permission = true,
                Association = "Butchers",
                Comp_num = "Football player",
            });
            athletes.Add(new Athlete()
            {
                Name = "Kei Nishikori",
                Record = 12,
                RecordThisYear = 8,
                Permission = false,
                Association = "The Smashers",
                Comp_num = "Tennis player",
            });
            athletes.Add(new Athlete()
            {
                Name = "Maria Sharapova",
                Record = 13,
                RecordThisYear = 12,
                Permission = true,
                Association = "Hoopsters",
                Comp_num = "Basketball player",
            });
            athletes.Add(new Athlete()
            {
                Name = "Venus Williams",
                Record = 2,
                RecordThisYear = 1,
                Permission = true,
                Association = "Hoopsters",
                Comp_num = "Swimmer",
            });
        }

    }
}
