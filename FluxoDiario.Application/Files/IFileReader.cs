using FluentResults;
using FluxoDiario.Application.Dtos;

namespace FluxoDiario.Application.Files
{
    public interface IFileReader
    {
        Result<FileDto> ObterArquivo(string path);
    }
}
