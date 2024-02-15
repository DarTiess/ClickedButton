using EventsBus;
using EventsBus.Signals;
using LeaderBoard;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ButtonsWindow : MonoBehaviour
    {
        [SerializeField] private Button _addButton;
        [SerializeField] private Button _deleteButton;
        [SerializeField] private Button _leaderBoardButton;
        [SerializeField] private Button _soundButton;
        [SerializeField] private Button _nextLevelButton;
        [SerializeField] private Text _coinsText;
        [SerializeField] private LeaderBoardView _leaderBoard;

        private IEventBus _eventBus;
        private int _coins;
        private int _addCoins;

        private void Start()
        {
            _addButton.onClick.AddListener(AddCoins);
            _deleteButton.onClick.AddListener(DeleteCoins);
            _leaderBoardButton.onClick.AddListener(ShowLeaderBoard);
            _soundButton.onClick.AddListener(SwitchSound);
            _nextLevelButton.onClick.AddListener(NextLevel);
            _leaderBoard.gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            _addButton.onClick.RemoveListener(AddCoins);
            _deleteButton.onClick.RemoveListener(DeleteCoins);
            _leaderBoardButton.onClick.RemoveListener(ShowLeaderBoard);
            _soundButton.onClick.RemoveListener(SwitchSound);
            _nextLevelButton.onClick.RemoveListener(NextLevel);
        }

        public void Initialize(IEventBus eventBus, int coins, int addCoins)
        {
            _eventBus = eventBus;
            _coins = coins;
            _addCoins = addCoins;
            _coinsText.text = _coins.ToString();
        }

        private void NextLevel()
        {
            _eventBus.Invoke(new NextLevel());
            _eventBus.Invoke(new ClickedButton());
        }

        private void SwitchSound()
        {
            _eventBus.Invoke(new SwitchMusic());
            _eventBus.Invoke(new ClickedButton());
        }

        private void ShowLeaderBoard()
        {
            //LeaderBoard
            _eventBus.Invoke(new ClickedButton());
            _eventBus.Invoke(new UpdateLeaderBoard(_coins));
            _leaderBoard.gameObject.SetActive(true);
            if(_leaderBoard.gameObject.activeInHierarchy)
            _leaderBoard.UpdateLb();

        }

        private void DeleteCoins()
        {
            _coins = 0;
            _coinsText.text = _coins.ToString();
            _eventBus.Invoke(new DeleteCoins());
            _eventBus.Invoke(new ClickedButton());
        }

        private void AddCoins()
        {
            _coins += _addCoins;
            _coinsText.text = _coins.ToString();
            _eventBus.Invoke(new AddCoins(_coins));
            _eventBus.Invoke(new ClickedButton());
        }
    }
}