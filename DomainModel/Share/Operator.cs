using DomainModel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Share
{
    public class Operator
    {
        public Operator(Guid id, string name)
        {
            IdValidation(id);
            NameValidation(name);

            this.Id = id;
            this.Name = name;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }

        private void IdValidation(Guid id)
        {
            if (id == Guid.Empty)
                throw new DomainServiceException("شناسه شخص معتبر نمی باشد");
        }

        private void NameValidation(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new DomainServiceException("نام شخض معتبر نمی باشد");
        }
    }
}
