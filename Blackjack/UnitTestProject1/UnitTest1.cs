using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ClassLibrary1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Hand hand = new Hand();
            //deck.Add(new Card() { Suits = (Suit)i, Faces = (Face)j });
            deck.deck.Add(new Card() { Suits = Suit.Heart, Faces = Face.Ace });
            deck.deck.Add(new Card() { Suits = Suit.Heart, Faces = Face.Eight });
            int Score += deck.deck.
            Assert.AreEqual(19, deck.deck.)

        }
    }
}
