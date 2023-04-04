using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZTGUI_GYAK04
{
    public class AthleteLogic : IAthleteLogic
    {

        IList<Athlete> athletes;
        IList<Athlete> competition;
        IMessenger messenger;
        public AthleteLogic(IMessenger messenger)
        {
            this.messenger = messenger;
        }

        public void SetupCollections(IList<Athlete> athletes, IList<Athlete> competition)
        {
            this.athletes = athletes;
            this.competition = competition;
        }

        public void AddToAthletes(Athlete Athlete)
        {
            competition.Add(Athlete.GetCopy());
            messenger.Send("Athlete added", "AthleteInfo");
        }

        public void RemoveFromAthletes(Athlete Athlete)
        {
            competition.Remove(Athlete);
            messenger.Send("Athlete removed", "AthleteInfo");
        }
        public void Load(ObservableCollection<Athlete> athletes)
        {
            athletes.Add(new Athlete()
            {
                Name = "Józsi",
                Record = 8,
                RecordThisYear = 10,
                Permission = true,
                Association = "Wild Horses",
                Comp_num = "Kislabda hajítás",
            });
            athletes.Add(new Athlete()
            {
                Name = "Sanyi",
                Record = 8,
                RecordThisYear = 10,
                Permission = false,
                Association = "ASDFGH",
                Comp_num = "Ksdfghjk",
            });
            athletes.Add(new Athlete()
            {
                Name = "Kati",
                Record = 8,
                RecordThisYear = 10,
                Permission = true,
                Association = "sdf",
                Comp_num = "sdfghj",
            });
            athletes.Add(new Athlete()
            {
                Name = "Ibolya",
                Record = 8,
                RecordThisYear = 10,
                Permission = true,
                Association = "wrfghd",
                Comp_num = "jtrktzj2",
            });
        }

    }
}
