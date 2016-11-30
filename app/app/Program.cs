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
            userLogin();
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

    public void userLogin()
    {
        Console.Write("Enter User ID: ");
        int userID = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter PIN: ");
        string userPin = Console.ReadLine();

        resetWindow();
        verifyUserLogin(userID, userPin);
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

    public void verifyUserLogin(int userID, string userPin)
    {
        if (accounts[userID, 5] == userPin)
        {
            showUserOptions(userID);
        }
        else
        {
            Console.WriteLine("Invalid ID aur PIN \n");
            Console.WriteLine("- Enter 1 for retry \n- Enter any key for main menu");

            string tempInput = Console.ReadLine();
            resetWindow();

            if (tempInput == "1")
                userLogin();
            else
                loginOption();
        }
    }

    public void showAdminOptions()
    {
        Console.WriteLine("Welcome Admin \n");
        Console.WriteLine("*************\n");
        Console.WriteLine("Select options\n");
        Console.WriteLine("1- Add Account\n2- Update Account\n3- View all Accounts\n4- Back to main menu");
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

            Console.Write("Password: ");
            string pass = Console.ReadLine();

            addAccount(acntID, name, phone, acntNo, balance, pass);
        }
        else if (option == 2)
        {
            Console.Write("Update Account #: ");
            int acID = Convert.ToInt32(Console.ReadLine());

            resetWindow();
            updateAccount(acID);
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

            Console.WriteLine("- Enter any key for admin menu");
            Console.ReadLine();
            resetWindow();
            showAdminOptions();
        }
        else if (option == 4)
        {
            loginOption();
        }
    }

    public void addAccount(int ID, string name, string phone, string acntNo, string balance, string pass)
    {
        accounts[acntID, 0] = Convert.ToString(ID);
        accounts[acntID, 1] = name;
        accounts[acntID, 2] = phone;
        accounts[acntID, 3] = acntNo;
        accounts[acntID, 4] = balance;
        accounts[acntID, 5] = pass;
        acntID++;

        resetWindow();
        //StreamWriter sr = new StreamWriter(@"account.csv");
        //var line = String.Format("{0},{1}", "kumail", "1");
        //sr.Write(line);
        //sr.Close();
        Console.WriteLine("Account successfully created! \n");
        Console.WriteLine("- Enter 1 to add more account \n- Enter any key for admin menu");
        string tempInput = Console.ReadLine();

        resetWindow();

        if (tempInput == "1")
            adminActions(1, ID);
        else
            showAdminOptions();
    }

    public void updateAccount(int ID)
    {
        Console.WriteLine("Update Account Info for ID {0}: \n", accounts[ID, 0]);

        Console.Write("Name: ({0}) ", accounts[ID, 1]);
        string name = Console.ReadLine();

        Console.Write("Phone #: ({0}) ", accounts[ID, 2]);
        string phone = Console.ReadLine();

        if (name != "")
            accounts[ID, 1] = name;

        if (phone != "")
            accounts[ID, 2] = phone;

        resetWindow();
        Console.WriteLine("Account info successfully updated! \n");
        Console.WriteLine("- Enter any key for admin menu");
        Console.ReadLine();

        resetWindow();
        showAdminOptions();
    }

    public void showUserOptions(int uID)
    {
        Console.WriteLine("Welcome {0} \n", accounts[uID, 1]);
        Console.WriteLine("*************\n");
        Console.WriteLine("Select options\n");
        Console.WriteLine("1- Balance Inquiry\n2- Deposit\n3- Withdraw\n4- View account info\n5- Update basic info\n6- Change pin\n7- Back to main menu");
        int userAction = Convert.ToInt32(Console.ReadLine());

        resetWindow();
        userActions(userAction, uID);
    }

    public void userActions(int option, int ID)
    {
        if (option == 1)
        {
            showBalance(ID);
            Console.WriteLine("- Enter any key for user menu");
            Console.ReadLine();
            resetWindow();
            showUserOptions(ID);
        }
        else if (option == 2)
        {
            deposit(ID);
            Console.WriteLine("- Enter any key for user menu");
            Console.ReadLine();
            resetWindow();
            showUserOptions(ID);
        }
        else if (option == 3)
        {
            withdraw(ID);
            Console.WriteLine("- Enter any key for user menu");
            Console.ReadLine();
            resetWindow();
            showUserOptions(ID);
        }
        else if (option == 4)
        {
            Console.WriteLine("Account Info\n");
            Console.WriteLine("{0}{4}\n{1}{5}\n{2}{6}\n{3}{7}", formatText("Name:", 15), formatText("Phone:", 15), formatText("Account #:", 15), formatText("Balance:", 15),
                              accounts[ID, 1], accounts[ID, 2], accounts[ID, 3], accounts[ID, 4]);
            Console.WriteLine("\n\n- Enter any key for user menu");
            Console.ReadLine();
            resetWindow();
            showUserOptions(ID);
        }
        else if(option == 5)
        {
            Console.WriteLine("Update basic info\n");
            Console.Write("Name: ({0}) ", accounts[ID, 1]);
            string name = Console.ReadLine();
            Console.Write("Phone: ({0}) ", accounts[ID, 2]);
            string phone = Console.ReadLine();

            if (name != "")
                accounts[ID, 1] = name;

            if (phone != "")
                accounts[ID, 2] = phone;

            Console.WriteLine("Account info successfully updated! \n");
            Console.WriteLine("\n- Enter any key for user menu");
            Console.ReadLine();
            resetWindow();
            showUserOptions(ID);
        }
        else if (option == 6)
        {
            Console.WriteLine("Change account pin\n");
            Console.Write("Current PIN: ");
            string pin = Console.ReadLine();
            Console.Write("New PIN: ");
            string npin = Console.ReadLine();
            Console.Write("Confirm PIN: ");
            string cpin = Console.ReadLine();

            Console.WriteLine("\n");

            if (pin != accounts[ID, 5])
            {
                Console.WriteLine("Invalid current pin");
            }
            else if (npin != cpin)
            {
                Console.WriteLine("PIN not matched");
            }
            else
            {
                accounts[ID, 5] = npin;
                resetWindow();
                Console.WriteLine("PIN updated successfully!");
            }

            Console.WriteLine("\n- Enter any key for user menu");
            Console.ReadLine();

            resetWindow();
            showUserOptions(ID);
        }
        else 
        {
            loginOption();
        }
    }

    public void showBalance(int ID)
    {
        Console.WriteLine("Available Balance: {0}", accounts[ID, 4]);
        Console.WriteLine();
    }

    public void deposit(int ID)
    {
        Console.Write("Enter deposit amount: ");
        int depAmount = Convert.ToInt32(Console.ReadLine());
        int curBal = Convert.ToInt32(accounts[ID, 4]);
        accounts[ID, 4] = (curBal + depAmount).ToString();
        Console.WriteLine("\nNew balance : {0} \n\n", accounts[ID, 4]);
    }

    public void withdraw(int ID)
    {
        Console.Write("Enter withdraw amount: ");
        int wdAmount = Convert.ToInt32(Console.ReadLine());
        int curBal = Convert.ToInt32(accounts[ID, 4]);

        if (wdAmount > curBal)
        {
            Console.WriteLine("Insufficient Balance");
        }
        else
        {
            accounts[ID, 4] = (curBal - wdAmount).ToString();
            Console.WriteLine("\nNew balance : {0}\n\n", accounts[ID, 4]);
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
