using Microsoft.EntityFrameworkCore;
using OlxApplicationDB.Models;
using OlxApplicationDB.DbContextOlx;

namespace OlxApplication
{
    internal class Program
    {
        private static int _userId;
        static void InitializeDataBase()
        {
            using var dbContext = new OlxDbContext();
            dbContext.Database.EnsureCreated();
        }

        static void LogIn()
        {
            Console.WriteLine("What is your name?");
            string name=Console.ReadLine();

            using var dbContext=new OlxDbContext();
            var user =dbContext.Users.SingleOrDefault(x => x.Name == name); 
            if(user == null)
            {
                user = new User { Name = name };
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                Console.WriteLine("Login succeed\n");
            }

            _userId=user.Id;
        }

        static void ReadAnnouncement()
        {
            using var dbContext = new OlxDbContext();

            var user = dbContext.Users.Include(u => u.Announces).SingleOrDefault(u => u.Id == _userId);
            Console.WriteLine($"You have {user.Announces.Count} announcement");

            foreach(var ad in user.Announces)
            {
                Console.WriteLine($"Ad id={ad.Id} name={ad.NameAd} description={ad.Description}");
            }
        }

        static void AddAd()
        {
            using var dbContext = new OlxDbContext();

            Console.WriteLine("Insert the name of ad.");

            string nameAd = Console.ReadLine();

            Console.WriteLine("Insert the ad.");

            string descriptionAd=Console.ReadLine();

            if (descriptionAd != null && nameAd!=null)
            {
                var ad = new Ad {UserId=_userId,Description = descriptionAd,NameAd=nameAd }; 
                dbContext.Ads.Add(ad);
                dbContext.SaveChanges();
            }
        }

        static void UpdateAnnouncement()
        {
            using var dbContext = new OlxDbContext();

            var user=dbContext.Users.Include(u=>u.Announces).SingleOrDefault(u=>u.Id==_userId);

            Console.WriteLine("Insert the id for the ad you want to modify.");
            string str = Console.ReadLine();
            int idAd=int.Parse(str);

            var ad=user.Announces.SingleOrDefault(i => i.Id == idAd);

            if (ad != null)
            {
                Console.WriteLine("Please enter the new description for the ad. ");
                str=Console.ReadLine();
                ad.Description = str;
                Console.WriteLine("Modify announcement successful\n");
            }
            else
            {
                Console.WriteLine("Id is invalid");
            }

            dbContext.SaveChanges();

        }

        static void DeleteAd()
        {
            using var dbContext=new OlxDbContext();
            var user=dbContext.Users.Include(u=>u.Announces).SingleOrDefault(u=>u.Id==_userId);

            Console.WriteLine("Insert the id for the ad you want to delete.");
            string str = Console.ReadLine();
            int idAd = int.Parse(str);

            var ad = user.Announces.SingleOrDefault(i=>i.Id==idAd);

            if (ad != null)
            {
                dbContext.Ads.Remove(ad);
                dbContext.SaveChanges();
                Console.WriteLine("Delete ad successful\n");
            }
            else
            {
                Console.WriteLine("Id is invalid");
            }
        }

        static void AddAddress()
        {
           
            using var dbContext = new OlxDbContext();
            var adr = dbContext.Adr.Where(u => u.UserId == _userId).FirstOrDefault();

            if (adr == null)
            {
                Console.WriteLine("Insert the country.");

                string country = Console.ReadLine();

                Console.WriteLine("Insert the town.");

                string town = Console.ReadLine();

                Console.WriteLine("Insert the street.");

                string street = Console.ReadLine();

                Console.WriteLine("Insert the number of street");

                string numberOfStreet = Console.ReadLine();

                if (country != null && town != null && street != null && numberOfStreet != null)
                {
                    var address = new Address { UserId = _userId, Country = country, Town = town, Street = street, NumberStreet = int.Parse(numberOfStreet) };
                    dbContext.Adr.Add(address);
                    dbContext.SaveChanges();
                }
            }
            else
            {
                Console.WriteLine("You already have the address!");
            }
            
        }

        static void ReadAddress()
        {
            using var dbContext= new OlxDbContext();
            var adr=dbContext.Adr.Where(u=>u.UserId==_userId).FirstOrDefault();
            if (adr != null)
            {
                Console.WriteLine("Your address is: ");
                Console.WriteLine($"Country: {adr.Country}, Town:{adr.Town}, Street:{adr.Street}, Number:{adr.NumberStreet}");
            }
            else
            {
                Console.WriteLine("Your address is empty!");
            }
            
        }

        static void Menu()
        {
            Console.WriteLine("To read the announcement enter 2.");
            Console.WriteLine("To add a new ad enter 3.");
            Console.WriteLine("To modify an ad enter 4.");
            Console.WriteLine("To delete an ad enter 5");
            Console.WriteLine("To insert the address enter 6");
            Console.WriteLine("To read the address enter 7");
            Console.WriteLine("To stop the application press 8.\n");
        }

        static void FunctionalityMenu()
        {
            LogIn();
            int var;
            do
            {
                Menu();
                Console.WriteLine("Insert the option");
                string str = Console.ReadLine();
                var = int.Parse(str);
                switch (var)
                {
                    case 2:
                        ReadAnnouncement();
                        break;
                    case 3:
                        AddAd();
                        break;
                    case 4:
                        UpdateAnnouncement();
                        break;
                    case 5:
                        DeleteAd();
                        break;
                    case 6:
                        AddAddress();
                        break;
                    case 7:
                        ReadAddress();
                        break;
                    case 8:
                        Console.WriteLine("The application has stopped\n");
                        break;
                }

            } while (var != 8);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Olx!\n");
            InitializeDataBase();
            FunctionalityMenu();
        }
    }
}