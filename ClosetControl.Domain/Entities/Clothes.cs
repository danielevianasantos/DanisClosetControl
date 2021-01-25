using System;

namespace ClosetControl.Domain.Entities
{
    public class Clothes
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Style { get; set; }
        public string Fabric { set; get; }
        public string Color { get; set; }
        public string Observation { set; get; }
        public DateTime LastUsed { get; set; }
        public int Season { get; set; }

        public Clothes()
        {
        }

        public Clothes(string type, string style, string fabric, string color, string observation, DateTime lastUsed, int season)
        {
            Id = Guid.NewGuid();
            Type = type.ToLower();
            Fabric = fabric.ToLower();
            Color = color.ToLower();
            Observation = observation.ToLower();
            LastUsed = lastUsed;
            Season = season;
        }
    }
}
