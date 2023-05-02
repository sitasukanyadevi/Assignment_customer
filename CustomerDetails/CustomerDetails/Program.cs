using System;
using System.Security.Cryptography;

namespace CustomerDetails
{
    class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }

        public string City { get; set; }
    }
    class Details
    {
        List<Customer> customers;
        public Details()
        {
            customers = new List<Customer>()
            {
                new Customer{CustomerId=1,FirstName="John",LastName="X",Email="john@gmail.com",Age=36,Phone="6309619958",City="hyd"},
                new Customer{CustomerId=2,FirstName="Stella",LastName="S",Email="stella@gmail.com",Age=29,Phone="6309619957",City="vizag"},
                new Customer{CustomerId=3,FirstName="Sophia",LastName="g",Email="sophia@gmail.com",Age=44,Phone="6309619956",City="chennai"}
            };
        }

        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }
        public int GenerateCustomerId(string firstName, string lastName)
        {
            Random rand = new Random();
            int randomNumber = rand.Next(1, 99);
            return randomNumber;
        }
        public Customer GetCustomer(int id)
        {
            foreach (Customer customer in customers)
            {
                if (customer.CustomerId == id)
                    return customer;
            }
            return null;

        }
        public bool UpdateDetails(int id)
        {
            foreach (Customer cust in customers)
            {
                if (cust.CustomerId == id)
                {
                    Console.WriteLine("Enter the New Details");
                    Console.WriteLine("Enter First Name");
                    cust.FirstName = Console.ReadLine();
                    Console.WriteLine("Enter Last Name");
                    cust.LastName = Console.ReadLine();
                    Console.WriteLine("Enter Email Id: ");
                    cust.Email = Console.ReadLine();
                    Console.WriteLine("Enter Age");
                    cust.Age = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("Enter Phone Number:");
                    string num = Console.ReadLine();
                    if (num.Length != 10)
                    {
                        Console.WriteLine("Invalid Number!! Enter the number again: ");
                        cust.Phone = Console.ReadLine();
                    }
                    Console.WriteLine("Enter City");
                    cust.City = Console.ReadLine();
                    return true;
                }

            }
            return false;
        }
        public List<Customer> GetCustomers()
        {
            return customers;
        }
        public bool DeleteProduct(int id)
        {
            foreach (Customer cust in customers)
            {
                if (cust.CustomerId == id)
                {
                    customers.Remove(cust);
                    return true;
                }
            }
            return false;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Details obj = new Details();
            string ans = "";
            do
            {
                Console.WriteLine("Details of Customers");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Get Customer By Id");
                Console.WriteLine("3. Get All Customer");
                Console.WriteLine("4. Delete Customer By Id");
                Console.WriteLine("5. Update Customer Details");
                int choice = Convert.ToInt16(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter customer firstname");
                            string fname = Console.ReadLine();
                            Console.WriteLine("Enter customer Lastname");
                            string lname = Console.ReadLine();
                            Console.WriteLine("Enter email id:");
                            string email = Console.ReadLine();
                            Console.WriteLine("Enter age of the customer:");
                            int age = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine("Enter phone number of the customer:");
                            string ph = Console.ReadLine();
                            if (ph.Length != 10)
                            {
                                Console.WriteLine("Invalid Number!! Enter the number again: ");
                                ph = Console.ReadLine();
                            }
                            Console.WriteLine("Enter City");
                            string city = Console.ReadLine();
                            int custid = obj.GenerateCustomerId(fname, lname);
                            Console.WriteLine($"Your Customer ID is {custid}");
                            obj.AddCustomer(new Customer() { CustomerId = custid, FirstName = fname, LastName = lname, Email = email, Age = age, Phone = ph, City = city });
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter Customer id ");
                            int id = Convert.ToInt16(Console.ReadLine());
                            Customer? cust = obj.GetCustomer(id);
                            if (cust == null)
                            {
                                Console.WriteLine("Customer with specified id does not exists");
                            }
                            else
                            {
                                Console.WriteLine($" {cust.CustomerId} {cust.FirstName} {cust.LastName} {cust.Email} {cust.Age} {cust.Phone} {cust.City}");
                            }
                            break;
                        }
                    case 3:
                        {
                            foreach (var cust in obj.GetCustomers())
                            {
                                Console.WriteLine($" {cust.CustomerId} {cust.FirstName} {cust.LastName} {cust.Email} {cust.Age} {cust.Phone} {cust.City}");
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter Customer id:");
                            int id = Convert.ToInt16(Console.ReadLine());
                            if (obj.DeleteProduct(id))
                            {
                                Console.WriteLine("customer deleted successfully");
                            }
                            else
                            {
                                Console.WriteLine("Customer with specified id does not exist");
                            }

                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Enter Customer ID");
                            int id = Convert.ToInt16(Console.ReadLine());
                            if (obj.UpdateDetails(id))
                            {
                                Console.WriteLine("Customer Detail Updated Successfully!!");
                            }
                            else
                            {
                                Console.WriteLine("Customer with specified id does not exist");
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid choice!!!!");
                            break;
                        }

                }
                Console.WriteLine("Do you wish to continue?[y/n");
                ans = Console.ReadLine();
            }
            while (ans.ToLower() == "y");
        }

    }

}