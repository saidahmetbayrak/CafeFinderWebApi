using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;
using System.ComponentModel.DataAnnotations;
using System;

namespace CafeFinderWebApi.Model
{
    public class Cafe
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }   
         
        [Required]
        public string City { get; set; }
    }
}
