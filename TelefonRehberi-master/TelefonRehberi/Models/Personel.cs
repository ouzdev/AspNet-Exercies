using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TelefonRehberi.Models
{
    [Table("TBLPERSONEL")]
    public class Personel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required(ErrorMessage ="Lütfen Ad alanıı doldurunuz."), StringLength(50)]
        public string AD { get; set; }
        [Required(ErrorMessage ="Lütfen Soyadı alanın doldurunuz."), StringLength(50)]
        public string SOYAD { get; set; }
        [Required(ErrorMessage ="Lütfen telefon numarası alanını doldurunuz."), StringLength(11,ErrorMessage ="Telefon numarası en fazla 11 karakter uzunluğunda olabilir.")]
        public string TELEFON { get; set; }
        [StringLength(1000)]
        public string DETAY { get; set; }
        public int YONETICI { get; set; }
        public string YONETICIAD { get; set; }
        public int DepartmanID { get; set; }
        public virtual Departman Departman { get; set; }

    }
}