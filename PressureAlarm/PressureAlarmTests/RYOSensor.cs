using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PressureAlarm;

namespace PressureAlarmTests
{
    public class RYOSensor : ISensor
    {
        double TirePressure;

        public double TirePressure1 { get => TirePressure; set => TirePressure = value; }

        double ISensor.QueryHardwareForPsiValue()
        {
            return TirePressure;
        }
    }
}
