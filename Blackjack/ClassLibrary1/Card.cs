using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public enum Suit
    {
        Heart,
        Diamond,
        Spade,
        Club
    }

    public enum Face
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
    }
    public class Card
     {

        public Face Faces { get; set; }
        public Suit Suits { get; set; }
        public int Values { get; set; }

        //public Card(string suit, string face, int value)
        //{
        //    Suits = suit;
        //    Faces = face;
        //    Values = value;
        //}
        
     }
}
