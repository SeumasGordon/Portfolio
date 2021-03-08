using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace Blackjack
{
    class Program
    {
        static Deck deck;
        static Hand hand;
        static List<Card> PlayerHand;
        static List<Card> DealerHand;
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("Welcome to BlackJack.");
                
                int menuchoice = 0;
                string[] mainmenu = new string[] { "1. Play Blackjack", "2. Shuffle and Show Deck", "3. Exit" };
                ReadChoice("Choice:  ", mainmenu, out menuchoice);
                if (menuchoice == 1) // Play Blackjack
                {
                    deck = new Deck();
                    PlayerHand = new List<Card>();
                    DealerHand = new List<Card>();
                    hand = new Hand();
                    deck.shuffle();
                    deck.shuffle();
                    Console.Clear();

                    while (true)
                    {
                        Deal();
                        break;
                    }

                    //Console.Clear();
                    //for (int i = 0; i < 2; i++)
                    //{
                    //    hand.AddCard(deck2.deck[i]);
                    //    hand.AddCardDealer(deck2.deck[i + 2]);
                    //}

                }
                else if (menuchoice == 2) // Shuffle Cards and show deck
                {
                    Console.Clear();
                    deck = new Deck();
                    hand = new Hand();
                    deck.shuffle();
                    Console.Clear();
                    deck.shuffle();
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (menuchoice == 3) // Exit
                {
                    break;
                    //System.Environment.Exit(1);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You did not enter a valid selection.");
                    Console.ReadKey();
                }
            }
        }
        static int ReadInteger(string prompt) // Show the prompt, read input, return integer.
        {
            int ans = 0;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out ans) == false)
                {
                    Console.WriteLine("That is not an integer. Please try again.");
                }
                else
                {
                    break;
                }

            }
            return ans;
        }
        static void ReadChoice(string prompt, string[] options, out int selection)
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine(options[i]);
            }
            while (true)
            {
                selection = ReadInteger(prompt);
                break;
            }

        }
        static void Deal()
        {
            deck.newdeck();
            deck.shuffle();
            Reset();
            Console.Clear();
            if (deck.RemainingCards() < 20)
            {
                deck.newdeck();
            }
            Console.WriteLine("Remaining cards: " + deck.RemainingCards());
            Console.WriteLine();
            PlayerHand.Add(deck.Draw());
            PlayerHand.Add(deck.Draw());

            foreach (Card card in PlayerHand)
            {
                
                if (card.Faces == Face.Ace)
                {
                    if (card.Values <= 10)
                    {

                        card.Values += 10;
                    }
                 
                }
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Player :");
            Console.ResetColor();
            Display(PlayerHand[0]);
            Display(PlayerHand[1]);
            Console.WriteLine("Score: {0}", PlayerHand[0].Values + PlayerHand[1].Values );
            Console.WriteLine();
            DealerHand.Add(deck.Draw());
            DealerHand.Add(deck.Draw());
            foreach (Card card in DealerHand)
            {
                if (card.Faces == Face.Ace)
                {
                    if (card.Values <= 10)
                    {

                        card.Values += 10;
                    }


                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Dealer :");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Face Suit ?");
            Console.ResetColor();
            Display(DealerHand[1]);
            Console.WriteLine("Score: {0}", DealerHand[1].Values);
            Console.WriteLine();

            if (DealerHand[0].Values + DealerHand[1].Values == 21)
            {
                Console.WriteLine("Dealer has black Jack! ");

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Dealer doesn't have Blackjack.");
            }

            if (PlayerHand[0].Values + PlayerHand[1].Values == 21)
            {
                Console.WriteLine("Blackjack!!");
                
                Console.ReadKey();
            }

            do
            {
                string[] mainmenu = new string[] { "1. Stand", "2. Hit" };
                int menuchoice = 0;
                ReadChoice("Choice:  ", mainmenu, out menuchoice);
                if (menuchoice == 1) // Stand
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Dealer :");
                    Console.ResetColor();
                    Display(DealerHand[0]);
                    Display(DealerHand[1]);
                    //Console.BackgroundColor = ConsoleColor.White;
                    //Console.ForegroundColor = ConsoleColor.Black;
                    //Console.WriteLine("Face Suit ?");
                    //Console.ResetColor();
                    Console.WriteLine("Score: {0}", DealerHand[0].Values + DealerHand[1].Values);
                    Console.WriteLine();

                    int crdval = 0;
                    foreach (Card card in DealerHand)
                    {
                        crdval += card.Values;
                    }

                    while (crdval < 17)
                    {
                        DealerHand.Add(deck.Draw());
                        crdval = 0;
                        foreach (Card card in DealerHand)
                        {
                            crdval += card.Values;
                        }
                        Display(DealerHand[DealerHand.Count - 1]);
                    }
                    crdval = 0;
                    foreach (Card card in DealerHand)
                    {
                        crdval += card.Values;
                    }
                    Console.WriteLine("Dealer Score : " + crdval);

                    if (crdval > 21)
                    {
                        Console.WriteLine("Dealer Busted. You Won.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        int crdval2 = 0;
                        foreach (Card card in PlayerHand)
                        {
                            crdval2 += card.Values;
                        }

                        if (crdval > crdval2)
                        {
                            Console.WriteLine("Dealer Won with " + crdval + " you had " + crdval2);
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Player Won with " + crdval2 + " Dealer had " + crdval);
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    break;
                }
                if (menuchoice == 2) // Hit
                {
                    //Console.Clear();
                    PlayerHand.Add(deck.Draw());
                    Display(PlayerHand[PlayerHand.Count - 1]);
                    //Console.WriteLine("Hit " + PlayerHand[PlayerHand.Count - 1].Faces + " of " + PlayerHand[PlayerHand.Count - 1].Suits);
                    int cardVale = 0;
                    foreach (Card card in PlayerHand)
                    {
                        cardVale += card.Values;
                    }
                    Console.WriteLine("New Score " + cardVale);
                    if (cardVale > 21)
                    {
                        Console.WriteLine("You Busted.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                    else if (cardVale == 21)
                    {
                        Console.WriteLine("Stand");
                    }
                }
                    //Console.ReadKey();
            }
            while (true);
            
        }
        static void Display(Card newcard)
        {
            if (newcard.Suits == Suit.Heart)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{newcard.Faces}  ♥ " + newcard.Values);
                Console.ResetColor();
            }
            else if (newcard.Suits == Suit.Diamond)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{newcard.Faces}  ♦  " + newcard.Values);
                Console.ResetColor();
            }
            else if (newcard.Suits == Suit.Spade)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"{newcard.Faces}  ♠  " + newcard.Values);
                Console.ResetColor();
            }
            else if (newcard.Suits == Suit.Club)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"{newcard.Faces}  ♣ " + newcard.Values);
                Console.ResetColor();
            }
        }
        //static string HandDisplay(Card Hand)
        //{
        //    foreach (var card in PlayerHand)
        //    {

        //    }
        //}
        static void Reset()
        {
            foreach (Card card in DealerHand)
            {
                int i = 0;
                DealerHand[i].Values = 0;
            }
            foreach (Card card in PlayerHand)
            {
                int i = 0;
                PlayerHand[i].Values = 0;
            }


        }
    }
}
