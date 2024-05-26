using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medieval_Clash.Lib.UserStructure
{
    public class Bot : User
    {
        private Difficulty _difficulty;
        
        public Bot(string name, int rating, int healthPoints, int manaPoints, int money, Difficulty difficulty) : base(name, rating, healthPoints, manaPoints, money)
        {
            _difficulty = difficulty;
        }
    }
}
