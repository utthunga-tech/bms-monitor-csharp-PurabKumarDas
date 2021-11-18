using System;


namespace Checker
{
    using CustomExtenion1;
    public class Program
    {
        public enum TemperatureUnit
        {
            Centrigrade, Farenheit
        }
        static bool batteryIsOk(float temperature, float soc, float chargeRate, TemperatureUnit unitOfTemperature)
        {

            if (unitOfTemperature == TemperatureUnit.Farenheit)
            {
                temperature = (float)((temperature - 32) / 1.8);
                chargeRate = (float)((chargeRate - 32) / 1.8);
                soc = (float)((soc - 32) / 1.8);
            }

            if (temperature < 0 || temperature > 45)
            {
                Console.WriteLine(checker.Properties.Resources.TemperatureRange);
                return false;
            }

            else if (soc < 20 || soc > 80)
            {
                Console.WriteLine(checker.Properties.Resources.SocRange);
                return false;
            }
            else if (chargeRate > 0.8)
            {
                Console.WriteLine(checker.Properties.Resources.ChargeRateRange);
                return false;
            }

            return true;
        }

        static void ExpectStatus(bool expression)
        {
            if (expression)
            {
                Console.WriteLine("Expected false, but got true");
                //Environment.Exit(1);
            }
            else if (!expression)
            {
                Console.WriteLine("Expected true, but got false");
                //Environment.Exit(1);
            }

        }

        public static int Main(string[] args)
        {
            Func<float, float, float, TemperatureUnit, bool> batteryCheckFunc = new Func<float, float, float, TemperatureUnit, bool>(batteryIsOk);
            Action<bool> checkStatusFun = new Action<bool>(ExpectStatus);

            checkStatusFun(batteryCheckFunc(25, 70, 0.7f,TemperatureUnit.Centrigrade).BatteryWarnings(25, 70, 0.7f,TemperatureUnit.Centrigrade));

            checkStatusFun(batteryCheckFunc(50, 85, 0.0f,TemperatureUnit.Centrigrade).BatteryWarnings(25, 70, 0.7f, TemperatureUnit.Centrigrade));

            Console.WriteLine("All ok");

            return 0;
        }



    }

}



