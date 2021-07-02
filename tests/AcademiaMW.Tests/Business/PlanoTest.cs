using AcademiaMW.Business.Models;
using Xunit;

namespace AcademiaMW.Tests.Business
{
    public class PlanoTest
    {
        [Fact(DisplayName = "Adicionar novo plano")]
        [Trait("Categoria", "Plano tests")]
        public void AdicionarNovoPlano_NovoCliente_ComSucesso()
        {
            //arrange e act 
            var planoValor = new PlanoValor(100, new Plano("Hercules")) ;

            //Assert
            Assert.True(planoValor.Plano.EhValido());
            Assert.True((bool)planoValor.Plano.Ativo);
        }

        [Fact(DisplayName = "Desativar o plano")]
        [Trait("Categoria", "Plano tests")]
        public void DesativarPlano_PlanoCadastrado_ComSucesso()
        {
            //arrange 
            var planoValor = new PlanoValor(100, new Plano("Hercules"));

            //act
            planoValor.Plano.DesativarPlano();

            //Assert
            Assert.False((bool)planoValor.Plano.Ativo);
        }
    }
}
