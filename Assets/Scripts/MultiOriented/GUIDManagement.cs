using System;
using System.Linq;

namespace Assets.Scripts.MultiOriented
{
    public class GuidManagement
    {
        private string[] _guids { get; set; }
        void Check(string guid) { }
        void GetGuid(Action<string> action) { }
        string GetGuidByObjectName(string name) { return String.Empty;}
        void Initialization() { }
    }
}