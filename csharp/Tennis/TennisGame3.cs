using System;

namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int _p1Points => _player1.Points;
        private int _p2Points => _player2.Points;
        private string _p1Name => _player1.Name;
        private string _p2Name => _player2.Name;
        
        private Player _player1;
        private Player _player2;

        private static readonly string[] ScoreNames = ["Love", "Fifteen", "Thirty", "Forty"];

        public TennisGame3(string player1Name, string player2Name)
        {
            _player1 = new Player(player1Name);
            _player2 = new Player(player2Name);
        }

        public string GetScore()
        {
            
            if (_p1Points < 4 && _p2Points < 4 && _p1Points + _p2Points < 6)
            {
                var player2ScoreName = ScoreNames[_p1Points];
                var player1ScoreName = ScoreNames[_p2Points];
                return IsTie ? player2ScoreName + "-All" : player2ScoreName + "-" + player1ScoreName;
            }

            if (IsTie)
                return "Deuce";
            var playerWithMorePoints = WhoHasMorePoints();
            return GetAdvantageOrWinScore(playerWithMorePoints);
        }

        private string WhoHasMorePoints()
        {
            return _p1Points > _p2Points ? _p1Name : _p2Name;
        }

        private string GetAdvantageOrWinScore(string player)
        {
            return (PointsDifference()  == 1) ? "Advantage " + player : "Win for " + player;
        }

        private int PointsDifference() => Math.Abs(_p1Points - _p2Points);

        private bool IsTie => _p1Points == _p2Points;

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