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
            string s;
            if (_p2Points < 4 && _p1Points < 4 && _p2Points + _p1Points < 6)
            {
                string[] p = { "Love", "Fifteen", "Thirty", "Forty" };
                s = p[_p2Points];
                return (_p2Points == _p1Points) ? s + "-All" : s + "-" + p[_p1Points];
            }

            if (_p2Points == _p1Points)
                return "Deuce";
            s = _p2Points > _p1Points ? _p1Name : _p2Name;
            return ((_p2Points - _p1Points) * (_p2Points - _p1Points) == 1) ? "Advantage " + s : "Win for " + s;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                _p2Points += 1;
            else
                _p1Points += 1;
        }

    }
}