using System;
using Assets.Scripts.Contracts;
using Assets.Scripts.StorageProvider.Service;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.EventManagment.Provider
{
    public class UIEventManager
    {
        private void ReloadGame()
        {
            SettingsSingleton.GetSettings().PlayerScore = 0;
            // reload current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Additive);
            // unload old scene
            SceneManager.UnloadSceneAsync(1);
            // resume game
            // hide failed window
            /*ContainerDto.RecordLabel.text = "Score ";
            ContainerDto.Failed.SetActive(false);*/
        }
    }
}