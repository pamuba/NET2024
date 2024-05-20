using Microsoft.AspNetCore.DataProtection;

namespace DemoWebApplication.Security
{
    public class UniqueCode
    {
        public readonly string BankIdRouteValue = "BankIdRouteValue";
    }
    public class CustomIDataProtection
    {
        private readonly IDataProtector protector;
        public CustomIDataProtection(IDataProtectionProvider dataProtectionProvider, UniqueCode uniqueCode)
        {
            protector = dataProtectionProvider.CreateProtector(uniqueCode.BankIdRouteValue);
        }
        public string Decode(string data)
        {
            return protector.Protect(data);
        }
        public string Encode(string data)
        {
            return protector.Unprotect(data);
        }
    }
}
