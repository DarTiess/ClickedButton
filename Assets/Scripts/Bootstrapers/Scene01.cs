using EventsBus;
using LeaderBoard;
using UI;
using UnityEngine;
using UnityEngine.Serialization;
using YG;

namespace Bootstrapers
{
    public class Scene01 : MonoBehaviour
    {
        [FormerlySerializedAs("_uiWindowPrefab")]
        [SerializeField] private ButtonsWindow _buttonsWindowPrefab;
        [SerializeField] private int _addCoins;


        private EventBus _eventBus;
        private int coins;
        private ButtonsWindow _buttonsWindow;
        private LeaderBoardHandler _leaderBoard;

        private void Awake()
        {
            coins = YandexGame.savesData.money;
            _eventBus = EventBus.Instance;
            _leaderBoard = new LeaderBoardHandler(_eventBus);
            CreateUiWindow();
        }

        private void CreateUiWindow()
        {
            _buttonsWindow = Instantiate(_buttonsWindowPrefab);
            _buttonsWindow.Initialize(_eventBus, coins, _addCoins);
        }
    }
}

//LeaderBoard