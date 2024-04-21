using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Patterns.Command
{
    public class AccountInvoker
    {
        private ICommand loginAccount;
        private ICommand logoutAccount;

        public AccountInvoker(ICommand loginAccount, ICommand logoutAccount)
        {
            this.loginAccount = loginAccount;
            this.logoutAccount = logoutAccount;
        }

        public void clickLoginAccount()
        {
            loginAccount.execute();
        }

        public void clickLogoutAccount()
        {
            logoutAccount.execute();
        }
    }
}
