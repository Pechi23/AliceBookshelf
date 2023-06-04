//read input
string inputFile = "InputFile.txt";
StreamReader sr = new StreamReader(inputFile);

List<string> input = new List<string>();
string inputLine;
while ((inputLine = sr.ReadLine()) != null)
    input.Add(inputLine);

foreach(string line in input)
{
    Stack<char> stack = new Stack<char>();
    foreach (char c in line)
    {
        if (c == '\\')
        {
            string reversed = "";
            while (stack.Any() && stack.Peek() != '/')
                reversed += stack.Pop();
            if (stack.Any() && stack.Peek() == '/')
                stack.Pop();
            for(int i=0;i<reversed.Length;i++)
                stack.Push(reversed[i]);
        }
        else
            stack.Push(c);
    }
    
    char[] reversedStack = new char[stack.Count];
    for (int i = reversedStack.Length - 1; i >= 0; i--)
        reversedStack[i] = stack.Pop();

   foreach(var el in reversedStack)
        Console.Write(el);
    Console.WriteLine();
}