using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace Stok_Kayıt
{
    public class StokKayit : DbContext
    {

        public StokKayit()
            : base("name=StokKayit")
        {
        }
        public DbSet<Stok> stok { get; set; }

    }
    public class Stok
    {
        [Key]
        public int Id { get; set; }
        public int StokKodu { get; set; }
        public string StokAdi { get; set; }
        public string birim { get; set; }
        public int MevcutStok { get; set; }
        public int MinStok { get; set; }
        public int MaxStok { get; set; }
    }

}