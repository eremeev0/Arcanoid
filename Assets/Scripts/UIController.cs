using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class UIController: MonoBehaviour
    {

        // Em... i catch so weird bug => start = Exit, exit = Start. 
        private Button start;
        private Button exit;
        private Button restart;
        private Button menu;

        void Start()
        {
            
            GameObject.Find("/UI/Failed/Panel").SetActive(false);
            start = GameObject.Find("/UI/Menu/Panel/Start").GetComponent<Button>();
            
            exit = GameObject.Find("/UI/Menu/Panel/Exit").GetComponent<Button>();
            
            restart = GameObject.Find("/UI/Failed/Panel/Restart").GetComponent<Button>();
            
            menu = GameObject.Find("/UI/Failed/Panel/OpenMenu").GetComponent<Button>();
            
            start.onClick.AddListener(CloseGame);
            exit.onClick.AddListener(StartGame);
            restart.onClick.AddListener(RestartGame);
            menu.onClick.AddListener(ShowMenu);
            Time.timeScale = 0;
        }

        void Update()
        {
            if (SceneManager.sceneCountInBuildSettings == 2)
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));
            }
        }



        public void StartGame()
        {
            print("start");
            GameObject.Find("/UI/Menu/Panel").SetActive(false);
            Time.timeScale = 1;
        }

        public void CloseGame()
        {
            print("close");
            #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(1);
            Time.timeScale = 1;
            GameObject.Find("/UI/Failed/Panel").SetActive(false);
            print("restart");
        }

        public void ShowMenu()
        {
            GameObject.Find("/UI/Menu/Panel").SetActive(true);
            GameObject.Find("/UI/Failed/Panel").SetActive(false);
            print("show menu");
        }

        public void SetPoints(float points)
        {

        }
    }
}