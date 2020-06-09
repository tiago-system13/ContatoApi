using System;

namespace bdiEntidades.Entidades
{
    public class Contato
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sexo { get; set; }

        public DateTime DataNascimento { get; set; }

        public int Idade { get; set; }

        public Contato()
        {

        }
        public Contato(Contato contato)
        {
            this.Id = contato.Id;
            this.Nome = contato.Nome;
            this.Sexo = contato.Sexo;
            this.DataNascimento = contato.DataNascimento;
            this.Idade = contato.Idade;
        }
    }
}
