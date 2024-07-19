using FluxoDiario.Application.Dtos.FluxoDiario;
using FluxoDiario.Application.Mappers.FluxoDiario;
using FluxoDiario.Application.Mappers.FluxoDiario.Interfaces;
using FluxoDiario.Application.UseCases.FluxoDiario;
using FluxoDiario.Application.Validators;
using FluxoDiario.Application.Validators.FluxoDiario;
using FluxoDiario.DataAccess.Contexts;
using FluxoDiario.DataAccess.Mappers;
using FluxoDiario.DataAccess.Mappers.FluxoDiario;
using FluxoDiario.DataAccess.Mappers.FluxoDiario.Interfaces;
using FluxoDiario.DataAccess.Models;
using FluxoDiario.DataAccess.Repositories.FluxoDiario;
using FluxoDiario.Domain.Contexts.FluxoDiario.Eventos;
using FluxoDiario.Domain.Contexts.FluxoDiario.Lancamentos;
using FluxoDiario.Domain.Events;
using FluxoDiario.Domain.Factories.FluxoDiario;
using FluxoDiario.Domain.Factories.FluxoDiario.Interfaces;
using FluxoDiario.Domain.Repositories.FluxoDiario;
using FluxoDiario.Domain.Services.FluxoDiario;
using Moq;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDiario.Tests.Integrations.Configuration
{
    public class FluxoDiarioServicesFixture
    {
        public Mock<IEventPublisher> MockEventPublisher = new Mock<IEventPublisher>();
        public Mock<ILogger> MockLogger = new Mock<ILogger>();

        private FluxoDiarioDbContext _dbContext;
        public FluxoDiarioDbContext DbContext
        {
            get
            {
                if(_dbContext == null)
                    _dbContext = LocalDbContextProvider.New();

                return _dbContext;
            }
        }

        public CriarCaixaUseCase NewCriarCaixaUseCase()
        {
            return new CriarCaixaUseCase(
                NewFluxoDiarioService(),
                NewCaixaApplicationMapper(),
                NewCriarCaixaValidator(),
                NewLancamentoFactory()
            );
        }

        private IFluxoDiarioService NewFluxoDiarioService()
            => new FluxoDiarioService(MockLogger.Object, NewCaixaWriteRepository(), MockEventPublisher.Object);

        private ICaixaApplicationMapper NewCaixaApplicationMapper()
            => new CaixaApplicationMapper();

        private IValidator<CriarCaixaDto> NewCriarCaixaValidator()
            => new CriarCaixaValidator();

        private ILancamentoFactory NewLancamentoFactory()
            => new DefaultLancamentoFactory(MockLogger.Object);

        private ICaixaDataMapper NewCaixaDataMapper()
            => new CaixaDataMapper();

        private IDefaultDataModelMapper<LancamentoDataModel, ILancamento> NewLancamentoDataMapper()
            => new LancamentoDataMapper(NewLancamentoFactory());

        private IDefaultDataModelMapper<NovoLancamentoDataModel, NovoLancamento> NewNovoLancamentoDataMapper()
            => new NovoLancamentoDataMapper();

        private ICaixaWriteRepository NewCaixaWriteRepository()
            => new CaixaRepository(
                DbContext,
                NewCaixaDataMapper(),
                NewLancamentoDataMapper(),
                NewNovoLancamentoDataMapper(),
                MockLogger.Object);
    }
}
