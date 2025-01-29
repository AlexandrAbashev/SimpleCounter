using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;


namespace SimpleCounter
{
    public partial class MainWindow : Window
    {
        private long counter = 0;
        private long step = 1;
        public MainWindow()
        {
            InitializeComponent();
            currentNumberText.Text = $"{counter}";
        }

        private void SubButton_Click(object sender, RoutedEventArgs e)
        {
            if (!long.TryParse(stepTextbox.Text, out step))
                return;
            UpdateCounter(step, false);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!long.TryParse(stepTextbox.Text, out step))
                return;
            UpdateCounter(step, true);
        }

        private void UpdateCounter(long step, bool isAddition)
        {
            if (isAddition)
            {
                long max = long.MaxValue;
                if (counter > max - step)
                {
                    counter = max;
                }
                else
                {
                    counter += step;
                }
            }
            else
            {
                long min = long.MinValue;
                if (counter < min + step)
                {
                    counter = min;
                }
                else
                {
                    counter -= step;
                }
            }
            currentNumberText.Text = $"{counter}";
        }

        private void StepTextbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^\d+$");
        }

        private void StepTextbox_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }
    }
}