using System;

namespace Checker
{
    class Program
    {
        static bool batteryIsOk(float temperature, float soc, float chargeRate)
        {
            if (temperature < 0 || temperature > 45)
            {
                Console.WriteLine("Temperature is out of range!");
                return false;
            }
            else if (soc < 20 || soc > 80)
            {
                Console.WriteLine("State of Charge is out of range!");
                return false;
            }
            else if (chargeRate > 0.8)
            {
                Console.WriteLine("Charge Rate is out of range!");
                return false;
            }
            return true;
        }

        static void ExpectStatus(bool expression)
        {
            if (!expression)
            {
                Console.WriteLine("Expected true, but got false");
                Environment.Exit(1);
            }
            else if (expression)
            {
                Console.WriteLine("Expected false, but got true");
                Environment.Exit(1);
            }

        }
   
        static int Main(string[] args)
        {
            Func<float,float,float,bool> batteryCheckFunc = new Func<float, float, float, bool>(batteryIsOk);
            Action<bool> checkStatusFun = new Action<bool>(ExpectStatus);

            checkStatusFun(batteryCheckFunc(25, 70, 0.7f));
            checkStatusFun(batteryCheckFunc(50, 85, 0.0f));
          
            Console.WriteLine("All ok");
            return 0;
        }
    }
}
