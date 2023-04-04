﻿using Microsoft.Toolkit.Mvvm.Messaging;
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
