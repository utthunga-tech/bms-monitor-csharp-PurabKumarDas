using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CustomExtenion1
{
    public static class WarningExtension
    {
        public static bool BatteryWarnings(this bool WarnBatter, float temperature, float soc, float chargeRate, Checker.Program.TemperatureUnit unitOfTemperature)
        {
            if (unitOfTemperature == Checker.Program.TemperatureUnit.Farenheit)
            {
                temperature = (float)((temperature - 32) / 1.8);
                chargeRate = (float)((chargeRate - 32) / 1.8);
                soc = (float)((soc - 32) / 1.8);
            }

            #region SOC Check
            if (soc >= 20 && soc <= 20 + 4)
            {

                Console.WriteLine(checker.Properties.Resources.SOCWarning.Replace("[replace]","SOC"));
                return false;
            }

            else if (soc >= 80 - 4 && soc <= 80)
            {

                Console.WriteLine(checker.Properties.Resources.SOCWarning2.Replace("[replace]", "SOC"));
                return false;
            }
            #endregion

            #region Temperature check
            if (temperature >= 0 && temperature <= ((5 * 45) / 100))
            {
                Console.WriteLine(checker.Properties.Resources.SOCWarning.Replace("[replace]", "Temperature"));
                return false;
            }
            else if (soc >= 80 - 2.25 && soc <= 80)
            {

                Console.WriteLine(checker.Properties.Resources.SOCWarning2.Replace("[replace]", "Temperature"));
                return false;
            }
            #endregion

            #region ChargeRate check
            if (chargeRate >= 0 && chargeRate <= 0.8 + 0.04)
            {
                Console.WriteLine(checker.Properties.Resources.SOCWarning.Replace("[replace]", "Charge Rate"));
                return false;
            }
            else if (soc >= 0.8 - 0.04 && soc <= 0.8)
            {
                Console.WriteLine(checker.Properties.Resources.SOCWarning2.Replace("[replace]", "Charge Rate"));
                return false;
            }
            #endregion

            return true;
        }
    }
}
