using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz2_LINQ;

public class PeopleFactory
{
    private readonly Random random = new Random(50);
    public List<Employee> AddEmployeeUsers(int numberOfUsers)
    {
        List<Employee> users = new List<Employee>();
        for (int i = 0; i < numberOfUsers; i++)
        {
            users.Add(CreateEmployeeUser());
        }
        return users;
    }
    public List<Customer> AddCustomerUsers(int numberOfUsers, List<Employee> salesReps)
    {
        List<Customer> users = new List<Customer>();
        for (int i = 0; i < numberOfUsers; i++)
        {
            users.Add(CreateCustomerUser(salesReps[random.Next(salesReps.Count)]));
        }
        return users;
    }

    public Employee CreateEmployeeUser()
    {
        string name = GenerateRandomName();
        Address address = GenerateRandomAddress();
        string email = $"{name.ToLower().Replace(" ", ".")}@email.com";
        DateTime hireDate = GenerateRandomDate();
        Department department = GenerateRandomDepartment();

        return new Employee(name, address, email, hireDate, department);
    }
    public Customer CreateCustomerUser(Employee salesRep)
    {
        string name = GenerateRandomName();
        Address address = GenerateRandomAddress();

        return new Customer(name, address, salesRep);
    }

    private string GenerateRandomName()
    {
        string[] firstNames = { "John", "Emma", "Michael", "Sophia", "James", "Olivia", "Robert", "Ava", "William", "Isabella", "Heather", "Nancy", "David", "Aaron", "Cathy", "Margaret", "Chris" };
        string[] lastNames = { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor", "Mitchell","Burchill","Caldwell","MacDonald", "London", "Sanderson" };
        string firstName = firstNames[random.Next(firstNames.Length)];
        string lastName = lastNames[random.Next(lastNames.Length)];
        return $"{firstName} {lastName}";
    }

    private Address GenerateRandomAddress()
    {
        //some arrays to hold address data to pick from
        string[] streets = { "Main Street", "Fake Street", "Awesome Boulevard", "Another Lane", "Real Road", "Some Place" };
        string[] provinces = { "BC", "AB", "MB", "SK", "ON", "QC", "PE", "NB", "NS", "NL" };
        string[] cities = { "Vancouver", "Victoria", "Kelowna", "Calgary", "Edmonton", "Red Deer", "Winnipeg", "Brandon", "Springfield", "Saskatoon","Regina","Prince Albert", "Toronto","Ottawa","Mississauga", "Montreal", "Quebec City","Laval", "Charlottetown", "Summerside","Cavendish", "Saint John", "Moncton","Fredericton", "Halifax", "Sydney", "Truro", "St.John's", "Cornerbrook", "Labrador City" };
        //getting a random street number with a random street from the array
        string street = random.Next(0, 3000) + " " + streets[random.Next(streets.Length)];
        //The Cities and provinces here are arranged in a logical order so we just use one random
        //number so we get a city that is in the correct province
        int city_province = random.Next(provinces.Length);
        string city = cities[random.Next(city_province * 3, city_province * 3 + 2)];
        string province = provinces[city_province];
        //separate method call to generate the more involved Postal Code
        string postalCode = GenerateRandomPostalCode();

        return new Address { Street = street, City = city, Province = province, PostalCode = postalCode };
    }
    private string GenerateRandomPostalCode()
    {
        string postalCode = "";
        for (int i = 0; i < 6; i++)
        {
            if (i % 2 == 0)
            {
                // Generate a random uppercase letter
                postalCode += (char)('A' + random.Next(26));
            }
            else
            {
                // Generate a random digit
                postalCode += random.Next(10);
            }
            if (i == 2) postalCode += " ";
        }
        return postalCode;
    }


    private DateTime GenerateRandomDate()
    {
        DateTime start = new DateTime(2010, 1, 1);
        int range = (DateTime.Today - start).Days;
        return start.AddDays(random.Next(range));
    }

    private Department GenerateRandomDepartment()
    {
        Array values = Enum.GetValues(typeof(Department));
        return (Department)values.GetValue(random.Next(values.Length))!;
    }
}  
