using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using ConsoleTables;

namespace Millionaire
{
    class Program
    {

        public struct Question
        {
            public string id;
            public int difficulty;
            public string name;
            public string correct;
            public string a;
            public string b;
            public string c;
            public string d;
            public Question(string identification, int level, string nameOfQuestion, string correctAnswer, string firstAnswer, string secondAnswer, string thirdAnswer, string fourthAnswer)
            {
                id = identification;
                difficulty = level;
                name = nameOfQuestion;
                correct = correctAnswer;
                a = firstAnswer;
                b = secondAnswer;
                c = thirdAnswer;
                d = fourthAnswer;
            }
        }

        public struct Player
        {
            public string name;
            public string surname;
            public string date;
            public int moneyWon;
            public string jokers;
            public Player(string namePlayer, string surnamePlayer, string datePlayer, int amount, string used)
            {
                name = namePlayer;
                surname = surnamePlayer;
                date = datePlayer;
                moneyWon = amount;
                jokers = used;
            }
        }

        static void Main(string[] args)
        {
            showMainMenu();
        }

        static void showMainMenu()
        {
            System.Media.SoundPlayer play_background = play_background_sound();

            string s = "Welcome to the Millionare!";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);

            Console.WriteLine();
            showMenu();
            int choice = your_option();
            stop_background_sound(play_background);
            
            while (choice != 51)
            {

                if (choice == 49)
                {
                    choice = playGame();
                }
                if (choice == 50)
                {
                    choice = showResults();
                }
            }
        }

        static void showMenu()
        {
            Console.WriteLine("Pick a number:");
            Console.WriteLine("1 - New game");
            Console.WriteLine("2 - Results");
            Console.WriteLine("3 - Exit");
        }

