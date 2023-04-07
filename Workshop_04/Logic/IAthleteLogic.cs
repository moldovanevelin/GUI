using System.Collections.Generic;
using System.Collections.ObjectModel;
using SZTGUI_GYAK04.Models;

namespace SZTGUI_GYAK04.Logic
{
    public interface IAthleteLogic
    {
        void AddToAthletes(Athlete Athlete);
        void RemoveFromAthletes(Athlete Athlete);
        void Load(ObservableCollection<Athlete> Athletes);
        void SetupCollections(IList<Athlete> athletes, IList<Athlete> competition, JsonFileName userInput);
        void ShowAthleteData(Athlete athlete);
        void Save(string userInput);
    }
}