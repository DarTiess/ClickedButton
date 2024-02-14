using Infrastructure.Level.EventsBus;
using UnityEngine;
using YG;

public class Scene02 : MonoBehaviour
{
    [SerializeField] private AdWindow _adWindowPrefab;
    [SerializeField] private int _addCoins;


    private EventBus _eventBus;
    private int coins;
    private AdWindow _buttonsWindow;

    private void Awake()
    {
        coins=  YandexGame.savesData.money;
        _eventBus = EventBus.Instance;
        CreateUiWindow();
    }
    private void CreateUiWindow()
    {
        _buttonsWindow = Instantiate(_adWindowPrefab);
        _buttonsWindow.Initialize(_eventBus, _addCoins);
    }
    

    //ShowLeaderBoard
    
}