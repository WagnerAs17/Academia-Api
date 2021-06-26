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
            var plano = new Plano("Hercules", 100);

            //Assert
            Assert.True(plano.EhValido());
            Assert.True(plano.Ativo);
        }

        [Fact(DisplayName = "Desativar o plano")]
        [Trait("Categoria", "Plano tests")]
        public void DesativarPlano_PlanoCadastrado_ComSucesso()
        {
            //arrange 
            var plano = new Plano("Hercules", 100);

            //act
            plano.DesativarPlano();

            //Assert
            Assert.False(plano.Ativo);
        }
    }
}
