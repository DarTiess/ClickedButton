using System;
using EventsBus;
using EventsBus.Signals;
using UnityEngine;
using YG;

namespace LeaderBoard
{
    public class LeaderBoardHandler: IDisposable
    {
        private readonly IEventBus _eventBus;

        public LeaderBoardHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
            _eventBus.Subscribe<UpdateLeaderBoard>(OnUpdateLeaderBoard);
      
        }

        private void OnUpdateLeaderBoard(UpdateLeaderBoard obj)
        {
            Debug.Log("Update Handler "+ obj.Coins);
        
            YandexGame.NewLeaderboardScores("LeaderBoard", obj.Coins);
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<UpdateLeaderBoard>(OnUpdateLeaderBoard);

        }
    }
}