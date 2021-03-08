using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressureAlarm;

namespace PressureAlarmTests
{
    [TestClass]
    public class pressureAlarmTests
    {
        [TestMethod]
        public void PressureToHigh()
        {
            //
            RYOSensor sensor = new RYOSensor();
            sensor.TirePressure1 = 100;
            pressureAlarm PA = new pressureAlarm(sensor);
            //
            PA.Check();
            //
            Assert.AreEqual(true, PA.Alarm);
        }
        [TestMethod]
        public void CheckPressureToLow()
        {
            //
            RYOSensor sensor = new RYOSensor();
            sensor.TirePressure1 = 0;
            pressureAlarm PA = new pressureAlarm(sensor);
            
            //
            PA.Check();
            //
            Assert.AreEqual(true, PA.Alarm);
        }
        [TestMethod]
        public void CheckPressureIsGood()
        {
            //
            RYOSensor sensor = new RYOSensor();
            sensor.TirePressure1 = 30;
            pressureAlarm PA = new pressureAlarm(sensor);
            //
            PA.Check();
            //
            Assert.AreEqual(false, PA.Alarm);
        }
    }
}
