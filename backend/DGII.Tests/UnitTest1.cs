using DGII.Core.Entities;
using DGII.Core.Interfaces;
using DGII.Core.Services;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace DGII.Tests;

public class ContribuyenteServiceTests
{
    [Fact]
    public async Task GetAllAsync_ReturnsContribuyentesFromRepository()
    {
        var expected = new List<Contribuyente>
        {
            new() { RncCedula = "98754321012", Nombre = "JUAN PEREZ", Tipo = "PERSONA FISICA", Estatus = "activo" }
        };

        var repoMock = new Mock<IContribuyenteRepository>();
        var loggerMock = new Mock<ILogger<ContribuyenteService>>();
        repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(expected);
        var service = new ContribuyenteService(repoMock.Object, loggerMock.Object);

        var result = await service.GetAllAsync();

        result.Should().BeEquivalentTo(expected);
        repoMock.Verify(r => r.GetAllAsync(), Times.Once);
    }

    [Fact]
    public async Task GetByRncAsync_ReturnsContribuyente_WhenExists()
    {
        const string rnc = "98754321012";
        var expected = new Contribuyente { RncCedula = rnc, Nombre = "JUAN PEREZ" };

        var repoMock = new Mock<IContribuyenteRepository>();
        var loggerMock = new Mock<ILogger<ContribuyenteService>>();
        repoMock.Setup(r => r.GetByRncAsync(rnc)).ReturnsAsync(expected);
        var service = new ContribuyenteService(repoMock.Object, loggerMock.Object);

        var result = await service.GetByRncAsync(rnc);

        result.Should().BeEquivalentTo(expected);
        repoMock.Verify(r => r.GetByRncAsync(rnc), Times.Once);
    }

    [Fact]
    public async Task GetByRncAsync_ReturnsNull_WhenNotFound()
    {
        const string rnc = "00000000000";

        var repoMock = new Mock<IContribuyenteRepository>();
        var loggerMock = new Mock<ILogger<ContribuyenteService>>();
        repoMock.Setup(r => r.GetByRncAsync(rnc)).ReturnsAsync((Contribuyente?)null);
        var service = new ContribuyenteService(repoMock.Object, loggerMock.Object);

        var result = await service.GetByRncAsync(rnc);

        result.Should().BeNull();
        repoMock.Verify(r => r.GetByRncAsync(rnc), Times.Once);
    }

    [Fact]
    public async Task GetAllAsync_PropagatesException_WhenRepositoryFails()
    {
        var repoMock = new Mock<IContribuyenteRepository>();
        var loggerMock = new Mock<ILogger<ContribuyenteService>>();
        repoMock.Setup(r => r.GetAllAsync()).ThrowsAsync(new InvalidOperationException("Repo failed"));
        var service = new ContribuyenteService(repoMock.Object, loggerMock.Object);

        var act = async () => await service.GetAllAsync();

        await act.Should().ThrowAsync<InvalidOperationException>();
    }
}

public class ComprobanteFiscalServiceTests
{
    [Fact]
    public async Task GetAllAsync_ReturnsComprobantesFromRepository()
    {
        var expected = new List<ComprobanteFiscal>
        {
            new() { Id = 1, RncCedula = "98754321012", NCF = "E310000000001", Monto = 200m, Itbis18 = 36m }
        };

        var repoMock = new Mock<IComprobanteFiscalRepository>();
        var loggerMock = new Mock<ILogger<ComprobanteFiscalService>>();
        repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(expected);
        var service = new ComprobanteFiscalService(repoMock.Object, loggerMock.Object);

        var result = await service.GetAllAsync();

        result.Should().BeEquivalentTo(expected);
        repoMock.Verify(r => r.GetAllAsync(), Times.Once);
    }

    [Fact]
    public async Task GetByRncAsync_ReturnsComprobantesForGivenRnc()
    {
        const string rnc = "98754321012";
        var expected = new List<ComprobanteFiscal>
        {
            new() { Id = 1, RncCedula = rnc, NCF = "E310000000001", Monto = 200m, Itbis18 = 36m },
            new() { Id = 2, RncCedula = rnc, NCF = "E310000000002", Monto = 1000m, Itbis18 = 180m }
        };

        var repoMock = new Mock<IComprobanteFiscalRepository>();
        var loggerMock = new Mock<ILogger<ComprobanteFiscalService>>();
        repoMock.Setup(r => r.GetByRncAsync(rnc)).ReturnsAsync(expected);
        var service = new ComprobanteFiscalService(repoMock.Object, loggerMock.Object);

        var result = await service.GetByRncAsync(rnc);

        result.Should().BeEquivalentTo(expected);
        repoMock.Verify(r => r.GetByRncAsync(rnc), Times.Once);
    }

    [Fact]
    public async Task GetTotalItbisByRncAsync_ReturnsCalculatedTotalFromRepository()
    {
        const string rnc = "98754321012";
        const decimal expectedTotal = 216m;

        var repoMock = new Mock<IComprobanteFiscalRepository>();
        var loggerMock = new Mock<ILogger<ComprobanteFiscalService>>();
        repoMock.Setup(r => r.GetTotalItbisByRncAsync(rnc)).ReturnsAsync(expectedTotal);
        var service = new ComprobanteFiscalService(repoMock.Object, loggerMock.Object);

        var result = await service.GetTotalItbisByRncAsync(rnc);

        result.Should().Be(expectedTotal);
        repoMock.Verify(r => r.GetTotalItbisByRncAsync(rnc), Times.Once);
    }

    [Fact]
    public async Task GetTotalItbisByRncAsync_PropagatesException_WhenRepositoryFails()
    {
        const string rnc = "98754321012";

        var repoMock = new Mock<IComprobanteFiscalRepository>();
        var loggerMock = new Mock<ILogger<ComprobanteFiscalService>>();
        repoMock.Setup(r => r.GetTotalItbisByRncAsync(rnc)).ThrowsAsync(new InvalidOperationException("Repo failed"));
        var service = new ComprobanteFiscalService(repoMock.Object, loggerMock.Object);

        var act = async () => await service.GetTotalItbisByRncAsync(rnc);

        await act.Should().ThrowAsync<InvalidOperationException>();
    }
}