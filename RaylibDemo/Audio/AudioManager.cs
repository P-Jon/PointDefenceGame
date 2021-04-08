using PointDefence.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using System.IO;

namespace PointDefence.Audio
{
    public class AudioManager
    {
        private string _audioDirectory = GameData.localDir + "Audio/";
        private Dictionary<string, Sound> _audioDictionary = new Dictionary<string, Sound>();

        public AudioManager()
        {
            OpenAudioDevice();
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

        public void PlaySound(string sound)
        {
            if (_audioDictionary.ContainsKey(sound))
                Raylib.PlaySound(_audioDictionary[sound]);
        }

        private void OpenAudioDevice()
        {
            Raylib.InitAudioDevice();
        }

        public void CloseAudioDevice()
        {
            Raylib.CloseAudioDevice();
        }
    }
}