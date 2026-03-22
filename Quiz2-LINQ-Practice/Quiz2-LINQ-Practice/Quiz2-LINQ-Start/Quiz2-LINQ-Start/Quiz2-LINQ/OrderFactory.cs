using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz2_LINQ;

public class OrderFactory
{
    private readonly Random random = new Random(50);

    public Order CreateRandomOrder(List<Employee> employees, List<Customer> customers)
    {
        int totalItems = random.Next(1, 25); // Random number of items between 1 and 25
        decimal totalAmount = (decimal)(random.NextDouble() * 5000); // Random total amount up to 5000
        DateTime orderDate = GenerateRandomDate();

        Customer customer = customers[random.Next(customers.Count)];
        Employee salesRep = employees[random.Next(employees.Count)];

        return new Order
        {
            TotalItems = totalItems,
            TotalAmount = totalAmount,
            OrderDate = orderDate,
            Customer = customer,
            SalesRep = salesRep
        };
    }

    public List<Order> CreateRandomOrders(int count, List<Employee> employees, List<Customer> customers)
    {
        List<Order> orders = new List<Order>();
        for (int i = 0; i < count; i++)
        {
            orders.Add(CreateRandomOrder(employees,customers));
        }
        return orders;
    }
    private DateTime GenerateRandomDate()
    {
        DateTime start = new DateTime(2010, 1, 1);
        int range = (DateTime.Today - start).Days;
        return start.AddDays(random.Next(range));
    }
}
