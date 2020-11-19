using System;
using System.Collections.Generic;
using System.Text;

using Novell.Directory.Ldap;
using Unionized.Contract;

namespace Unionized.Service
{
    public static class LdapExtensions
    {
        public static DirectoryUser CreateUserfromAttributes(this LdapAttributeSet attributeSet, string distinguishedName)
        {
            var ldapUser = new DirectoryUser
            {
                ObjectSid = attributeSet.getAttribute("objectSid")?.StringValue,
                ObjectGuid = attributeSet.getAttribute("objectGUID")?.StringValue,
                ObjectCategory = attributeSet.getAttribute("objectCategory")?.StringValue,
                ObjectClass = attributeSet.getAttribute("objectClass")?.StringValue,
                MemberOf = attributeSet.getAttribute("memberOf")?.StringValueArray,
                CommonName = attributeSet.getAttribute("cn")?.StringValue,
                UserName = attributeSet.getAttribute("name")?.StringValue,
                SamAccountName = attributeSet.getAttribute("sAMAccountName")?.StringValue,
                UserPrincipalName = attributeSet.getAttribute("userPrincipalName")?.StringValue,
                Name = attributeSet.getAttribute("name")?.StringValue,
                DistinguishedName = attributeSet.getAttribute("distinguishedName")?.StringValue ?? distinguishedName,
                DisplayName = attributeSet.getAttribute("displayName")?.StringValue,
                FirstName = attributeSet.getAttribute("givenName")?.StringValue,
                LastName = attributeSet.getAttribute("sn")?.StringValue,
                Description = attributeSet.getAttribute("description")?.StringValue,
                Phone = attributeSet.getAttribute("telephoneNumber")?.StringValue,
                EmailAddress = attributeSet.getAttribute("mail")?.StringValue,
                Address = new LdapAddress
                {
                    Street = attributeSet.getAttribute("streetAddress")?.StringValue,
                    City = attributeSet.getAttribute("l")?.StringValue,
                    PostalCode = attributeSet.getAttribute("postalCode")?.StringValue,
                    StateName = attributeSet.getAttribute("st")?.StringValue,
                    CountryName = attributeSet.getAttribute("co")?.StringValue,
                    CountryCode = attributeSet.getAttribute("c")?.StringValue
                },

                SamAccountType = int.Parse(attributeSet.getAttribute("sAMAccountType")?.StringValue ?? "0")
            };

            return ldapUser;
        }
    }
}
