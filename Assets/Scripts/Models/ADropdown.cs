using System;
using System.ComponentModel;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.Models
{
    public class ADropdown
    {
        public Dropdown UIDropdown { get; private set; }

        public ADropdown([NotNull] Dropdown uiDropdown, UnityAction<int> action)
        {
            try
            {
                if (uiDropdown.gameObject == null)
                    throw new WarningException();

                UIDropdown = uiDropdown;
                UIDropdown.onValueChanged.AddListener(action);
            }
            catch (Exception e)
            {
                Debug.LogWarning($"Sender: {typeof(ADropdown)}\n" + ExceptionModel.GetExceptionInfo(e));
                throw;
            }
        }

        public ADropdown([NotNull] Dropdown uiDropdown)
        {
            try
            {
                if (uiDropdown.gameObject == null)
                    throw new WarningException();

                UIDropdown = uiDropdown;
            }
            catch (Exception e)
            {
                Debug.LogWarning($"Sender: {typeof(ADropdown)}\n" + ExceptionModel.GetExceptionInfo(e));
                throw;
            }
        }
    }
}