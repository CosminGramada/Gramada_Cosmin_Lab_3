using System.Windows.Input;

namespace Gramada_Cosmin_Lab_3.CustomCommands
{
    class StopCommand
    {
        private static RoutedUICommand launch_command;
        static StopCommand()
        {
            var myInputGestures = new InputGestureCollection();
            myInputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Control));
            launch_command = new RoutedUICommand("Launch", "Launch", typeof(StopCommand), myInputGestures);
        }
        public static RoutedUICommand Launch => launch_command;
    }
}
