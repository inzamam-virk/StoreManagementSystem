using System;
using System.IO;
namespace OOP_Project
{
    class Product
    {
        protected string name;
        protected string Cat;
        protected int price;
        protected int Quantity;
        protected int MinStock;

        public void ShowHeader()
        {
            Console.WriteLine( "*********************************************\n"
                             + "           Store Management System           \n"
                             + "*********************************************\n");
        }

        public int ShowMenu()
        {

            Console.WriteLine("Enter your Choice from 1 to 6 :\n1. Add Product\n2. To Purchase Product\n3. To View Customers\n4. View All Products\n" +
                "5. Find Product With Highest Unit Price\n6. View Sales Tax of All Products\n7. Products to be Order\n8. Exit");
            return int.Parse(Console.ReadLine());
        }

        public void ShowSubHeader(string x)
        {
            Console.WriteLine(x+"\n --------------------------------------");
        }

        public Product AddProduct()
        {
            Product obj = new Product();
            Console.WriteLine("Enter the name of the product :");
            obj.name = Console.ReadLine();
            Console.WriteLine("Enter the Catagory of the product :");
            obj.Cat = Console.ReadLine();
            Console.WriteLine("Enter the price of the product :");
            obj.price = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Quantitiy of the product :");
            obj.Quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Minimum stock quantity of the product :");
            obj.MinStock = int.Parse(Console.ReadLine());
            string path =("C://Users//extra//OneDrive//Desktop//Week 2 Lab (Object project OOP)//Object project OOP//file.txt");
            string[] stri = { obj.name + " " + obj.Cat + " " + obj.price + " " + obj.Quantity + " " + obj.MinStock };
            File.AppendAllLines(path, stri);
            Console.WriteLine("Product Added succesfully...");
            return obj;

        }

        public void ViewProduct()
        {
            string path = ("C://Users//extra//OneDrive//Desktop//Week 2 Lab (Object project OOP)//Object project OOP//file.txt");
            string[] prod = File.ReadAllLines(path);
            Console.WriteLine("Product      Catagory    Price    Stock    MinStock");

            foreach(string l in prod)
            {
                string[] col = l.Split(" ");
                Console.WriteLine(col[0] + "        " + col[1] + "       " + int.Parse(col[2]) + "        " + int.Parse(col[3]) + "        " + int.Parse(col[4]));
            }

        }

        public void GetHighPriceProduct()
        {
            string path = ("C://Users//extra//OneDrive//Desktop//Week 2 Lab (Object project OOP)//Object project OOP//file.txt");
            string[] prod = File.ReadAllLines(path);
            int pricee = 0;
            string productt = "";
            foreach(string l in prod)
            {
                string[] col = l.Split(" ");
                if (int.Parse(col[2]) > pricee)
                {
                    pricee = int.Parse(col[2]);
                    productt = col[0];
                }
            }
            Console.WriteLine("Product with highest price is :"+productt );
        }

        public void CalculateTax()
        {
            string path = ("C://Users//extra//OneDrive//Desktop//Week 2 Lab (Object project OOP)//Object project OOP//file.txt");
            string[] prod = File.ReadAllLines(path);
            double tax =0,taxx=0.05;
            foreach(string l in prod)
            {
                string[] col = l.Split(" ");
                tax = tax + int.Parse((col[2])) * (taxx);
            }
            Console.WriteLine("Sales tax on all products is : "+tax);
        }
        public void ProductToBeOrder(Product[] arr,int x)
        {
            string path = ("C://Users//extra//OneDrive//Desktop//Week 2 Lab (Object project OOP)//Object project OOP//file.txt");
            string[] prod = File.ReadAllLines(path);
            int y = 0;
            Console.WriteLine("Product     Catagory     Threshold     To Be Order");
            foreach(string l in prod)
            {
                string[] col = l.Split(" ");
                if (int.Parse(col[3]) <int.Parse( col[4]))
                {
                    y = 1;
                }
                else
                {
                    y = 0;
                }
                Console.WriteLine(col[0] + "       " + col[1] + "         " + col[4] + "             " + y);
            }
        }
    }

