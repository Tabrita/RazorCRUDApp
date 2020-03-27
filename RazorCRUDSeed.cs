using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RazorCRUDApp.Data;
using RazorCRUDApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorCRUDApp
{
    public class RazorCRUDSeed
    {
        public static async Task SeedAsync(RazorCRUDContext context, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                // TODO: Only run this if using a real database
                //context.Database.Migrate();
                //context.Database.EnsureCreated();
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(GetPreconfiguredCategories());
                    await context.SaveChangesAsync();
                }
                if (!context.Products.Any())
                {
                    context.Products.AddRange(GetPreconfiguredProducts());
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<RazorCRUDSeed>();
                    log.LogError(exception.Message);
                    await SeedAsync(context, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        private static IEnumerable<Category> GetPreconfiguredCategories()
        {
            return new List<Category>()
            {
                new Category()
                {
                Name = "White Appliances",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, " +
                                "tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo " +
                                "dolorum ab tempora nihil dicta earum fugiat.",
                ImageName = "one"
                },
                new Category()
                {
                Name = "Smart Watches",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque " +
                                "laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                ImageName = "two"
                },
                new Category()
                {
                Name = "Home & Kitchen",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste " +
                                "ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                ImageName = "tree"
                }
            };
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Name = "IPhone X",
                    Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless, " +
                                "OLED screen, wireless charging and facial recognition cameras.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste " +
                                    "ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. " +
                                    "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum " +
                                    "rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-1.png",
                    UnitPrice = 35.00,
                    CategoryId = 1
                 },
                new Product()
                {
                    Name = "Samsung 10",
                    Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless, OLED screen, " +
                                "wireless charging and facial recognition cameras.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum " +
                                    "obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor " +
                                    "sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit " +
                                    "odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-2.png",
                    UnitPrice = 10.00,
                    CategoryId = 1
                },
                new Product()
                {
                    Name = "Huawei Plus",
                    Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless, OLED screen, " +
                                "wireless charging and facial recognition cameras.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum " +
                                    "obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor " +
                                    "sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit " +
                                    "odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-3.png",
                    UnitPrice = 30.00,
                    CategoryId = 2
                },
                new Product()
                {
                    Name = "Xiaomi Mi 9",
                    Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless, OLED screen, " +
                                "wireless charging and facial recognition cameras.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum " +
                                    "obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor " +
                                    "sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit " +
                                    "illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-4.png",
                    UnitPrice = 25.00,
                    CategoryId = 1
                },
                new Product()
                {
                    Name = "HTC U11+ Plus",
                    Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless, OLED screen, wireless charging " +
                                "and facial recognition cameras.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit " +
                                    "odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing " +
                                    "elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum " +
                                    "fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-5.png",
                    UnitPrice = 20.00,
                    CategoryId = 1
                },
                new Product()
                {
                    Name = "LG G7 ThinQ",
                    Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless, OLED screen, wireless charging " +
                                "and facial recognition cameras.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit " +
                                    "odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. " +
                                    "Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-6.png",
                    UnitPrice = 15.00,
                    CategoryId = 1
                }
            }; 
            
        }
        
    }
}

