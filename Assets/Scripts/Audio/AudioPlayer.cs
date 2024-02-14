using System;
using Infrastructure.Level.EventsBus;
using Infrastructure.Level.EventsBus.Signals;
using Plugins.Audio.Core;
using Plugins.Audio.Utils;

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
    }

    private void PlayBackgroundMusic(SwitchMusic obj)
    {
        if (_onPlayMusic)
        {
            _musicSource.Stop();
        }
        else
        {
            _musicSource.Play(_musicClip.Key);
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
        _musicSource.Play(_musicClip.Key);
    }

    public void Dispose()
    {
        _eventBus.Unsubscribe<ClickedButton>(PlaySound);

    }
}