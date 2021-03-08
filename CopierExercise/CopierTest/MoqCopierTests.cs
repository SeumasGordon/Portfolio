using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CopierExercise;

namespace CopierTest
{
    [TestClass]
    public class MoqCopierTests
    {
        [TestMethod]
        public void CopierCopyEmptyString()
        {
            int counter = 0;
            string sourceString = "\n";
            string destinationString = string.Empty;
            //
            Mock<ISource> source = new Mock<ISource>();
            Mock<IDestination> destination = new Mock<IDestination>();
            Copier copier = new Copier(destination.Object, source.Object);


            source.Setup(x => x.GetChar()).Returns(() => sourceString[counter++]).Callback(() => counter++);

            destination.Setup(x => x.SetChar(It.IsAny<char>())).Callback((char c) => destinationString += c);
            //
            copier.Copy();
            //
            Assert.AreEqual("", destinationString);
        }

        [TestMethod]
        public void CopierSingleCharString()
        {
            int counter = 0;
            string sourceString = "A\n";
            string destinationString = "";
            //
            Mock<ISource> source = new Mock<ISource>();
            Mock<IDestination> destination = new Mock<IDestination>();
            Copier copier = new Copier(destination.Object, source.Object);


            source.Setup(x => x.GetChar())
                .Returns(() => sourceString[counter])
                .Callback(() => counter++);

            destination.Setup(x => x.SetChar(It.IsAny<char>())).Callback((char c) => destinationString += c);
            //
            copier.Copy();
            //
            Assert.AreEqual("A", destinationString);
        }

        [TestMethod]
        public void CopierDoubleCharString()
        {
            int counter = 0;
            string sourceString = "AB\n";
            string destinationString = "";
            //
            Mock<ISource> source = new Mock<ISource>();
            Mock<IDestination> destination = new Mock<IDestination>();
            Copier copier = new Copier(destination.Object, source.Object);


            source.Setup(x => x.GetChar())
                .Returns(() => sourceString[counter])
                .Callback(() => counter++);

            destination.Setup(x => x.SetChar(It.IsAny<char>())).Callback((char c) => destinationString += c);
            //
            copier.Copy();
            //
            Assert.AreEqual("AB", destinationString);
        }

        [TestMethod]
        public void CopierTrippleCharString()
        {
            int counter = 0;
            string sourceString = "ABC\n";
            string destinationString = "";
            //
            Mock<ISource> source = new Mock<ISource>();
            Mock<IDestination> destination = new Mock<IDestination>();
            Copier copier = new Copier(destination.Object, source.Object);


            source.Setup(x => x.GetChar())
                .Returns(() => sourceString[counter])
                .Callback(() => counter++);

            destination.Setup(x => x.SetChar(It.IsAny<char>())).Callback((char c) => destinationString += c);
            //
            copier.Copy();
            //
            Assert.AreEqual("ABC", destinationString);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void NegativeCopiernewlinemissing()
        {
            int counter = 0;
            string sourceString = "ABC";
            string destinationString = "";
            //
            Mock<ISource> source = new Mock<ISource>();
            Mock<IDestination> destination = new Mock<IDestination>();
            Copier copier = new Copier(destination.Object, source.Object);


            source.Setup(x => x.GetChar())
                .Returns(() => sourceString[counter])
                .Callback(() => counter++);

            destination.Setup(x => x.SetChar(It.IsAny<char>())).Callback((char c) => destinationString += c);
            //
            copier.Copy();
            //
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void NegativeCopiersoucenull()
        {
            int counter = 0;
            string sourceString = null;
            string destinationString = "";
            //
            Mock<ISource> source = null;
            Mock<IDestination> destination = new Mock<IDestination>();
            Copier copier = new Copier(destination.Object, source.Object);


            source.Setup(x => x.GetChar())
                .Returns(() => sourceString[counter])
                .Callback(() => counter++);

            destination.Setup(x => x.SetChar(It.IsAny<char>())).Callback((char c) => destinationString += c);
            //
            copier.Copy();
            //
            Assert.AreEqual("ABC", destinationString);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void NegativeCopierDestinationNull()
        {
            int counter = 0;
            string sourceString = "ABC\n";
            string destinationString = null;
            //
            Mock<ISource> source = new Mock<ISource>();
            Mock<IDestination> destination = null;
            Copier copier = new Copier(destination.Object, source.Object);


            source.Setup(x => x.GetChar())
                .Returns(() => sourceString[counter])
                .Callback(() => counter++);

            destination.Setup(x => x.SetChar(It.IsAny<char>()))
                .Callback((char c) => destinationString += c);
            //
            copier.Copy();
            //
            //Assert.AreEqual("ABC", destinationString);
        }

        [TestMethod]
        public void CopierCallsSourceGetChar()
        {
            int counter = 0;
            string sourceString = "A\n";
            string destinationString = "";
            //
            Mock<ISource> source = new Mock<ISource>();
            Mock<IDestination> destination = new Mock<IDestination>();
            Copier copier = new Copier(destination.Object, source.Object);


            source.Setup(x => x.GetChar())
                .Returns(() => sourceString[counter])
                .Callback(() => counter++);

            destination.Setup(x => x.SetChar(It.IsAny<char>()))
                .Callback((char c) => destinationString += c);
            //
            copier.Copy();
            //
            source.Verify(s => s.GetChar(), Times.AtLeastOnce());
        }

        [TestMethod]
        public void CopierCallsDestinationSetChar()
        {
            int counter = 0;
            string sourceString = "A\n";
            string destinationString = "";
            //
            Mock<ISource> source = new Mock<ISource>();
            Mock<IDestination> destination = new Mock<IDestination>();
            Copier copier = new Copier(destination.Object, source.Object);


            source.Setup(x => x.GetChar())
                .Returns(() => sourceString[counter])
                .Callback(() => counter++);

            destination.Setup(x => x.SetChar(It.IsAny<char>()))
                .Callback((char c) => destinationString += c);
            //
            copier.Copy();
            //
            destination.Verify(s => s.SetChar(It.IsAny<char>()), Times.AtLeastOnce());
        }
    }
}
