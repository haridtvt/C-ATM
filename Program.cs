using System;
using System.Data.Common;
using System.Reflection.Metadata;
using System.Text.Encodings.Web;
using System.Xml.Serialization;
class Program
{
    static int id;
    static int try_enter = 0;
    static int try_option = 0;

    static void Main(string[] args)
    {
        monitor_console monitor = new monitor_console();
        feature_ATM ATM = new feature_ATM();
        
        // database user       	
        string[] user_name = {"Hari","VanHai","Ronaldo","Messi","Booklee"};
        string[] user_nation = {"VietNam","VietNam","Portugal","Arghentina","Korea"};
        string[] user_PIN = {"Hari123","hari","goat_1","goat_2","banbua"};
        float[] user_balance = {1500,1800,67000000,60000000,100};
        // database user       	



        //have a 5 object user        	
        user[] user_id = new user[5];
        for (int i = 0; i < 5; i++)
        {
            user_id[i] = new user(user_name[i],user_PIN[i],user_nation[i],user_balance[i]);
        }
        //have a 5 object user
        
        // Check login, if enter wrong username or password three time, ATM exit()
        while(true)
        {
            string username = monitor.input_console_username();
            if(checking_exist(username,user_id))
            {
                string passwod =  monitor.input_console_password();
                if (checking_password(passwod, user_id[id].get_PIN()))
                {
                    monitor.welcome();
                    break;
                }
                else 
                {
                    monitor.input_error_password();
                    Console.WriteLine("Try again!!!".ToUpper());
                    try_enter +=1;
                }
            }
            else 
            {
                monitor.input_error_user_not_exist();
                Console.WriteLine("Try again!!".ToUpper());
                try_enter +=1;
            }
            if (try_enter == 3) {exit_pg();}
        }
        // Check login, if enter wrong username or password three time, ATM exit()


        //Conduct feature ATM:
        while(true)
        {
            monitor.monitor_option();
            int option = int.Parse(Console.ReadLine());
            if (option > 4 || option < 0)
            {
                monitor.option_invalid();
                Console.WriteLine("Try again!!".ToUpper());
                try_option +=1;
                if (try_option > 2) {exit_pg();}
            }
            switch(option)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("======= INFO USER ========");
                    Console.WriteLine("YOUR NAME: " + user_id[id].get_username());
                    Console.WriteLine("YOUR NATION: " + user_id[id].get_nation());
                    Console.WriteLine("YOUR BALANCE: " + user_id[id].get_balance());
                    Console.WriteLine("==========================");
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("ENTER YOUR MONEY: ");
                    int money = int.Parse(Console.ReadLine());
                    if (ATM.check_money(money,user_id[id].get_balance()))
                    {
                        Console.WriteLine("HERE IS YOUR MONEY: " + money);
                        user_id[id].set_balance(ATM.update_money(user_id[id].get_balance(),money));
                        Console.WriteLine("ACCOUNT BALANCE: " + user_id[id].get_balance());
                    }
                    else {Console.WriteLine("NOT ENOUGH MONEY");}
                    break;  
                case 3:
                    Console.Clear();
                    Console.WriteLine("ENTER YOUR PIN: ");
                    string old_PIN = Console.ReadLine();
                    if (old_PIN == user_id[id].get_PIN())
                    {
                        int confirm = 0;
                        while(true)
                        {
                            Console.WriteLine("Enter your new PIN: ".ToUpper());
                            string new_PIN = Console.ReadLine();
                            Console.WriteLine("Please confirm your new PIN".ToUpper());
                            string new_PIN2 = Console.ReadLine();
                            if(confirm_newPIN(new_PIN,new_PIN2))
                            {
                                user_id[id].set_PIN(new_PIN);
                                Console.WriteLine("\n");
                                Console.WriteLine("===  Success !!  ====".ToUpper());
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("PIN not match, Try again".ToUpper());                
                                confirm +=1;
                            }
                            if (confirm > 2) {break;}
                        }
                    }
                    else {monitor.input_error_password();}
                    break;
                // case 4:
                //     Console.WriteLine("Enter your user need to tranfer: ");
                //     string new_user = Console.ReadLine();

                //     break;
                case 4:
                    out_of_ATM();
                    exit_pg();
                    break;
            }
        }
        //Conduct feature ATM:

    }
    public static bool checking_exist(string input_user, user[] args)
    {
        for(int i = 0;i< args.Length;i++)
        {
            if(args[i].get_username() ==  input_user)
            {
                id = i;
                return true;
            }
        }
        return false;
    }
    public static bool checking_password(string input_password, string arg)
    {
        if(arg ==  input_password)
        {
            return true;
        }
        else {return false;}
    }
    public static void out_of_ATM()
    {
        Console.Clear();
        Console.WriteLine("==========================");
        Console.WriteLine("THANK YOU FOR YOUR CHOICE");
        Console.WriteLine("Good Bye !!!".ToUpper());
    }
    public static void exit_pg()
    {
        Environment.Exit(0);
    }
    public static bool confirm_newPIN(string PIN1, string PIN2)
    {
        if (PIN1 == PIN2)
        {
            return true;
        }
        else {return false;}
    }
}