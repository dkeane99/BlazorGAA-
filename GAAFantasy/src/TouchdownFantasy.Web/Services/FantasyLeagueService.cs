using TouchdownFantasy.Web.Models;

namespace TouchdownFantasy.Web.Services;

/// <summary>
/// In-memory demo data for the Touchdown Fantasy portfolio project.
/// Replace this service with a repository/API integration for a production application.
/// </summary>
public sealed class FantasyLeagueService
{
    public string LeagueName => "Sunday Legends";
    public int Week => 7;
    public decimal WaiverBudget => 72m;

    public IReadOnlyList<Player> Players { get; } = new List<Player>
    {
        new(1, "Lamar Jackson", "BAL", Position.QB, "CLE", 24.8m, 28.4m, 98),
        new(2, "Jalen Hurts", "PHI", Position.QB, "NYG", 23.6m, 19.2m, 96),
        new(3, "Christian McCaffrey", "SF", Position.RB, "ATL", 22.9m, 25.1m, 100),
        new(4, "Bijan Robinson", "ATL", Position.RB, "SF", 21.4m, 17.8m, 99),
        new(5, "Breece Hall", "NYJ", Position.RB, "NE", 16.7m, 12.3m, 91),
        new(6, "CeeDee Lamb", "DAL", Position.WR, "GB", 20.2m, 24.6m, 99),
        new(7, "Amon-Ra St. Brown", "DET", Position.WR, "TB", 19.8m, 21.1m, 99),
        new(8, "Ja'Marr Chase", "CIN", Position.WR, "PIT", 19.5m, 16.9m, 98),
        new(9, "Puka Nacua", "LAR", Position.WR, "ARI", 17.3m, 22.0m, 96),
        new(10, "Travis Kelce", "KC", Position.TE, "LAC", 12.4m, 10.7m, 88),
        new(11, "Sam LaPorta", "DET", Position.TE, "TB", 10.9m, 8.2m, 86),
        new(12, "Justin Tucker", "BAL", Position.K, "CLE", 8.4m, 11.0m, 79),
        new(13, "Ravens D/ST", "BAL", Position.DST, "CLE", 7.8m, 9.0m, 64),
        new(14, "Josh Allen", "BUF", Position.QB, "MIA", 25.2m, 27.8m, 99),
        new(15, "Derrick Henry", "BAL", Position.RB, "CLE", 18.2m, 20.4m, 97),
        new(16, "De'Von Achane", "MIA", Position.RB, "BUF", 17.6m, 14.1m, 94),
        new(17, "Mike Evans", "TB", Position.WR, "DET", 15.8m, 18.3m, 91),
        new(18, "George Kittle", "SF", Position.TE, "ATL", 13.1m, 15.5m, 93),
        new(19, "Evan McPherson", "CIN", Position.K, "PIT", 7.9m, 6.0m, 71),
        new(20, "Steelers D/ST", "PIT", Position.DST, "CIN", 8.1m, 12.0m, 72)
    };

    public IReadOnlyList<RosterSlot> StartingRoster
    {
        get
        {
            var picks = new (string Slot, Position? Position, int? Id)[]
            {
                ("QB", Position.QB, 1), ("RB", Position.RB, 3), ("RB", Position.RB, 5),
                ("WR", Position.WR, 6), ("WR", Position.WR, 7), ("TE", Position.TE, 10),
                ("FLEX", null, 9), ("K", Position.K, 12), ("D/ST", Position.DST, 13)
            };
            return picks.Select(x => new RosterSlot(x.Slot, x.Position,
                x.Id is int id ? Players.First(p => p.Id == id) : null)).ToList();
        }
    }

    public IReadOnlyList<Standing> Standings { get; } = new List<Standing>
    {
        new(1, "Gridiron Gurus", "Alex Morgan", "5–1", 812.4m, 690.2m, 3),
        new(2, "Sunday Legends", "Jordan Davis", "4–2", 784.6m, 721.8m, 2),
        new(3, "Fourth & Goal", "Taylor Reed", "4–2", 762.1m, 733.9m, 1),
        new(4, "Waiver Wizards", "Sam Carter", "4–2", 748.7m, 740.5m, 2),
        new(5, "End Zone Empire", "Riley Brooks", "3–3", 739.2m, 721.4m, 1),
        new(6, "Blitz Brigade", "Casey Lane", "3–3", 710.5m, 702.7m, 0),
        new(7, "Hail Mary Club", "Jamie Quinn", "3–3", 697.8m, 744.1m, 1),
        new(8, "Red Zone Rebels", "Drew Parker", "2–4", 688.2m, 761.0m, 2)
    };

    public IReadOnlyList<(string Day, string Time, string Game, string Note)> Schedule { get; } =
    [
        ("THU · OCT 15", "20:15", "SEA @ DEN", "Thursday Night Football"),
        ("SUN · OCT 18", "14:30", "HOU @ JAX", "Early window"),
        ("SUN · OCT 18", "18:00", "CHI @ ATL", "Sunday afternoon"),
        ("MON · OCT 19", "01:20", "TB @ DET", "Monday Night Football")
    ];

    public decimal ProjectedStarterPoints => StartingRoster.Where(x => x.Player is not null).Sum(x => x.Player!.ProjectedPoints);
    public decimal LastWeekStarterPoints => StartingRoster.Where(x => x.Player is not null).Sum(x => x.Player!.LastWeekPoints);
}
