namespace Uniza.CSharp.Lab.Events
{
    class WeatherStationSimulator
    {
        public float CurrentTemperature { get; set; }

        public float LowTemperatureThreshold { get; set; } = 0f;

        public float HighTemperatureThreshold { get; set; } = 40f;

        public float DiffTemperatureThreshold { get; set; } = 0.25f;

        public event EventHandler? LowTemperature;
        public event EventHandler<float>? HighTemperature;
        public event EventHandler<TemperatureEventArgs>? TemperatureChanged;

        public void Start(float startingTemperature = 5, int generateEveryMilliseconds = 1000)
        {
            // Tu vstupuje negenerický delegát Action - vytvorí sa úloha, ktorá sa bude vykonávať na pozadí
            Task.Factory.StartNew(() =>
            {
                Random random = new(10);

                int temperatureCount = 10;
                int temperatureSign = +1;

                float previousTemperature;
                float temperature = startingTemperature;
                while (true)
                {
                    temperatureCount--;
                    if (temperatureCount < 0)
                    {
                        temperatureCount = random.Next(10);
                        temperatureSign = random.NextDouble() >= 0.5 ? -1 : 1;
                    }
                    
                    previousTemperature = temperature;
                    temperature += temperatureSign * (float)Math.Round(random.NextDouble(), 2);
                    CurrentTemperature = temperature;

                    // Ak nastane nízka teplota, vyvolá sa udalosť LowTemperature
                    if (temperature < LowTemperatureThreshold)
                    {
                        OnLowTemperature();
                    }

                    // TODO: Úloha 2.1 - ak nastane vysoká teplota (väčšia ako HighTemperatureThreshold), vyvolajte udalosť HighTemperature
                    if (temperature > HighTemperatureThreshold)
                    {
                        // ???
                    }

                    // TODO: Úloha 2.4 - ak nastane zmena teploty, vyvolajte udalosť TemperatureChanged
                    if (Math.Abs(temperature - previousTemperature) >= DiffTemperatureThreshold)
                    {
                        // ???
                    }

                    Thread.Sleep(generateEveryMilliseconds);
                }
            });
        }

        protected virtual void OnLowTemperature()
        {
            LowTemperature?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnHighTemperature(float temperature)
        {
            HighTemperature?.Invoke(this, temperature);
        }

        // TODO: Úloha 2.3 - pridajte metódu OnTemperatureChanged pre vyvolanie udalosti TemperatureChanged
        // ???
    }
}
