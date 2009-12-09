using System;
using System.Collections.Generic;

namespace Sandbox.DispatchTable
{
    // Idea taken from http://leftrightfold.com/?p=85

    public class Dispatcher
    {
        IList<Channel> channels;
        IDictionary<Genre, Action<Channel>> actions;

        public Dispatcher()
        {
            channels = new List<Channel>();
            actions = new Dictionary<Genre, Action<Channel>>();
            SetupChannels();
            SetupActions();
        }

        void SetupChannels()
        {
            channels.Add( new Channel() { Station = "SVT1", Genre = Genre.News, ShowTitle = "Aktuellt", Repeat = true });
            channels.Add( new Channel() { Station = "SVT2", Genre = Genre.Children, ShowTitle = "Bolibompa", Repeat = false });
            channels.Add( new Channel() { Station = "TV3", Genre = Genre.Entertainment, ShowTitle = "Desperate Housewives", Repeat = false });
            channels.Add( new Channel() { Station = "TV4", Genre = Genre.Entertainment,  ShowTitle = "Parlamentet", Repeat = false });
            channels.Add( new Channel() { Station = "Kanal 5", Genre = Genre.Entertainment, ShowTitle = "Arga snickaren", Repeat = false });
            channels.Add( new Channel() { Station = "TV6", Genre = Genre.Comedy, ShowTitle = "Family Guy", Repeat = false });
        }

        void SetupActions()
        {
            actions.Add( Genre.News, c => Console.WriteLine(" Boooring! "));
            actions.Add( Genre.Entertainment, c => Console.WriteLine(c.ShowTitle +  " is on TV!" ));
            actions.Add( Genre.Children, c => Console.WriteLine("Hurry kids! It's " + c.ShowTitle + " on " + c.Station));
            actions.Add( Genre.Comedy, c => Console.WriteLine("Comedy time! " + c.ShowTitle +  " is on TV!"));
        }

        public void Run()
        {
            Dispatch( channels, actions );
        }

        static void Dispatch( IEnumerable<Channel> channels, IDictionary<Genre, Action<Channel>> actions )
        {
            foreach( var channel in channels )
                actions[channel.Genre]( channel );
        }
    }
}
