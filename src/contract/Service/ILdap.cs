using System;

using Unionized.Contract;
namespace Unionized.Contract.Service
{
    public  interface ILdap : IDisposable
    {
        DirectoryUser GetDirectoryUser(string username);
        bool ValidateDirectoryUser(string username, string password);
    }
}