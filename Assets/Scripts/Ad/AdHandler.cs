using System;
using EventsBus;
using EventsBus.Signals;
using YG;

namespace Ad
{
    public class AdHandler: IDisposable
    {
        private IEventBus _eventBus;

        public AdHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
            _eventBus.Subscribe<ShowFullScreenAd>(ShowFullScreenAd);
            _eventBus.Subscribe<ShowReward>(ShowRewardAd);
        }

        private void ShowRewardAd(ShowReward obj)
        {
            YandexGame.RewVideoShow(obj.Id);
        }

        private void ShowFullScreenAd(ShowFullScreenAd obj)
        {
            YandexGame.Instance.ResetTimerFullAd();
            YandexGame.FullscreenShow();
            _eventBus.Invoke(new PauseGame());
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<ShowFullScreenAd>(ShowFullScreenAd);
            _eventBus.Unsubscribe<ShowReward>(ShowRewardAd);
        }
    }
}