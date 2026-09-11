namespace GuessNumber;

class Program
{
    static Random rnd = new Random();
    static int randomNumberAnswer =rnd.Next(1,51);
    static void Main()
    {
        try
        {
            Console.WriteLine("Guess The number");
            Console.WriteLine("I will get a random number from 1 - 50; you will have to guess: ");
            DisplayMenu();
            while (true)
            {
                string userInputChar = CheckInputChar();
                switch (userInputChar)
                {
                    case "m": DisplayMenu();
                    break;
                    case "g":System.Console.Write("enter Guess: "); int userInputNumber = CheckInputNumber(); 
                    Guess(userInputNumber, randomNumberAnswer);
                    break;
                    case "h": Hint(randomNumberAnswer);
                    break;
                    case "a": ShowAnswer();
                    break;
                    case "x": Environment.Exit(0);
                    break;
                    default: System.Console.WriteLine("enter a vaild option in the menu");
                    break;
                }
                //Guess(randomNumberAnswer, userInputNumber);



            }
        }
        catch(Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
    static int CheckInputNumber()
    {
        int userInput=0;
        while(!int.TryParse(Console.ReadLine(), out userInput))
        {
            System.Console.WriteLine("Skriv ett heltal ");
        }
        if(userInput < 1 || userInput > 50)
        {
            throw new Exception("Skriv in ett heltal mellan 1-50");
            //självklart kan ändra till att användare inte blir utkastad men ser ingen anledning till det
        }
        return userInput;  
    }

    static string CheckInputChar(){
        System.Console.Write("Enter one of the options:");
        while (true)
        { 
            string? userInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(userInput))
            {
                return userInput.ToLower();
            }
            
            System.Console.WriteLine("Please enter a vaild option in the menu");
        }

       
    }

    static void Guess (int userInput, int randomNumberAnswer){
        
        if(randomNumberAnswer == userInput)
        {
            System.Console.WriteLine("you gussed correct"); 
            Environment.Exit(0);
            
        }
        System.Console.WriteLine("Wrong try again");
        
    }

    static void DisplayMenu()
    {
        Console.WriteLine("----Menu----");
        Console.WriteLine("You can enter these numbers at all times");
        Console.WriteLine("Press 'm' to show menu");
        Console.WriteLine("Press 'g' to guess");
        Console.WriteLine("Press 'h' to get hint");
        Console.WriteLine("Press 'a' for answer");
        Console.WriteLine("Press 'x' to Exit the game");
    }
    static int newMin = 1;
    static int newMax = 51;
    static void Hint(int randNumberAnswer)
    {
        while (true)
        {
            int hintRandom = rnd.Next(newMin,newMax);
            if(hintRandom >= randNumberAnswer)
            {
                System.Console.WriteLine($"your number is lower then: {hintRandom}");
                System.Console.WriteLine();
                newMax = hintRandom;
                break;
            }
            System.Console.WriteLine($"your number is bigger then: {hintRandom}");
            System.Console.WriteLine();
            newMin = hintRandom;
            break;
        }
    }

    static void ShowAnswer()
    {
        Console.WriteLine(randomNumberAnswer);

    }
}
