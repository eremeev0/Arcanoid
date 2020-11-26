using System;
using Assets.Scripts.MultiOriented.Models;
using UnityEngine;

namespace Assets.Scripts.GameScene
{
    public class LevelLoader
    {
        public LevelN Level { get; set; }
        public string SaveName { get; set; }
        private readonly ActionContainer _actions;
        private static LevelLoader _loader;

        public static LevelLoader GetLoader()
        {
            return _loader ?? (_loader = new LevelLoader());
        }
        private LevelLoader()
        {
            _actions = new ActionContainer();
            SaveName = string.Empty;
        }
        public void Run(LevelStates state)
        {
            switch (state)
            {
                case LevelStates.LoadLevel:
                    if (SaveName == string.Empty)
                    {
                        Debug.LogError("Empty save filename");
                        return;
                    }
                    //Level = _actions.LoadLevel(SaveName);
                    Debug.LogWarning("Level load func work, but file not found");
                    break;
                case LevelStates.InitializeLevel:
                    Level = _actions.LevelInit(Level);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
    }
}