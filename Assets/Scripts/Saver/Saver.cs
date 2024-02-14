using System;
using Infrastructure.Level.EventsBus;
using Infrastructure.Level.EventsBus.Signals;
using YG;

public class Saver: IDisposable
{
    private IEventBus _eventBus;
    
    public Saver(IEventBus eventBus)
    {
        _eventBus = eventBus;
        _eventBus.Subscribe<AddCoins>(SaveCoins);
        _eventBus.Subscribe<DeleteCoins>(ClearCoins);
        Load();
    }

   
    public void Dispose()
    {
        _eventBus.Unsubscribe<AddCoins>(SaveCoins);
        _eventBus.Unsubscribe<DeleteCoins>(ClearCoins);
    }

    private void ClearCoins(DeleteCoins obj)
    {
        YandexGame.savesData.money = 0;
        YandexGame.SaveProgress();
    }

    private void SaveCoins(AddCoins addCoins)
    {
        YandexGame.savesData.money = addCoins.Coins;
        YandexGame.SaveProgress();

    }

    private void Load() => YandexGame.LoadProgress();
    
}