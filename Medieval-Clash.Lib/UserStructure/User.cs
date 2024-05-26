﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medieval_Clash.Lib.UserStructure
{
    public class User
    {
       public string Name { get; set; }
       public int Rating{ get; set; }

       public int HealthPoints { get; set; }
       public int ManaPoints { get; set; }
       public int Money { get; set; }
       public List<Card> UserDeck { get; set; }

       public User(string name, int rating, int healthPoints, int manaPoints, int money ) {
            Name = name;
            Rating = rating;
            HealthPoints = healthPoints;
            ManaPoints = manaPoints;
            Money = money;
            UserDeck = new List<Card>();
       }


    }
    //ToDo: fragen wegen userinfo, was wollen wir da exactly?
}
