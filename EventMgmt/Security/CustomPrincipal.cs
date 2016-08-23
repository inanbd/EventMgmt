using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using DAL;

namespace EventMgmt.Security
{
    public class CustomPrincipal : IPrincipal
    {

        private User user;
        public CustomPrincipal(String username)
        {

        }

        public IIdentity Identity
        {
            get;set;
        }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}