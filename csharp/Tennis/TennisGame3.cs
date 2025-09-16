using System;

namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int P1Points => _player1.Points;
        private int P2Points => _player2.Points;
        private string P1Name => _player1.Name;
        private string P2Name => _player2.Name;
        
        private readonly Player _player1;
        private readonly Player _player2;

        private static readonly string[] ScoreNames = ["Love", "Fifteen", "Thirty", "Forty"];

        public TennisGame3(string player1Name, string player2Name)
        {
            _player1 = new Player(player1Name);
            _player2 = new Player(player2Name);
        }

        public string GetScore()
        {
            
            if (ThereIsNoWinnerYetijaeoifjea())
            {
                var player2ScoreName = ScoreNames[P1Points];
                var player1ScoreName = ScoreNames[P2Points];
                return IsTie ? player2ScoreName + "-All" : player2ScoreName + "-" + player1ScoreName;
            }

            if (IsTie)
                return "Deuce";
            var playerWithMorePoints = WhoHasMorePoints();
            return GetAdvantageOrWinScore(playerWithMorePoints);
        }

        private bool ThereIsNoWinnerYetijaeoifjea()
        {
            return P1Points < 4 && P2Points < 4 && P1Points + P2Points < 6;
        }

        private string WhoHasMorePoints()
        {
            return P1Points > P2Points ? P1Name : P2Name;
        }

        private string GetAdvantageOrWinScore(string player)
        {
            return (PointsDifference()  == 1) ? "Advantage " + player : "Win for " + player;
        }

        private int PointsDifference() => Math.Abs(P1Points - P2Points);

        private bool IsTie => P1Points == P2Points;

        public void WonPoint(string playerName)
        {
            if (playerName == _player1.Name)
                _player1.ScorePoint();
            else
                _player2.ScorePoint();
        }

    }
    
    public class Player
    {
        public string Name { get; private set; }
        public int Points { get; private set; }

        public Player(string name)
        {
            Name = name;
            Points = 0;
        }
        public void ScorePoint()
        {
            Points++;
        }
    }
}