namespace SpaceController.Models
{
    public class DeviceResolution
    {
        public int Rows { get; set; }

        public int Colums { get; set; }

        public static DeviceResolution Builder(string data)
        {
            var values = data.Split('x');
            return new DeviceResolution
            {
                Rows = int.Parse(values[1]),
                Colums = int.Parse(values[0])
            };
        }

    }
}
