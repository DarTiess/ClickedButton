using EventsBus;
using EventsBus.Signals;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class AdWindow : MonoBehaviour
    {
        [SerializeField] private Button _rewardButton;
        [SerializeField] private Button _intentionalButton;
        [SerializeField] private ImageBackground _imageBackground;
    
        private IEventBus _eventBus;
   
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

        public void Initialize(IEventBus eventBus, int addCoins, ImageConfig imageConfig)
        {
            _eventBus = eventBus;
            _imageBackground.Initialize(imageConfig);
        }
    

        private void ShowFullScreen()
        {
            _eventBus.Invoke(new ClickedButton());
            _eventBus.Invoke(new ShowFullScreenAd());
        }

        private void ShowReward()
        {
            _eventBus.Invoke(new ClickedButton());
            _eventBus.Invoke(new ShowReward(1));
        }
    }
}