using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Deck
    {
        
        public List<Card> deck;
        public Deck()
        {
            newdeck();
        }
        public void newdeck()
        {
            deck = new List<Card>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    deck.Add(new Card() { Suits = (Suit)i, Faces = (Face)j });//sets value to cards
                    if (j <= 8)
                    {
                        deck[deck.Count - 1].Values = j + 1;

                    }
                    else
                    {
                        deck[deck.Count - 1].Values = 10;
                    }
                }
            }
        }

        
        public void shuffle()
        {
            Random Rng = new Random();
            for (int i = 0; i < deck.Count; i++)
            {
                int c1 = Rng.Next(0, 52);
                int c2 = Rng.Next(0, 52);

                Card card = deck[c1];
                deck[c1] = deck[c2];
                deck[c2] = card;

                PrintDeck(deck[i]);

                //dck += $"{deck[i].Suits}\t of {deck[i].Faces}  \t  value of {deck[i].Values} \n";

            }
            //Console.WriteLine(dck);

        }
        
        public Card Draw()
        {
            if(deck.Count <= 0)
            {
                this.newdeck();
                this.shuffle();
            }

            Card cardreturn = deck[deck.Count - 1];
            deck.RemoveAt(deck.Count - 1);
            return cardreturn;
        }

        public void PrintDeck(Card newcard)
        {
            int i = 0;
            //foreach (Card card in deck)
            //{
                if (newcard.Suits == Suit.Heart)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{newcard.Faces}  \t♥");
                    Console.ResetColor();
                }
                else if (newcard.Suits == Suit.Diamond)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{newcard.Faces}  \t♦");
                    Console.ResetColor();
                }
                else if (newcard.Suits == Suit.Spade)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"{newcard.Faces}  \t♠");
                    Console.ResetColor();
                }
                else if (newcard.Suits == Suit.Club)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"{newcard.Faces}  \t♣");
                    Console.ResetColor();
                }
                i++;
            //}
        }
        public int RemainingCards()
        {
            return deck.Count;
        }

    }
}
