using System;
using Hanka.ApiDotNet6.Domain.Validations;

namespace Hanka.ApiDotNet6.Domain.Entities
{
    /*
        sealed não pode ser herdada 
    */
    public sealed class Person
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Phone { get; private set; }

        public Person(string document, string name, string phone)
        {
            Validation(document, name, phone);        
        }

        private void Validation(string document, string name, string phone)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Name cannot be null or empty");
            DomainValidationException.When(string.IsNullOrEmpty(document), "Document cannot be null or empty");
            DomainValidationException.When(string.IsNullOrEmpty(phone), "Document cannot be null or empty");

            Name = name;
            Document = document;
            Phone = Phone;
        }
    }
}

