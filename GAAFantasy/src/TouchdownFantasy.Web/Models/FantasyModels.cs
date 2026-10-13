namespace TouchdownFantasy.Web.Models;

public enum Position { QB, RB, WR, TE, K, DST }

public sealed record Player(
    int Id, string Name, string Team, Position Position, string Opponent,
    decimal ProjectedPoints, decimal LastWeekPoints, int RosteredPercent,
    string Status = "Healthy", decimal Salary = 0, string Bye = "—");

public sealed record RosterSlot(string Slot, Position? Position, Player? Player);
public sealed record MatchupTeam(string Name, string Manager, string Record, decimal Points, string Initials);
public sealed record Standing(int Rank, string Team, string Manager, string Record, decimal PointsFor, decimal PointsAgainst, int Streak);
