using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stok_Kayıt
{
    public class SeedMethod : System.Data.Entity.DropCreateDatabaseIfModelChanges<StokKayit>
    {
        protected override void Seed(StokKayit context)
        {
            var malzemes = new List<Stok>()
            {
                new Stok { StokKodu=1002,StokAdi="Civi",birim="adet",MevcutStok=100,MinStok=50,MaxStok=200},
                new Stok { StokKodu=1003,StokAdi="Demir",birim="gram",MevcutStok=5000,MinStok=500,MaxStok=20000},
                new Stok { StokKodu=1004,StokAdi="Gümüş",birim="gram",MevcutStok=1000,MinStok=50,MaxStok=2000}

            };
            malzemes.ForEach(s => context.stok.Add(s));
            context.SaveChanges();
        }
    }
}
