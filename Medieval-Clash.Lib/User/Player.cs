using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medieval_Clash.Lib.User
{
    internal class Player : User
    {
        private string ProfilePictureFileName { get; set; }
        public Player(string name, int rating, int healthPoints, int manaPoints, int money, string profilePictureFileName) : base(name, rating, healthPoints, manaPoints, money)
        {
            ProfilePictureFileName = profilePictureFileName;
        }
    }
}
