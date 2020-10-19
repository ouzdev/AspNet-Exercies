using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TelefonRehberi.Models
{
    [Table("TBLDEPARTMAN")]
    public class Departman
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required,StringLength(60)]
        public string DepartmanAd { get; set; }

        public virtual List<Personel> Personels { get; set; }
    }
}