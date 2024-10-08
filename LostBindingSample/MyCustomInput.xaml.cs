using System.Windows;
using System.Windows.Controls;

namespace LostBindingSample;

public partial class MyCustomInput : UserControl
{
  public MyCustomInput()
  {
    InitializeComponent();
  }

  public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
    nameof(Value),
    typeof(string),
    typeof(MyCustomInput),
    new PropertyMetadata(default(string)));

  public string Value
  {
    get => (string)GetValue(ValueProperty);
    set => SetValue(ValueProperty, value);
  }
}