using System;

namespace CoffeeShopApp
{
   
    public class InvalidCoffeeSizeException : Exception
    {
        public InvalidCoffeeSizeException(string message) : base(message) { }
    }

    public class InvalidPaymentAmountException : Exception
    {
        public InvalidPaymentAmountException(string message) : base(message) { }
    }

    public class CoffeeShop
    {
        
        public string CoffeeSize { get; set; }
        public double PaymentAmount { get; set; }

        public void ProcessOrder()
        {
            try
            {
               
                if (string.IsNullOrWhiteSpace(CoffeeSize) ||
                    !(CoffeeSize.Equals("Small", StringComparison.OrdinalIgnoreCase) ||
                      CoffeeSize.Equals("Medium", StringComparison.OrdinalIgnoreCase) ||
                      CoffeeSize.Equals("Large", StringComparison.OrdinalIgnoreCase)))
                {
                    throw new InvalidCoffeeSizeException("Invalid coffee size. Valid sizes are Small, Medium, or Large.");
                }

                
                if (PaymentAmount <= 0)
                {
                    throw new InvalidPaymentAmountException("Invalid payment amount. The amount must be greater than zero.");
                }

                Console.WriteLine($"Order placed successfully! Coffee Size: {CoffeeSize}, Payment Amount: ${PaymentAmount:F2}");
            }
            catch (InvalidCoffeeSizeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (InvalidPaymentAmountException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CoffeeShop coffeeShop = new CoffeeShop();

            try
            {
                Console.WriteLine("Enter Coffee Size (Small, Medium, Large):");
                coffeeShop.CoffeeSize = Console.ReadLine();

                Console.WriteLine("Enter Payment Amount:");
                coffeeShop.PaymentAmount = double.Parse(Console.ReadLine());

                coffeeShop.ProcessOrder();
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid input format. Please enter numeric values for the payment amount.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            Console.Read();
        }
    }
}
