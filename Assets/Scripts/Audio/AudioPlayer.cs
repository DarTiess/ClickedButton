using System;
using EventsBus;
using EventsBus.Signals;
using Plugins.Audio.Core;
using Plugins.Audio.Utils;
using YG;

namespace Audio
{
    public class AudioPlayer: IDisposable
    {
        private SourceAudio _musicSource;
        private SourceAudio _soundSource;
        private AudioDataProperty _musicClip;
        private AudioDataProperty _soundClip;
        private IEventBus _eventBus;
        private bool _onPlayMusic;

        public AudioPlayer(IEventBus eventBus, SourceAudio musicSource, SourceAudio soundSource,
                           AudioDataProperty musicClip, AudioDataProperty soundClip)
        {
            _eventBus = eventBus;
            _musicSource = musicSource;
            _musicClip = musicClip;
            _soundSource = soundSource;
            _soundClip = soundClip;
            PlayBackgroundMusic();
            _eventBus.Subscribe<ClickedButton>(PlaySound);
            _eventBus.Subscribe<SwitchMusic>(PlayBackgroundMusic);
            YandexGame.OpenFullAdEvent += StopMusic;
            YandexGame.CloseFullAdEvent += PlayMusic;
        }

        private void StopMusic()
        {
            _musicSource.Stop();
        }

        private void PlayMusic()
        {
            _musicSource.Play(_musicClip.Key);
        }

        private void PlayBackgroundMusic(SwitchMusic obj)
        {
            if (_onPlayMusic)
            {
                StopMusic();
            }
            else
            {
               PlayMusic();
            }

            _onPlayMusic = !_onPlayMusic;
        }

        private void PlaySound(ClickedButton obj)
        {
            _soundSource.Play(_soundClip.Key);
        }

        private void PlayBackgroundMusic()
        {
            _onPlayMusic = true;
          PlayMusic();
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<ClickedButton>(PlaySound);
            _eventBus.Unsubscribe<SwitchMusic>(PlayBackgroundMusic);
            YandexGame.OpenFullAdEvent -= StopMusic;
            YandexGame.CloseFullAdEvent -= PlayMusic;

        }
    }
}