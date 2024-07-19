using FluentResults;
using FluxoDiario.Domain.Contexts.FluxoDiario;
using FluxoDiario.Domain.Contexts.FluxoDiario.Lancamentos;
using FluxoDiario.Domain.Contexts.FluxoDiario.Saldos;
using Moq;

namespace FluxoDiario.Tests.Unit.Domain.Contexts.FluxoDiario.Saldos
{
    public class SaldoTests
    {
        [Fact]
        public void Contabilizar_WhenLancamentoIsInvalid_ReturnLancamentoFailedMessage()
        {
            #region Arrange
            string errorMessage = "Erro teste wharever";
            double valor = 123;
            var resultEsperado = Result.Fail(errorMessage);

            var lancamentoMock = new Mock<ILancamento>();
            var caixaMock = new Mock<Caixa>();
            lancamentoMock.Setup(x => x.Lancar(valor))
                .Returns(resultEsperado);

            var saldo = new Saldo(valor, caixaMock.Object);
            #endregion

            var result = saldo.Contabilizar(lancamentoMock.Object);

            Assert.Equal(resultEsperado.Errors.First().Message, result.Errors.First().Message);
        }

        [Fact]
        public void Contabilizar_WhenLancamentoIsValid_UpdateValorAndReturnNovoLancamentoEvent()
        {
            #region Arrange
            double novoValor = 500;
            double valorAntigo = 200;
            var lancamentoId = 32;
            var caixaId = 54;

            var lancamentoMock = new Mock<ILancamento>();
            var caixaMock = new CaixaMock("teste");
            caixaMock.SetId(caixaId);

            var saldo = new Saldo(valorAntigo, caixaMock);

            lancamentoMock.Setup(x => x.Lancar(valorAntigo))
                .Returns(novoValor);

            lancamentoMock.Setup(x => x.Id)
                .Returns(lancamentoId);
            #endregion

            var result = saldo.Contabilizar(lancamentoMock.Object);

            #region Assert
            var evento = result.Value;

            Assert.True(result.IsSuccess);
            Assert.Equal(lancamentoId, evento.LancamentoId);
            Assert.Equal(caixaId, evento.CaixaId);
            Assert.Equal(valorAntigo, evento.SaldoAnterior);
            Assert.Equal(novoValor, evento.SaldoAtual);
            Assert.Equal(novoValor, saldo.Valor);
            #endregion
        }
    }
}
