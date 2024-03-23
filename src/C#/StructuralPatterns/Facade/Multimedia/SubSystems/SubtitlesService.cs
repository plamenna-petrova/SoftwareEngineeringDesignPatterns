using System;
using System.Collections.Generic;
using System.Text;

namespace Multimedia.SubSystems
{
    public class SubtitlesService
    {
        public void DisplaySubtitle(string subtitlesLanguage)
        {
            Console.WriteLine($"Displaying subtitle: {subtitlesLanguage}");
        }
    }
}
