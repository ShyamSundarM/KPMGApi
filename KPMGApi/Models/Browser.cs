using System.ComponentModel.DataAnnotations;

namespace KPMGApi.Models
{
    public class Browser
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public double Share { get; set; }
    }
}
