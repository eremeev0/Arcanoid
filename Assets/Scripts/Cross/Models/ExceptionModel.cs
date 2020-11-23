using System;

namespace Assets.Scripts.Cross.Models
{
    public class ExceptionModel
    {
        public static string GetExceptionInfo(Exception e)
        {
            return $"Message: {e.Message}\n" +
                   $"Target: {e.TargetSite}\n" +
                   $"Stack trace: \n{e.StackTrace}\n";
        }
    }
}