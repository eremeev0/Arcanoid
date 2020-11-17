using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Models
{
    public class ALabel
    {
        public ALabel(Text uiLabel)
        {
            try
            {
                if (uiLabel.gameObject == null)
                    throw new WarningException();

                Label = uiLabel;
            }
            catch (Exception e)
            {
                Debug.LogWarning($"Sender: {typeof(ALabel)}\n" + ExceptionModel.GetExceptionInfo(e));
                throw;
            }
        }

        public Text Label { get; private set; }

    }
}