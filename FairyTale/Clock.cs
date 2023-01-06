using EnsureThat;
using System;

namespace FairyTale
{
    public class Clock
    {
        public Clock(DateTime startDateTime)
        {
            _currentDateTime = startDateTime;
        }

        public void AddDay()
        {
           _currentDateTime = _currentDateTime.AddDays(1);
        }

        public DateTime Show()
        {
            return _currentDateTime;
        }

        private DateTime _currentDateTime;
    }
}
