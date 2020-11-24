using System;
using Common;
using Common.Interfaces;
using Domain.Events;

namespace Application.EventHandlers
{
    public class PatientCreatedHandler : IEventHandling<PatientCreated>
    {
        public void Handler(PatientCreated args)
        {
            Console.WriteLine("=> Patient created event handled");
            Console.WriteLine($"Sending email to {args.Patient.Name}");
        }
    }
}
