using JetBrains.Annotations;
using UnityEngine.UI;

namespace Assets.Scripts.Contracts
{
    public class ASlider
    {
        public Slider UISlider;
        
        public Text ValueLabel;
        public ASlider([NotNull]Slider uiSlider,[CanBeNull] Text valueLabel)
        {
            UISlider = uiSlider;
            ValueLabel = valueLabel;
        }
        [CanBeNull]
        public delegate void OnClick();
    }
}