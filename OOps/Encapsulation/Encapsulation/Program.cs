using System;

namespace Encapsulation
{
    class Encapsulation
    {
        private int atmPin;
        public int getreturn()
        {
            return atmPin;

        }
        public void setValue(int pin)
        {
            atmPin = pin;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Encapsulation e = new Encapsulation();
            e.setValue(8969);
            Console.WriteLine("Hello World!" + e.getreturn());
        }
    }
}
