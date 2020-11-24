using System;
using Common;
using Domain.Events;

namespace Domain.Entities
{
    public class Patient
    {
        public Patient(string name, string email)
        {
            Id = new Guid();
            Name = name;
            Email = email;
            Console.WriteLine($"Attempting to create the patient {Name} with email {Email}");
            DomainEvents.Raise(new PatientCreated(this));
        }

        public Guid Id { get; set; }
        public string Name { get; }
        public string Email { get; }
    }
}
