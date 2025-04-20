string[] lines = File.ReadAllLines("C:/Users/marti/Desktop/škola/2. ročník/4. semester/C#/cvičenie 02 notebookz/numbers.txt");
Console.WriteLine(lines[0]);
Console.WriteLine(lines[^1]);
Console.WriteLine(lines[lines.Length / 2]);

static void printStatistics(ReadOnlySpan<string> span) {
    int sum = 0;
    double variance = 0.0;
    double mean = 0.0;

    foreach (string line in span) {
        sum += Convert.ToInt32(line);
        mean += Convert.ToInt32(line);
    }
    mean /= span.Length;
    foreach (string line in span)
    {
        variance += (Convert.ToInt32(line) - mean) * (Convert.ToInt32(line) - mean);
    }
    variance /= span.Length;   

    Console.WriteLine($"Suma je {sum}");
    Console.WriteLine($"Variancia je {variance}");
    Console.WriteLine($"Stredna hodntota je {mean}");
    
}/*
  * JEDNA MOZNOST
Span<string> span1 = new(lines, start: 0, length: 300);
span1.Fill("0");
*/
/*
 * DRUHA MOZNOST*/
Span<string> span1 = new(lines);
ReadOnlySpan<string> spaan = new(lines);
Span<string> span2 = span1.Slice(start: 0, length: 300);
span2.Fill("0");

Span<string> span3 = span1.Slice(start: 4000, length: 2001);
span3.Fill("500");
printStatistics(span1);

Span<string> spanOd5000 = span1.Slice(start: 5000);
printStatistics(spanOd5000);

void RotateStringArray(string[] stringArray, int step = 1, bool left = true) { 
    string[] novePole = new string[stringArray.Length];
    Span<string> novePoleSpan = new(novePole);
    if (left)
    {
        Span<string> spanToShift = new(stringArray, start: 0, length: step);
        Span<string> spanToMove = new(stringArray, start: step, length: stringArray.Length - step);
        Span<string> novePoleShifted = new(novePole, start: stringArray.Length - step, length: step);
        Span<string> novePoleMoved = new(novePole, start: 0, length: stringArray.Length - step);
        spanToShift.CopyTo(novePoleShifted);
        spanToMove.CopyTo(novePoleMoved);
    }
    else {
        Span<string> spanToShift = new(stringArray, start: stringArray.Length - step, length: step);
        Span<string> spanToMove = new(stringArray, start: 0, length: stringArray.Length - step);
        Span<string> novePoleShifted = new(novePole, start: 0, length: step);
        Span<string> novePoleMoved = new(novePole, start: step, length: stringArray.Length - step);
        spanToShift.CopyTo(novePoleShifted);
        spanToMove.CopyTo(novePoleMoved);
    }
    stringArray = novePole;
    Console.WriteLine(stringArray);
}
string[] pole = new string[] {"a", "b", "c", "d", "e"};
RotateStringArray(pole, step: 3, left: false);




