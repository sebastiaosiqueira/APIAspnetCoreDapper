using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using BaltaStore.Domain.StoreContext.Enums;
using FluentValidator;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Order : Notifiable
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;
        public Order(Customer customer)
        {
            Customer = customer;

            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }
        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Delivery => _deliveries.ToArray();


        public void AddItem(OrderItem item)
        {
            _items.Add(item);
            //validaitem
            //adicone ao pedido
        }

        //criar um pedido
        public void Place()
        {
            //gera o numero do pedido
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            if (_items.Count == 0)
                AddNotification("Order", "Esse pedido não possui itens");


        }

        //pagar um pedido
        public void Pay()
        {
            Status = EOrderStatus.Paid;

        }
        //enviar um pedido
        public void Ship()
        {
            var deliveries = new List<Delivery>();
            var count = 1;
            foreach (var item in _items)
            {
                if (count == 5)
                {
                    count = 1;
                    deliveries.Add(new Entities.Delivery(DateTime.Now.AddDays(5)));
                }
                count++;
            }
            deliveries.ForEach(x => x.Ship());
            deliveries.ForEach(x => _deliveries.Add(x));

        }
        //cancelar um pedido
        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }
    }
}