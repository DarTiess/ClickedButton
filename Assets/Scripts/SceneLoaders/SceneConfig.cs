using System.Collections.Generic;
using UnityEngine;

namespace SceneLoaders
{
    [CreateAssetMenu(menuName = "Configs/Scene", fileName = "SceneConfig", order = 52)]
    public class SceneConfig : ScriptableObject
    {
        [SerializeField] private List<string> _sceneNames;
        private int _currentScene=0;


        public string GetNextScene()
        {
            _currentScene += 1;
            if (_currentScene >= _sceneNames.Count)
            {
                _currentScene = 0;
            }
            return _sceneNames[_currentScene];
        }

        public void Restart()
        {
            _currentScene = 0;
        }
    }
}