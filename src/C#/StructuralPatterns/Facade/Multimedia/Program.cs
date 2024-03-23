using Multimedia.Facade;
using System;

namespace Multimedia
{
    public class Program
    {
        static void Main(string[] args)
        {
            var multimediaFacade = new MultimediaFacade();

            Console.WriteLine("Start watching movie");
            multimediaFacade.WatchMovie("Inception", "DTS", "English");

            Console.WriteLine();

            Console.WriteLine("Start listening music");
            multimediaFacade.ListenToMusic("Stairway to Heaven");
        }
    }
}
