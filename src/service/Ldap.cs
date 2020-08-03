using System;
using System.Collections.Generic;
using System.Text;

using Unionized.Contract;
using Unionized.Contract.Service;
using Novell.Directory.Ldap;

namespace Unionized.Service
{ 
    public class LdapService : ILdapService
    {
        private readonly string[] _attributes = {
        "objectSid", "objectGUID", "objectCategory", "objectClass", "memberOf", "name", "cn", "distinguishedName",
        "sAMAccountName", "sAMAccountName", "userPrincipalName", "displayName", "givenName", "sn", "description",
        "telephoneNumber", "mail", "streetAddress", "postalCode", "l", "st", "co", "c"
        };

        public LdapService(UnionizedConfiguration config)
        {
            Configuration = config;
            Connection = GetConnection();
        }

        public bool ValidateDirectoryUser(string username, string password)
        {
            string dn = $"{username}@unionsquared.lan";
            bool isValid;
            try
            {
                Connection.Bind(dn, password);
                isValid = true;
            }
            catch
            {
                isValid = false;
            }
            return isValid;
        }

        public DirectoryUser GetDirectoryUser(string username)
        {
            var filter = $"(&(objectClass=user)(samAccountName={username}))";
            var searchResults = Connection.Search(Configuration.LdapSettings.SearchBase, LdapConnection.SCOPE_SUB, filter, this._attributes, false);

            DirectoryUser user = null;
            Connection.Bind(Configuration.ServiceAccount.Name, Configuration.ServiceAccount.Password);
            while (searchResults.hasMore())
            {
                LdapEntry entry = searchResults.next();
                user = entry.getAttributeSet().CreateUserfromAttributes(entry.DN);
            }

            return user;
        }

        private LdapConnection GetConnection()
        {
            var connection = new LdapConnection()
            {
                SecureSocketLayer = false
            };

            connection.Connect(Configuration.LdapSettings.ServerName, LdapConnection.DEFAULT_PORT);

            return connection;
        }

        protected UnionizedConfiguration Configuration { get; set; }

        protected LdapConnection Connection { get; set; }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (Connection != null)
                    {
                        Connection.Disconnect();
                        Connection.Dispose();
                    }
                }

                disposedValue = true;
            }
        }
        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion
    }
}
