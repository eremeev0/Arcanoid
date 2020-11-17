using Assets.Scripts.Models;
using Assets.Scripts.Models.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Initializers.UI
{
    public class FailedInitializer
    {
        public FailedInitializer(Failed uiFailed)
        {
            UIFailed = uiFailed;

            UIFailed.CommonLabel = 
                new ALabel(GameObject.Find("/UI/Failed/Panel/Text").GetComponent<Text>());

            UIFailed.RecordLabel = 
                new ALabel(GameObject.Find("/UI/Failed/Panel/Record").GetComponent<Text>());

            UIFailed.RestartButton = 
                new AButton(GameObject.Find("/UI/Failed/Panel/Restart").GetComponent<Button>());

            UIFailed.MenuButton = 
                new AButton(GameObject.Find("/UI/Failed/Panel/OpenMenu").GetComponent<Button>());

            UIFailed.MainObject = GameObject.Find("/UI/Failed/Panel");
        }

        public Failed UIFailed { get; private set; }
    }
}