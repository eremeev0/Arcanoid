using JetBrains.Annotations;
using UnityEngine.UI;

namespace Assets.Scripts.Contracts
{
    public class AButton
    {
        public Button UIButton;

        public AButton([NotNull] Button uiButton)
        {
            UIButton = uiButton;
        }

        [CanBeNull]
        public delegate void OnClick();
    }
}