using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz2_LINQ;

public class Employee
{
    public string Name { get; set; }
    public Address Address { get; set; }
    public string EmployeeID { get; private set; }
    public string Email { get; set; }
    public DateTime HireDate { get; set; }
    public Department Department { get; set; }
    public Employee()
    {
        
    }
    public Employee(string name, Address address, string email, DateTime hiredate, Department department)
    {
        Name = name;
        Address = address;
        EmployeeID = email.Split('@',3)[0] + hiredate.Year + hiredate.Nanosecond;
        Email = email;   
        Department = department;
        HireDate = hiredate;
    }
    public override string ToString()
    {
        return Name;
    }
}
public class Customer
{
    public string Name { get; set; }
    public Address Address { get; set; }
    public int CustomerID { get;  set; }
    public Employee SalesRep { get; set; }
    public List<Order> Orders { get; set; }

    public Customer()
    {

    }
    public Customer(string name, Address address, Employee salesRep) 
    {
        Name = name;
        Address = address;
        SalesRep = salesRep;

    }

    public override string ToString()
    {
        return Name;
    }
}

public class Address
{
    public int AddressID { get; set; }
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Province { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"{Street}, {City}";
    }

}
public enum Department
{
    IT,
    Marketing,
    Sales,
    Finance,
    HR
}
