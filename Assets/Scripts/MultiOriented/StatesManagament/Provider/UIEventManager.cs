using Assets.Scripts.MultiOriented.Contracts;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.MultiOriented.StatesManagament.Provider
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