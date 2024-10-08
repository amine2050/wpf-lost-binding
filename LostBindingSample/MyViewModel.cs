using System.Windows.Input;

namespace LostBindingSample;

public class MyViewModel : BindableBase
{
  public MyViewModel()
  {
    ChangeTheValueCommand = new DelegateCommand(OnChangeTheValue);
  }

  private void OnChangeTheValue()
  {
    TheValue += "X";
  }

  private string _theValue = "";
  public string TheValue
  {
    get => _theValue;
    set => SetProperty(ref _theValue, value);
  }

  public ICommand ChangeTheValueCommand { get; }
}

