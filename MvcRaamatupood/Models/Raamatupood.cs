using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace MvcRaamatupood.Models
{
    public class Raamatupood
    {
        public int ID { get; set; }
        public string Pealkiri { get; set; }
        public string Autor { get; set; }
        [Display(Name = "Ilmumis aasta")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        public DateTime IlmumisAasta { get; set; }
        public string Kirjastus { get; set; }
        public decimal Hind { get; set; }
    }

    public class RaamatupoodDBContext : DbContext
    {
        public DbSet<Raamatupood> Raamatupood { get; set; }
    }
}