using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Entities
{
    public class Book : Base
    {
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public string Assunto { get; set; }
        public int Ano { get; set; }
        public int NumeroDePaginas { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public double Peso { get; set; }
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
        public int EditorId { get; set; }
        public Editor Editor { get; set; }
    }
}
