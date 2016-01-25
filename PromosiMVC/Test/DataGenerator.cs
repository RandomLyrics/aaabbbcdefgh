using PromosiMVC.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PromosiMVC.Test
{
    public class DataGenerator
    {
        private PromosiDBModelContainer DB;
        private static int count = 6;

        public DataGenerator(PromosiDBModelContainer db)
        {
            this.DB = db;
        }

        public void Generate()
        {
            //randoms
            Random rnd = new Random();
            var streets = new List<string>
               {
                   "Lipowa",
                   "Warszawska",
                   "Magnata",
                   "Ulkowska",
                   "Jarzębska",
                   "Żadna"
                };
            var names = new List<string>
               {
                   "Ryszard",
                   "Jadwiga",
                   "Mariusz",
                   "John",
                   "Helmut",
                   "Barbara"
                };
            var cnames = new List<string>
               {
                   "Maltex",
                   "Kuraż",
                   "Dentix",
                   "Xanox",
                   "Iga",
                   "Świeżo"
                };
            var dom = new List<string>
               {
                   "@gmail.com",
                   "@hotmail.com",
                   "@op.pl",
                   "@wp.pl",
                   "@onet.pl",
                   "@dragon.com"
                };
            //City
            var cities = new List<City>()
               {
                   {new City { Name = "Warszawa" } },
                   {new City { Name = "Wrocław" } },
                   {new City { Name = "Zakopane" } },
                   {new City { Name = "Gdańsk" } }
                };
            DB.CitySet.AddRange(cities);
            DB.SaveChanges();

            //Branch
            var branches = new List<Branch>
            {
                {new Branch { Name = "Uroda", Description = "Salon fryzjerski, kosmetyczny"} },
                {new Branch { Name = "Medycyna", Description = "Dentysta, gabinet lekarski" } },
                {new Branch { Name = "Motoryzacja", Description = "Warsztat samochodowy, wulkanizator" } },
                {new Branch { Name = "Gastronomia", Description = "Restauracje, fast-food" } }
            };
            DB.BranchSet.AddRange(branches);
            DB.SaveChanges();

            //Company
            for (int i = 0; i < cnames.Count; i++)
            {
                var c = new Company();
                c.Adress = streets.PickRandom() + " " + rnd.Next(1, 80);
                c.Branch = DB.BranchSet.PickRandom();
                c.Name = cnames[i];
                c.NIP = rnd.Next(100, 999).ToString() + "-" + rnd.Next(100, 999).ToString() + "-" + rnd.Next(10, 99).ToString() + "-" + rnd.Next(10, 99).ToString();
                c.ChannelName = c.Name;
                c.Phonenumber = "+48 " + rnd.Next(100000000, 999999999).ToString();
                c.City = DB.CitySet.PickRandom();
                c.Email = c.Name + dom.PickRandom();
                c.Password = TestHelpers.GenerateCode(6);
                DB.CompanySet.Add(c);
            }
            DB.SaveChanges();

            //User
            for (int i = 0; i < count*3; i++)
            {
                var c = new User();
                c.Surname = streets.PickRandom();
                c.Name = names.PickRandom();
                c.DeviceToken = TestHelpers.GenerateCode(12);
                c.Password = TestHelpers.GenerateCode(8);
                c.RegistrationId = TestHelpers.GenerateCode(14);
                c.Phonenumber = rnd.Next(100000000, 999999999).ToString();
                c.Email = c.Name + dom.PickRandom();
                DB.UserSet.Add(c);
            }
            DB.SaveChanges();
            
            //Followings
            
            foreach (var item in DB.UserSet)
            {
                if (rnd.Next(0, 100) >= 80)
                {
                    var f = new Followings();
                    f.User = item;
                    f.Company = DB.CompanySet.PickRandom();
                    DB.FollowingsSet.Add(f);
                } 
            }
            DB.SaveChanges();

            ////Push
            //for (int i = 0; i < count; i++)
            //{
            //    var c = new Push();
            //    // if (rnd.Next(0,1) == 1)
            //    c.Company = DB.CompanySet.PickRandom();
            //    c.Available = true;
            //    c.DateBegin = DateTime.Today;
            //    c.DateEnd = c.DateBegin.AddHours(rnd.Next(4, 48));
            //    c.Description = TestHelpers.GenerateText(64);
            //    c.Text = TestHelpers.GenerateText(32);
            //    DB.PushSet.Add(c);
            //}
            //DB.SaveChanges();
        }
    }
}