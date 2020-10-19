using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TelefonRehberi.Models
{
    [Table("TBLADMİN")]
    public class Admin
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required,StringLength(50)]
        public string KULLANICIADI { get; set; }
        [Required]
        public string SIFRE { get; set; }
    }
}