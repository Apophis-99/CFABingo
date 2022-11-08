using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CFABingo.Controls;

public partial class DialogBox : UserControl
{
    private string _message;
    private List<string> _buttonOptions;

    public EventHandler OptionChosen;

    public string Message
    {
        get => _message;
        set
        {
            _message = value;
            DisplayText.Text = Message;
        }
    }

    public List<string> ButtonOptions
    {
        get => _buttonOptions;
        init
        {
            _buttonOptions = value;
            foreach (var button in ButtonOptions.Select(option => new Button
                {
                    Content = option,
                    Margin = new Thickness(2)
                }))
            {
                button.Click += Button_Clicked;
                ButtonDisplay.Children.Add(button);
            }

            ((Button) ButtonDisplay.Children[0]).Focus();
        }
    }

    public string SelectedOption { get; private set; }

    public DialogBox()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs args)
    {
        SelectedOption = ((Button)sender).Content.ToString() ?? string.Empty;
        OptionChosen.Invoke(sender, args);
    }
}
