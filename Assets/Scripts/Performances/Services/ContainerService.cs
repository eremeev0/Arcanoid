using System;
using Assets.Scripts.Contracts;
using Assets.Scripts.EventManagment.Provider;
using UnityEngine;
using UnityEngine.UI;
using UnityException = UnityEngine.UnityException;

namespace Assets.Scripts.Performances.Services
{
    public class ContainerService
    {
        public static void TryInitialize()
        {
            try
            {
                ContainerDto.Menu = GameObject.Find("/UI/Menu/Panel");
                ContainerDto.Failed = GameObject.Find("/UI/Failed/Panel");
                ContainerDto.Score = GameObject.Find("/UI/Score/Panel");
                ContainerDto.Settings = GameObject.Find("/UI/Settings/Panel");
                ContainerDto.Player = GameObject.Find("/Character/playerPillar");
                ContainerDto.Ball = GameObject.Find("/ActiveObjects/gameBall");
                ContainerDto.PlatformsList = GameObject.Find("/ActiveObjects/Platforms");

                //variableForPrefab = (GameObject)Resources.Load("prefabs/prefab1", typeof(GameObject));
                ContainerDto.Platform = Resources.Load<GameObject>("Prefabs/ActiveObjects/Platform");//GameObject.Find("/ActiveObjects/Platforms/Platform");

                ContainerDto.StartButton = GameObject.Find("/UI/Menu/Panel/Start").GetComponent<Button>();
                ContainerDto.RestartButton = GameObject.Find("/UI/Failed/Panel/Restart").GetComponent<Button>();
                ContainerDto.MenuButton = GameObject.Find("/UI/Failed/Panel/OpenMenu").GetComponent<Button>();
                ContainerDto.SettingsButton = GameObject.Find("/UI/Menu/Panel/Settings").GetComponent<Button>();
                ContainerDto.BackToMenuButton = GameObject.Find("/UI/Settings/Panel/Exit").GetComponent<Button>();
                ContainerDto.SaveButton = GameObject.Find("/UI/Settings/Panel/Save").GetComponent<Button>();
                ContainerDto.ResetButton = GameObject.Find("/UI/Settings/Panel/Reset").GetComponent<Button>();
                ContainerDto.ExitButton = GameObject.Find("/UI/Menu/Panel/Exit").GetComponent<Button>();
                ContainerDto.SpeedSlider = GameObject.Find("/UI/Settings/Panel/Slider").GetComponent<Slider>();
                ContainerDto.ColorsList = GameObject.Find("/UI/Settings/Panel/Dropdown").GetComponent<Dropdown>();
                ContainerDto.ResolutionsList = GameObject.Find("/UI/Settings/Panel/ResolutionDropdown").GetComponent<Dropdown>();
                ContainerDto.ScoreLabel = GameObject.Find("/UI/Score/Panel/Panel/count").GetComponent<Text>();
                ContainerDto.RecordLabel = GameObject.Find("/UI/Failed/Panel/Result").GetComponent<Text>();
                ContainerDto.SpeedValue = GameObject.Find("/UI/Settings/Panel/Slider/value").GetComponent<Text>();
                ContainerDto.Manager = GameObject.Find("EventSystem2").GetComponent<EventManager>();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                throw;
            }
        }
    }
}