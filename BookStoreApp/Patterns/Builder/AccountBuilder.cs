using BookStoreApp.Models;
using BookStoreApp.Patterns.Builder;
using System.Security.Principal;

public class AccountBuilder : IAccountBuilder
{
    private readonly Customer cus = new Customer(); 

    public IAccountBuilder SetName(string name)
    {
        cus.Name = name;
        return this;
    }

    public IAccountBuilder SetBirthDay(System.DateTime DOB)
    {
        cus.DOB = DOB;
        return this;
    }

    public IAccountBuilder SetPhone(string Phone_number)
    {
        cus.Phone_Number = Phone_number;
        return this;
    }

    public IAccountBuilder SetAddress(string address)
    {
        cus.Address = address;
        return this;
    }

    public IAccountBuilder SetUserName(string user_name)
    {
        cus.User_Name = user_name;
        return this;
    }

    public IAccountBuilder SetPassword(string password)
    {
        cus.Password = password;
        return this;
    }

    public Customer Create()
    {
        return cus;
    }
}
