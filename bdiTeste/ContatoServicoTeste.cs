using bdiEntidades.Entidades;
using bdiNegocios.Exceptions;
using bdiNegocios.Interfaces;
using bdiNegocios.Servicos;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bdiTeste
{
    public class ContatoServicoTeste
    {
        private Mock<IContatoRepositorio> contatoRepositorioMock;

        private ContatoServico ContatoServico;

        [SetUp]
        public void Setup()
        {
            contatoRepositorioMock = new Mock<IContatoRepositorio>();

            contatoRepositorioMock.Setup(c => c.ListarTodos()).Returns(ListarContatosMock);

            contatoRepositorioMock.Setup(c => c.Adicionar(It.IsAny<Contato>())).Returns(ListarContatosMock().FirstOrDefault());

            contatoRepositorioMock.Setup(c => c.Editar(It.IsAny<Contato>(), It.IsAny<Contato>())).Returns(ListarContatosMock().FirstOrDefault());

            contatoRepositorioMock.Setup(c => c.ObterPorNome(It.IsAny<string>())).Returns(ListarContatosMock().FirstOrDefault());

            ContatoServico = new ContatoServico(contatoRepositorioMock.Object);
        }

        [Test]
        public void AdicionarContato_ComSucesso_RetornaContato()   
        {
            contatoRepositorioMock.Setup(c => c.ObterPorNome(It.IsAny<string>())).Returns((Contato)null);
            var contato = ObterContatoMock(1, "Tiago Santos", Convert.ToDateTime("13/02/1988"));
            var resultado = ContatoServico.AdicionarAsync(contato).Result;

            Assert.NotNull(resultado);
            Assert.AreEqual(contato.Id, resultado.Id);
            Assert.AreEqual(contato.Nome, resultado.Nome);
            Assert.AreEqual(contato.DataNascimento, resultado.DataNascimento);
            contatoRepositorioMock.Verify(p => p.Adicionar(It.IsAny<Contato>()), Times.Once);
        }

        [Test]
        public void AdicionarContato_Exception_Idade_Inferior_5anos()
        {
            var contato = ObterContatoMock(1, "Yan Santana", Convert.ToDateTime("22/04/2016"));
    
            var ex = Assert.ThrowsAsync<NegocioException>(() => ContatoServico.AdicionarAsync(contato));
            Assert.That(ex.Message, Is.EqualTo($"O Contato não tem permissão para ser criado, pois tem idade inferior a 5 anos"));
        }

        [Test]
        public void AdicionarContato_Exception_Duplicidade_Nome()
        {
            var contato = ObterContatoMock(1, "Tiago Santos", Convert.ToDateTime("13/02/1988"));

            var ex = Assert.ThrowsAsync<NegocioException>(() => ContatoServico.AdicionarAsync(contato));
            Assert.That(ex.Message, Is.EqualTo($"Já existe registro de contato com mesmo nome na base de dados."));
        }

        [Test]

        public void EditarContato_ComSucesso_RetornaContato()
        {
            contatoRepositorioMock.Setup(p => p.ObterPorId(It.IsAny<int>())).Returns(ListarContatosMock().FirstOrDefault());

            var contato = ObterContatoMock(1, "Tiago Santos", Convert.ToDateTime("13/02/1988"));

            var resultado = ContatoServico.EditarAsync(contato).Result;

            Assert.NotNull(resultado);
            Assert.AreEqual(contato.Id, resultado.Id);
            Assert.AreEqual(contato.Nome, resultado.Nome);
            Assert.AreEqual(contato.DataNascimento, resultado.DataNascimento);
            contatoRepositorioMock.Verify(p => p.Editar(It.IsAny<Contato>(), It.IsAny<Contato>()), Times.Once);

        }

        [Test]
        public void EditarContato_Exception_Duplicidade_Nome()
        {
            var contato = ObterContatoMock(1, "Tiago Santos", Convert.ToDateTime("13/02/1988"));
            contato.Id = 10;

            var ex = Assert.ThrowsAsync<NegocioException>(() => ContatoServico.AdicionarAsync(contato));
            Assert.That(ex.Message, Is.EqualTo($"Já existe registro de contato com mesmo nome na base de dados."));
        }


        [Test]
        public void EditarContato_Exception_Idade_Inferior_5anos()
        {
            var contato = ObterContatoMock(1, "Sandra Santana", Convert.ToDateTime("22/04/2018"));

            var ex = Assert.ThrowsAsync<NegocioException>(() => ContatoServico.AdicionarAsync(contato));
            Assert.That(ex.Message, Is.EqualTo($"O Contato não tem permissão para ser criado, pois tem idade inferior a 5 anos"));
        }

        [Test]
        public void EditarContato_Exception_ContatoNaoEncontrado()
        {
            var contato = ObterContatoMock(1, "Tiago Santos", Convert.ToDateTime("13/02/1988"));

            contatoRepositorioMock.Setup(p => p.ObterPorId(It.IsAny<int>())).Returns((Contato)null);

            var ex = Assert.ThrowsAsync<NegocioException>(() => ContatoServico.EditarAsync(contato));

            Assert.That(ex.Message, Is.EqualTo($"Contato não encontrado para o id: { contato.Id}"));
        }

        [Test]
        public void ObterContatoPorId_ComSucesso_RetornaContato()
        {
            var contato = ListarContatosMock().FirstOrDefault();

            contatoRepositorioMock.Setup(p => p.ObterPorId(It.IsAny<int>())).Returns(contato);

            var resultado = ContatoServico.ObterPorIdAsync(It.IsAny<int>()).Result;

            Assert.IsNotNull(resultado);
            Assert.AreEqual(resultado.Id, contato.Id);
        }

        [Test]
        public void ObterContatoPorId_ComException_ContatoNaoEncontrado()
        {

            contatoRepositorioMock.Setup(p => p.ObterPorId(It.IsAny<int>())).Returns((Contato) null);
            var id = 50;
            var ex = Assert.ThrowsAsync<NegocioException>(() => ContatoServico.ObterPorIdAsync(id));
            Assert.That(ex.Message, Is.EqualTo($"Contato não encontrado para o id: {id}"));
        }

        [Test]
        public void DeletarContato_ComSucesso()
        {
            var contato = ListarContatosMock().FirstOrDefault();

            contatoRepositorioMock.Setup(p => p.ObterPorId(It.IsAny<int>())).Returns(contato);

            contatoRepositorioMock.Setup(p => p.Deletar(It.IsAny<Contato>())).Returns(true);

            var resultado = ContatoServico.DeletarAsync(contato.Id).Result;

            Assert.IsNotNull(resultado);
            Assert.AreEqual(true, resultado);
            contatoRepositorioMock.Verify(p => p.Deletar(It.IsAny<Contato>()), Times.Once);
        }

        [Test]
        public void DeletarContato_ComException_ContatoNaoEncontrado()
        {

            contatoRepositorioMock.Setup(p => p.ObterPorId(It.IsAny<int>())).Returns((Contato)null);
            
            var id = 12;
            var ex = Assert.ThrowsAsync<NegocioException>(() => ContatoServico.DeletarAsync(id));
            Assert.That(ex.Message, Is.EqualTo($"Contato não encontrado para o id: {id}"));
        }

        [Test]
        public void ListarContatos_ComSucesso_RetornaListaContato()
        { 
            var resultado = ContatoServico.ListarContatosAsync().Result;

            Assert.IsNotEmpty(resultado);
            Assert.AreEqual(ListarContatosMock().Count, resultado.Count);
        }


        private Contato ObterContatoMock(int id, string nome, DateTime dateNascimento)
        {
            return new Contato()
            {
                Id = id,
                Nome = nome,
                Sexo = "F",
                DataNascimento = dateNascimento
            };
        }

        private List<Contato> ListarContatosMock()
        {
            return new List<Contato>()
            {
               ObterContatoMock(1,"Tiago Santos",Convert.ToDateTime("13/02/1988")),
               ObterContatoMock(1,"Yan Santana",Convert.ToDateTime("22/04/2016")),
                ObterContatoMock(1,"Maria Santana",Convert.ToDateTime("13/03/1076")),
            };
        }
    }
}