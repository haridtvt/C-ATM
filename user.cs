class user
{
	private string username;
	private string PIN;
	private string nation;
	private float balance;
	public user(string username, string PIN, string nation, float balance)
	{
		this.username = username;
		this.PIN = PIN;
		this.nation = nation;
		this.balance = balance;
	}
	public string get_username() { return this.username;}
	public string get_PIN() { return this.PIN;}
	public string get_nation() { return this.nation;}
	public float get_balance() { return this.balance;}	
	public void set_username(string value1) {this.username = value1;}
	public void set_PIN(string value1) {this.PIN = value1;}
	public void set_nation(string value1) {this.nation = value1;}
	public void set_balance(float value1) {this.balance = value1;}
}