        static int playGame()
        {
            int callCounter = 1;
            int askAudienceCounter = 1;
            int halfHalfCounter = 1;
            System.Media.SoundPlayer playerBackground = play_background_sound();
            List<Question> questions = loadQuestions();
            Console.Clear();
            Random rnd = new Random();
            int amountWon = 0;
            bool gameOn = true;
            int counterQuestions = 0;
            string dateToday = DateTime.Today.ToString("dd-MM-yyyy");
            Console.WriteLine("Type in your name:");
            string playerName = Console.ReadLine();
            Console.WriteLine("Type in your surname:");
            string playerSurname = Console.ReadLine();
            int questionNumber = 0;
            int[] questionNumberCheck = new int[16];
            bool questionOK;
            Console.Clear();
            for (int i = 1; i < 16; i++)
            {
                if (gameOn == true)
                {
                    do
                    {
                        questionOK = true;
                        if (i < 5)
                        {
                            questionNumber = rnd.Next(1, 9);
                        }
                        if (i < 7 && i > 4)
                        {
                            questionNumber = rnd.Next(9, 13);
                        }
                        if (i < 9 && i > 6)
                        {
                            questionNumber = rnd.Next(13, 17);
                        }
                        if (i < 11 && i > 8)
                        {
                            questionNumber = rnd.Next(17, 21);
                        }
                        if (i < 13 && i > 10)
                        {
                            questionNumber = rnd.Next(21, 24);
                        }
                        if (i < 15 && i > 12)
                        {
                            questionNumber = rnd.Next(24, 29);
                        }
                        if (i == 15)
                        {
                            questionNumber = rnd.Next(29, 31);
                        }
                        for (int q = 0; q < 15; q++)
                        {
                            if (questionNumberCheck[q] == questionNumber)
                            {
                                questionOK = false;
                            }
                        }

                    } while (questionOK == false);
                    stop_background_sound(playerBackground);
                    System.Media.SoundPlayer player1 = new System.Media.SoundPlayer();
                    player1.SoundLocation = ("C:\\Users\\Mario\\Documents\\Visual Studio 2017\\Projects\\Millionaire\\Sounds\\questions.wav");
                    player1.Play();
                    questionNumberCheck[i] = questionNumber;
                    Console.Write("{0}. question: ", i);
                    Console.WriteLine(questions[questionNumber - 1].name);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("a: {0}", questions[questionNumber - 1].a);
                    Console.WriteLine();
                    Console.WriteLine("b: {0}", questions[questionNumber - 1].b);
                    Console.WriteLine();
                    Console.WriteLine("c: {0}", questions[questionNumber - 1].c);
                    Console.WriteLine();
                    Console.WriteLine("d: {0}", questions[questionNumber - 1].d);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Avaliable jokers are:");
                    if (callCounter == 1)
                    {
                        Console.WriteLine("press i for Call joker");
                    }
                    if (askAudienceCounter == 1)
                    {
                        Console.WriteLine("press o for Ask audience joker");
                    }
                    if (halfHalfCounter == 1)
                    {
                        Console.WriteLine("press p for 50/50 joker");
                    }
                    Console.WriteLine();
                    Console.WriteLine("***** to quit the game press q");
                    Console.WriteLine();
                    Console.WriteLine("Your answer: ");
                    string yourAnswer = Console.ReadLine();


                    while (yourAnswer != "a" && yourAnswer != "b" && yourAnswer != "c" && yourAnswer != "d"
                        && yourAnswer != "i" && yourAnswer != "o" && yourAnswer != "p" && yourAnswer != "q")
                    {
                        Console.Clear();
                        Console.WriteLine("Incorrect answer format. Please try again!");
                        Console.Write("{0}. question: ", i);
                        Console.WriteLine(questions[questionNumber - 1].name);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("a: {0}", questions[questionNumber - 1].a);
                        Console.WriteLine();
                        Console.WriteLine("b: {0}", questions[questionNumber - 1].b);
                        Console.WriteLine();
                        Console.WriteLine("c: {0}", questions[questionNumber - 1].c);
                        Console.WriteLine();
                        Console.WriteLine("d: {0}", questions[questionNumber - 1].d);
                        Console.WriteLine();
                        Console.WriteLine("Avaliable jokers are:");
                        if (callCounter == 1)
                        {
                            Console.WriteLine("press i for Call joker");
                        }
                        if (askAudienceCounter == 1)
                        {
                            Console.WriteLine("press o for Ask audience joker");
                        }
                        if (halfHalfCounter == 1)
                        {
                            Console.WriteLine("press p for 50/50 joker");
                        }
                        Console.WriteLine();
                        Console.WriteLine("***** to quit the game press q");
                        Console.WriteLine();
                        Console.WriteLine("Your answer: ");
                        yourAnswer = Console.ReadLine();
                    }

                    while (yourAnswer == "i" || yourAnswer == "o" || yourAnswer == "p")
                    {
                        if (yourAnswer == "i" && callCounter == 1)
                        {
                            string friend = getFriend();
                            callCounter++;
                            int chance = rnd.Next(1, 101);
                            if (counterQuestions < 5)
                            {
                                 chance = rnd.Next(1, 55);
                            }
                            if (counterQuestions >= 5 && counterQuestions < 7)
                            {
                                chance = rnd.Next(1, 60);
                            }
                            if (counterQuestions >= 7 && counterQuestions < 9)
                            {
                                chance = rnd.Next(1, 65);
                            }
                            if (counterQuestions >= 9 && counterQuestions < 11)
                            {
                                chance = rnd.Next(1, 70);
                            }
                            if (counterQuestions >= 11 && counterQuestions < 13)
                            {
                                chance = rnd.Next(1, 75);
                            }
                            if (counterQuestions >= 13 && counterQuestions < 15)
                            {
                                chance = rnd.Next(1, 80);
                            }
                            if (counterQuestions == 15)
                            {
                                chance = rnd.Next(1, 85);
                            }

                           if (chance < 50)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("**CALL** {0} says the answer is: {1}", friend, questions[questionNumber - 1].correct);
                                    Console.WriteLine();
                                }
                                else
                                {
                                    int luck = rnd.Next(1, 4);
                                    if (luck == 1)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("**CALL** {0} says the answer is: a", friend);
                                        Console.WriteLine();
                                    }
                                    if (luck == 2)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("**CALL** {0} says the answer is: b", friend);
                                        Console.WriteLine();
                                    }
                                    if (luck == 3)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("**CALL** {0} says the answer is: c", friend);
                                        Console.WriteLine();
                                    }
                                    if (luck == 4)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("**CALL** {0}  says the answer is: d", friend);
                                        Console.WriteLine();
                                    }
                                }
                           
