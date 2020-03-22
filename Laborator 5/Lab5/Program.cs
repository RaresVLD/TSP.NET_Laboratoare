using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Call the desired method here
            Console.Read();
        }

        static void firstPart()
        {
            using (ModelSelfReferences context = new ModelSelfReferences())
            {
                SelfReference selfReference1 = new SelfReference()
                {
                    Name = "Parinte"
                };

                SelfReference selfReference2 = new SelfReference()
                {
                    Name = "Copil1",
                    ParentSelfReference = selfReference1
                };

                SelfReference selfReference3 = new SelfReference()
                {
                    Name = "Copil2",
                    ParentSelfReference = selfReference2
                };

                context.SelfReferences.Add(selfReference1);
                context.SelfReferences.Add(selfReference2);
                context.SelfReferences.Add(selfReference3);
                context.SaveChanges();

                foreach (SelfReference self in context.SelfReferences)
                {
                    Console.WriteLine("{0}, {1}", self.Name, self.ParentSelfReferenceId);
                    foreach (SelfReference child in context.SelfReferences)
                    {
                        Console.WriteLine("Hashmap: {0}", child.Name);
                    }
                }
            }
            Console.ReadKey();
        }

        static void secondPart()
        {
            using (var context = new ProductContext()){
                var product = new Product
                {
                    SKU = 149,
                    Description = "Expandable Hydration Pack",
                    Price = 19.97M,
                    ImageURL = "/pack147.jpg"
                }; 
                context.Product.Add(product); 
                product = new Product {
                    SKU = 179, 
                    Description = "Rugged Ranger Duffel Bag", 
                    Price = 39.97M, ImageURL = "/pack178.jpg" 
                }; 
                context.Product.Add(product); 
                product = new Product { 
                    SKU = 189, 
                    Description = "Range Field Pack",
                    Price = 98.97M, 
                    ImageURL = "/noimage.jp" 
                };
                context.Product.Add(product); 
                product = new Product {
                    SKU = 209,
                    Description = "Small Deployment Back Pack",
                    Price = 29.97M, 
                    ImageURL = "/pack202.jpg" 
                }; 
                context.Product.Add(product); 
                context.SaveChanges();
            }
            using (var context = new ProductContext()){
                foreach (var p in context.Product) { 
                    Console.WriteLine("{0} {1} {2} {3}", p.SKU, p.Description, p.Price.ToString("C"), p.ImageURL); 
                } 
            }
        } 

        static void thirdPart()
        {
            byte[] thumbBits = new byte[100]; 
            byte[] fullBits = new byte[2000];
            using (var context = new PhotographContext()){ 
                var photo = new Photograph { 
                    Title = "My Dog", 
                    ThumbnailBits = thumbBits
                }; 
                var fullImage = new PhotographFullImage {
                    HighResolutionBits = fullBits
                };
                photo.PhotographFullImage = fullImage; 
                context.Photographs.Add(photo); context.SaveChanges(); 
            }
            using (var context = new PhotographContext()){
                foreach (var photo in context.Photographs)
                {
                    Console.WriteLine("Photo: {0}, ThumbnailSize {1} bytes", photo.Title, photo.ThumbnailBits.Length);
                    context.Entry(photo).Reference(p => p.PhotographFullImage)
                        .Load();
                    Console.WriteLine("Full Image Size: {0} bytes", photo.PhotographFullImage.HighResolutionBits.Length);
                }
            }
        }

        static void fourthPart()
        {
            using (var context = new BusinessContext()){ 
                var business = new Business { 
                    Name = "Corner Dry Cleaning", 
                    LicenseNumber = "100x1"
                }; 
                context.Businesses.Add(business); 
                var retail = new Retail { 
                    Name = "Shop and Save", 
                    LicenseNumber = "200C",
                    Address = "101 Main", 
                    City = "Anytown", 
                    State = "TX",
                    ZIPCode = "76106" 
                }; 
                context.Businesses.Add(retail);
                var web = new eCommerce {
                    Name = "BuyNow.com", 
                    LicenseNumber = "300AB",
                    URL = "www.buynow.com"
                }; 
                context.Businesses.Add(web); 
                context.SaveChanges();
            }
            using (var context = new BusinessContext()){ 
                Console.WriteLine("\n---All Businesses ---"); 
                foreach (var b in context.Businesses) { 
                    Console.WriteLine("{0} (#{1})", b.Name, b.LicenseNumber); 
                } 
                Console.WriteLine("\n---Retail Businesses ---");
                foreach (var r in context.Businesses.OfType<Retail>()){ 
                    Console.WriteLine("{0} (#{1})", r.Name, r.LicenseNumber); 
                    Console.WriteLine("{0}", r.Address);
                    Console.WriteLine("{0}, {1} {2}", r.City, r.State, r.ZIPCode);
                } 
                Console.WriteLine("\n---eCommerce Businesses ---");
                foreach (var e in context.Businesses.OfType<eCommerce>()) {
                    Console.WriteLine("{0} (#{1})", e.Name, e.LicenseNumber);
                    Console.WriteLine("Online address is: {0}", e.URL); 
                } 
            }
        }

        static void fifthPart()
        {
            using (var context = new EmployeeContext()){ 
                var fte = new FullTimeEmployee {
                    FirstName = "Jane",
                    LastName = "Doe",
                    Salary = 71500M 
                }; 
                context.Employees.Add(fte); 
                fte = new FullTimeEmployee {
                    FirstName = "John",
                    LastName = "Smith",
                    Salary = 62500M 
                };
                context.Employees.Add(fte); 
                var hourly = new HourlyEmployee {
                    FirstName = "Tom",
                    LastName = "Jones",
                    Wage = 8.75M
                }; 
                context.Employees.Add(hourly);
                context.SaveChanges();
            }
            using (var context = new EmployeeContext()){
                Console.WriteLine("---All Employees ---");
                foreach (var emp in context.Employees) {
                    bool fullTime = emp is HourlyEmployee ? false : true; 
                    Console.WriteLine("{0} {1} ({2})", emp.FirstName, emp.LastName, fullTime ? "Full Time" : "Hourly");
                }
                Console.WriteLine("---Full Time ---"); 
                foreach (var fte in context.Employees.OfType<FullTimeEmployee>()) {
                    Console.WriteLine("{0} {1}", fte.FirstName, fte.LastName);
                }
                Console.WriteLine("---Hourly ---"); 
                foreach (var hourly in context.Employees.OfType<HourlyEmployee>()) {
                    Console.WriteLine("{0} {1}", hourly.FirstName, hourly.LastName);
                } 
            }
        }
    }
}
