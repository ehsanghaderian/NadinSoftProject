using DomainModel.Exceptions;
using DomainModel.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DomainModel.Products
{
    public class Product
    {
        //for orm!
        private Product(){}
        public Product(string name, DateTime produceDate, string? manufacturerPhone, string manufacturerEmail, bool isAvailable, Guid operatorId, string operatorName)
        {
            EmailValidation(manufacturerEmail);
            ProductNameValidation(name);
            ProduceDateValidation(produceDate);

            Id = Guid.NewGuid();
            Name = name;
            ProduceDate = produceDate;
            ManufacturerPhone = manufacturerPhone;
            ManufacturerEmail = manufacturerEmail;
            IsAvailable = isAvailable;
            OperatorInfo = new Operator(operatorId, operatorName);
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public DateTime ProduceDate { get; private set; }
        public string? ManufacturerPhone { get; private set; }
        public string ManufacturerEmail { get; private set; }
        public bool IsAvailable { get; private set; }
        public Operator OperatorInfo { get; private set; }

        public void Update(string name , string? manufacturerPhone, bool isAvailable)
        {
            ProductNameValidation(name);

            Name = name;
            ManufacturerPhone = manufacturerPhone;
            IsAvailable = isAvailable;
        }

        private void EmailValidation(string email)
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

            if (string.IsNullOrEmpty(email) || !Regex.IsMatch(email, regex, RegexOptions.IgnoreCase))
                throw new DomainServiceException("ایمیل سازنده محصول معتبر نمی باشد");
        }

        private void ProductNameValidation(string productName)
        {
            if (string.IsNullOrEmpty(productName))
                throw new DomainServiceException("نام محصول معتبر نمی باشد");
        }

        private void ProduceDateValidation(DateTime produceDate)
        {
            if(produceDate ==  DateTime.MinValue || produceDate == DateTime.MaxValue)
                throw new DomainServiceException("تاریخ تولید محصول معتبر نمی باشد");
        }
    }
}
