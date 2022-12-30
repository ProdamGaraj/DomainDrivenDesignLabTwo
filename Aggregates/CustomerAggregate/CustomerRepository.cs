using MyApp.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp.CustomerAggregate;

/// <summary>
/// Репозиторий для хранения данных в памяти
/// </summary>
public class CustomerRepository : IDisposable
{
    private List<Customer> _customers;

    public CustomerRepository()
    {
        _customers = new List<Customer>();
    }

    public void Add(Customer customer)
    {
        _customers.Add(customer);
    }

    public Customer Get(string id)
    {
        return _customers.FirstOrDefault(c => c.Id == id);
    }

    public IEnumerable<Customer> GetAll()
    {
        return _customers.Where(c => c.Deleted != true);
    }

    public void MarkAsDeleted(Customer customer)
    {
        customer.Deleted = true;
        Update(customer);
    }

    public void Delete(Customer customer)
    {
        _customers.Remove(customer);
    }

    public void Update(Customer customer)
    {
        var existingCustomer = _customers.FirstOrDefault(c => c.Id == customer.Id);
        if (existingCustomer != null)
        {
            existingCustomer = customer;
        }
    }

    public void Dispose()
    {
        
    }
}
