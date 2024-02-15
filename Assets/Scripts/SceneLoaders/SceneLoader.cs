using System;
using EventsBus;
using EventsBus.Signals;
using UnityEngine.SceneManagement;

namespace SceneLoaders
{
    public class SceneLoader: IDisposable
    {
        private readonly IEventBus _eventBus;
        private SceneConfig _sceneConfig;

        public SceneLoader(IEventBus eventBus, SceneConfig sceneConfig)
        {
            _eventBus = eventBus;
            _sceneConfig = sceneConfig;
            _eventBus.Subscribe<NextLevel>(LoadNextLevel);
            LoadLevel();
        }

        private void LoadLevel()
        {
            var nextScene = _sceneConfig.GetNextScene();
            if (nextScene == SceneManager.GetActiveScene().name)
            {
                nextScene = _sceneConfig.GetNextScene();
            }

            SceneManager.LoadSceneAsync(nextScene);
        }

        private void LoadNextLevel(NextLevel obj)
        {
            LoadLevel();
        }

    
        public void Dispose()
        {
            _sceneConfig.Restart();
        }
    }
}