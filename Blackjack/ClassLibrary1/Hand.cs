using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Hand
    {
        List<Card> cards = new List<Card>();
        int score = 0;
        public int handCount = 0;
        int value = 0;
        public Hand()
        {
            Card[] hands = new Card[5];
            Card[] dealerhand = new Card[5];
        }
        Deck deck = new Deck();
        public Card Draw()
        {
            if (cards.Count <= 0)
            {
                deck.newdeck();
                deck.shuffle();
            }

            Card cardreturn = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);
            return cardreturn;
        }

        //public void AddCard(Card newcard)
        //{
        //    for (int i = 0; i < hands.Length; i++)
        //    {
        //        if (hands[i] == null)
        //        {
        //            hands[i] = newcard;
        //            score += value;
        //            handCount++;
        //            //Console.WriteLine(newcard.Display(hands[i]));
        //            break;
        //        }
        //        else if (hands[i] == newcard)
        //        {
        //            //handCount++;
        //            break;
        //        }
        //    }
        //    for (int i = 0; i < hands.Length; i++)
        //    {
        //        if (newcard.Faces == Face.Ace)
        //        {
        //            if (score + 11 > 21)
        //            {
        //                newcard.Values = 1;
        //            }
        //        }
        //    }
        //}
    }
}
