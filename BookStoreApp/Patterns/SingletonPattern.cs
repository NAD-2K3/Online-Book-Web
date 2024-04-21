using System.Web;
using System.Web.SessionState;
using BookStoreApp.Models;

public sealed class SingletonPattern
{
    private static BookStoreOnlineEntities1 _instance;
    private static readonly object LockObject = new object();
    private BookStoreOnlineEntities1 _db { get; }
    private SingletonPattern() 
    {

    }

    public static BookStoreOnlineEntities1 Instance
    {
        get
        {
            lock (LockObject)
            {
                return _instance ?? new SingletonPattern().GetDbContext();
            }
        }
    }

    public BookStoreOnlineEntities1 GetDbContext()
    {
        if(_instance == null )
            _instance = new BookStoreOnlineEntities1(); 
        return _instance;
    }
}
