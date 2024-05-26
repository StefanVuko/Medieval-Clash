using Medieval_Clash.Lib.UserStructure;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;


namespace Medieval_Clash.Lib
{
    public class Game
    {
        private string _gameName;
        private GameDeck _deck;
        private Boolean _finished;
        
        private Player _player;
        private Bot _bot;
        
        public Game(string gameName, Player player, Bot bot)
        {
            _gameName = gameName;
            _finished = false;
            _player = player;
            _bot = bot;
        }

        public void PlayGame()
        {
            _deck = new GameDeck(assignCards());
            _deck.Shuffle();

            for (int i = 0; i < 5; i++)
            {
                _player.UserDeck.Add(_deck.DrawCard());
                _bot.UserDeck.Add(_deck.DrawCard());
            }
   
            while (!_finished)
            {
                Console.WriteLine("Player Cards: \n");
                printUserCards(_player);
                Console.WriteLine("----------------");
                Console.WriteLine("\nBot Cards: ");
                printUserCards(_bot);

                Console.WriteLine("Pick your Card: ");
                string input = Console.ReadLine();
                Console.WriteLine("Your Card is:\n" + _player.UserDeck[Convert.ToInt32(input)].ToString());

                _finished = true;
            }
        }

        public void printUserCards(User user) 
        {
            int inc = 1;
            foreach (var card in user.UserDeck)
            {
                Console.WriteLine(inc + ". " + card.ToString());
                inc++;
            }
        }

        public void LeaveGame()
        {

        }

        public void PlaceCard(User user, Card card) { 

        }

        public void RemoveCard(User user, Card card) {
        
        }

        private List<Card> assignCards()
        {
            List<Card> deck = new List<Card>
            {
                new Card("Placeholder", "Att1", 20, TypeOfCard.Attack, 50, 0, 0),
                new Card("Placeholder", "Att2", 50, TypeOfCard.Attack, 40, 0, 0),
                new Card("Placeholder", "Att3", 20, TypeOfCard.Attack, 30, 0, 0),
                new Card("Placeholder", "Def1", 20, TypeOfCard.Defense, 0, 10, 0),
                new Card("Placeholder", "Def2", 20, TypeOfCard.Defense, 0, 20, 0),
                new Card("Placeholder", "Def3", 20, TypeOfCard.Defense, 0, 30, 0),
                new Card("Placeholder", "Spe1", 20, TypeOfCard.Special, 0, 0, 20),
                new Card("Placeholder", "Spe2", 20, TypeOfCard.Special, 0, 0, 20),
                new Card("Placeholder", "Spe3", 20, TypeOfCard.Special, 0, 0, 20),
                new Card("Placeholder", "Spe4", 20, TypeOfCard.Special, 0, 0, 20)
            };

            return deck;
        }
    }
}
