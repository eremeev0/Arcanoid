using System;
using Assets.Scripts.EventManagment.Events;
using UnityEngine.UI;

namespace Assets.Scripts.Contracts.Service
{
    public class UIDataInit
    {
        public static Dropdown InitDropdown(Dropdown obj, UIEvents @event)
        {
            obj.ClearOptions();
            switch (@event)
            {
                case UIEvents.INIT_COLOR_LIST:
                    foreach (var color in UIDataSettingsDto.Colors)
                    {
                        obj.options.Add(new Dropdown.OptionData { text = color });
                    }
                    break;
                case UIEvents.INIT_RESOLUTION_LIST:
                    foreach (var resolution in UIDataSettingsDto.Resolutions)
                    {
                        obj.options.Add(new Dropdown.OptionData { text = resolution });
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(@event), @event, null);
            }
            
            return obj;
        }
    }
}