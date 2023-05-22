using System.ComponentModel.DataAnnotations;

namespace KPMGApi.Models
{
    public class RainTimeline
    {
        [Key]
        public string Category { get; set; }
        public double Tokyo { get; set; }
        public double NewYork { get; set; }
        public double London { get; set; }
        public double Berlin { get; set; }
    }
}
