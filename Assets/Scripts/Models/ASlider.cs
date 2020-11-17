using System;
using System.ComponentModel;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.Models
{
    public class ASlider
    {
        public Slider UISlider { get; private set; }
        [Obsolete("Property ValueLabel has been deprecated. Use SpeedValueLabel instead. (Models.ALabel in your UI Model)", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Text UIValueLabel { get; private set; }
        [Obsolete("This constructor has been deprecated. Use ASlider(Slider, UnityAction<float>) instead. ", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ASlider([NotNull]Slider uiSlider, Text uiValueLabel, UnityAction<float> action)
        {
            try
            {
                if (uiSlider.gameObject == null)
                    throw new WarningException();

                if (uiValueLabel.gameObject == null)
                    throw new WarningException();

                UISlider = uiSlider;
                UIValueLabel = uiValueLabel;
                UISlider.onValueChanged.AddListener(action);
            }
            catch (Exception e)
            {
                Debug.LogWarning($"Sender: {typeof(ASlider)}\n" + ExceptionModel.GetExceptionInfo(e));
                throw;
            }
        }
        [Obsolete("This constructor has been deprecated. Use ASlider(Slider) instead. ", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ASlider([NotNull] Slider uiSlider, Text uiValueLabel)
        {
            try
            {
                if (uiSlider.gameObject == null)
                    throw new WarningException();

                if (uiValueLabel.gameObject == null)
                    throw new WarningException();

                UISlider = uiSlider;
                UIValueLabel = uiValueLabel;
            }
            catch (Exception e)
            {
                Debug.LogWarning($"Sender: {typeof(ASlider)}\n" + ExceptionModel.GetExceptionInfo(e));
                throw;
            }
        }
        public ASlider([NotNull] Slider uiSlider)
        {
            try
            {
                if (uiSlider.gameObject == null)
                    throw new WarningException();

                UISlider = uiSlider;
            }
            catch (Exception e)
            {
                Debug.LogWarning($"Sender: {typeof(ASlider)}\n" + ExceptionModel.GetExceptionInfo(e));
                throw;
            }
        }
        public ASlider([NotNull] Slider uiSlider, UnityAction<float> action)
        {
            try
            {
                if (uiSlider.gameObject == null)
                    throw new WarningException();

                UISlider = uiSlider;
                UISlider.onValueChanged.AddListener(action);
            }
            catch (Exception e)
            {
                Debug.LogWarning($"Sender: {typeof(ASlider)}\n" + ExceptionModel.GetExceptionInfo(e));
                throw;
            }
        }
        /*
        public delegate void OnClick();*/
    }
}