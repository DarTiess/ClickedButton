namespace Infrastructure.Level.EventsBus.Signals
{
    public class AddCoins
    {
        private int _coins;
        public int Coins => _coins;

        public AddCoins(int coins)
        {
            _coins = coins;
        }
    }
}