using System;

namespace _179773
{
    class Program
    {
        // instantiate object of class StreamWriter
        static Random random;
        // The main entry point for the application.
        static void Main(string[] args)
        {
            //the following string is used to generate the random symbols.
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", userAns = "";
            string[] storedquestions;//string array to store the generated random symbols as Questions.
            char[] storedchar;//character array to store the symbole witch the user will be looking for in the question.
            char[] generatedSymbol;//to generate a random symbol from the random generated string. 
            int[] correctAnswer;//array to store the correct awnsers.
            int[] userAnswer;//array to store the user's awnsers.
            int[] answerResult;//array to store the compareson result between the user's awnser and the correct awnser.
            int QuestionsNumber, symbolsNumber;
            bool stay = true;//this boolian value is used to control the Do-While loop.


            Console.WriteLine("Enter The Maximum Number of Questions: ");
            QuestionsNumber = int.Parse(Console.ReadLine());
            //initializing arrays.
            storedquestions = new string[QuestionsNumber];
            storedchar = new char[QuestionsNumber];
            correctAnswer = new int[QuestionsNumber];
            userAnswer = new int[QuestionsNumber];
            answerResult = new int[QuestionsNumber];
            generatedSymbol = new char[QuestionsNumber];
            Console.WriteLine("============================================================================================= ");

            //this loop to generate,show and getting user's awnsers.
            for (int i = 0; i <= QuestionsNumber - 1; i++)
            {
                Console.WriteLine("Question: " + (i + 1) + "\nPlease Enter an integer value between 3 and 100 (the number of characters from witch to enumerate certain symbol==degree of difficulty)");
                symbolsNumber = int.Parse(Console.ReadLine());

                if (symbolsNumber < 3 || symbolsNumber > 100)
                {
                    Console.WriteLine("Enter a number between 3 and 100 PLEASE.");
                    break;
                }
                storedquestions[i] = Randomsymbol(characters, symbolsNumber);
                generatedSymbol[i] = char.Parse( Randomsymbol(storedquestions[i], 1));
                storedchar[i] = generatedSymbol[0];
                correctAnswer[i] = Test(storedquestions[i], storedchar[i]);

                Console.WriteLine("How many times the symbol ( " + storedchar[i] + " ) has been repeated in the following characters: ");
                Console.WriteLine(storedquestions[i]);

                Console.WriteLine("To Ignore the Question Type Ignore.");
                userAns = Console.ReadLine();
                if (userAns == "ignore" || userAns == "Ignore")
                {
                    answerResult[i] = 0;
                    Console.WriteLine("============================================================================================= ");
                }
                else
                {
                    userAnswer[i] = int.Parse(userAns);
                    answerResult[i] = resultTest(userAnswer[i], correctAnswer[i]);
                    Console.WriteLine("============================================================================================= ");
                }
            }
            do
            {
                Console.WriteLine("to exit,type exit.");
                Console.WriteLine("to get the number of Wrong Answers, type 1.");
                Console.WriteLine("to get the number of right Answers, type 2.");
                Console.WriteLine("to view all questions with correct and answered responses,type 3.");
                userAns = Console.ReadLine();

                //switch condition to react according to the user's answers.
                switch (userAns)
                {
                    //this case to show the number of wrong awnsers.
                    case "1":
                        wrongAnswers(answerResult);
                        break;
                    //this case to show the number of right awnsers.
                    case "2":
                        rightAnswers(answerResult);
                        break;
                    //in these two cases the result is the task so i used one line of code.
                    case "exit":
                    case "Exit":
                        stay = false;
                        break;
                    //this case to call the function that show the table of awnsers.
                    case "3":
                        all(storedquestions, storedchar, userAnswer, correctAnswer);
                        break;
                    //to redirect the user to enter on of the options (1,2,3 or exit).
                    default:
                        Console.WriteLine("============================================================================================= ");
                        Console.WriteLine("PLEASE Enter 1,2,3 or exit .");
                        Console.WriteLine("============================================================================================= ");
                        break;
                }
            } while (stay);

        }
        //function to generate a random string of symbols.
        static string Randomsymbol(string chars, int symbolNumber)
        {
            random = new Random();
            char tempchar = ' ';
            string returnedstring = "";


            for (int j = 0; j < symbolNumber; j++)
            {
                tempchar = chars[random.Next(chars.Length)];
                returnedstring = returnedstring + tempchar;
            }

            return returnedstring;
        }
        //function to perform a test to count the correct answers.
        static int Test(string testString, char smbl)
        {
            int counter = 0;
            char[] testArray = new char[testString.Length];
            testArray = testString.ToCharArray();

            for (int i = 0; i < testArray.Length; i++)
            {
                if (testArray[i] == smbl)
                {
                    counter++;
                }
            }
            return counter;
        }
        //function to return (1) for right awnsers and (0) for wrong awnsers.
        static int resultTest(int user, int ans)
        {
            if (user == ans)
                return 1;
            else
                return 0;
        }
        //function to count the wrong awnsers.
        static void wrongAnswers(int[] answer)
        {
            int w = 0;
            for (int i = 0; i < answer.Length; i++)
            {
                if (answer[i] == 0)
                {
                    w++;
                }
            }
            Console.WriteLine("============================================================================================= ");
            Console.WriteLine("The number of Wrong awnsers : " + w);
            Console.WriteLine("============================================================================================= ");
        }
        //function to count the right awnsers.
        static void rightAnswers(int[] answer)
        {
            int R = 0;
            for (int i = 0; i < answer.Length; i++)
            {
                if (answer[i] == 1)
                {
                    R++;
                }
            }
            Console.WriteLine("============================================================================================= ");
            Console.WriteLine("The number of Right awnsers : " + R);
            Console.WriteLine("============================================================================================= ");
        }
        //function to show the questions , the symbol that we are asking about , the user's awnser and the correct awnsers.
        static void all(string[] sq, char[] sc, int[] ua, int[] ca)
        {
            Console.WriteLine("Questions \t Symbol \t User Answer \t Correct Awnser \n=============================================================================================");
            for (int i = 0; i < sq.Length; i++)
            {
                Console.WriteLine(sq[i] + " \t" + sc[i] + " \t" + ua[i] + " \t" + ca[i]);
            }
            Console.WriteLine("============================================================================================= ");
        }
    }
}
