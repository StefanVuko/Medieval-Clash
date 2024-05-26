using Medieval_Clash.Lib;

Card card = new Card("Placeholder", "Att1", 20, TypeOfCard.Attack, 50, 0, 0);

Card card2 = new Card("Placeholder", "Def1", 50, TypeOfCard.Defense, 0, 20, 0);

Card card3 = new Card("Placeholder", "Spe1", 20, TypeOfCard.Special, 0, 0, 20);

List<Card> deck = new List<Card>();
deck.Add(card);
deck.Add(card2);
deck.Add(card3);

GameDeck gameDeck = new GameDeck(deck);
Console.WriteLine("Normal Gamedeck");
Console.WriteLine(gameDeck.ToString());
Console.WriteLine("-----------------------");
gameDeck.Shuffle();

Console.WriteLine("After Shuffle");
Console.WriteLine(gameDeck.ToString());
Console.WriteLine("-----------------------");
Console.WriteLine("Drawing a card, card on top of the deck");
Console.WriteLine(gameDeck.DrawCard());