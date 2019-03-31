using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

// use [Column("Name")] to name a column differently in the db

namespace WebAppDeloittes.city.model
{
    [Table("Cities")]
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        public int Rating { get; set; } // 1 - 5

        public DateTime Established { get; set; }

        public long EstimatedPopulation { get; set; }
    }
}
