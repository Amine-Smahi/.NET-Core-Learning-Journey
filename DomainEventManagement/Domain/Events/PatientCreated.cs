using System;
using Common;
using Common.Interfaces;
using Domain.Entities;

namespace Domain.Events
{
    public readonly struct PatientCreated : IDomainEvent
    {
        public DateTime DateOccurred { get; }

        public readonly Patient Patient;

        public PatientCreated(Patient patient)
        {
            Patient = patient;
            DateOccurred = DateTime.Now;

            Console.WriteLine("=> Patient created event raised");
        }
    }
}
