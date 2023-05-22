using System.ComponentModel.DataAnnotations;

namespace KPMGApi.Models
{
    public class JobEmployment
    {
        [Key]
        public int Category { get; set; }
        public int Developers { get; set; }
        public int Manufacturing { get; set; }
        public int Sales { get; set; }
        public int Operations { get; set; }
        public int Other { get; set; }
    }
}
