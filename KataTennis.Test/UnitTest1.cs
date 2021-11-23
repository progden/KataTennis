using KataTennis.Lib;
using NUnit.Framework;

namespace KataTennis.Test
{
    public class TestScore
    {
        private class FakeScore: Score
        {
            public FakeScore(int playerOne, int playerTwo, bool isAdvA = false, bool isAdvB = false)
            {
                _playerOne = playerOne;
                _playerTwo = playerTwo;
                _isAdvA = isAdvA;
                _isAdvB = isAdvB;
            }

            private int _playerOne;
            private int _playerTwo;
            private bool _isAdvA;
            private bool _isAdvB;

            protected override int GetPlayerOneScore()
            {
                return _playerOne;
            }

            protected override int GetPlayerTwoScore()
            {
                return _playerTwo;
            }

            protected override bool IsAdvA()
            {
                return _isAdvA;
            }
            protected override bool IsAdvB()
            {
                return _isAdvB;
            }
        }

        [Test]
        public void Show_love_all()
        {
            var score = new FakeScore(0, 0);
            Assert.AreEqual("love all", score.ToString());
        }
        
        [Test]
        public void Show_fifteen_love()
        {
            var score = new FakeScore(1, 0);
            Assert.AreEqual("fifteen love", score.ToString());
        }
        
        [Test]
        public void Show_thirty_all()
        {
            var score = new FakeScore(2, 2);
            Assert.AreEqual("thirty all", score.ToString());
        }
        
        [Test]
        public void Show_deuce()
        {
            var score = new FakeScore(3, 3);
            Assert.AreEqual("deuce", score.ToString());
        }
        
        [Test]
        public void Show_A_Win()
        {
            var score = new FakeScore(4, 3);
            Assert.AreEqual("A Win", score.ToString());
        }
        
        [Test]
        public void Show_A_Adv()
        {
            var score = new FakeScore(3, 3, isAdvA:true);
            Assert.AreEqual("A Adv.", score.ToString());
        }

        [Test]
        public void Show_B_Adv()
        {
            var score = new FakeScore(3, 3, isAdvB:true);
            Assert.AreEqual("B Adv.", score.ToString());
        }
        
    }
    public class Tests
    {
        private Game _game;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Player1_win_1_point()
        {
            GivenPlayerOneGetPoint(1);

            Assert.AreEqual("fifteen love", _game.Score().ToString());
        }

        private void GivenPlayerTwoGetPoint(int potins = 1)
        {
            for (int i = 0; i < potins; i++)
            {
                _game.Point(Player.Two);
            }
        }

        private void GivenPlayerOneGetPoint(int points = 1)
        {
            for (int i = 0; i < points; i++)
            {
                _game.Point(Player.One);
            }
        }

        [SetUp]
        public void SetUp()
        {
            _game = new Game();
        }

        [Test]
        public void Player1_win_2_point()
        {
            GivenPlayerOneGetPoint(2);
            Assert.AreEqual("thirty love", _game.Score().ToString());
        }
        [Test]
        public void Player1_win_3_point()
        {
            GivenPlayerOneGetPoint(3);
            Assert.AreEqual("forty love", _game.Score().ToString());
        }
        [Test]
        public void Player1_win_4_point()
        {
            GivenPlayerOneGetPoint(4);
            Assert.AreEqual("A Win", _game.Score().ToString());
        }

        [Test]
        public void Player1_and_2_both_2_point()
        {
            GivenPlayerOneGetPoint(2);
            GivenPlayerTwoGetPoint(2);

            Assert.AreEqual("thirty all", _game.Score().ToString());
        }
        
        [Test]
        public void Player2_Advantage()
        {      
            GivenPlayerOneGetPoint(3);
            GivenPlayerTwoGetPoint(3);
            GivenPlayerTwoGetPoint(1);

            Assert.AreEqual("B Adv.", _game.Score().ToString());
        }

        [Test]
        public void Player2_advantage_and_win()
        {
            GivenPlayerOneGetPoint(3);
            GivenPlayerTwoGetPoint(3);
            GivenPlayerTwoGetPoint(1);
            GivenPlayerTwoGetPoint(1);

            Assert.AreEqual("B Win", _game.Score().ToString());
        }
        
        [Test]
        public void Player2_AdvantageAgain()
        {      
            GivenPlayerOneGetPoint(3);
            GivenPlayerTwoGetPoint(3);
            GivenPlayerTwoGetPoint(1);
            GivenPlayerOneGetPoint(1);
            GivenPlayerTwoGetPoint(1);

            Assert.AreEqual("B Adv.", _game.Score().ToString());
        }
        
        [Test]
        public void Player1_and_2_win_3_point()
        {      
            GivenPlayerOneGetPoint(3);
            GivenPlayerTwoGetPoint(3);

            Assert.AreEqual("deuce", _game.Score().ToString());
        }
        
        [Test]
        public void Player1_Advantage()
        {      
            GivenPlayerOneGetPoint(3);
            GivenPlayerTwoGetPoint(3);
            GivenPlayerOneGetPoint(1);

            Assert.AreEqual("A Adv.", _game.Score().ToString());
        }
        
        [Test]
        public void Player1_AdvantageAgain()
        {      
            GivenPlayerOneGetPoint(3);
            GivenPlayerTwoGetPoint(3);
            GivenPlayerOneGetPoint(1);
            GivenPlayerTwoGetPoint(1);
            GivenPlayerOneGetPoint(1);

            Assert.AreEqual("A Adv.", _game.Score().ToString());
        }
    }
}