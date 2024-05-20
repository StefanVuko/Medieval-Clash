using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medieval_Clash.Lib.User
{
    internal class User
    {
       private string Name { get; set; }
       private int Rating{ get; set; }
   
        private int HealthPoints { get; set; }
        private int ManaPoints { get; set; }
        private int Money { get; set; }
        private List<Object> UserDeck { get; set; }

        public User(string name, int rating, int healthPoints, int manaPoints, int money ) {
            Name = name;
            Rating = rating;
            HealthPoints = healthPoints;
            ManaPoints = manaPoints;
            Money = money;
        }
    }
    //ToDo: fragen wegen userinfo, was wollen wir da exactly?
}
