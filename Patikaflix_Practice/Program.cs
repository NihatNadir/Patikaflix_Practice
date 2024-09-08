using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patikaflix_Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var diziListesi = new List<Diziler>()
                {
                    new Diziler("Avrupa Yakası", 2004, new List<string> {"Komedi" }, 2004, "Yuksel Aksu", "Kanal D"),
                    new Diziler("Yalan Dünya", 2012, new List<string> {"Komedi" }, 2004, "Gülseren Buda Başkaya", "Fox TV"),
                    new Diziler("Jet Sosyete", 2018, new List<string> {"Komedi" }, 2004, "Gülseren Buda Başkaya", "TV8"),
                    new Diziler("Dadı", 2006, new List<string> {"Komedi"}, 2004, "Yusuf Pirhasan", "Kanal D"),
                    new Diziler("Belalı Baldız", 2007, new List<string> { "Komedi" }, 2004, "Yuksel Aksu", "Kanal D"),
                    new Diziler("Arka Sokaklar", 2004, new List<string> { "Polisiye","Dram" }, 2004, "Orhan Oğuz", "Kanal D"),
                    new Diziler("Aşk-ı Memnu", 2008, new List<string> {"Dram" ,"Romantik" }, 2004, "Hilal Saral", "Kanal D"),
                    new Diziler("Muhteşem Yüzyıl", 2011, new List<string> {"Dram" ,"Tarihi" }, 2004, "Mercan Çilingiroğlu", "Star TV"),
                    new Diziler("Yaprak Dökümü", 2006, new List<string> { "Dram" }, 2004, "Serdar Akar", "Kanal D")
                };
            bool check = true;
            while (check)
            {

                Console.WriteLine("---Patikaflix Uygulamasına Hoşgeldiniz---");
                Console.WriteLine("Eklemek istediğiniz dizinin adını giriniz...");

                string seriesName = Console.ReadLine(); // kullanıcının girdiği değerin ilk harfini büyük alır
                seriesName = char.ToUpper(seriesName[0])+seriesName.Substring(1);

            year:
                Console.WriteLine("Dizinin yapım yılını giriniz...");
                int productionYear;

                bool isValid = int.TryParse(Console.ReadLine(), out productionYear);
                if (!isValid)
                {
                    Console.WriteLine("Geçersiz giriş yaptınız lütfen bir sayı giriniz.");
                    goto year;
                }

                List<string> genreList = new List<string>();
            genre:
                Console.WriteLine("Dizinin türünü giriniz.");

                string genre = Console.ReadLine();
                genre = char.ToUpper(genre[0]) + genre.Substring(1); // kullanıcının girdiği değerin ilk harfini büyük alır
                genreList.Add(genre);
            error:
                Console.WriteLine("Başka bir tür eklemek istermisiniz. \nEvet için 'e' Hayır için 'h' basın");
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "e": goto genre;

                    case "h":
                        break;
                    default:
                        Console.WriteLine("Hatalı tuş girdiniz.");
                        goto error;


                }

                Console.WriteLine("Yayınlanmaya başlayacak tarihi giriniz.");

            releaseYear:

                int releaseYear;

                isValid = int.TryParse(Console.ReadLine(), out releaseYear);

                if (!isValid)

                {
                    Console.WriteLine("Geçersiz giriş yaptınız lütfen bir sayı giriniz.");
                    goto releaseYear;
                }

                Console.WriteLine("Yönetmen adını giriniz.");
                string director = Console.ReadLine();
                director = char.ToUpper(director[0]) + director.Substring(1);  // kullanıcının girdiği değerin ilk harfini büyük alır

                Console.WriteLine("Yayınlanacağı platformu giriniz.");
                string platform = Console.ReadLine();
                platform = char.ToUpper(platform[0]) + platform.Substring(1); // kullanıcının girdiği değerin ilk harfini büyük alır

                diziListesi.Add(new Diziler(seriesName, productionYear, genreList, releaseYear, director, platform)); 

            exit:
                Console.WriteLine("Diziniz eklendi başka bir dizi eklemek istiyorsanız 'e' istemiyorsanız 'h' basın.");

                input = Console.ReadLine().ToLower();
                if (input == "e")
                {
                    check = true;
                }
                else if (input == "h")
                {
                    check = false;
                }
                else
                {
                    Console.WriteLine("Hatalı tuş girişi yaptınız.");
                    goto exit;
                }
            }

            var comedyList = diziListesi // Listeye içinde komedi olanları filtreledikten sonra bunlarla yeni bir nesne oluşturur bunlarıda dizi adı ve yönetmen adı ile sıralar
                .Where(x => x.Genre.Contains("Komedi"))
                .Select(x => new Humour(x.SeriesName, x.Genre, x.Director))
                .OrderBy(x => x.SeriesName)
                .ThenBy(x => x.Director)
                .ToList();

            foreach (var x in comedyList) // Listedeki elemanları ekrana yazdırır 
            {                
                foreach (var y in x.Genre)
                {
                    if (y == "Komedi")
                    {
                        Console.WriteLine($"Dizi Adı : {x.SeriesName} - Dizinin Türü : {y} - Dizinin Yönetmeni : {x.Director} ");
                        
                    }
                }
            }

            Console.ReadLine();



        }


    }
}

