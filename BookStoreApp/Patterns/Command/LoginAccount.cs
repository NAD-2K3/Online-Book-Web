using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Patterns.Command
{
    internal class LoginAccount : ICommand
    {
        private Account account;

        public LoginAccount(Account account)
        {
            this.account = account;
        }   

        public void execute()
        {
            account.Login();
        }
    }
}
