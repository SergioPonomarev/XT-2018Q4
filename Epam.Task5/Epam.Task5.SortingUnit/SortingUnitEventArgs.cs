using System;

namespace Epam.Task5.SortingUnit
{
    public class SortingUnitEventArgs : EventArgs
    {
        public SortingUnitEventArgs(string message, double timePerformance)
        {
            this.Message = message;
            this.TimePerformance = timePerformance;
        }

        public string Message { get; private set; }

        public double TimePerformance { get; private set; }
    }
}
