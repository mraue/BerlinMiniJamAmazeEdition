﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace CreatingDust.AchievementSimulator.CrossContext.Services
{
    public class AudioService : IAudioService
    {
        const string KEY_AUDIO_SERVICE_DATA = "audioServiceData";
        const string KEY_FX_ENABLED = "fxEnabled";
        const string KEY_MUSIC_ENABLED = "musicEnabled";

        const bool AUDIO_ENABLED_DEFAULT_VALUE = true;

        AudioServiceComponent _audioServiceComponent;

        public bool fxEnabled { get { return _fxEnabled; } set { _fxEnabled = value; } }
        bool _fxEnabled;

        public bool musicEnabled { get { return _musicEnabled; } set { _musicEnabled = value; CheckBackground(); } }

        bool _musicEnabled;


        public void Setup()
        {
            if (_audioServiceComponent == null)
            {                
                var go = new GameObject();
                go.name = "Audio Service";
                _audioServiceComponent = go.AddComponent<AudioServiceComponent>();
            }

            _fxEnabled = AUDIO_ENABLED_DEFAULT_VALUE;
            _musicEnabled = AUDIO_ENABLED_DEFAULT_VALUE;
        }

        public void Play(AudioId id)
        {
            if (fxEnabled)
            {                
                _audioServiceComponent.Play(id);
            }
        }

        public void SetBackground(AudioId id)
        {
            if (musicEnabled)
            {
                _audioServiceComponent.SetBackground(id);
            }
            else
            {
                _audioServiceComponent.StopBackground();
            }
        }

        void CheckBackground()
        {
            if (!musicEnabled)
            {
                _audioServiceComponent.StopBackground();
            }
        }
    }
}