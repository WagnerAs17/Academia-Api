using AcademiaMW.Business.Models;
using AcademiaMW.Core.ValueTypes;
using System;
using System.Linq;
using Xunit;

namespace AcademiaMW.Tests.Business
{
    //public class ClienteTest
    //{
    //    [Fact(DisplayName = "Adicionar novo cliente sem nome")]
    //    [Trait("Categoria", "Cliente Test")]
    //    public void AdicionarNovoCliente_NovoCliente_SemONome()
    //    {
    //        //arrange
    //        var planoValorId = Guid.NewGuid();
    //        var userId = Guid.NewGuid();
    //        var endereco = CriarEndereco();

    //        //act
    //        var cliente = new Cliente(userId, planoValorId, string.Empty, 
    //            new DateTime(1999, 12, 23), "59188260097", "email@email.com", endereco);

    //        //assert
    //        Assert.False(cliente.EhValido());
    //        Assert.Equal(1, cliente.ValidationResult.Errors.Count);
    //        Assert.Equal("O nome é obrigatório", cliente.ValidationResult.Errors.FirstOrDefault().ErrorMessage);
    //    }

    //    [Fact(DisplayName = "Adicionar novo cliente com cpf inválido")]
    //    [Trait("Categoria", "Cliente Test")]
    //    public void AdicionarNovoCliente_NovoCliente_CpfInvalido()
    //    {
    //        //arrange
    //        var planoValorId = Guid.NewGuid();
    //        var userId = Guid.NewGuid();
    //        var endereco = CriarEndereco();

    //        //act & assert
    //        Assert.Throws<DomainException>(() =>
    //            new Cliente(userId, planoValorId, "Rodolfo", new DateTime(1999, 12, 23), string.Empty ,"email@email.com", endereco));
    //    }

    //    [Fact(DisplayName = "Adicionar novo cliente menor que treze anos")]
    //    [Trait("Categoria", "Cliente Test")]
    //    public void AdicionarNovoCliente_NovoCliente_MenorQueTrezeAnos()
    //    {
    //        //arrange
    //        var planoValorId = Guid.NewGuid();
    //        var userId = Guid.NewGuid();
    //        var endereco = CriarEndereco();
    //        var cliente = new Cliente(userId, planoValorId, "Rodolfo", DateTime.Now, "59188260097", "email@email.com", endereco);

    //        //act 
    //        var maiorIdade = cliente.EhMenorDeTrezeAnos();

    //        //arrange
    //        Assert.False(maiorIdade);
    //    }

    //    public Endereco CriarEndereco()
    //    {
    //        return new Endereco("Violetea", "200", "Jardim Odete", "08598140", "Itaquaquecetuba", "SP");
    //    }
    //}
}
