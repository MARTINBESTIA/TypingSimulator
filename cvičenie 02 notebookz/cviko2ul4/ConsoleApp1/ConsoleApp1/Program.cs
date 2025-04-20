// See https://aka.ms/new-console-template for more information
string[] poleTextaku = File.ReadAllLines("C:/Users/marti/Desktop/škola/2. ročník/4. semester/C#/cvičenie 02 notebookz/Operations-input.txt");
int[] poleCisel = new int[Convert.ToInt32(poleTextaku[0])];
int i = 1;
foreach (string str in poleTextaku[1..^0]) { 
    string[] numbers = poleTextaku[i].Split(" ");
    int firstIndex = Convert.ToInt32(numbers[0]);
    int lastIndex = Convert.ToInt32(numbers[1]);
    switch (Convert.ToChar(numbers[2])) { 
        case '+':
            for (int j = firstIndex; j <= lastIndex; j++) {
                poleCisel[j] += Convert.ToInt32(numbers[3]);
            }
            break;
        case '-':
            for (int j = firstIndex; j <= lastIndex; j++)
            {
                poleCisel[j] -= Convert.ToInt32(numbers[3]);
            }
            break;
        case '*':
            for (int j = firstIndex; j <= lastIndex; j++)
            {
                poleCisel[j] *= Convert.ToInt32(numbers[3]);
            }
            break;
        case '/':
            for (int j = firstIndex; j <= lastIndex; j++)
            {
                poleCisel[j] /= Convert.ToInt32(numbers[3]);
            }
            break;
    }
    i++;
}
Console.WriteLine("done");
string[] output = new string[1000];
for (int e = 0; e < 1000; e++)
{
    output[e] = Convert.ToString(poleCisel[e]);
}
File.WriteAllLines("output.txt", output);

