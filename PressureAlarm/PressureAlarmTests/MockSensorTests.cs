using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PressureAlarm;

namespace PressureAlarmTests
{
    [TestClass]
    public class MockSensorTests
    {
        [TestMethod]
        public void PressureToHigh()
        {
            //
            Mock<ISensor> mock = new Mock<ISensor>();
            mock.Setup(sensor => sensor.QueryHardwareForPsiValue()).Returns(100);
            pressureAlarm PA = new pressureAlarm(mock.Object);
            //
            PA.Check();
            //
            Assert.AreEqual(true, PA.Alarm);
        }
        [TestMethod]
        public void PressureToLow()
        {
            //
            Mock<ISensor> mock = new Mock<ISensor>();
            mock.Setup(sensor => sensor.QueryHardwareForPsiValue()).Returns(0);
            pressureAlarm PA = new pressureAlarm(mock.Object);
            //
            PA.Check();
            //
            Assert.AreEqual(true, PA.Alarm);
        }
        [TestMethod]
        public void PressureJustRight()
        {
            //
            Mock<ISensor> mock = new Mock<ISensor>();
            mock.Setup(sensor => sensor.QueryHardwareForPsiValue()).Returns(30);
            pressureAlarm PA = new pressureAlarm(mock.Object);
            //
            PA.Check();
            //
            Assert.AreEqual(false, PA.Alarm);
        }
    }
}
