using FluentResults;
using FluxoDiario.Application.UseCases.Relatorios.Interfaces;
using FluxoDiario.Domain.Contexts.Relatorios;
using FluxoDiario.Domain.Repositories.Relatorios;
using Serilog;

namespace FluxoDiario.Application.UseCases.Relatorios
{
    public class ConsultarStatusRelatorioUseCase : IConsultarStatusRelatorioUseCase
    {
        private readonly IRelatorioReadRepository _repository;

        public ConsultarStatusRelatorioUseCase(IRelatorioReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Relatorio>> ExecutarAsync(int input, CancellationToken ct = default)
        {
            return await _repository.BuscarRelatorioAsync(input, ct);
        }
    }
}
