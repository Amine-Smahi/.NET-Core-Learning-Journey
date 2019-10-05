using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Entities
{
    public abstract class Base
    {
        public virtual int Id { get; set; }
        public virtual DateTime DataCadastro { get; set; }
        public virtual bool Status { get; set; }
    }
}
