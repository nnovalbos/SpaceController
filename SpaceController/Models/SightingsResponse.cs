using System.Collections.Generic;
using System.IO;
using SpaceController.Common;
using SpaceController.Contracts.Utils;

namespace SpaceController.Models
{
    public class SightingsResponse : ITxtParseable
    {
        public SightingsResponse()
        {
        }

        public List<Sighting> Sightings { get; set; } = new List<Sighting>();

        public ITxtParseable Parser(string txtData)
        {
            var newParseable = new SightingsResponse();

            using (StreamReader reader = new StreamReader(Utilities.GenerateStreamFromString(txtData)))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    var parsed = new Sighting().Parser(line);
                    newParseable.Sightings.Add((Sighting)parsed);
                }
            }

            return newParseable;
        }
    }
}