                            Console.WriteLine("Your answer: ");
                            yourAnswer = Console.ReadLine();
                            while (yourAnswer != "a" && yourAnswer != "b" && yourAnswer != "c" && yourAnswer != "d"
                        && yourAnswer != "i" && yourAnswer != "o" && yourAnswer != "p" && yourAnswer != "q")
                            {
                                Console.WriteLine("Incorrect answer format. Please try again!");
                                Console.WriteLine("Your answer: ");
                                yourAnswer = Console.ReadLine();
                            }
                        }
                        if (yourAnswer == "o" && askAudienceCounter == 1)
                        {
                            askAudienceCounter++;
                            int chance = rnd.Next(1, 101);
                           
                                if (counterQuestions < 5)
                                {
                                    chance = rnd.Next(1, 55);
                                }
                                if (counterQuestions >= 5 && counterQuestions < 7)
                                {
                                    chance = rnd.Next(1, 60);
                                }
                                if (counterQuestions >= 7 && counterQuestions < 9)
                                {
                                    chance = rnd.Next(1, 65);
                                }
                                if (counterQuestions >= 9 && counterQuestions < 11)
                                {
                                    chance = rnd.Next(1, 70);
                                }
                            if (counterQuestions >= 11 && counterQuestions < 13)
                            {
                                chance = rnd.Next(1, 75);
                            }
                            if (counterQuestions >= 13 && counterQuestions < 15)
                                {
                                    chance = rnd.Next(1, 80);
                                }
                                if (counterQuestions == 15)
                                {
                                    chance = rnd.Next(1, 85);
                                }

                                if (chance < 50)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Audience says the answer is: {0}", questions[questionNumber - 1].correct);
                                    Console.WriteLine();
                                }
                                else
                                {
                                    int luck = rnd.Next(1, 4);
                                    if (luck == 1)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Audience says the answer is: a");
                                        Console.WriteLine();
                                    }
                                    if (luck == 2)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Audience says the answer is: b");
                                        Console.WriteLine();
                                    }
                                    if (luck == 3)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Audience says the answer is: c");
                                        Console.WriteLine();
                                    }
                                    if (luck == 4)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Audience says the answer is: d");
                                        Console.WriteLine();
                                    }
                                }
                            
                            Console.WriteLine("Your answer: ");
                                yourAnswer = Console.ReadLine();
                                while (yourAnswer != "a" && yourAnswer != "b" && yourAnswer != "c" && yourAnswer != "d"
                            && yourAnswer != "i" && yourAnswer != "o" && yourAnswer != "p" && yourAnswer != "q")
                                {
                                    Console.WriteLine("Incorrect answer format. Please try again!");
                                    Console.WriteLine("Your answer: ");
                                    yourAnswer = Console.ReadLine();
                                }
                        }
                        if (yourAnswer == "p" && halfHalfCounter == 1)
                        {
                            string firstCase ="";
                            string secondCase = questions[questionNumber - 1].correct;
                            halfHalfCounter++;

                            int firstRand = rnd.Next(1, 3);
                            if (firstRand == 1)
                            {
                                firstCase = questions[questionNumber - 1].correct;
                                do
                                {
                                    int secondRand = rnd.Next(1, 4);
                                    if (secondRand == 1)
                                    {
                                        secondCase = ("a");
                                    }
                                    if (secondRand == 2)
                                    {
                                        secondCase = ("b");
                                    }
                                    if (secondRand == 3)
                                    {
                                        secondCase = ("c");
                                    }
                                    if (secondRand == 4)
                                    {
                                        secondCase = ("d");
                                    }
                                } while (secondCase == questions[questionNumber - 1].correct);
                            }
                                if (firstRand == 2)
                                {
                                    do
                                    {
                                        int secondRand = rnd.Next(1, 4);
                                        if (secondRand == 1)
                                        {
                                            firstCase = ("a");
                                        }
                                        if (secondRand == 2)
                                        {
                                            firstCase = ("b");
                                        }
                                        if (secondRand == 3)
                                        {
                                            firstCase = ("c");
                                        }
                                        if (secondRand == 4)
                                        {
                                            firstCase = ("d");
                                        }
                                    } while (firstCase == questions[questionNumber - 1].correct);
                                }
                            
                            Console.WriteLine();
                            Console.WriteLine("Correct answer is: {0} or {1}", firstCase, secondCase);
                            Console.WriteLine();
                            Console.WriteLine("Your answer: ");
                            yourAnswer = Console.ReadLine();
                            while (yourAnswer != firstCase && yourAnswer != secondCase && yourAnswer != "i" && yourAnswer != "o" && yourAnswer != "p" && yourAnswer != "q")
                            {
                                Console.WriteLine("Incorrect answer format. Please try again!");
                                Console.WriteLine("Your answer: ");
                                yourAnswer = Console.ReadLine();
                            }
                        }
                        if(yourAnswer == "p" && halfHalfCounter == 2 || yourAnswer == "o" && askAudienceCounter == 2 || yourAnswer == "i" && callCounter == 2)
                        {
                            Console.WriteLine("Incorrect answer format. Please try again!");
                            Console.WriteLine("Your answer: ");
                            yourAnswer = Console.ReadLine();
                            while (yourAnswer != "a" && yourAnswer != "b" && yourAnswer != "c" && yourAnswer != "d"
                       && yourAnswer != "i" && yourAnswer != "o" && yourAnswer != "p" && yourAnswer != "q")
                            {
                                Console.WriteLine("Incorrect answer format. Please try again!");
                                Console.WriteLine("Your answer: ");
                                yourAnswer = Console.ReadLine();
                            }
                        }
                    }
                    if (yourAnswer == questions[questionNumber - 1].correct)
                    {
                        System.Media.SoundPlayer playerCorrect = new System.Media.SoundPlayer();
                        playerCorrect.SoundLocation = ("C:\\Users\\Mario\\Documents\\Visual Studio 2017\\Projects\\Millionaire\\Sounds\\correct1.wav");
                        System.Media.SoundPlayer playerCorrectBig = new System.Media.SoundPlayer();
                        playerCorrectBig.SoundLocation = ("C:\\Users\\Mario\\Documents\\Visual Studio 2017\\Projects\\Millionaire\\Sounds\\correct2.wav");
                        Console.Clear();
                        player1.Stop();
                        counterQuestions += 1;
                        Console.WriteLine("CORRECT");
                        if (counterQuestions == 1)
                        {
                            playerCorrect.Play();
                            Console.WriteLine();
                            Console.WriteLine("You have won 100KN!");
                            amountWon = 100;
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(5000);
                            Console.Clear();
                        }
                        if (counterQuestions == 2)
                        {
                            playerCorrect.Play();
                            Console.WriteLine();
                            Console.WriteLine("You have won 200KN!");
                            amountWon = 200;
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(5000);
                            Console.Clear();
                        }
                        if (counterQuestions == 3)
                        {
                            playerCorrect.Play();
                            Console.WriteLine();
                            Console.WriteLine("You have won 300KN!");
                            amountWon = 300;
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(5000);
                            Console.Clear();
                        }
                        if (counterQuestions == 4)
                        {
                            playerCorrect.Play();
                            Console.WriteLine();
                            Console.WriteLine("You have won 500KN!");
                            amountWon = 500;
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(5000);
                            Console.Clear();
                        }
                        if (counterQuestions == 5)
                        {
                           playerCorrectBig.Play();
                            Console.WriteLine();
                            Console.WriteLine("YOU HAVE WON 1000KN!!!!!!!!!!!!!!!!!!!!!!!!!");
                            amountWon = 1000;
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(8000);
                            Console.Clear();
                        }
                        if (counterQuestions == 6)
                        {
                            playerCorrect.Play();
                            Console.WriteLine();
                            Console.WriteLine("You have won 2000KN!");
                            amountWon = 2000;
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(5000);
                            Console.Clear();
                        }
                        if (counterQuestions == 7)
                        {
                            playerCorrect.Play();
                            Console.WriteLine();
                            Console.WriteLine("You have won 4000KN!");
                            amountWon = 4000;
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(5000);
                            Console.Clear();
                        }
                        if (counterQuestions == 8)
                        {
                            playerCorrect.Play();
                            Console.WriteLine();
                            Console.WriteLine("You have won 8000KN!");
                            amountWon = 8000;
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(5000);
                            Console.Clear();
                        }
                        if (counterQuestions == 9)
                        {
                           playerCorrect.Play();
                            Console.WriteLine();
                            Console.WriteLine("You have won 1600KN!");
                            amountWon = 16000;
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(5000);
                            Console.Clear();
                        }
                        if (counterQuestions == 10)
                        {
                           playerCorrectBig.Play();
                            Console.WriteLine();
                            Console.WriteLine("YOU HAVE WON 32000KN!!!!!!!!!!!!!!!!!!!!!!!!!");
                            amountWon = 32000;
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(8000);
                            Console.Clear();
                        }
                        if (counterQuestions == 11)
                        {
                            playerCorrect.Play();
                            Console.WriteLine();
                            Console.WriteLine("You have won 64000KN!");
                            amountWon = 64000;
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(5000);
                            Console.Clear();
                        }
                        if (counterQuestions == 12)
                        {
                           playerCorrect.Play();
                            Console.WriteLine();
                            Console.WriteLine("You have won 125000KN!");
                            amountWon = 125000;
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(5000);
                            Console.Clear();
                        }
                        if (counterQuestions == 13)
                        {
                           playerCorrect.Play();
                            Console.WriteLine();
                            Console.WriteLine("You have won 250000KN!");
                            amountWon = 250000;
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(5000);
                            Console.Clear();
                        }
                        if (counterQuestions == 14)
                        {
                           playerCorrect.Play();
                            Console.WriteLine();
                            Console.WriteLine("You have won 500000KN!");
                            amountWon = 500000;
                            Console.WriteLine();
                            System.Threading.Thread.Sleep(5000);
                            Console.Clear();
                        }
                        if (counterQuestions == 15)
                        {
                            Console.WriteLine();
                            Console.WriteLine("YOU HAVE WON 1000000KN!!!!!!!!!!!!!!!!!!!!!!!!!");
                            amountWon = 1000000;
                            Console.WriteLine();
                           playerCorrectBig.Play();
                            System.Threading.Thread.Sleep(8000);
                            Console.Clear();
                        }
                    }
                    if (yourAnswer == "q")
                    {
                        gameOn = false;
                        Console.Clear();
                        Console.WriteLine("You have quit!");
                        player1.Stop();
                        System.Media.SoundPlayer playerQuit = new System.Media.SoundPlayer();
                        playerQuit.SoundLocation = ("C:\\Users\\Mario\\Documents\\Visual Studio 2017\\Projects\\Millionaire\\Sounds\\fail.wav");
                        playerQuit.Play();
                        System.Threading.Thread.Sleep(5000);
                    }
                    if(yourAnswer != questions[questionNumber - 1].correct && yourAnswer != "q")
                        {
                        if (counterQuestions < 5)
                        {
                            amountWon = 0;
                        }
                        if (counterQuestions >= 5)
                        {
                            amountWon = 1000;
                        }
                        if (counterQuestions >= 10)
                        {
                            amountWon = 32000;
                        }
                        if (counterQuestions == 15)
                        {
                            amountWon = 1000000;
                        }
                        Console.Clear();
                            player1.Stop();
                            gameOn = false;
                            Console.WriteLine("INCORRECT");
                            System.Media.SoundPlayer playerIncorrect = new System.Media.SoundPlayer();
                            playerIncorrect.SoundLocation = ("C:\\Users\\Mario\\Documents\\Visual Studio 2017\\Projects\\Millionaire\\Sounds\\fail.wav");
                            playerIncorrect.Play();
                            System.Threading.Thread.Sleep(5000);
                        }
                }
            }
            
            string usedJokers = "";
            if (callCounter !=1)
            {
                usedJokers = usedJokers + " " + "Call";
            }
            if (askAudienceCounter !=1 )
            {
                usedJokers = usedJokers + " " + "Ask audience";
            }
            if (halfHalfCounter != 1)
            {
                usedJokers = usedJokers + " " + "50/50";
            }

            Console.WriteLine("You have won {0} kn", amountWon);

            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Users\\Mario\\Documents\\Visual Studio 2017\\Projects\\Millionaire\\results.xml");
            XmlNode Player = doc.CreateElement("Player");
            XmlNode name = doc.CreateElement("name");
            name.InnerText = playerName;
            Player.AppendChild(name);
            XmlNode surname = doc.CreateElement("surname");
            surname.InnerText = playerSurname;
            Player.AppendChild(surname);
            XmlNode date = doc.CreateElement("date");
            date.InnerText = dateToday;
            Player.AppendChild(date);
            XmlNode moneyWon = doc.CreateElement("moneyWon");
            moneyWon.InnerText = Convert.ToString(amountWon);
            Player.AppendChild(moneyWon);
            XmlNode jokers = doc.CreateElement("jokers");
            jokers.InnerText = usedJokers;
            Player.AppendChild(jokers);
            doc.DocumentElement.AppendChild(Player);
            doc.Save("C:\\Users\\Mario\\Documents\\Visual Studio 2017\\Projects\\Millionaire\\results.xml");


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            System.Media.SoundPlayer background_sound = play_background_sound();
            showMenu();
            int choice = your_option();
            return choice;
        }

        static List<Question> loadQuestions()
        {
            List<Question> questions = new List<Question>();
            string sXml = "";
            StreamReader oSr = new StreamReader("questions.xml");
            using (oSr)
            {
                sXml = oSr.ReadToEnd();
            }
            XmlDocument oXml = new XmlDocument();
            oXml.LoadXml(sXml);
            XmlNodeList oNodes = oXml.SelectNodes("//data/Question");

            foreach (XmlNode oNode in oNodes)
            {

                questions.Add(new Question(oNode.Attributes["id"].Value, Convert.ToInt32(oNode.Attributes["difficulty"].Value), oNode.Attributes["name"].Value,
                    oNode.Attributes["correct"].Value, oNode.Attributes["a"].Value, oNode.Attributes["b"].Value,
                    oNode.Attributes["c"].Value, oNode.Attributes["d"].Value));

            }
            return questions;
        }

        static int showResults()
        {
            System.Media.SoundPlayer soundPlayer = play_background_sound();
            Console.Clear();

            List<Player> players = new List<Player>();
            string wXml = "";
            StreamReader pSr = new StreamReader("C:\\Users\\Mario\\Documents\\Visual Studio 2017\\Projects\\Millionaire\\results.xml");
            using (pSr)
            {
                wXml = pSr.ReadToEnd();
            }
            XmlDocument lXml = new XmlDocument();
            lXml.LoadXml(wXml);
            XmlNodeList pNodes = lXml.SelectNodes("//Player");

            foreach (XmlNode oNode in pNodes)
            {
                string name = oNode["name"].InnerText;
                string surname = oNode["surname"].InnerText;
                string date = oNode["date"].InnerText;
                int moneyWon = Convert.ToInt32(oNode["moneyWon"].InnerText);
                string jokers = oNode["jokers"].InnerText;
                players.Add(new Player(name, surname, date, moneyWon, jokers));

            }


            int n = players.Count();
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (players[j].moneyWon < players[j + 1].moneyWon)
                    {
                        Player temp = players[j];
                        players[j] = players[j + 1];
                        players[j + 1] = temp;
                    }

            Console.WriteLine("All players:");


            var table = new ConsoleTable("No. ", "name", "surname", "date", "money won", "jokers used");
            int rbr = 1;
            foreach (Player player in players)
            {
                table.AddRow(rbr++ + ".", player.name, player.surname, player.date, player.moneyWon, player.jokers);
            }

            table.Write();
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            showMenu();
            int choice = your_option();
            stop_background_sound(soundPlayer);
            return choice;
        }

        static System.Media.SoundPlayer play_background_sound()
        {
            System.Media.SoundPlayer playerBackground = new System.Media.SoundPlayer();
            playerBackground.SoundLocation = ("C:\\Users\\Mario\\Documents\\Visual Studio 2017\\Projects\\Millionaire\\Sounds\\background.wav");
            playerBackground.Play();
            return playerBackground;
        }
        static void stop_background_sound( System.Media.SoundPlayer player)
        {
            player.Stop();
        }

        static int your_option()
        {
            int a = Convert.ToInt32(Console.ReadKey().Key);
            while (a != 49 && a != 50 && a != 51)
            {
                Console.WriteLine(a);
                Console.Clear();
                Console.WriteLine("\nWrong, try again!");
                showMenu();
                Console.Write("\nYour choice: ");
                a = Convert.ToInt32(Console.ReadKey().Key);
            }
            Console.Clear();
            return a;
        }

        static string getFriend()
        {
            Random rnd = new Random();
            string[] friends = new string[20]
            {
                "Marcy","John","Tomas","Alex","Anna","Ivy","Steve","Tony","Bob","George",
                "Jimmy","Karem","Stacy","Chris","Chuck","Frank","Max","Matt","Piotr","Spock" 
            };
            int random = rnd.Next(0,21);
            return friends[random];
        }
    }
}




      