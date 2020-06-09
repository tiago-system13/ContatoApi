using System;

namespace bdiApi.Models.DTO
{
    public class ContatoDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sexo { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}
