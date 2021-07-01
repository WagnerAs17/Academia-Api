using AcademiaMW.Business.Enum;
using AcademiaMW.Business.Models;
using AcademiaMW.Core.ValueTypes;
using System;
using System.Linq;
using Xunit;

namespace AcademiaMW.Tests.Business
{
    public class ClienteTest
    {
        [Fact(DisplayName = "Adicionar novo cliente")]
        [Trait("Categoria", "Cliente Test")]
        public void AdicionarNovoCliente_NovoCliente_ComContrato()
        {
            //arrange & act
            var cliente = Cliente.ClienteFactory.CriarClienteComContrato("minhaSenha" 
                ,"Wagber" ,new DateTime(2000, 02, 17), "92578850038", "wagner@gmail.com");

            //assert
            Assert.True(cliente.EhValido());
        }

        [Fact(DisplayName = "Adicionar novo cliente menor de idade")]
        [Trait("Categoria", "Cliente Test")]
        public void AdicionarNovoCliente_NovoCliente_MenorDeIdade()
        {
            //arrange & act
            var cliente = Cliente.ClienteFactory.CriarClienteComContrato("minhaSenha",
                 "Wagner", new DateTime(2020, 02, 17), "92578850038", "wagner@gmail.com");

            //assert
            Assert.False(cliente.EhValido());
            Assert.True(cliente.ValidationResult.Errors.Any());
            Assert.Equal("O Cliente deve ter mais de 13 anos", cliente.ValidationResult.Errors.FirstOrDefault().ErrorMessage);
        }

        [Fact(DisplayName = "Adicionar novo cliente cpf inválido")]
        [Trait("Categoria", "Cliente Test")]
        public void AdicionarNovoCliente_NovoCliente_CpfInvalido()
        {
            //assert & act
            var exception = Assert.Throws<DomainException>(() => {
                Cliente.ClienteFactory
                    .CriarClienteComContrato("minhaSenha", 
                        "Wagner", 
                        new DateTime(2020, 02, 17), 
                        string.Empty, "wagner@gmail.com");
            });

            //assert
            Assert.IsType<DomainException>(exception);
            Assert.Equal("Cpf informado inválido", exception.Message);
        }

        [Fact(DisplayName = "Adicionar novo cliente e-mail inválido")]
        [Trait("Categoria", "Cliente Test")]
        public void AdicionarNovoCliente_NovoCliente_EmailInvalido()
        {
            //assert & act
            var exception = Assert.Throws<DomainException>(() => {
                Cliente.ClienteFactory
                    .CriarClienteComContrato("minhaSenha",
                        "Wagner",
                        new DateTime(2020, 02, 17),
                        "92578850038", string.Empty);
            });

            //assert
            Assert.IsType<DomainException>(exception);
            Assert.Equal("E-mail informado inválido", exception.Message);
        }
    }
}
