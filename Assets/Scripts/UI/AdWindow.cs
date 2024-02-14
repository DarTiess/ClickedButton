using System;
using Infrastructure.Level.EventsBus;
using UnityEngine;
using UnityEngine.UI;

public class AdWindow : MonoBehaviour
{
    [SerializeField] private Button _rewardButton;
    [SerializeField] private Button _intentionalButton;
    [SerializeField] private ImageBackground _imageBackground;
   


    private IEventBus _eventBus;
    private int _addCoins;
   
    

    private void Start()
    {
        _rewardButton.onClick.AddListener(ShowReward);
        _intentionalButton.onClick.AddListener(ShowFullScreen);
    }

  

    private void OnDisable()
    {
        _rewardButton.onClick.RemoveListener(ShowReward);
        _intentionalButton.onClick.RemoveListener(ShowFullScreen);
    }

    public void Initialize(IEventBus eventBus, int addCoins)
    {
        _eventBus = eventBus;
        _addCoins = addCoins;
    }
    

    private void ShowFullScreen()
    {
        //show
    }

    private void ShowReward()
    {
        //show after *2 coins
    }
}