using IBGE.Api.Domain.Entities;

namespace IBGE.Domain.Test;

public class TownTest
{
    [Fact]
    public void GivenStateOrCodeLessZeroReturnFalse()
    {
        var town = new Town(10, 1,"Campinas");

        Assert.False(town.HasValid);
    }

    [Fact]
    public void GivenStateWithGreaterZeroReturnTrue()
    {
        var town = new Town(10, 10, "Campinas");

        Assert.True(town.HasValid);
    }
}
