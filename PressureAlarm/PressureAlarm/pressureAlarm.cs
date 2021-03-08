using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressureAlarm
{
    public class pressureAlarm
    {
		private const double lowPressureThreshold = 15;

		private const double highPressureThreshold = 32;


		ISensor sensor = null;


		bool alarm = false;

		public pressureAlarm(ISensor sensor)
        {
			this.sensor = sensor;
        }
		public void Check()
		{

			double pressure = sensor.QueryHardwareForPsiValue();


			if (pressure < lowPressureThreshold || highPressureThreshold < pressure)
			{

				alarm = true;

			}

		}


		public bool Alarm
		{

			get { return alarm; }

		}
	}
}
