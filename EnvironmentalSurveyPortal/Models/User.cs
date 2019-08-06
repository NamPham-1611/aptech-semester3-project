using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnvironmentalSurveyPortal.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(10)]
        public string UID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [StringLength(20)]
        public string Class { get; set; }

        [StringLength(20)]
        public string Specification { get; set; }

        [StringLength(20)]
        public string Section { get; set; }

        [StringLength(15)]
        public string Role { get; set; } = "Student";

        public bool isActive { get; set; } = false;

        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}