using AcademiaMW.Business.Enum;
using AcademiaMW.Business.Models;
using System;
using Xunit;

namespace AcademiaMW.Tests.Business
{
    public class ContratoTest
    {
        [Fact(DisplayName = "Adicionar novo contrato")]
        [Trait("Categoria", "Contrato test")]
        public void AdicionarContrato_NovoContrato_ComSucesso()
        {
            //arrange
            var planoDesconto = new PlanoDesconto(Guid.NewGuid(), 2);

            //act
            var contrato = new Contrato(planoDesconto);

            //assert
            Assert.True(contrato.Ativo);
        }

        [Fact(DisplayName = "Contrato encerrado")]
        [Trait("Categoria", "Contrato test")]
        public void AdicionarContrato_ContratoCadastrado_ContratoEncerrado()
        {
            //arrange
            var planoDesconto = new PlanoDesconto(Guid.NewGuid(), 2);
            var contrato = new Contrato(planoDesconto);

            //act
            contrato.EncerrarContrato();

            //assert
            Assert.False(contrato.ContratoValido());
        }
    }
}
