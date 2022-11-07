using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using CFABingo.Utilities.Settings;
using Xceed.Wpf.Toolkit;

namespace CFABingo.Controls;

public partial class SettingsOption
{
    private string _title = "<option_tag>";
    private readonly SettingsOptionType _type = SettingsOptionType.String;
    private string _warning = "";
    private bool _changed;
    private dynamic _displayValue;

    public string Title
    {
        get => _title;
        set 
        { 
            _title = value;
            TitleText.Text = _title;
        }
    }
    public SettingsOptionType Type
    {
        get => _type;
        init { _type = value; SetupType(); }
    }

    public string Warning
    {
        get => _warning;
        set { 
            _warning = value;
            if (Warning.Length == 0) return;
            WarningText.Visibility = Visibility.Visible;
            WarningText.Text = Warning;
        }
    }

    public dynamic DisplayValue
    {
        get => _displayValue;
        set { _displayValue = value; InitDisplayValue(); }
    }

    private bool Changed
    {
        get => _changed;
        set { 
            _changed = value;
            ChangedIcon.Visibility = _changed ? Visibility.Visible : Visibility.Hidden;
        }
    }

    public string Bond { get; init; }

    public SettingsOption()
    {
        InitializeComponent();
        SetupType();
        Changed = false;
    }

    private void InitDisplayValue()
    {
        try
        {
            switch (Type)
            {
                case SettingsOptionType.Integer:
                    ((TextBox)Encapsulator.Child).Text = DisplayValue.ToString();
                    break;
                case SettingsOptionType.String:
                    ((TextBox)Encapsulator.Child).Text = DisplayValue.ToString();
                    break;
                case SettingsOptionType.Colour:
                    ((ColorPicker)Encapsulator.Child).SelectedColor = (Color) DisplayValue;
                    break;
                case SettingsOptionType.Boolean:
                    ((ToggleButton)Encapsulator.Child).IsChecked = Convert.ToBoolean(DisplayValue);
                    break;
                default:
                    break;
            }
        }
        catch (Exception)
        {
            //MainWindow.Manager.DebugWindow.Add(new DebugMessage($"Failed to initialise display value for setting: {Title}", DebugMessageLevel.Warning));
        }
    }
    
    private void SetupType()
    {
        Encapsulator.Child = Type switch
        {
            SettingsOptionType.Integer => new TextBox(),
            SettingsOptionType.String => new TextBox(),
            SettingsOptionType.Colour => new ColorPicker(),
            SettingsOptionType.Boolean => new ToggleButton(),
            _ => Encapsulator.Child
        };
    }
    
    public dynamic? Get()
    {
        return _type switch
        {
            SettingsOptionType.Boolean => ((ToggleButton)Encapsulator.Child).IsChecked,
            SettingsOptionType.Colour => new SolidColorBrush((Color)((ColorPicker) Encapsulator.Child).SelectedColor),
            SettingsOptionType.Integer => Convert.ToInt32(((TextBox)Encapsulator.Child).Text),
            SettingsOptionType.String => ((TextBox)Encapsulator.Child).Text,
            _ => 0
        };
    }

    public void Reset()
    {
        InitDisplayValue();
    }
}
