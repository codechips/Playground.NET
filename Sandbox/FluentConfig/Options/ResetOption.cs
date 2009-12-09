using System;

namespace Sandbox.FluentConfig.Options
{
    public class ResetOption : IOption
    {
        public void Act( object option )
        {
            // Cast object to boolean and do some stuff    
            var choice = (bool) option;
            Console.WriteLine("Reset? " + choice);
        }
    }
}