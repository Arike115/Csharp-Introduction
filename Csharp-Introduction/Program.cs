using Csharp_Introduction;
using System.Data.SqlTypes;
using System.Linq;

var cust = new List<Customer> 
{ 
    new Customer{Id = 1, Name = "Bob"},
    new Customer{Id = 2, Name = "Shola"},
    new Customer{Id = 3, Name = "Grace"},
    new Customer{Id = 4, Name = "Gift"},

};

var orders = new List<Order> 
{
    new Order {OrderId = 101, OrderName ="Spag", CustomerId = 1} ,
    new Order {OrderId = 102, OrderName ="Rice", CustomerId = 3},
    new Order {OrderId = 103, OrderName ="yam", CustomerId = 2},
    new Order {OrderId = 104, OrderName ="Grains", CustomerId = 2},
    new Order {OrderId = 105, OrderName ="Bread", CustomerId = 3},
    new Order {OrderId = 106, OrderName ="Chocolate"}
};

//query syntax
var leftjoin = from sale in orders //left data
               join client in cust //right data
               on sale.CustomerId equals client.Id
               into ordergroup
               from value in ordergroup.DefaultIfEmpty()
               select new {sale, Name = value == null ? "N/A" : value.Name};


//method syntax
var leftjoinmethod = orders.GroupJoin(cust,
                        sale => sale.CustomerId,
                        client => client.Id,
                        (sale, client) => new {sale, client}
                        ).SelectMany( x => x.client.DefaultIfEmpty(),
                         (sale, client) => new 
                         {
                             sale?.sale?.OrderName,
                             sale?.sale?.OrderId,
                             client?.Name
                         
                         }
                        );


var rightjoinmethod = cust.GroupJoin(orders,
                        client => client.Id,
                        sale => sale.CustomerId,
                        (client, sale) => new { client, sale }
                        ).SelectMany(x => x.sale.DefaultIfEmpty(),
                         (client, sale) => new 
                         {
                             sale?.OrderName,
                             sale?.OrderId,
                             client?.client?.Name
                         }
                        );


var fullouterjoinmethod = leftjoinmethod.Union(rightjoinmethod);
foreach (var item in fullouterjoinmethod)
{
    Console.WriteLine($"OrderName: {item.OrderName} === CustomerName:{item.Name}");
}














////join(inner join) query syntax
//var result = from client in cust
//             join sale in orders on client.Id equals sale.CustomerId
//             select new { client.Name, sale.OrderName };

//method syntax

//var results = cust.Join(orders,
//                client => client.Id,
//                sale => sale.CustomerId,
//                (client, sale) => new
//                {
//                    client.Name,
//                    sale.OrderName
//                });



//foreach (var item in results)
//{
//    Console.WriteLine($"Customer: {item.Name} ===== OrderName {item.OrderName}");
//}