using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Sandbox.FluentConfig.Options;

namespace Sandbox.FluentConfig
{
    public class Config
    {
        IDictionary<string, IOption> workers;
        public Config()
        {
            SetupWorkers();
            var config = Configure( reset => true, debug => true, amount => 10, start => DateTime.Now, delete => true );
            Dispatch( config ); 
        }

        void SetupWorkers()
        {
            workers = new Dictionary<string, IOption>();
            workers.Add( "reset", new ResetOption() );
            workers.Add( "debug", new DebugOption() );
            workers.Add( "amount", new AmountOption() );
        }

        void Dispatch( IDictionary<string, object> config )
        {
            foreach( var option in config )
            {
                if (workers.ContainsKey( option.Key ))
                    workers[option.Key].Act( option.Value );
            }
        }

        static IDictionary<string,object> Configure(params Expression<Func<string, object>>[] parameters)
        {
            var options = new Dictionary<string, object>();
           
            foreach( var parameter in parameters )
                options.Add( parameter.Parameters[0].Name, parameter.Compile().Invoke( string.Empty ) );

            return options;
        }
    }
}
