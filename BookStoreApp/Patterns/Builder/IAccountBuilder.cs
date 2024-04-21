using BookStoreApp.Models;

namespace BookStoreApp.Patterns.Builder
{
    public interface IAccountBuilder
    {
        IAccountBuilder SetName(string firstName);
        IAccountBuilder SetBirthDay(System.DateTime DOB);
        IAccountBuilder SetPhone(string phone_number);
        IAccountBuilder SetPassword(string password);
        IAccountBuilder SetAddress(string address);
        IAccountBuilder SetUserName(string user_name);
        Customer Create();
    }

}
