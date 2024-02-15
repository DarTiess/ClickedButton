using Ad;
using EventsBus;
using UI;
using UnityEngine;
using YG;

namespace Bootstrapers
{
    public class Scene02 : MonoBehaviour
    {
        [SerializeField] private AdWindow _adWindowPrefab;
        [SerializeField] private int _addCoins;
        [SerializeField] private ImageConfig _imageConfig;


        private EventBus _eventBus;
        private int coins;
        private AdWindow _buttonsWindow;
        private AdHandler _adHandler;

        private void Awake()
        {
            coins=  YandexGame.savesData.money;
            _eventBus = EventBus.Instance;
            _adHandler = new AdHandler(_eventBus);
            CreateUiWindow();
        }
        private void CreateUiWindow()
        {
            _buttonsWindow = Instantiate(_adWindowPrefab);
            _buttonsWindow.Initialize(_eventBus, _addCoins, _imageConfig);
        }
    }
}