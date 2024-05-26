using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medieval_Clash.Lib
{
    public class GameManager
    {
        private GameManager _gameManager;

        public GameManager(GameManager gameManager) 
        {
            _gameManager = gameManager; 
        }

        public GameManager GetGameManager() { return _gameManager; }

        
    }
}
