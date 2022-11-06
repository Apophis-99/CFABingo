using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace CFABingo.Utilities;

public class Game
{
    private readonly List<int> _remainingNumbers;
    private List<int> _recentNumbers;

    private int _currentNumber;

    public int CurrentNumber
    {
        get => _currentNumber;
        set
        {
            _currentNumber = value;
            MainWindow.MainPanel.DisplayNumber = _currentNumber;
        }
    }
    
    public Game()
    {
        _remainingNumbers = new List<int>();
        _recentNumbers = new List<int>();
        Reset();
    }

    public void GetNext()
    {
        if (_remainingNumbers.Count <= 0) return;
        
        var rand = new Random();
        CurrentNumber = _remainingNumbers[rand.Next() % _remainingNumbers.Count];
        _remainingNumbers.Remove(CurrentNumber);

        MainWindow.RecentPanel.Add(CurrentNumber);
        MainWindow.GameStatePanel.UpdateBall(CurrentNumber);
        _recentNumbers.Add(CurrentNumber);
    }

    private void Reset()
    {
        _remainingNumbers.Clear();
        for (var i = 0; i < 90; i++)
            _remainingNumbers.Add(i + 1);
        
        _recentNumbers.Clear();
        MainWindow.RecentPanel.Reset();
        MainWindow.GameStatePanel.Reset();

        CurrentNumber = 0;
    }

    public void Reset(object sender, ExecutedRoutedEventArgs e)
    {
        Reset();
    }
}
