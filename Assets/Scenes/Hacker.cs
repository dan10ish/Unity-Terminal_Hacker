using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game Configuration Data
    string[] level1Passwords = { "collection", "manuscripts", "bookcase", "archive", "accumulation", "constantinople", "aggregation", "bookstore", "microform", "institution", "athenaeum", "carrel", "bibliotheca", "academy", "museum", "videotape", "audiobook", "prehistory", "bookshelf", "bibliophile", "edifice", "cubicle", "depositary"};
    string[] level2Passwords = { "assailant", "armed", "convict", "burglar", "cruiser", "detective", "escape", "felony", "fingerprint", "firearms", "guilty", "handcuffs", "intruder", "innocent", "partner", "perpetrator", "patrol", "wanted", "witness", "radar", "pursuit", "pistol", "misdemeanor"};
    string[] level3Passwords = { "meteoroid", "atmosphere", "supernova", "horizon", "asteroid", "constellation", "magnitude", "nebula", "equinox", "density", "solstice", "observatory", "zodiac", "starlight", "inertia", "universe", "eclipse", "astronomy"};

    //Game State
    int level;

    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;

    string password;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu ()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("            Terminal Hacker");
        Terminal.WriteLine("                     - DANISH A.");
        Terminal.WriteLine("           ");
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local Library");
        Terminal.WriteLine("Press 2 for the Police station");
        Terminal.WriteLine("Press 3 for the NASA");
        Terminal.WriteLine("Enter your selection: ");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
		{
            ShowMainMenu();
        }

        else if (currentScreen == Screen.MainMenu)
		{
            RunMainMenu(input);
        }

        else if (currentScreen == Screen.Password)
		{
           CheckPassword(input);
		}

    }


    void RunMainMenu (string input)
	{

        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
		{
            level = int.Parse(input);
            AskForPassword();
		}

        else if (input == "007") // easter egg 1
        {
            Terminal.WriteLine("Please select a level Mr. Bond!  ");
        }
        else if (input == "avais") // easter egg 2
        {
            Terminal.WriteLine("Hello Mr. Avais. Please select a level!");
        }
        else if (input == "anwar") // easter egg 2
        {
            Terminal.WriteLine("Hello Mr. Anwar. Please select a level!");
        }
        else
        {
            Terminal.WriteLine("Please chose a valid level!");
        }
    }


    void AskForPassword()
	{
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
       switch(level)
		{
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;

            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;

            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;

            default:
                Debug.LogError("Invalid Level");
                break;

		}
        Terminal.WriteLine("Enter your Password to hack into the   system");
        Terminal.WriteLine("            ");
        Terminal.WriteLine("Hint: " + password.Anagram());
    }

    void CheckPassword (string input)
	{
        if (input == password)
		{
            DisplayWinScreen();
		}
        else
		{
            Terminal.WriteLine(@"
____       ___
\   \    /   /
 \   \  /   /
  \   \/   /
  /       \
 /   / \   \
/___/   \___\
"
                );
            Terminal.WriteLine("Sorry, wrong password! ");
            Terminal.WriteLine("Type menu to try again! ");
		}
	}

    void DisplayWinScreen()
	{
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
	}

    void ShowLevelReward()
	{
        switch(level)
		{
            case 1:
                Terminal.WriteLine("Welcome to the Local Library! ");
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"

    _________
   /      / /
  /      / /
 /      / /
/______/ /
(______(/
"
                );
                Terminal.WriteLine("You are Welcome to type menu anytime..");
                break;

            case 2:
                Terminal.WriteLine("Welcome to the Police Station! ");
                Terminal.WriteLine("Salute Sir!");
                Terminal.WriteLine(@"

        ___
     __/__/:___      
   /  ________/
  /  /:__/
 /  /
/__/
"
                );
                Terminal.WriteLine("You are Welcome to type menu anytime..");
                break;



            case 3:
                Terminal.WriteLine("Welcome to Nasa Sir!");
                Terminal.WriteLine(@"



 ________________________________
(   _   ) |__  | |   ____) |__   |   
|  | |  |  __) | |____   |  __)  |
|  | |  | |  0 |  ____|  | |   0 |
|__| |__|_(____|_(_______|_(_____|
"
                );
                Terminal.WriteLine("You are Welcome to type menu anytime..");
                break;




            default:
                Debug.LogError("Try Again! ");
                break;


             
		}
	}

}
