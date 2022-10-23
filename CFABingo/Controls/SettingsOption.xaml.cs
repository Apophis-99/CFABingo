using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CFABingo.Utilities;

namespace CFABingo.Controls;

public partial class SettingsOption
{
    private string _title = "Default Title";
    private SettingsOptionType _type;

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
        set { _type = value; SetupType(); }
    }
    
    public SettingsOption()
    {
        InitializeComponent();
    }

    private void SetupType()
    {
        switch (Type)
        {
            case SettingsOptionType.Integer:
                TypeEncapsulator.Child = new TextBox
                {
                    Text="100"
                };

                break;
            case SettingsOptionType.String:
                TypeEncapsulator.Child = new TextBox
                {
                    Text = "str"
                };
                break;
            case SettingsOptionType.Colour:
                TypeEncapsulator.Child = new Button
                {
                    Background = Brushes.Aqua
                };
                break;
            default:
                break;
        }
    }
}
