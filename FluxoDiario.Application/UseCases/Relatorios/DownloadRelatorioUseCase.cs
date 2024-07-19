using FluentResults;
using FluxoDiario.Application.Dtos;
using FluxoDiario.Application.Files;
using FluxoDiario.Application.UseCases.Relatorios.Interfaces;
using FluxoDiario.Domain.Contexts.Relatorios.Tipos;
using FluxoDiario.Domain.Repositories.Relatorios;
using FluxoDiario.Shared.Results.Relatorios;
using Serilog;

namespace FluxoDiario.Application.UseCases.Relatorios
{
    public class DownloadRelatorioUseCase : IDownloadRelatorioUseCase
    {
        private readonly IRelatorioReadRepository _relatorioReadRepository;
        private readonly ILogger _logger;
        private readonly IFileReader _fileReader;
        
        public DownloadRelatorioUseCase(IRelatorioReadRepository repository, ILogger logger, IFileReader fileReader)
        {
            _relatorioReadRepository = repository;
            _logger = logger;
            _fileReader = fileReader;
        }

        public async Task<Result<FileDto>> ExecutarAsync(int input, CancellationToken ct = default)
        {
            var consultaRelatorio = await _relatorioReadRepository.BuscarRelatorioAsync(input, ct);

            if(consultaRelatorio.IsFailed)
            {
                _logger.Warning("Relatorio solicitado não foi encontrado.");
                return consultaRelatorio.ToResult();
            }

            if (consultaRelatorio.Value.Status != StatusRelatorio.Criado)
                return new RelatorioNaoGeradoResult($"Relatório {input} ainda não foi gerado.");

            if(string.IsNullOrWhiteSpace(consultaRelatorio.Value.CaminhoArquivo))
            {
                _logger.Warning("Relatorio solicitado não foi gerado.");
                return new RelatorioNaoGeradoResult($"O relatório {input} não foi gerado corretamente." +
                    $" Solicite a criação de outro relatório e tente novamente.");
            }

            return _fileReader.ObterArquivo(consultaRelatorio.Value.CaminhoArquivo);
        }
    }
}
