using Assets.Scripts.GameScene;
using Assets.Scripts.GameScene.Storage;
using Assets.Scripts.MultiOriented.Contracts;
using UnityEditor;

namespace Assets.Scripts.MultiOriented.StatesManagament.ActionsContainer
{
    public class GlobalActionContainer
    {

        private readonly DataManager _settings;
        private readonly LevelLoader _levelLoader;
        public GlobalActionContainer()
        {
            _settings = new DataManager();
            _levelLoader = LevelLoader.GetLoader();
        }

        public void StartGame()
        {
            SettingsSingleton.GetSettings().IsGameStopped = false;
            if (_levelLoader.Level == null)
            {
                _levelLoader.Run(LevelStates.InitializeLevel);
            }
        }


        public void ResumeGame()
        {
            SettingsSingleton.GetSettings().IsGameStopped = false;

        }

        public void CloseGame()
        {
            #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

        public void PauseGame()
        {
            SettingsSingleton.GetSettings().IsGameStopped = true;
        }
    }
}