    class CusPurchase : Product
    {
        static string CusName;
        static int CusQuantity;
        static int PhoneNo;
        static int CusPrice;
        public void CusDetails()
        {
            Console.WriteLine("Enter the Name of Product :");
            name = Console.ReadLine();
            Console.WriteLine("Enter the Name of Customer :");
            CusName = Console.ReadLine();
            Console.WriteLine("Enter the Phone No of Customer :");
            PhoneNo = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Quantity to purchase :");
            CusQuantity = int.Parse(Console.ReadLine());
            UpdateDetails();
            string path = ("C://Users//extra//OneDrive//Desktop//Week 2 Lab (Object project OOP)//Object project OOP//Details.txt");
            string[] str = { CusName + " " + name + " " + PhoneNo + " " + CusPrice };
            File.AppendAllLines(path, str);
        }
        public void UpdateDetails()
        {
            string path = ("C://Users//extra//OneDrive//Desktop//Week 2 Lab (Object project OOP)//Object project OOP//file.txt");
            string[] prod = File.ReadAllLines(path);
            foreach (string l in prod)
            {
                string[] col = l.Split(" ");
                if (name == col[0])
                {
                    CusPrice = CusQuantity * int.Parse(col[2]);
                    int n = int.Parse(col[3]) - CusQuantity;
                    using(System.IO.StreamWriter file = new System.IO.StreamWriter(col[3]))
                    {
                        file.WriteLine(n.ToString());
                    }
                    Console.WriteLine("Total Bill is " + CusPrice);

                }
            }
        }
        public void ViewDetails()
        {
            string path = ("C://Users//extra//OneDrive//Desktop//Week 2 Lab (Object project OOP)//Object project OOP//Details.txt");
            string[] prod = File.ReadAllLines(path);
            Console.WriteLine("Customer      Product     PhoneNo        Bill");

            foreach (string l in prod)
            {
                string[] col = l.Split(" ");
                Console.WriteLine(col[0] + "        " + col[1] + "       " + int.Parse(col[2]) + "        " + int.Parse(col[3]));
            }
        }
    }

    class drive
    {
        static void Main(string[] args)
        {
            CusPurchase obj1 = new CusPurchase();
            int a = obj1.ShowMenu();
            int w = 0;
            Product[] arr = new Product[w];
            if (a == 1)
            {
                obj1.ShowHeader();
                obj1.ShowSubHeader("Add Product");
                obj1.AddProduct();
                Main(args);
            }
            else if (a == 2)
            {
                obj1.ShowHeader();
                obj1.ShowSubHeader("Customer Interface");
                obj1.CusDetails();
                Main(args);
            }
            else if (a == 3)
            {
                obj1.ShowHeader();
                obj1.ShowSubHeader("Customers Details");
                obj1.ViewDetails();
                Main(args);
            }
            else if (a == 4)
            {
                obj1.ShowHeader();
                obj1.ShowSubHeader("View Products");
                obj1.ViewProduct();
                Main(args);
            }
            else if (a == 5)
            {
                obj1.ShowHeader();
                obj1.ShowSubHeader("Get the product with highest price ");
                obj1.GetHighPriceProduct();
                Main(args);
            }
            else if (a == 6)
            {
                obj1.ShowHeader();
                obj1.ShowSubHeader("View sales tax");
                obj1.CalculateTax();
                Main(args);
            }
            else if (a == 7)
            {
                obj1.ShowHeader();
                obj1.ShowSubHeader("Products to be ordered ");
                obj1.ProductToBeOrder(arr, w);
                Main(args);
            }
            else if (a == 8)
            {
                Console.WriteLine("Thank You ,Have a niice day!");
                return;
            }
        }
    }
}
