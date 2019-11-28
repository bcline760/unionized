using System;
using System.Collections.Generic;
using System.Text;

namespace Unionized
{
    public class UnionizedConfiguration
    {
        public string AllowedHosts { get; set; }

        public string EncryptionKey { get; set; }

        //public Dictionary<string,string> SecurityGroups { get; set; }

        public string ConnectionString { get; set; }

        public LdapSettings LdapSettings { get; set; }

        public ServiceAccount ServiceAccount { get; set; }

        public CertificateSettings Certificate { get; set; }
    }

    public class LdapSettings
    {
        public string ServerName { get; set; }

        public string SearchBase { get; set; }

        public string ContainerName { get; set; }

        public string DomainName { get; set; }

        public string DomainDistinguishedName { get; set; }
    }

    public class ServiceAccount
    {
        public string Name { get; set; }

        public string Password { get; set; }
    }

    public class CertificateSettings
    {
        public string Thumbprint { get; set; }

        public string CommonName { get; set; }

        public string CertificateLocation { get; set; }

        public string Password { get; set; }
    }
}
