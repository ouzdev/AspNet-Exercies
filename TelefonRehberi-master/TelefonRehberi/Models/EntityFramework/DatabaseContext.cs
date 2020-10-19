using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TelefonRehberi.Models.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Personel> Personeller { get; set; }
        public DbSet<Departman> Departmanlar { get; set; }
        public DbSet<Admin> SuperUser { get; set; }


        public DatabaseContext()
        {
            Database.SetInitializer(new DatabaseInitializer());
        }



    }
    public class DatabaseInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            //Departmanlar insert ediliyor. 
            for (int i = 0; i < 10; i++)
            {
                Departman dpt = new Departman();
                dpt.DepartmanAd = FakeData.PlaceData.GetCountry();
                context.Departmanlar.Add(dpt);
            }
            context.SaveChanges();
            List<Departman> tumDepartmanlar = context.Departmanlar.ToList();



            // Personeller random olarak insert ediliyor.
            foreach (Departman item in tumDepartmanlar)
            {
                for (int i = 0; i < FakeData.NumberData.GetNumber(1,5); i++)
                {
                    Personel prs = new Personel();
                    prs.AD = FakeData.NameData.GetFirstName();
                    prs.SOYAD = FakeData.NameData.GetSurname();
                    prs.TELEFON = FakeData.NumberData.GetNumber(11).ToString();
                    prs.DETAY = FakeData.TextData.GetSentences(5);
                    prs.YONETICI = 0;
                    prs.YONETICIAD = "";
                    prs.Departman = item;
                    context.Personeller.Add(prs);
                }
            }

            Admin adm = new Admin();
            adm.KULLANICIADI = "ouzdev";
            adm.SIFRE ="123456";
            context.SuperUser.Add(adm);

            context.SaveChanges();
        }

    }
}