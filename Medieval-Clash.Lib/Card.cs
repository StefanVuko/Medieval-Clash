using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medieval_Clash.Lib
{
    public class Card
    {
        private string _imageFileName;
        private string _name;
        private int _price;
        private TypeOfCard _typeOfCard;
        private int _damage;
        private int _defense;
        private int _manaPoints;

        public Card(string imageFileName, string name, int price, TypeOfCard typeOfCard, int damage, int defense, int manaPoints)
        {
            _imageFileName = imageFileName;
            _name = name;
            _price = price;
            _typeOfCard = typeOfCard;
            _damage = damage;
            _defense = defense;
            _manaPoints = manaPoints;
        }

        public string ImageFileName { get => _imageFileName; set => _imageFileName = value; }
        public string Name { get => _name; set => _name = value; }
        public int Price { get => _price; set => _price = value; }
        public TypeOfCard TypeOfCard { get => _typeOfCard; set => _typeOfCard = value; }
        public int Damage { get => _damage; set => _damage = value; }
        public int Defense { get => _defense; set => _defense = value; }
        public int ManaPoints { get => _manaPoints; set => _manaPoints = value; }

        public override string ToString()
        {
            return "Name: " + _name + "\nPrice: " + _price + "\nType of Card: " + _typeOfCard.ToString() + "\nDamage: " + _damage + "\nDefense: " + _defense + "\nMana Points: " + _manaPoints + "\n";
        }
    }
}
