using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DL;

namespace ConsoleGUI
{
    public class TransactionScript
    {
        BLUser bluser = new BLUser();
        BLProduct blproduct = new BLProduct();
        BLOrder bLOrder = new BLOrder();
        OrderDetailBL odBL = new OrderDetailBL();
        string username = "";
        string password = "";
        private User InitUser() {
            Console.WriteLine("Enter User name:");
            username = Console.ReadLine();
            Console.WriteLine("Enter Password:");
            password = Console.ReadLine();
            User user = new User(username, password);
            return user;    
        }

        private int getProductData() {
            foreach (ProductDTO p in blproduct.GetAllProduct())
            {
                Console.WriteLine("ProductID:" + p.ProductId);
                Console.WriteLine("Product Name:" + p.Name);
                Console.WriteLine("Description: " + p.Description);
                Console.WriteLine("Quantity: " + p.Quantity);
                Console.WriteLine("Price: " + p.Price);
                Console.WriteLine("------------------------------");
            }
            Console.WriteLine("Choose your Item by ID");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            return id;
        }

        private string AddOrder(int productId)
        {
            int userId = bluser.getUserId(username);
            DateTime date = DateTime.Now;
            decimal price = blproduct.getPricebyID(productId);
            string orderNumber = bLOrder.generateOrderNumber(userId, productId, date);
            OrderDTO order = new OrderDTO(userId, date, price, orderNumber);
            if (blproduct.quantityDecrease(productId) == -1)
            {
                return "Out of stock.";
            }
            else {
                string productName = blproduct.getProductName(productId);
                bLOrder.addOrder(order);
                int orderId = bLOrder.getOrderid(orderNumber);
                OrderDetailDTO orderDetail = new OrderDetailDTO(orderId, productId, userId, productName, price);
                odBL.addOrderDetail(orderDetail);
            }
            

            return $"Order placed successfully!\nOrder Number: {orderNumber}";
        }

        public void Run()
        {
            User user = InitUser();
            Console.Clear();
            if (bluser.checkLogin(user) == null)
            {
                Console.WriteLine("username or password errors");
            }
            else
            {
                bool shopping = true;
                while (shopping) {
                    int productid = getProductData();
                    string result = AddOrder(productid);
                    Console.WriteLine(result);
                    Console.WriteLine("Choose next action:");
                    Console.WriteLine("1. Continue Shopping");
                    Console.WriteLine("2. See Orders");
                    Console.WriteLine("3. Exit");

                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            break;
                        case 2:
                            Console.Clear();
                            List<OrderDTO> orders = bLOrder.GetAllOrder();
                            if (orders.Count == 0)
                            {
                                Console.WriteLine("No orders found.");
                            }
                            else
                            {
                                foreach (var order in orders)
                                {
                                    Console.WriteLine($"OrderID: {order.id}");
                                    Console.WriteLine($"UserID: {order.userId}");
                                    Console.WriteLine($"OrderDate: {order.date}");
                                    Console.WriteLine($"TotalAmount: {order.totalAmount}");
                                    Console.WriteLine($"OrderNumber: {order.orderNumber}");
                                    Console.WriteLine("------------------------------");
                                }
                            }
                            Console.WriteLine("Press any key to return to the product list...");
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.WriteLine("Thank you for shopping!");
                            shopping = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please choose between 1 and 3.");
                            break;
                    }
                }
            }
        }


    }
}
