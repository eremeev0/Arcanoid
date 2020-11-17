using System;
using System.ComponentModel;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.Models
{
    public class AButton
    {
        public Button UIButton { get; private set; }

        /*
        public AButton([NotNull] Button uiButton)
        {
            UIButton = uiButton;
        }
        
        public delegate void ButtonAction();
        */

        public AButton([NotNull] Button uiButton, UnityAction action)
        {
            try
            {
                if (uiButton.gameObject == null)
                    throw new WarningException();

                UIButton = uiButton;
                UIButton.onClick.AddListener(action);
            }
            catch (Exception e)
            {
                Debug.LogWarning($"Sender: {typeof(AButton)}\n" + ExceptionModel.GetExceptionInfo(e));
                throw;
            }
        }
        public AButton([NotNull] Button uiButton)
        {
            try
            {
                if (uiButton.gameObject == null)
                    throw new WarningException();

                UIButton = uiButton;
            }
            catch (Exception e)
            {
                Debug.LogWarning($"Sender: {typeof(AButton)}\n" + ExceptionModel.GetExceptionInfo(e));
                throw;
            }
        }
    }
}