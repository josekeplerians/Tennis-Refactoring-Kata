using System;

namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int _p1Points;
        private int _p2Points;
        private readonly string _p1Name;
        private readonly string _p2Name;

        public TennisGame3(string player1Name, string player2Name)
        {
            _p1Name = player1Name;
            _p2Name = player2Name;
        }

        public string GetScore()
        {
            if (_p1Points < 4 && _p2Points < 4 && _p1Points + _p2Points < 6)
            {
                string[] scoreNames = ["Love", "Fifteen", "Thirty", "Forty"];
                var player2ScoreName = scoreNames[_p1Points];
                var player1ScoreName = scoreNames[_p2Points];
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
            if (playerName == "player1")
                _p1Points += 1;
            else
                _p2Points += 1;
        }

    }
}