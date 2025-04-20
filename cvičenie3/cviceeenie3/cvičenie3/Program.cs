// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
for (int i = 0; i < 4; i++) {
    stringBuilder.Append($"{i}. ");
    stringBuilder.Append(args[i]);
    stringBuilder.Append("\n");
}
Console.WriteLine(stringBuilder.ToString());
Console.WriteLine(stringBuilder.ToString().Length);
