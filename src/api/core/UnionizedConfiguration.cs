using System;
using System.Collections.Generic;
using System.Text;

namespace Unionized
{
    public class UnionizedConfiguration
    {
        public string AllowedHosts { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public bool IsDevelopment { get; set; }

        public LdapSettings LdapSettings { get; set; }

        public ServiceAccount ServiceAccount { get; set; }

        public ApiEndpoint HomeAssistant { get; set; }
    }

    public class LdapSettings
    {
        public string ServerName { get; set; }

        public string SearchBase { get; set; }
    }

    public class ServiceAccount
    {
        public string Name { get; set; }

        public string Password { get; set; }
    }

    public class ApiEndpoint
    {
        public string Endpoint { get; set; }

        public string ApiKey { get; set; }
    }
}
