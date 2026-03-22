using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz2_LINQ;

public class Order
{
    public int OrderID { get; set; }
    public int TotalItems {  get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime OrderDate { get; set; }

    public Customer Customer { get; set; }
    public Employee SalesRep { get; set; }

    public override string ToString()
    {
        return $"OrderID: {OrderID} \n" +
            $"TotalItems: {TotalItems} \n" +
            $"TotalAmount: {TotalAmount:c} \n" +
            $"OrderDate: {OrderDate.ToShortDateString()} \n" +
            $"Customer: {Customer.Name}, " +
            $"Sales Rep: {SalesRep.EmployeeID}";
    }
}
