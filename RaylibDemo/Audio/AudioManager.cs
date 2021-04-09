﻿using PointDefence.Core.Data;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.IO;

namespace PointDefence.Audio
{
    public class AudioManager
    {
        private string _audioDirectory = GameData.localDir + "Sounds/";
        private Dictionary<string, Sound> _audioDictionary = new Dictionary<string, Sound>();

        public AudioManager()
        {
            OpenAudioDevice();
            LoadSoundsFromDirectory();
            Raylib.SetMasterVolume(0.3f);
        }

        private void LoadSoundsFromDirectory()
        {
            var files = Directory.GetFiles(_audioDirectory);

            foreach (var file in files)
            {
                var fileWithoutExtension = Path.GetFileNameWithoutExtension(file);
                var sound = Raylib.LoadSound(file);
                _audioDictionary.Add(fileWithoutExtension, sound);
            }
        }

        private Sound GetSound(string sound)
        {
            if (_audioDictionary.ContainsKey(sound))
                return _audioDictionary[sound];
            else
                throw new Exception($"Sound: {sound} is not an available sound.");
        }

        public void PlaySound(string sound)
        {
            Raylib.PlaySound(GetSound(sound));
        }

        public void StopSound(string sound)
        {
            Raylib.StopSound(GetSound(sound));
        }

        public void UnloadSounds()
        {
            foreach (var val in _audioDictionary)
            {
                Raylib.UnloadSound(val.Value);
            }
        }

        private void OpenAudioDevice()
        {
            Raylib.InitAudioDevice();
        }

        public void CloseAudioDevice()
        {
            UnloadSounds();
            Raylib.CloseAudioDevice();
        }
    }
}