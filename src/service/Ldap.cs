using System;
using System.Collections.Generic;
using System.Text;

using Unionized.Contract;
using Unionized.Contract.Service;
using Novell.Directory.Ldap;

namespace Unionized.Service
{ 
    public class Ldap : ILdap
    {
        private readonly string[] _attributes = {
        "objectSid", "objectGUID", "objectCategory", "objectClass", "memberOf", "name", "cn", "distinguishedName",
        "sAMAccountName", "sAMAccountName", "userPrincipalName", "displayName", "givenName", "sn", "description",
        "telephoneNumber", "mail", "streetAddress", "postalCode", "l", "st", "co", "c"
        };

        public Ldap(UnionizedConfiguration config)
        {
            Configuration = config;
            Connection = GetConnection();
        }

        public bool ValidateDirectoryUser(string username, string password)
        {
            bool isValid = false;
            string dn = $"{username}@unionsquared.lan";
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
            //connection.Bind(Configuration.ServiceAccount.Name, Configuration.ServiceAccount.Password);

            //if (!connection.Bound)
            //    throw new LdapException();

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
