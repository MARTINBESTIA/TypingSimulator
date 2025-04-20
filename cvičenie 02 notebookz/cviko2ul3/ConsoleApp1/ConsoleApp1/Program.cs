// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
int cursorPos = 0;
while (true) {
    if (cursorPos >= Console.BufferWidth) {
        cursorPos = 0;
        Console.Clear();
    }
    Console.CursorTop = Convert.ToInt32(args[1]);
    if (cursorPos != 0) {
        Console.CursorLeft = cursorPos - 1;
    }
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write(" ");
    Console.CursorTop = Convert.ToInt32(args[1]);
    Console.CursorLeft = cursorPos;
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write(args[0]);
    cursorPos++;
    Thread.Sleep(100);
}