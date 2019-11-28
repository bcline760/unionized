using System;
using System.Collections.Generic;
using System.Text;

namespace Unionized.Contract
{
    public class DirectoryUser
    {
        public string ObjectSid { get; set; }

        public string ObjectGuid { get; set; }

        public string ObjectCategory { get; set; }

        public string ObjectClass { get; set; }

        public string Name { get; set; }

        public string CommonName { get; set; }

        public string DistinguishedName { get; set; }

        public string SamAccountName { get; set; }

        public int SamAccountType { get; set; }

        public string[] MemberOf { get; set; }

        public bool IsDomainAdmin { get; set; }

        public bool MustChangePasswordOnNextLogon { get; set; }

        public string UserPrincipalName { get; set; }

        public string DisplayName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{this.FirstName} {this.LastName}";

        public string EmailAddress { get; set; }

        public string Description { get; set; }

        public string Phone { get; set; }

        public LdapAddress Address { get; set; }

        public string SecurityStamp => Guid.NewGuid().ToString("D");

        public string UserName
        {
            get => this.Name;
            set => this.Name = value;
        }

        public string NormalizedUserName => this.UserName;

        public string NormalizedEmail => this.EmailAddress;

        public string Id => Guid.NewGuid().ToString("D");

        public string Email => this.EmailAddress;
    }

    public class LdapAddress
    {
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
    }
}
