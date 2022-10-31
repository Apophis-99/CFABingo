using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace CFABingo.Utilities;

public class Game
{
    private List<int> _remainingNumbers;
    private List<int> _recentNumbers;
    private int _currentNumber;

    public int CurrentNumber
    {
        get => _currentNumber;
        set => _currentNumber = value;
    }
    
    public Game()
    {
        _remainingNumbers = new List<int>();
        for (var i = 0; i < 90; i++)
            _remainingNumbers.Add(i + 1);

        _recentNumbers = new List<int>();

        _currentNumber = 0;
    }

    public void GetNext()
    {
        var random = new Random();
        var newNum = _remainingNumbers[random.Next() % _remainingNumbers.Count];
        CurrentNumber = newNum;
        _recentNumbers.Remove(newNum);
    }
}
