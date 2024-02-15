namespace EventsBus.Signals
{
    public class ShowReward
    {
        private int _id;
        public int Id => _id;

        public ShowReward(int id)
        {
            _id = id;
        }
    }
}