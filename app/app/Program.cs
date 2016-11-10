using System;

public class Account
{
    private int loginType, acntID;
    private string[,] accounts = new string[30, 10];

    public Account()
    {
        acntID = 0;
    }

    public string formatText(string text, int size)
    {
        return text + new string(' ', size - text.Length);
    }

    public void resetWindow()
    {
        // Clear Window
        Console.Clear();

        Console.WriteLine("***************************************************");
        Console.WriteLine("********************BANKING APP********************");
        Console.WriteLine("***************************************************\n\n");
    }

    public void loginOption()
    {
        Console.WriteLine("Select Account Type \n\n1- Admin \n2- User\n");
        loginType = Convert.ToInt32(Console.ReadLine());

        resetWindow();

        // if login type admin
        if (loginType == 1)
            adminLogin();
        //if login type user
        else
            Console.WriteLine("Welcome User");
    }

    public void adminLogin()
    {
        Console.Write("Enter Admin ID: ");
        string adminID = Console.ReadLine();
        Console.Write("Enter Admin PIN: ");
        int adminPin = Convert.ToInt32(Console.ReadLine());

        resetWindow();
        verifyAdminLogin(adminID, adminPin);
    }

    public void verifyAdminLogin(string adminID, int adminPin)
    {
        if (adminID == "kumail" && adminPin == 1234)
        {
            showAdminOptions();
        }
        else
        {
            Console.WriteLine("Invalid ID aur PIN \n");
            Console.WriteLine("- Enter 1 for retry \n- Enter any key for main menu");

            string tempInput = Console.ReadLine();
            resetWindow();

            if (tempInput == "1")
                adminLogin();
            else
                loginOption();
        }
    }

    public void showAdminOptions()
    {
        Console.WriteLine("Welcome Admin \n");
        Console.WriteLine("*************\n");
        Console.WriteLine("Select options\n");
        Console.WriteLine("1- Add Account\n2- Update Account\n3- View all Accounts\n");
        int adminAction = Convert.ToInt32(Console.ReadLine());

        resetWindow();
        adminActions(adminAction, acntID);

    }

    public void adminActions(int option, int ID)
    {
        if (option == 1)
        {
            Console.WriteLine("Add New Account: \n");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Phone #: ");
            string phone = Console.ReadLine();

            Console.Write("Account #: ");
            string acntNo = Console.ReadLine();

            Console.Write("Initial Balance: ");
            string balance = Console.ReadLine();

            addAccount(acntID, name, phone, acntNo, balance);
        }
        else if (option == 3)
        {
            Console.WriteLine("List of Accounts \n");
            Console.WriteLine("| ID | {0} | {1} | {2} | {3} |", formatText("Name", 20), formatText("Phone #", 15), formatText("Account #", 15), formatText("Balance", 8));
            Console.WriteLine(new string('-', 76));

            for (int i = 0; i < ID; i++)
            {
                Console.WriteLine("| {0} | {1} | {2} | {3} | {4} |", formatText(accounts[i, 0], 2), formatText(accounts[i, 1], 20), formatText(accounts[i, 2], 15), formatText(accounts[i, 3], 15), formatText(accounts[i, 4], 8));
                Console.WriteLine(new string('-', 76));
            }
        }
    }

    public void addAccount(int ID, string name, string phone, string acntNo, string balance)
    {
        accounts[acntID, 0] = Convert.ToString(ID);
        accounts[acntID, 1] = name;
        accounts[acntID, 2] = phone;
        accounts[acntID, 3] = acntNo;
        accounts[acntID, 4] = balance;
        acntID++;

        resetWindow();
        Console.WriteLine("Account successfully created! \n");
        Console.WriteLine("- Enter 1 to add more account \n- Enter any key for admin menu");
        string tempInput = Console.ReadLine();

        resetWindow();

        if (tempInput == "1")
        {
            adminActions(1, ID);
        }
        else
        {
            showAdminOptions();
        }
    }
}

public class Program
{
    public static void Main()
    {
        Account obj = new Account();

        Console.SetWindowSize(
            Math.Min(120, Console.LargestWindowWidth),
            Math.Min(40, Console.LargestWindowHeight));

        obj.resetWindow();
        obj.loginOption();
    }
}