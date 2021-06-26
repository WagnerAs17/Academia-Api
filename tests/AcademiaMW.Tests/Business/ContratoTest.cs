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
            //arrange & act
            var contrato = new Contrato(Guid.NewGuid(), TempoContrato.SeisMeses, 10);

            //assert
            Assert.True(contrato.Ativo);
        }

        [Fact(DisplayName = "Adicionar novo contrato com tempo inválido")]
        [Trait("Categoria", "Contrato test")]
        public void AdicionarContrato_NovoContrato_ContratoInvalido()
        {
            //arrange & act
            var tempoContrato = (TempoContrato)10;
            var contrato = new Contrato(Guid.NewGuid(),  tempoContrato , 10);

            //assert
            Assert.False(contrato.TempoDeContratoValido());
        }

        [Fact(DisplayName = "Contrato encerrado")]
        [Trait("Categoria", "Contrato test")]
        public void AdicionarContrato_ContratoCadastrado_ContratoEncerrado()
        {
            //arrange
            var contrato = new Contrato(Guid.NewGuid(), TempoContrato.SeisMeses, 10);

            //act
            contrato.EncerrarContrato();

            //assert
            Assert.False(contrato.ContratoValido());
        }
    }
}
