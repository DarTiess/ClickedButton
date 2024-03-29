﻿using Audio;
using EventsBus;
using Plugins.Audio.Core;
using Plugins.Audio.Utils;
using SceneLoaders;
using UI;
using UnityEngine;
using YG;

namespace Bootstrapers
{
    public class ProjectBootstrap : MonoBehaviour
    {
        [SerializeField] private YandexGame _yandexGamePrefab;
        [SerializeField] private SourceAudio _musicSourcePrefab;
        [SerializeField] private SourceAudio _soundSourcePrefab;
        [SerializeField] private AudioDataProperty _musicClip;
        [SerializeField] private AudioDataProperty _soundClip;
        [SerializeField] private SceneConfig _sceneConfig;
    

        private EventBus _eventBus;
        private Saver.Saver _saver;
        private AudioPlayer _audioPlayer;
        private SceneLoader _sceneLoader;
        private YandexGame _yandexGame;
        private ButtonsWindow _buttonsWindow;
        private SourceAudio _musicSource;
        private SourceAudio _soundSource;

        private void Awake()
        {
            CreateYGObject();

            _eventBus = new EventBus();
            _saver = new Saver.Saver(_eventBus);
            CreateAudio();
            _sceneLoader = new SceneLoader(_eventBus, _sceneConfig);
            DontDestroyOnLoad(this);
        }

        private void OnApplicationQuit()
        {
            _saver.Dispose();
            _audioPlayer.Dispose();
            _sceneLoader.Dispose();
        }

        private void CreateAudio()
        {
            _musicSource = Instantiate(_musicSourcePrefab,transform);
            _soundSource = Instantiate(_soundSourcePrefab, transform);
        
            _audioPlayer = new AudioPlayer(_eventBus, _musicSource, _soundSource, _musicClip, _soundClip);
        }

        private void CreateYGObject()
        {
            _yandexGame = Instantiate(_yandexGamePrefab, transform);
            _yandexGame._GameReadyAPI();
            _yandexGame._LanguageRequest();
        }

    }
}