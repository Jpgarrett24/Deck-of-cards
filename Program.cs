using System;
using System.Collections.Generic;

namespace DeckOfCards
{

    class Card
    {
        private string stringVal;
        private string suit;
        private int val;

        public string StringVal
        {
            get { return stringVal; }
            set { stringVal = value; }
        }
        public string Suit
        {
            get { return suit; }
            set { suit = value; }
        }
        public int Val
        {
            get { return val; }
            set { val = value; }
        }

        public Card(string name, string type, int num)
        {
            stringVal = name;
            suit = type;
            val = num;
        }
    }
    class Deck
    {
        string[] DeckStringValues = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
        string[] DeckSuits = { "Diamonds", "Hearts", "Clubs", "Spades" };
        int[] DeckIntValues = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
        public List<Card> cards = new List<Card>();
        private void CreateDeck()
        {
            foreach (string suit in DeckSuits)
            {
                foreach (int number in DeckIntValues)
                {
                    Card newCard = new Card(DeckStringValues[number - 1], suit, number);
                    cards.Add(newCard);
                }
            }
        }
        public Deck()
        {
            CreateDeck();
        }

        public Card Deal()
        {
            Card dealtCard = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);
            return dealtCard;
        }
        public void Reset()
        {
            cards = new List<Card>();
            CreateDeck();
        }
        public void Shuffle()
        {
            Random rnd = new Random();
            for (int i = 0; i < cards.Count; i++)
            {
                int k = rnd.Next(0, i);
                Card value = cards[k];
                cards[k] = cards[i];
                cards[i] = value;
            }
        }
    }
    class Player
    {
        string name;
        List<Card> hand = new List<Card>();

        public Player(string nombre)
        {
            Name = nombre;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public List<Card> Hand
        {
            get { return hand; }
            set { hand = value; }
        }
        public Card Draw(Deck deck)
        {
            Card newCard = deck.Deal();
            Hand.Add(newCard);
            return newCard;
        }
        public Card Discard(int location)
        {
            if (hand[location] == null) { System.Console.WriteLine("No item discard..."); return null; }
            else
            {
                Card discarded = hand[location];
                hand.RemoveAt(location);
                return discarded;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Deck Deck1 = new Deck();
            foreach (Card card in Deck1.cards)
            {
                System.Console.WriteLine($"{card.StringVal} of {card.Suit}: Number value of {card.Val}");
            }
            System.Console.WriteLine("\n");
            Deck1.Shuffle();
            foreach (Card card in Deck1.cards)
            {
                System.Console.WriteLine($"{card.StringVal} of {card.Suit}: Number value of {card.Val}");
            }
            System.Console.WriteLine("\n");
            System.Console.WriteLine(Deck1.Deal().StringVal);
            System.Console.WriteLine(Deck1.cards.Count);
            Deck1.Reset();
            System.Console.WriteLine(Deck1.cards.Count);
            Player Joe = new Player("Joe");
            System.Console.WriteLine("\n");
            Deck1.Shuffle();
            System.Console.WriteLine(Joe.Draw(Deck1).StringVal);
            System.Console.WriteLine(Joe.Hand.Count);
            System.Console.WriteLine(Joe.Discard(0).StringVal);
            System.Console.WriteLine(Joe.Hand.Count);
        }
    }
}
