using System;
using System.Collections;

namespace KataTennis.Lib
{
    public class Score
    {
        private Hashtable hash = new Hashtable();
        private bool isAdvA = false;
        private bool isAdvB = false;

        public Score()
        {
            hash[0] = "love";
            hash[1] = "fifteen";
            hash[2] = "thirty";
            hash[3] = "forty";
            _playerOne = Score_love;
            _playerTwo = Score_love;
        }
        
        public const int Score_love = 0;
        public const int Score_15 = 1; 
        public const int Score_30 = 2;
        public const int Score_40 = 3;

        public const int Score_win = 4; 
        private int _playerOne { get; set; }
        private int _playerTwo { get; set; }

        public void A()
        {
            if (GetPlayerOneScore() == Score_40 & GetPlayerTwoScore() == Score_40)
            {
                if (IsAdvA())
                    _playerOne++;
                else if (IsAdvB())
                    isAdvB = false;
                else // !isAdvA()
                    isAdvA = true;
            }
            else
            {
                _playerOne++;
            }
        }

        public void B()
        {
            if (GetPlayerOneScore() == Score_40 & GetPlayerTwoScore() == Score_40)
            {
                if (IsAdvB())
                    _playerTwo++;
                else if (IsAdvA())
                    isAdvA = false;
                else // !isAdvB()
                    isAdvB = true;
            }
            else
            {
                _playerTwo++;
            }
        }

        public override string ToString()
        {
            if (GetPlayerOneScore() == GetPlayerTwoScore() && GetPlayerOneScore() != Score_40)
                return hash[GetPlayerOneScore()]+" all";
            else if (GetPlayerOneScore() == GetPlayerTwoScore() && GetPlayerOneScore() == Score_40 && IsAdvA())
                return "A Adv.";
            else if (GetPlayerOneScore() == GetPlayerTwoScore() && GetPlayerOneScore() == Score_40 && IsAdvB())
                return "B Adv.";
            else if (GetPlayerOneScore() == GetPlayerTwoScore() && GetPlayerOneScore() == Score_40)
                return "deuce";
            else if (GetPlayerOneScore() == Score_win)
                return "A Win";
            else if (GetPlayerTwoScore() == Score_win)
                return "B Win";
            return hash[GetPlayerOneScore()] + " " + hash[GetPlayerTwoScore()];
        }

        protected virtual bool IsAdvB()
        {
            return isAdvB;
        }

        protected virtual bool IsAdvA()
        {
            return isAdvA;
        }

        protected virtual int GetPlayerTwoScore()
        {
            return _playerTwo;
        }

        protected virtual int GetPlayerOneScore()
        {
            return _playerOne;
        }
    }

    public class Player
    {
        public const string One = "One";
        public const string Two = "Two";
    }

    public class Game
    {
        private Score _score = new();
        public Score Point(string player)
        {
            if (player == Player.One)
            {
                _score.A();
            }
            else
            {
                _score.B();
            }

            return _score;
        }

        public Score Score()
        {
            return _score;
        }
    }
}

