using System;

namespace bdiApi.Models
{
    public class ContatoViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sexo { get; set; }

        public int Idade { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}
