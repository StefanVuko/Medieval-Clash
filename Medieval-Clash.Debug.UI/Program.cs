using Medieval_Clash.Lib;
using Medieval_Clash.Lib.UserStructure;


Player p1 = new Player("stixy",2000,40,20,40,String.Empty);
Bot b1 = new Bot("minz",1999,40,20,40,Difficulty.Normal);

Game _game = new Game("Game 1", p1, b1);

_game.PlayGame();

