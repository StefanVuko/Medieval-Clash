using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medieval_Clash.Lib.User
{
    enum Difficulty
    {
        Easy,
        Normal,
        Hard,
    }
    internal class Bot : User
    {
        
        private Difficulty _difficulty;
        public Bot(string name, int rating, int healthPoints, int manaPoints, int money, Difficulty difficulty) : base(name, rating, healthPoints, manaPoints, money)
        {
            _difficulty = difficulty;
        }
    }
}
