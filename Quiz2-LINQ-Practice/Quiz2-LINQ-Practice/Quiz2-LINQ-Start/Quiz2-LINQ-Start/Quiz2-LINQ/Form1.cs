using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.NativeInterop;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Quiz2_LINQ
{
    public partial class Form1 : Form
    {
        Context context;
        public Form1()
        {
            InitializeComponent();
            context = new Context();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            if (context.Customers.Count() == 0)
                AddContentToDataBase();
        }
        private void CallQuery1() //2 Marks
        {
            // 1. Get All Customers in a Specific City - Montreal
            // Sort by salesrep name
            var query1 = context.Customers
                .Where(c => c.Address.City == "Montreal")
                .OrderBy(c => c.SalesRep.Name);



            dgvQueryOutput.DataSource = query1.ToList();
            txtQuery.Text = query1.ToQueryString();
        }
        private void CallQuery2() //3 Marks
        {
            // 2. Find All Orders for sales rep Aaron Miller
            // that the total amount is at least 3500.
            // Sort by the total amount with the highest at the top

            var query2 = context.Orders
                .Where(o => o.SalesRep.Name == "Aaron Miller" && o.TotalAmount >= 3500)
                .OrderByDescending(o => o.TotalAmount);

            dgvQueryOutput.DataSource = query2.ToList();
            txtQuery.Text = query2.ToQueryString();
        }
        private void CallQuery3() //1 Marks
        {
            // 3. Find all Employees who work in HR
            //Hint: Department is an enumerated list. You must refer to it using Department.name
            // Substitute the name for the department name
            var query3 = context.Employees
                .Where(e => e.Department ==  Department.HR);

            dgvQueryOutput.DataSource = query3.ToList();
            txtQuery.Text = query3.ToQueryString();
        }
        private void CallQuery4() //2 Marks
        {
            DateTime searchDate = new DateTime(2022, 05, 21);
            // 4. Find All Orders Placed after the search date given
            // order by date oldest at the top
            var query4 = context.Orders
                .Where(o => o.OrderDate > searchDate)
                .OrderBy(o => o.OrderDate);

            dgvQueryOutput.DataSource = query4.ToList();
            txtQuery.Text = query4.ToQueryString();
        }
        private void CallQuery5() //2 Marks
        {
            //5. Find Customers without any orders
            var query5 = context.Customers
                .Where(c => c.Orders.Count == 0);

            dgvQueryOutput.DataSource = query5.ToList();
            txtQuery.Text = query5.ToQueryString();
        }
        private void CallQuery6() //3 Marks
        {
            // 6. Find All Orders Placed more than three years ago 
            // or customer id is 25
            // Hint: Method DateTime.Now.AddYears or store the date.
            // Sort by date with latest at the top
            var query6 = context.Orders
                .Where(c => c.OrderDate < DateTime.Now.AddYears(-3) || c.Customer.CustomerID == 25)
                .OrderByDescending(c => c.OrderDate);

            dgvQueryOutput.DataSource = query6.ToList();
            txtQuery.Text = query6.ToQueryString();
        }
        private void CallQuery7() //3 Marks
        {
            // 7. Find Customers with More than 4 Orders
            // Displaying their name, Address, and how many orders they have
            // Order by Count descending, then by Name ascending
            var query7 = context.Customers
                .Where(c => c.Orders.Count > 4)
                .OrderByDescending(c => c.Orders.Count)
                .ThenBy(c => c.Name)
                .Select(c => new
                {
                    c.Name,
                    c.Address,
                    c.Orders.Count
                });
  
            dgvQueryOutput.DataSource = query7.ToList();
            txtQuery.Text = query7.ToQueryString();
        }
        private void CallQuery8() //4 Marks
        {
            // 8. Calculate the Total Sales Amount and Average Sale
            // by Each Sales Rep Name
            var query8 = context.Orders
                .GroupBy(o => o.SalesRep.Name)
                .Select(group => new
                {
                    SalesRep = group.Key,
                    TotalSales = group.Sum(o => o.TotalAmount),
                    AvgSale =  group.Average(o => o.TotalAmount)
                });
 
            dgvQueryOutput.DataSource = query8.ToList();
            txtQuery.Text = query8.ToQueryString();
        }
        private void CallQueryBonus() // 3 marks
        {
            // Bonus: Find the first two order records that
            // the salesrep is emma johnson with total amount less than 1000
            var bonusQuery = context.Orders;

            dgvQueryOutput.DataSource = bonusQuery.ToList();
            txtQuery.Text = bonusQuery.ToQueryString();
        }
        private void cboQuerySelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboQuerySelector.SelectedIndex >= 0)
            {
                SelectQuery();
                dgvQueryOutput.AutoResizeColumns();
                lblNumberOfRecords.Text = dgvQueryOutput.RowCount.ToString();
            }
        }
        private void SelectQuery()
        {
            switch (cboQuerySelector.SelectedIndex)
            {
                case 0:
                    CallQuery1();
                    break;
                case 1:
                    CallQuery2();
                    break;
                case 2:
                    CallQuery3();
                    break;
                case 3:
                    CallQuery4();
                    break;
                case 4:
                    CallQuery5();
                    break;
                case 5:
                    CallQuery6();
                    break;
                case 6:
                    CallQuery7();
                    break;
                case 7:
                    CallQuery8();
                    break;
                default:
                    CallQueryBonus();
                    break;
            }
        }

        private void AddContentToDataBase()
        {
            //creating our factories to add people and orders
            PeopleFactory pf = new PeopleFactory();
            OrderFactory of = new OrderFactory();

            //adding 60 Employees to the database
            context.Employees.AddRange(pf.AddEmployeeUsers(60));
            context.SaveChanges();

            //Adding 80 Customers to the database, providing a list of employees (specifically in Sales)
            context.Customers.AddRange(pf.AddCustomerUsers(120,
               context.Employees.Where(e => e.Department == Department.Sales).ToList()));
            context.SaveChanges();

            //Adding 275 Orders to the database, proving a list of Sales employees and
            //a list of all Customers.
            context.Orders.AddRange(of.CreateRandomOrders(300,
                context.Employees.Where(e => e.Department == Department.Sales).ToList(),
                context.Customers.ToList()));
            context.SaveChanges();
        }
    }
}
