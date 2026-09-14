namespace GuessNumber;

class Program
{
    static Random rnd = new Random(); //Skapar en kopia/instans classen random och spara i variable rnd
    static int randomNumberAnswer =rnd.Next(1,51); // sätter classens slumpade värde i int randomNumberAnswer
    static void Main()
    {
        try // om något skulle bli fel hanterar vi det
        {
            Console.WriteLine("Guess The number");
            Console.WriteLine("I will get a random number from 1 - 50; you will have to guess: "); // text som bara körs en gång för att vissa att splet är igång
            DisplayMenu(); // simple method för att vissa meny 
            while (true) // en while function för att användare själv ska kunna välja när programet avlsutats
            {
                string userInputChar = CheckInputChar(); // Spara värdet från CheckInputChar i userInputChar -CHC är en method som kollar att användaren har skickat in ett giltligt nummer
                switch (userInputChar) // startar switch case där användarens input används för att avgöra vilket case vi ska till
                {
                    case "m": DisplayMenu(); // Visar upp menyn 
                    break;
                    case "g":System.Console.Write("enter Guess: "); // visar användaren att det är dags att skicka in ett värde
                    int userInputNumber = CheckInputNumber(); // spara in värdet vi får ut från checkinputnumber(en funktion som kollar så värdet användare skickar in är korrekt)
                    Guess(userInputNumber, randomNumberAnswer); // skickar in det värdet som användaren skrivit in samt det slumpade värdet som är tillgängligt överallt in i methoden Guess
                    break;
                    case "h": Hint(randomNumberAnswer); // skickar in det slumpade värdet i hint randomNumberAnswer = svaret på spelet
                    break;
                    case "a": ShowAnswer(); // kanska självklart visar randomNumberAnswer hade kunnat vara Console.WriteLine("randomNumberAnswer"); egentligen
                    break;
                    case "x": Environment.Exit(0); // avslutar programet
                    break;
                    default: System.Console.WriteLine("enter a vaild option in the menu"); // om inget av m,g,h,a,x har skickats in ber vi användaren att skicka in ett giltligt val
                    break;
                }
                //Guess(randomNumberAnswer, userInputNumber);



            }
        }
        catch(Exception ex) // hit alla throws skicka och om det skulle bli fel i try
        {
            System.Console.WriteLine(ex.Message); // Ex = det värdet som Exception ger. Så det som skrivs ut är det meddlande/fel Exception ger. 
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
            //självklart kan ändra till att användare inte blir utkastad men ser ingen anledning till det (detta är lättare)
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
    static void YouWin()
    {
        System.Console.WriteLine("poop!!!");

    }


}
