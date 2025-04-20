using Uniza.CSharp.Lab.Events;

// TODO: Úloha 2.0 - preskúmajte nasledujúci zdrojový kód

// Vytvoríme simulátor meteo stanice, ktorá bude zaznamenávať teplotu 
var simulator = new WeatherStationSimulator
{
    LowTemperatureThreshold = 5,
    HighTemperatureThreshold = 10
};

// Zachytíme udalosti 
simulator.LowTemperature += (sender, eventArgs) => Console.WriteLine($"Zaznamenaná NÍZKA teplota (pod {simulator.LowTemperatureThreshold} °C)! Aktuálna teplota: {(sender as WeatherStationSimulator)?.CurrentTemperature:F2}");

// TODO: Úloha 2.2 - zaregistrujte si na udalosť HighTemperature metódu, ktorá vypíše na konzolu: Console.WriteLine($"Zaznamenaná VYSOKÁ teplota ({temperature:F2} °C)!");


// TODO: Úloha 2.5 - zaregistrujte si na udalosť TemperatureChanged metódu SimulatorOnTemperatureChanged, v ktorej použijete: Console.WriteLine($"Zaznamenaná ZMENA teploty v čase {e.CurrentDate} o {e.Difference:F2} °C ({e.PreviousTemperature:F2} °C -> {e.CurrentTemperature:F2} °C)!");


simulator.Start(-0.5f);

Console.WriteLine("Stlačte akúkoľvek klávesu pre ukončenie programu...");
Console.ReadKey();
