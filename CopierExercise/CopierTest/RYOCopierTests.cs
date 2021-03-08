using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CopierExercise;

namespace CopierTest
{
    [TestClass]
    public class RYOCopierTests
    {
        [TestMethod]
        public void CopierCopiesEmptyString()
        {
            //
            RYODestination d = new RYODestination();
            RYOSource s = new RYOSource();
            Copier copier = new Copier(d, s);
            ((RYOSource)copier.Source).SourceString = "\n";
            //
            copier.Copy();
            //
            Assert.AreEqual("", ((RYODestination)copier.Destination).DestinationString);
        }

        [TestMethod]
        public void CopierCopiesSingleCharString()
        {
            //
            RYODestination d = new RYODestination();
            RYOSource s = new RYOSource();
            Copier copier = new Copier(d, s);
            ((RYOSource)copier.Source).SourceString = "A\n";
            //
            copier.Copy();
            //
            Assert.AreEqual("A", ((RYODestination)copier.Destination).DestinationString);
        }

        [TestMethod]
        public void CopierCopiesDoubleCharString()
        {
            //
            RYODestination d = new RYODestination();
            RYOSource s = new RYOSource();
            Copier copier = new Copier(d, s);
            ((RYOSource)copier.Source).SourceString = "AB\n";
            //
            copier.Copy();
            //
            Assert.AreEqual("AB", ((RYODestination)copier.Destination).DestinationString);
        }

        [TestMethod]
        public void CopierCopiesTripleCharString()
        {
            //
            RYODestination d = new RYODestination();
            RYOSource s = new RYOSource();
            Copier copier = new Copier(d, s);
            ((RYOSource)copier.Source).SourceString = "ABC\n";
            //
            copier.Copy();
            //
            Assert.AreEqual("ABC", ((RYODestination)copier.Destination).DestinationString);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void NegativeCopierNoNewLine()
        {
            //
            RYODestination d = new RYODestination();
            RYOSource s = new RYOSource();
            Copier copier = new Copier(d, s);
            ((RYOSource)copier.Source).SourceString = "ABC";
            //
            copier.Copy();
            //
            //Assert.AreEqual("ABC", ((RYODestination)copier.Destination).DestinationString);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void NegativeCopierSourceNull()
        {
            //
            RYODestination d = new RYODestination();
            RYOSource s = null;
            Copier copier = new Copier(d, s);
            ((RYOSource)copier.Source).SourceString = "ABC\n";
            //
            copier.Copy();
            //
            //Assert.AreEqual("ABC", ((RYODestination)copier.Destination).DestinationString);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void NegativeCopierDestinationNull()
        {
            //
            RYODestination d = null;
            RYOSource s = new RYOSource();
            Copier copier = new Copier(d, s);
            ((RYOSource)copier.Source).SourceString = "ABC\n";
            //
            copier.Copy();
            //
            //Assert.AreEqual("ABC", ((RYODestination)copier.Destination).DestinationString);
        }
    }
}
