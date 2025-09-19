using System.Reflection.Metadata;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Document = BaltaStore.Domain.StoreContext.ValueObjects.Document;

namespace BaltaStore.Test;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public void TestMethod1()
    {
        var name = new Name("Sebastiao", "Siqueira");
        var document = new Document("123456789454");
        var email = new Email("sebastiao@gmail.com");
        var c = new Customer(name, document, email, "987654789");
        var mouse = new Product("mouse", "rato", "image.png", 59.91M, 10);
        var impressora = new Product("impressora", "impressora", "image.png", 359.91M, 10);
        var cadeira = new Product("cadeira", "cadeira", "image.png", 559.91M, 10);
        var teclado = new Product("teclado", "teclado", "image.png", 159.91M, 10);

        var order = new Order(c);
        order.AddItem(new OrderItem(mouse, 5));
        order.AddItem(new OrderItem(impressora, 5));
        order.AddItem(new OrderItem(cadeira, 5));
        order.AddItem(new OrderItem(teclado, 5));

        order.Place();

        order.Pay();

        order.Ship();

        order.Cancel();

      
       
    }
}
