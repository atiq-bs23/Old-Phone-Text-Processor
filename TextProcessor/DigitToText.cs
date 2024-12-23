using System.Text;

namespace TextProcessor;

public class DigitToText
{
    private readonly StringBuilder _outputText;
    private readonly Dictionary<char, string> _digitTextMapping = new()
    {
        { '0', " " },
        { '2', "ABC" }, { '3', "DEF" }, { '4', "GHI" }, { '5', "JKL" },
        { '6', "MNO" }, { '7', "PQRS" }, { '8', "TUV" }, { '9', "WXYZ" },
    };

    private char _currentKey;
    private int _currentKeyPressCount;
    private bool _paused;

    public DigitToText()
    {
        _outputText = new StringBuilder();
        _currentKey = '\0';
        _currentKeyPressCount = 0;
        _paused = false;
    }

    /// <summary>
    /// Processes text from old phone keypad press.
    /// </summary>
    /// <param name="input">A string of characters (digits, '*', '#', ' ') as input</param>
    /// <returns>output text based on old phone keypad press.</returns>
    public string ProcessInput(string input)
    {
        foreach (char currentCharacter in input)
        {
            if (currentCharacter == '#') // end input, so finalizing output
            {
                FinalizeCurrentKey();
                break;
            }

            if (currentCharacter == '*') // removing last input
            {
                HandleBackspace();
                continue;
            }

            if (currentCharacter == ' ') //pause so finalizing current input and reseting for next input
            {
                _paused = true;
                FinalizeCurrentKey();
                ResetCurrentKey();
                continue;
            }

            if (_digitTextMapping.ContainsKey(currentCharacter))
            {
                if (currentCharacter == _currentKey && !_paused)
                {
                    _currentKeyPressCount++; // cycle through letters, 2222-> count 4
                }
                else
                {
                    FinalizeCurrentKey();
                    _currentKey = currentCharacter;
                    _currentKeyPressCount = 1; 
                    _paused = false;
                }
            }
        }

        return _outputText.ToString();
    }

    private void FinalizeCurrentKey()
    {
        if (_currentKey != '\0' && _digitTextMapping.TryGetValue(_currentKey, out string? value))
        {
            string chars = value;
            int index = (_currentKeyPressCount - 1) % chars.Length; //handling multiple press like 2222 -> 2 -> 'A'
            _outputText.Append(chars[index]); 
        }
    }

    private void ResetCurrentKey()
    {
        _currentKey = '\0';
        _currentKeyPressCount = 0;
    }

    private void HandleBackspace()
    {
        if (_currentKey != '\0') // resetting current key input and associated press count
        {
            ResetCurrentKey();
        }
        else if (_outputText.Length > 0) // removing last character
        {
            _outputText.Remove(_outputText.Length - 1, 1);
        }
    }
}
