namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int _mScore1 = 0;
        private int _mScore2 = 0;

        private bool IsTie => _mScore1 == _mScore2;

        public void WonPoint(string playerName)
        {
            if (IsPlayer1(playerName))
                _mScore1 += 1;
            else
                _mScore2 += 1;
        }

        private static bool IsPlayer1(string playerName)
        {
            return playerName == "player1";
        }

        public string GetScore()
        {
            var score = "";
            if (IsTie)
            {
                score = _mScore1 switch
                {
                    0 => "Love-All",
                    1 => "Fifteen-All",
                    2 => "Thirty-All",
                    _ => "Deuce"
                };
            }
            else if (AnyPlayerInAdvantageOrWin)
            {
                var minusResult = _mScore1 - _mScore2;
                score = minusResult switch
                {
                    1 => "Advantage player1",
                    -1 => "Advantage player2",
                    >= 2 => "Win for player1",
                    _ => "Win for player2"
                };
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    var tempScore = 0;
                    if (i == 1) tempScore = _mScore1;
                    else { score += "-"; tempScore = _mScore2; }

                    score += tempScore switch
                    {
                        0 => "Love",
                        1 => "Fifteen",
                        2 => "Thirty",
                        3 => "Forty",
                        _ => ""
                    };
                }
            }
            return score;
        }

        private bool AnyPlayerInAdvantageOrWin => _mScore1 >= 4 || _mScore2 >= 4;
    }
}

