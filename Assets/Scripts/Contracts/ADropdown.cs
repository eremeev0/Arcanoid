using JetBrains.Annotations;
using UnityEngine.UI;

namespace Assets.Scripts.Contracts
{
    public class ADropdown
    {
        public Dropdown UIDropdown;

        public ADropdown([NotNull] Dropdown uiDropdown)
        {
            UIDropdown = uiDropdown;
        }

        [CanBeNull]
        public delegate void Onclick();
    }
}