namespace EventsBus.Signals
{
    public class UpdateLeaderBoard
    {
        private int _coins;
        public int Coins => _coins;

        public UpdateLeaderBoard(int coins)
        {
            _coins = coins;
        }
    }
}