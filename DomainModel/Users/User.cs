using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Users
{
    public class User : IdentityUser<Guid>
    {
        public User(string name) : base()
        {
            NameValidation(name);

            this.Name = name;
        }

        public string Name { get; private set; }

        private void NameValidation(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("نام کاربر معتبر نمی باشد");
        }
    }
}
