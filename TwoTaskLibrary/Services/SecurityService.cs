using System.Net.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace TwoTaskLibrary.Services
{
    public class SecurityService : ISecurityService
    {
        private static readonly HMACSHA512 Hmac = new HMACSHA512();

        public byte[] ComputeHash(string passwordToCompute)
        {
            return Hmac.ComputeHash(Encoding.UTF8.GetBytes(passwordToCompute.ToCharArray()));
        }

        public byte[] GetKey()
        {
            return Hmac.Key;
        }
    }

    public interface ISecurityService
    {
        byte[] ComputeHash(string passwordToCompute);
        byte[] GetKey();
    }
}