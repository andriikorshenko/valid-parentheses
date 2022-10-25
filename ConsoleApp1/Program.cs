Console.WriteLine(IsValid("a({[]})"));
Console.WriteLine(IsValid("({}a!)"));
Console.WriteLine(IsValid("[http(s):...]"));
Console.WriteLine(IsValid("[http{(s):...]"));

bool IsValid(string s)
{
    if (string.IsNullOrEmpty(s))
    {
        return false;
    }

    Dictionary<char, char> _dictionary = new()
        {
            { '(', ')' },
            { '{', '}' },
            { '[', ']' }
        };

    Stack<char> _stack = new();

    for (int i = 0; i < s.Length; i++)
    {
        if (_dictionary.ContainsKey(s[i]))
        {
            _stack.Push(s[i]);
        }
        else if (!_dictionary.ContainsValue(s[i]))
        {
            continue;
        }
        else if (_stack.Count == 0)
        {
            return false;
        }
        else if (_dictionary[_stack.Pop()] != s[i])
        {
            return false;
        }
    }

    return _stack.Count == 0 ? true : false;
}

