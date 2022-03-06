using System;

namespace WebApplication.Services
{
    public class TimeService
    {
        public string GetTime() => DateTime.Now.ToString("H:mm:ss");
    }
}
