using System.Threading;
public class monitor_console
{
	public string input_username;
	public string input_password;
	public void monitor_option()
	{
		Console.WriteLine("\n");
		Console.WriteLine("PLEASE CHOOSE OPTION: ");
		Console.WriteLine("==========================");
		Console.WriteLine("|	1. Check info		");
		Console.WriteLine("|	2. Withdraw			");
		Console.WriteLine("|	3. Change PIN		");
		// Console.WriteLine("4. Tranfer money");
		Console.WriteLine("|	4. Exit				");
		Console.WriteLine("==========================");
	}
	public void welcome()
	{
		Console.Clear();
		Console.WriteLine("\n");
		Console.WriteLine("               LOANGDING....                      ");
		Thread.Sleep(2);
		Console.WriteLine("==             LOGIN SUCESS                     ==");
		Console.WriteLine("                WELCOME {0}                       ",input_username);
		Console.WriteLine("==================================================");
        // Console.WriteLine(input_username);
	}
	public string input_console_username()
	{
		Console.WriteLine("==================================================");
		Console.WriteLine("                WELCOME TO ATM                    ");
		Console.WriteLine("==================================================");
		Console.WriteLine("\n");
		Console.WriteLine("-	Please enter your username: ".ToUpper());
		input_username = Console.ReadLine();
		return input_username;		
	}
	public string input_console_password()
	{
        	Console.WriteLine("-	Please enter your passwod".ToUpper());
        	this.input_password = Console.ReadLine();
        	return this.input_password;		
	}
	public void input_error_user_not_exist()
	{
		Console.WriteLine("user not exist".ToUpper());
	}
	public void input_error_password()
	{
		Console.WriteLine("==========================");
		Console.WriteLine("password wrong !!!".ToUpper());
	}
	public void option_invalid()
	{
		Console.WriteLine("==========================");
		Console.WriteLine("Option invalid		 ".ToUpper());
	}
	public void messeage_success_login(string user_input)
	{
		Console.WriteLine("Login Success".ToUpper() + user_input);
	}
}