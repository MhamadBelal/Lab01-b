namespace Lab01_b
{
    public class Program
    {
        //Main method
        static void Main(string[] args)
        {

            try
            {
                StartSequence();
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.ToString() +" ,please try to correct it.");
            }
            finally
            {
                Console.WriteLine("Program is completed.");
            }
            Console.ReadLine();
        }

        //StartSequence method
        /// <summary>
        /// it takes an array and then do some operation and then show results.
        /// </summary>
        static void StartSequence()
        {
            try
            {
                Console.WriteLine("Welcome to my game! Let's do some math!");
                Console.WriteLine("Please enter a number greater than Zero");
                int number = Convert.ToInt32(Console.ReadLine());
                int[] arr = new int[number];
                arr = Populate(arr);
                int sum = GetSum(arr);
                int product = GetProduct(arr, sum);
                decimal quotient = GetQuotient(product);
                Console.WriteLine("Your array is size: " + arr.Length);
                Console.Write("The numbers in the array are ");
                for (int i = 0; i < arr.Length; i++)
                {
                    if (i == arr.Length - 1)
                        Console.WriteLine(arr[i]);
                    else
                        Console.Write(arr[i] + ",");
                }
                Console.WriteLine("The sum of the array is " + sum);
                Console.WriteLine(sum + " * " + (product / sum) + " = " + product);
                Console.WriteLine(product + " / " + (int)(product / quotient) + " = " + quotient);
            }
            catch(FormatException ex)
            {
                Console.WriteLine("Invalid input format. Please enter a valid integer.");
                Console.WriteLine("Exception message: " + ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Number entered is too large or too small.");
                Console.WriteLine("Exception message: " + ex.Message);
            }
        }


        //Populate method
        /// <summary>
        /// this will let th user to fill the array
        /// </summary>
        static int[] Populate(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Please enter number: " + (i + 1)+" of "+arr.Length);
                string input= Console.ReadLine();
                arr[i] = Convert.ToInt32(input);
            }
            return arr;
        }


        //GetSum method
        /// <summary>
        /// this will calculate the sum of the array
        /// </summary>
        static int GetSum(int[] arr)
        {
            int sum=0;
            for (int i = 0; i < arr.Length; i++)
                sum += arr[i];
            if (sum < 20)
                throw new Exception($"Value of {sum} is too low");

            return sum;
        }


        //GetProduct method
        /// <summary>
        /// get the sum * arr[number -1]
        /// </summary>
        static int GetProduct(int[] arr, int sum)
        {
            Console.WriteLine("Please select a randon number between 1 and "+arr.Length);
            int number=Convert.ToInt32(Console.ReadLine());
            if (number < 1 || number > arr.Length)
            {
                throw new IndexOutOfRangeException("Invalid random number selected.");
            }
            int product = sum * arr[number - 1];
            return product;

        }

        //GetQuotient method
        /// <summary>
        /// divide the product with a number for the user
        /// </summary>
        static decimal GetQuotient(int product)
        {
            try
            {
                Console.WriteLine("Please enter a number to divide your product " + product + " by");
                int dividend = Convert.ToInt32(Console.ReadLine());
                if (dividend == 0)
                {
                    throw new DivideByZeroException("Cannot divide by zero.");
                }
                decimal quotient = decimal.Divide(product, dividend );
                return quotient;
            }
            catch(DivideByZeroException ex) 
            {
                Console.WriteLine("Error: " + ex.Message);
                return 0;
            }
            
        }

    }
}