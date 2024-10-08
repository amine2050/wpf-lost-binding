using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;

namespace LostBindingSample;

public partial class BindingObserver : UserControl
{
  private readonly DispatcherTimer _timer;

  public BindingObserver()
  {
    InitializeComponent();

    _timer = new DispatcherTimer
    {
      Interval = TimeSpan.FromMilliseconds(100)
    };

    _timer.Tick += OnTimerTick;

    Loaded += OnLoaded;
  }

  private void OnLoaded(object sender, RoutedEventArgs e)
  {
    _timer.Start();
  }

  private void OnTimerTick(object? sender, EventArgs e)
  {
    UpdateBindingState();
  }

  private void UpdateBindingState()
  {
    if (ObservedObject is null || ObservedProperty is null)
    {
      return;
    }
    
    CurrentBindingExpression = BindingOperations.GetBindingExpression(ObservedObject, ObservedProperty);
  }

  public static readonly DependencyProperty ObservedObjectProperty = DependencyProperty.Register(
    nameof(ObservedObject),
    typeof(DependencyObject),
    typeof(BindingObserver),
    new PropertyMetadata(default(DependencyObject?)));

  public DependencyObject? ObservedObject
  {
    get => (DependencyObject?)GetValue(ObservedObjectProperty);
    set => SetValue(ObservedObjectProperty, value);
  }

  public static readonly DependencyProperty ObservedPropertyProperty = DependencyProperty.Register(
    nameof(ObservedProperty),
    typeof(DependencyProperty),
    typeof(BindingObserver),
    new PropertyMetadata(default(DependencyProperty?)));

  public DependencyProperty? ObservedProperty
  {
    get => (DependencyProperty?)GetValue(ObservedPropertyProperty);
    set => SetValue(ObservedPropertyProperty, value);
  }

  public static readonly DependencyProperty CurrentBindingExpressionProperty = DependencyProperty.Register(
    nameof(CurrentBindingExpression),
    typeof(BindingExpression),
    typeof(BindingObserver),
    new PropertyMetadata(default(BindingExpression?)));

  public BindingExpression? CurrentBindingExpression
  {
    get => (BindingExpression?)GetValue(CurrentBindingExpressionProperty);
    set => SetValue(CurrentBindingExpressionProperty, value);
  }
}