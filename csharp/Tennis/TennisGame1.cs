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
                score = Choosejkhgasjffddga();
            }
            else
            {
                score = $"{TranslateToScoring(_mScore1)}-{TranslateToScoring(_mScore2)}";
            }
            return score;
        }

        private static string TranslateToScoring(int tempScore)
        {
            return tempScore switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => ""
            };
        }

        private string Choosejkhgasjffddga()
        {
            var minusResult = _mScore1 - _mScore2;
            var score = minusResult switch
            {
                1 => "Advantage player1",
                -1 => "Advantage player2",
                >= 2 => "Win for player1",
                _ => "Win for player2"
            };
            return score;
        }

        private bool AnyPlayerInAdvantageOrWin => _mScore1 >= 4 || _mScore2 >= 4;
    }
}

