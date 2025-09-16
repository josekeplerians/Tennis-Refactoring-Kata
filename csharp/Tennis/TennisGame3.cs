namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int _p2;
        private int _p1;
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
            if (_p1 < 4 && _p2 < 4 && _p1 + _p2 < 6)
            {
                string[] p = { "Love", "Fifteen", "Thirty", "Forty" };
                s = p[_p1];
                return (_p1 == _p2) ? s + "-All" : s + "-" + p[_p2];
            }

            if (_p1 == _p2)
                return "Deuce";
            s = _p1 > _p2 ? _p1Name : _p2Name;
            return ((_p1 - _p2) * (_p1 - _p2) == 1) ? "Advantage " + s : "Win for " + s;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                _p1 += 1;
            else
                _p2 += 1;
        }

    }
}