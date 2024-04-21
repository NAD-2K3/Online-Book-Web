
using BookStoreApp.Models;
using System;

public class AccountDirector
{
    public Customer CreateStandardAccount(string name, string user_name, string password)
    {
        return new AccountBuilder()
            .SetName(name)
            .SetUserName(user_name)
            .SetPassword(password)
        .Create();
    }

    public Customer CreateFullAccount(string firstName, System.DateTime DOB, string phone, string address, string user_name, string password)
    {
        return new AccountBuilder()
            .SetName(firstName)
            .SetBirthDay(DOB)
            .SetPhone(phone)
            .SetAddress(address)
            .SetUserName(user_name)
            .SetPassword(password)
            .Create();
    }

    public AccountDirector CreateFullAccount()
    {
        throw new NotImplementedException();
    }
}


