namespace MatchGameEngine.Models
{
    public class GameResult
    {
        public Player Winner { get; set; }
        public Status Status { get; set; }

        public static GameResult Victory(Player winner)
        {
            return new GameResult()
            {
                Winner = winner,
                Status = Status.Victory
            };
        }

        public static GameResult Draw()
        {
            return new GameResult()
            {
                Status = Status.Draw
            };
        }
    }

    public enum Status
    {
        Draw,
        Victory
    }
}
