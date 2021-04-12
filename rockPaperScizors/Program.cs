using System;

namespace rockPaperScizors
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] choices = new string [3]{
                "Rock", "Paper", "Scissors"
            };
            Random rand = new Random();
            bool running = true;
            int compWins = 0;
            int playerWins = 0;
            
            //Variables above will maintain, variables in while running will reevaluate
            while (running)
            {
            int compChoiceIndex = rand.Next(choices.Length);
            string compChoice = choices[compChoiceIndex];

                
            System.Console.WriteLine(@" Rock, Paper or Scissors? 
            (R)ock / (P)aper / (S)cissors");
            ConsoleKeyInfo userInput = System.Console.ReadKey();
            if (userInput.Key == ConsoleKey.R) 
            {
                if(compChoice == "Paper"){
                    System.Console.WriteLine(" Comp Chose Paper, You Lose");
                    compWins++;
                    System.Console.WriteLine("Comp Wins: " + compWins);
                    System.Console.WriteLine("Player Wins: " + playerWins);
                } else if(compChoice == "Scissors"){
                    System.Console.WriteLine(" Comp Chose Scissors, You Win");
                    playerWins++;
                    System.Console.WriteLine("Comp Wins: " + compWins);
                    System.Console.WriteLine("Player Wins: " + playerWins);
                } else if(compChoice == "Rock"){
                    System.Console.WriteLine(" Comp Chose Rock Too, Tie");
                    System.Console.WriteLine("Comp Wins: " + compWins);
                    System.Console.WriteLine("Player Wins: " + playerWins);
                }
            } 
            if (userInput.Key == ConsoleKey.P) 
            {
                if(compChoice == "Paper"){
                    System.Console.WriteLine(" Comp Chose Paper, Tie");
                } else if(compChoice == "Scissors"){
                    System.Console.WriteLine(" Comp Chose Scissors, You Lose");
                    compWins++;
                    System.Console.WriteLine("Comp Wins: " + compWins);
                    System.Console.WriteLine("Player Wins: " + playerWins);
                } else if(compChoice == "Rock"){
                    System.Console.WriteLine(" Comp Chose Rock , You Win");
                    playerWins++;
                    System.Console.WriteLine("Comp Wins: " + compWins);
                    System.Console.WriteLine("Player Wins: " + playerWins);
                }
            } 
            if (userInput.Key == ConsoleKey.S) 
            {
                if(compChoice == "Paper"){
                    System.Console.WriteLine(" Comp Chose Paper, You Win");
                    playerWins++;
                    System.Console.WriteLine("Comp Wins: " + compWins);
                    System.Console.WriteLine("Player Wins: " + playerWins);
                } else if(compChoice == "Scissors"){
                    System.Console.WriteLine(" Comp Chose Scissors, Tie");
                } else if(compChoice == "Rock"){
                    System.Console.WriteLine(" Comp Chose Rock Too, You Lose");
                    compWins++;
                    System.Console.WriteLine("Comp Wins: " + compWins);
                    System.Console.WriteLine("Player Wins: " + playerWins);
                }
            } 
            else{
                System.Console.WriteLine(" Invalid input");
            }
            
            if(compWins == 10){
                System.Console.WriteLine("Comp reached 10 dubs, gg");
                running = false;
            }else if(playerWins == 10){
                System.Console.WriteLine("Player reached 10 dubs, gg");
                running = false;
            }
            }
        }
    }
}
