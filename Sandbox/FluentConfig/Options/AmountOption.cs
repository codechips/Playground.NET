using System;

namespace Sandbox.FluentConfig.Options
{
    public class AmountOption : IOption
    {
        public void Act(object option)
        {
            // Cast object to int and do some stuff    
            var amount = (int)option;
            Console.WriteLine("How many? " + amount);
        }
    }
}