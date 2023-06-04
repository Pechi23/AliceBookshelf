string inputFilePath = "InputFile.txt";
string outputFilePath = @"..\..\..\OutputFile.txt";

//read input
List<string> input = new List<string>();
using (StreamReader sr = new StreamReader(inputFilePath))
{
    string inputLine;
    while ((inputLine = sr.ReadLine()) != null)
        input.Add(inputLine);
}

//solver
using (StreamWriter sw = new StreamWriter(outputFilePath))
{
    
    foreach (string line in input)
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
    
        foreach (var el in reversedStack)
            sw.Write(el);
        sw.WriteLine();
    }
}