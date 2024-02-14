using System;
using Infrastructure.Level.EventsBus;
using Infrastructure.Level.EventsBus.Signals;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ButtonsWindow : MonoBehaviour
{
    [SerializeField] private Button _addButton;
    [SerializeField] private Button _deleteButton;
    [SerializeField] private Button _leaderBoardButton;
    [SerializeField] private Button _soundButton;
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private TextMeshProUGUI _coinsText;

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
        //
        _eventBus.Invoke(new ClickedButton());
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