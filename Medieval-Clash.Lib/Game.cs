using Medieval_Clash.Lib.UserStructure;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
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

        private Card _placedCard;
        private User _placedCardUser;
        
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

                PlaceCard(_player, _player.UserDeck[Convert.ToInt32(input)]);
                printPlacedView();

                PlaceCounter(_bot, getBotCard(_bot, TypeOfCard.Defense));
                Console.WriteLine("Bot Health: "+_bot.HealthPoints); //TODO: if health < 0, write 0 as health instead of negative numbers

                if(checkIfWon(_player, _bot))
                {
                    break;
                }
                
                _player.UserDeck.Add(_deck.DrawCard());
                _bot.UserDeck.Add(_deck.DrawCard());

                PlaceCard(_bot,getBotCard(_bot, TypeOfCard.Attack));
                printPlacedView();

                Console.WriteLine("Player Cards: \n");
                printUserCards(_player);
                Console.WriteLine("----------------");
                Console.WriteLine("Pick your Defense Card: ");
                string defenseInput = Console.ReadLine();
                PlaceCounter(_player, _player.UserDeck[Convert.ToInt32(defenseInput)]);
                Console.WriteLine("Your Health is: " + _player.HealthPoints);

                _player.UserDeck.Add(_deck.DrawCard());
                _bot.UserDeck.Add(_deck.DrawCard());

                checkIfWon(_player, _bot);
            }
        }

        public bool checkIfWon(User user1, User user2)
        {
            if (user1.HealthPoints <= 0)
            {
                Console.WriteLine(user2 + " won the game! Congrats!");
                _finished = true;
                return true;
            }
            if (user2.HealthPoints <= 0)
            {
                Console.WriteLine(user1 + " won the game! Congrats!");
                _finished = true;
                return true;
            }
            return false;
        }

        public Card getBotCard(User user, TypeOfCard typeOfCard)
        {
            // check if bot has this typeOfCard in Deck!!! -> !NullPointerException
            Card pickedCard = user.UserDeck.Where(item => item.TypeOfCard.Equals(typeOfCard)).First();
            Console.WriteLine(pickedCard);
            return pickedCard;
        }

        public void printUserCards(User user) 
        {
            int inc = 0;
            foreach (var card in user.UserDeck)
            {
                Console.WriteLine(inc + ". " + card.ToString());
                inc++;
            }
        }

        public void printPlacedView()
        {
            Console.WriteLine(_placedCard.ToString());
            Console.WriteLine(_placedCardUser.ToString());
        }


        public void LeaveGame()
        {

        }

        public void PlaceCard(User user, Card card) {
            //TODO in input das man nur attack oder special setzen kann
            user.UserDeck.Remove(card);

            if (_placedCard == null && _placedCardUser == null)
            {
                _placedCard = card;
                _placedCardUser = user;
            }
        }

        public void PlaceCounter(User user, Card card)
        {
            if (_placedCard != null && _placedCardUser != null && _placedCard.TypeOfCard.Equals(TypeOfCard.Attack))
            {
                user.UserDeck.Remove(card);
                if (_placedCard.Damage - card.Defense > 0)
                {
                    user.HealthPoints -= (_placedCard.Damage - card.Defense);
                }
            }

            _placedCard = null;
            _placedCardUser = null;
        }

        public void RemoveCard(User user, Card card) {
            user.UserDeck.Remove(card);
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
                new Card("Placeholder", "Att4", 20, TypeOfCard.Attack, 60, 0, 0),
                new Card("Placeholder", "Att5", 50, TypeOfCard.Attack, 90, 0, 0),
                new Card("Placeholder", "Att6", 20, TypeOfCard.Attack, 100, 0, 0),
                new Card("Placeholder", "Def4", 20, TypeOfCard.Defense, 0, 110, 0),
                new Card("Placeholder", "Def5", 20, TypeOfCard.Defense, 0, 140, 0),
                new Card("Placeholder", "Def6", 20, TypeOfCard.Defense, 0, 25, 0),
                new Card("Placeholder", "Att7", 20, TypeOfCard.Attack, 50, 0, 0),
                new Card("Placeholder", "Att8", 50, TypeOfCard.Attack, 40, 0, 0),
                new Card("Placeholder", "Att9", 20, TypeOfCard.Attack, 30, 0, 0),
                new Card("Placeholder", "Def7", 20, TypeOfCard.Defense, 0, 10, 0),
                new Card("Placeholder", "Def8", 20, TypeOfCard.Defense, 0, 20, 0),
                new Card("Placeholder", "Def9", 20, TypeOfCard.Defense, 0, 30, 0),
                new Card("Placeholder", "Att10", 20, TypeOfCard.Attack, 60, 0, 0),
                new Card("Placeholder", "Att11", 50, TypeOfCard.Attack, 90, 0, 0),
                new Card("Placeholder", "Att12", 20, TypeOfCard.Attack, 100, 0, 0),
                new Card("Placeholder", "Def10", 20, TypeOfCard.Defense, 0, 110, 0),
                new Card("Placeholder", "Def11", 20, TypeOfCard.Defense, 0, 140, 0),
                new Card("Placeholder", "Def12", 20, TypeOfCard.Defense, 0, 25, 0)/*,
                new Card("Placeholder", "Spe5", 20, TypeOfCard.Special, 0, 0, 20),
                new Card("Placeholder", "Spe6", 20, TypeOfCard.Special, 0, 0, 20),
                new Card("Placeholder", "Spe7", 20, TypeOfCard.Special, 0, 0, 20),
                new Card("Placeholder", "Spe8", 20, TypeOfCard.Special, 0, 0, 20),
                new Card("Placeholder", "Spe1", 20, TypeOfCard.Special, 0, 0, 20),
                new Card("Placeholder", "Spe2", 20, TypeOfCard.Special, 0, 0, 20),
                new Card("Placeholder", "Spe3", 20, TypeOfCard.Special, 0, 0, 20),
                new Card("Placeholder", "Spe4", 20, TypeOfCard.Special, 0, 0, 20)*/
            };

            return deck;
        }
    }
}
