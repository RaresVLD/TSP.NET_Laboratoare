using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP_NET_LAB3_GIT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test Model Designer First");
            AlbumArtistTest();
            Console.ReadKey();
        }
        static void TestPerson() { 
            using (Model1Container context = new Model1Container()) {
                Person p = new Person() { 
                    FirstName = "Julie", 
                    LastName = "Andrew",
                    MiddleName = "T", 
                    TelephoneNumber = "1234567890"
                }; 
                context.People.Add(p); 
                context.SaveChanges(); 
                var items = context.People; 
                foreach (var x in items)
                    Console.WriteLine("{0} {1}", x.Id, x.FirstName); 
            } 
        }
        static void TesTOneToMany() {
            Console.WriteLine("One to many association");
            using (Model1Container context = new Model1Container()) { 
                Customer c = new Customer() { 
                    Name = "Customer 1", 
                    City = "Iasi"
                }; 
                Order o1 = new Order() { 
                    TotalValue = "200",  
                    Date = DateTime.Now.ToString(), 
                    Customer = c }; 
                Order o2 = new Order() { 
                    TotalValue = "300",  
                    Date = DateTime.Now.ToString(), 
                    Customer = c 
                };
                context.Customers.Add(c);
                context.Orders.Add(o1); 
                context.Orders.Add(o2); 
                context.SaveChanges();
                var items = context.Customers;
                foreach (var x in items) { 
                    Console.WriteLine("Customer : {0}, {1}, {2}", x.CustomerId, x.Name, x.City); 
                    foreach (var ox in x.Orders)
                        Console.WriteLine("\tOrders: {0}, {1}, {2}", ox.OrderId, ox.Date, ox.TotalValue);
                } 
            } 
        }

        static void AlbumArtistTest()
        {
            using (Model1Container context = new Model1Container())
            {
                Album a = new Album()
                {
                    AlbumName = "Album 1"
                };

                Album a2 = new Album()
                {
                    AlbumName = "Album 2",
                };

                Artist artist = new Artist()
                {
                    FirstName = "John",
                    LastName = "Doe"

                };
                context.Albums.Add(a);
                context.Albums.Add(a2);
                context.Artists.Add(artist);
                context.SaveChanges();
                var artists = context.Artists;
                foreach (var x in artists)
                {
                    Console.WriteLine("Artist : {0}, {1}, {2}", x.ArtistId, x.FirstName, x.LastName);
                    foreach (var album in x.Albums)
                        Console.WriteLine("\tAlbum: {0}, {1}", album.AlbumId, album.AlbumName);
                }
            }
        }
    }
}
