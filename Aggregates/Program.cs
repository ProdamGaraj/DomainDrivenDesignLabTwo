using System;
using MyApp.CustomerAggregate;
using MyApp.OrderAggregate;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var customerRepository = new CustomerRepository())
            {
                var customerFactory = new Customer.CustomerFactory();

                var paypalCustomer = customerFactory.Create("John Doe", new PaypalPayment("john.doe@gmail.com"));
                customerRepository.Add(paypalCustomer);

                var stripeCustomer = customerFactory.Create("Jane Smith", new StripePayment("1234567890"));
                customerRepository.Add(stripeCustomer);

                var cardCustomer = customerFactory.Create("Vasiliy Petrov",
                    new CardPayment("1234567890", "Vasiliy Petrov", "01/2022", CardType.Mir));
                customerRepository.Add(cardCustomer);

                Console.WriteLine(paypalCustomer);
                Console.WriteLine(stripeCustomer);
                Console.WriteLine(cardCustomer);
                
                using (var orderRepository = new OrderRepository())
                {
                    var orderFactory = new Order.OrderFactory();
                    var order = orderFactory.Create(paypalCustomer);
                    order.AddProduct(new Product("Product 1", 9.99m));
                    order.AddProduct(new Product("Product 2", 3.99m));
                    order.SetShippingAddress(new Address("123 Main St", "New York", "NY", "USA", "10001"));
                    orderRepository.Add(order);
                    // смена статуса
                    order.SetStatus(OrderStatus.Shipped);
                    Console.WriteLine(order);
                    
                    order = orderFactory.Create(stripeCustomer);
                    order.AddProduct(new Product("Product 3", 199.99m));
                    order.SetShippingAddress(new Address("456 Market St", "Los Angeles", "CA", "USA", "90001"));
                    orderRepository.Add(order);
                    // смена статуса
                    order.SetStatus(OrderStatus.Delivered);
                    order.SetStatus(OrderStatus.Shipped);
                    Console.WriteLine(order);
                    
                    order = orderFactory.Create(cardCustomer);
                    order.AddProduct(new Product("Product 4", 29.99m));
                    order.AddProduct(new Product("Product 5", 39.99m));
                    order.SetShippingAddress(new Address("Prospect Pobedy", "Orlov", "Kyrov", "Russia", "612270"));
                    orderRepository.Add(order);
                    // смена статуса
                    order.SetStatus(OrderStatus.Delivered);
                    Console.WriteLine(order);
                }
            }
        }
    }
}