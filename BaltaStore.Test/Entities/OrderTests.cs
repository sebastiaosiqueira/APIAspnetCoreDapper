
using System.ComponentModel;
using System.Threading.Tasks;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Test.Entities
{
    [TestClass]
    public class OrderTests
    {
        private Product _mouse;
        private Product _keyboard;
        private Product _chair;
        private Product _monitor;
        private Customer _customer;
        private Order _order;
        public OrderTests()
        {
            var name = new Name("Sebastiao", "Siqueira");
            var document = new Document("4598789856656");
            var email = new Email("sebastiao@siqueira@gmail.com");
            _customer = new Customer(name, document, email, "12365489985");
            _order = new Order(_customer);


            _mouse = new Product("Mouse gamer", "Gamer", "mouse.jpg", 100M, 10);
            _keyboard = new Product("Keyboard gamer", "Gamer", "keyboard.jpg", 100M, 10);
            _chair = new Product("chair gamer", "chair", "chair.jpg", 100M, 10);
            _monitor = new Product("Monitor gamer", "Monitor", "Monitor.jpg", 100M, 10);



        }
        //Consigo criar um pedido
        [TestMethod]
        public void ShouldCreateOrderWhenValid()
        {
            Assert.AreEqual(true, _order.IsValid);
        }

        //Ao criar o pedido o status dever ser created
        [TestMethod]
        public void StatusShouldBeCreateWhenOrderCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        //ao adicionar um novo item a quantidade de itens deve mudar
        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoValidadItems()
        {
            _order.AddItem(_monitor, 5);
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(2, _order.Items.Count);
        }

        //ao adiconar um novo item deve subtrair a quantide do produto
        [TestMethod]
        public void ShouldReturnFiveWhenAddedPurchaseFiveItem()
        {
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(_mouse.QuantityOnHand, 5);
        }

        //ao confirmnar pedido, deve gerar um numero
        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlace()
        {
            _order.Place();
            Assert.AreNotEqual("", _order.Number);

        }

        //ao pagar um pedido, o status deve ser Pago
        [TestMethod]
        public void ShouldReturnPaidWhenOrderPaid()
        {

            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }
        //dados mais 10 produtos , devem haver duas entregas
        [TestMethod]

        public void ShouldTwoShipppingWhenPurchasedTenProducts()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.Ship();
            Assert.AreEqual(2, _order.Deliveries.Count);

        }

        //ao cancelar pedido , status dever ser cancelado
        [TestMethod]
        public void StatusShouldBeCanceledWhenOrderCanceled()
        {
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        //ao cancelar o pedido, deve cancelar as entregas
        [TestMethod]
        public void ShouldCancelShippingsWhenOrderCanceled()
        {/*
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.Ship();

            _order.Cancel();
            foreach (var x in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, x.Status);
            }
*/
        }

        public void CreateCustomer()
        {
            //verifica se o cpf ja existe
            //verifica se email ja existe
            //criar os VOs
            //Criar  as entidades
            //validar as entidades Vo
            //inserir o cliente no banco
            //envia convite do slake
            //envia um email de boas vindas
            
        }

    }
}