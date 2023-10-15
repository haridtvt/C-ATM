using System;
using System.Data.Common;
using System.Reflection.Metadata;
using System.Xml.Serialization;
class Program
{
    static int id;
    static int try_enter = 0;

    static void Main(string[] args)
    {
        monitor_console monitor = new monitor_console();
        
        
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
                    Console.WriteLine("Try again!!!");
                    try_enter +=1;
                }
            }
            else 
            {
                monitor.input_error_user_not_exist();
                Console.WriteLine("Try again!!");
                try_enter +=1;
            }
            if (try_enter == 3) {exit_pg();}
        }
        // Check login, if enter wrong username or password three time, ATM exit()



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
        Console.WriteLine("Good Bye !!!");
    }
    public static void exit_pg()
    {
        Environment.Exit(0);
    }
}