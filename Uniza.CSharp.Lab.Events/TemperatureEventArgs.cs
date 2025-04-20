namespace Uniza.CSharp.Lab.Events
{
    class TemperatureEventArgs : EventArgs
    {
        public DateTime CurrentDate { get; }

        public float CurrentTemperature { get; }

        public float PreviousTemperature { get; }

        public float Difference => Math.Abs(PreviousTemperature - CurrentTemperature);

        public TemperatureEventArgs(DateTime currentDate, float currentTemperature, float previousTemperature)
        {
            CurrentDate = currentDate;
            CurrentTemperature = currentTemperature;
            PreviousTemperature = previousTemperature;
        }
    }
}
