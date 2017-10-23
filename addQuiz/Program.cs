using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace addQuiz
{
    class Program
    {
        public static string playerName;
        public static int score =0;


        public static int firstNumber = 0;
        public static int secondnumber = 0;
        public static int opKey;
        public static string equation = "";
        public static int response = 0;
        public static int eqAnswer = 0;

        public static Dictionary<int, string> dRandomOp = new Dictionary<int, string>();
     

        public static void Main(string[] args)
        {

            //populate dictionary with operators

            dRandomOp.Add(1, "+");
            dRandomOp.Add(2, "-");
            dRandomOp.Add(3, "*");
            dRandomOp.Add(4, "/");
            //create opening line and menu

            Console.WriteLine("Welcome to the Crafter Math Assessment Quiz!\n"+
            "Please Enter Your Name: ");
            playerName= Console.ReadLine();


            //loop through all of the questions
            int i = 0;
            while (i < 5)
            {
                createCalculator();
                Console.WriteLine(equation);

                //make sure the input is valid
                var input = Console.ReadLine();
                
                while(!int.TryParse(input,out response))
                    {
                    Console.WriteLine("Invalid Input --Please resubmit.");
                    input = Console.ReadLine();
                  
                }
                evaluateAnswer();
                i++;
            }

            Console.WriteLine($"Quiz Summary: Score--{score}");
            Console.WriteLine("Press ENTER to EXIT");
            Console.ReadLine();
            Environment.Exit(0);
            
          

        }

        //createCalculator
        public static void createCalculator()
        {
            eqAnswer = 0;
            string dValue;
            Random rNumber = new Random();
            firstNumber=rNumber.Next(0, 100);
            secondnumber= rNumber.Next(0, 100);
            opKey = rNumber.Next(1, 4);

            //get operator value
           if( dRandomOp.TryGetValue(opKey, out dValue))
            {
                //use switch to build equation
                switch(opKey)
                {
                    case 1:
                    equation = $"What is {firstNumber} + {secondnumber}?";
                        eqAnswer = firstNumber + secondnumber;
                        break;
                    case 2:
                        equation = $"What is {firstNumber} - {secondnumber}?";
                        eqAnswer = firstNumber - secondnumber;
                        break;
                    case 3:
                        equation = $"What is {firstNumber} * {secondnumber}?";
                        eqAnswer = firstNumber * secondnumber;
                        break;
                    case 4:
                        equation = $"What is {firstNumber} / {secondnumber}?";
                        eqAnswer = firstNumber / secondnumber;
                        break;
                    default:
                        equation = "I do not know";
                        break;

                }
            }


        }


        //storePlayerStats

        //evaluateAnswer
        public static void evaluateAnswer()
        {
            if (response == eqAnswer)
            {
                Console.WriteLine("You are correct!");
                score++;
               // Console.ReadLine();

            }
            else
            {
                Console.WriteLine("Sorry, that is not the right answer");
               // Console.ReadLine();
                
            }
        }

    }
}
