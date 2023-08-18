// See https://aka.ms/new-console-template for more information
using NetChallenge.Domain.Entities;
using NetChallenge.Persistence.Concretes;

Console.WriteLine("Hello, World!");


var result = new OrderManager(new OrderRepository(), new CompanyManager(new CompanyRepository()), new ProductManager(new ProductRepository())).Add(
    new Order ()
    {
        ProductId = 7,
        NameOfThePersonPlacingTheOrder  = "DENEME" ,
        OrderDate = DateTime.Now
        
    }
    );

Console.WriteLine(result.IsSuccess);
Console.WriteLine(result.Message);
