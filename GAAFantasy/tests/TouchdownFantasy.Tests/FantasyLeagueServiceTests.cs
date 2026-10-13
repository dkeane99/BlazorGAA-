using TouchdownFantasy.Web.Models;
using TouchdownFantasy.Web.Services;
using Xunit;

namespace TouchdownFantasy.Tests;

public sealed class FantasyLeagueServiceTests
{
    private readonly FantasyLeagueService _league = new();

    [Fact]
    public void PlayerPool_ContainsUniqueIds()
    {
        Assert.Equal(_league.Players.Count, _league.Players.Select(p => p.Id).Distinct().Count());
    }

    [Fact]
    public void StartingRoster_HasNineSlots()
    {
        Assert.Equal(9, _league.StartingRoster.Count);
        Assert.All(_league.StartingRoster, slot => Assert.NotNull(slot.Player));
    }

    [Fact]
    public void StarterProjection_EqualsSumOfStarterProjections()
    {
        var expected = _league.StartingRoster.Sum(slot => slot.Player!.ProjectedPoints);
        Assert.Equal(expected, _league.ProjectedStarterPoints);
    }

    [Fact]
    public void Standings_AreOrderedByRank()
    {
        Assert.Equal(_league.Standings.OrderBy(t => t.Rank).Select(t => t.Rank), _league.Standings.Select(t => t.Rank));
    }

    [Fact]
    public void WaiverBudget_IsWithinLeagueBudget()
    {
        Assert.InRange(_league.WaiverBudget, 0m, 100m);
    }
}
