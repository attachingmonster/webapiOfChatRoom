using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using webapiOfChatRoom.Methods;
using webapiOfChatRoom.Models;

namespace webapiOfChatRoom.DAL
{
    class AccountInitializer :
       DropCreateDatabaseIfModelChanges<AccountContext>
    {
        protected override void Seed(AccountContext context)
        {
            var sysUsers = new List<SysUser>
            {               
                new SysUser {ID=1, UserAccount="Tom",UserPassword=CreateMD5.EncryptWithMD5("123"),RememberPassword="0"},
                new SysUser {ID=2, UserAccount ="Jerry",UserPassword =CreateMD5.EncryptWithMD5("123"),RememberPassword="0"}
                
            };
            sysUsers.ForEach(s => context.SysUsers.Add(s));
            context.SaveChanges();
          
          
        }
    }
}