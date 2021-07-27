using System;
using System.Globalization;
using SpaceController.Contracts.Utils;

namespace SpaceController.Models
{
    public class Sighting : ITxtParseable
    {
        public string ObservatoryCode { get; set; } = string.Empty;

        public DateTime Date { get; set; } = DateTime.Now;

        public DateTime Time { get; set; } = DateTime.Now;

        public string DeviceCode { get; set; } = string.Empty;

        public DeviceResolution DeviceResolution { get; set; } = new DeviceResolution();

        public string DeviceMatrix { get; set; } = string.Empty;

        public DateTime DateAndTime => Date + Time.TimeOfDay;


        public ITxtParseable Parser(string txtData)
        {
            var words = txtData.Split('\t');

            try
            {
                return new Sighting
                {
                    Date = DateTime.ParseExact(words[0], "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Time = DateTime.ParseExact(words[1], "hh:mm:ss", CultureInfo.InvariantCulture),
                    ObservatoryCode = words[2],
                    DeviceCode = words[3],
                    DeviceResolution = DeviceResolution.Builder(words[4]),
                    DeviceMatrix = words[5]
                };

                
            }
            catch(Exception)
            {
                return new Sighting();
            }
        }
        
    }
}
