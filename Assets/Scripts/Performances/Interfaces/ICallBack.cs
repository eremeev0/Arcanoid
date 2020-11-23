using UnityEngine.Events;

namespace Assets.Scripts.Performances.Interfaces
{
    public interface ICallBack
    {
        void AddListener(UnityAction action);
    }
}