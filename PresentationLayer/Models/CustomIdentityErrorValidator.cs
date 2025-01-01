using Microsoft.AspNetCore.Identity;

namespace PresentationLayer.Models
{
    public class CustomIdentityErrorValidator : IdentityErrorDescriber
    {
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError()
            {
                Code = "DuplicateEmail",
                Description = "Bu E-Posta Adresi Sistemde Zaten Kayıtlı!"
            };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresDigit",
                Description = "Şifrenizde En Az 1 Tane Rakam Olmalı!"
            };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresLower",
                Description = "Şifrenizde En Az 1 Tane Küçük Harf Olmalı!"
            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = "Şifrenizde En Az 1 Tane Büyük Harf Olmalı!"
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = "Şifrenizde En Az 1 Tane Sembol Olmalı!"
            };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = "Şifreniz En Az 6 Karakter Olmalı!"
            };
        }
    }
}
