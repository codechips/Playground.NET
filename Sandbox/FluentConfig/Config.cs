using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Sandbox.FluentConfig.Options;

namespace Sandbox.FluentConfig
{
    public class Config
    {
        IDictionary<string, IOption> options;
        public Config()
        {
            SetupOptions();
            
            var config = Configure( reset => true, debug => true, amount => 10, start => DateTime.Now, delete => true );
            
            Dispatch( config ); 
        }
        
        static IDictionary<string, object> Configure(params Expression<Func<string, object>>[] parameters)
        {
            var config = new Dictionary<string, object>();

            foreach (var parameter in parameters)
                config.Add(parameter.Parameters[0].Name, parameter.Compile().Invoke(string.Empty));

            return config;
        }
        
        void SetupOptions()
        {
            options = new Dictionary<string, IOption>();
            options.Add( "reset", new ResetOption() );
            options.Add( "debug", new DebugOption() );
            options.Add( "amount", new AmountOption() );
        }

        void Dispatch( IDictionary<string, object> config )
        {
            foreach( var c in config )
            {
                if (options.ContainsKey( c.Key ))
                    options[c.Key].Act( c.Value );
            }
        }

       
    }
}
