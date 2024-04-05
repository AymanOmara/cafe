namespace cafe.Domain.Users.Repository
{
	public interface IUserNotifier
	{
		Task Notify(string channel,string body);
    }
}

