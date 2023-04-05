using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SZTGUI_GYAK04
{
    public interface IAthleteLogic
    {
        void AddToAthletes(Athlete Athlete);
        void RemoveFromAthletes(Athlete Athlete);
        void Load(ObservableCollection<Athlete> Athletes);
        void SetupCollections(IList<Athlete> athletes, IList<Athlete> competition);
        void ShowAthleteData(Athlete athlete);
    }
}