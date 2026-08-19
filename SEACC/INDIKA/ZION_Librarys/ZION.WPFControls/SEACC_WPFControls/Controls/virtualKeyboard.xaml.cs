using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SEACC_WPFControls
{
    /// <summary>
    /// Interaction logic for virtualKeyboard.xaml
    /// </summary>
    public partial class virtualKeyboard : UserControl
    {
        bool shiftPress = false;

        public virtualKeyboard()
        {
            InitializeComponent();
            changeCaseKeypad();
        }

        public static DependencyProperty SEACC_KeyboardOutProperty = DependencyProperty.Register("KeyboardOut", typeof(string), typeof(virtualKeyboard));
        public string KeyboardOut
        {
            get
            {
                return (string)GetValue(SEACC_KeyboardOutProperty);
            }
            set
            {
                SetValue(SEACC_KeyboardOutProperty, value);
            }
        }

        public void changeCaseKeypad()
        {
            Regex upperCaseRegex = new Regex("[A-Z]");
            Regex lowerCaseRegex = new Regex("[a-z]");
            Button btn;
            foreach (UIElement elem in KeyPad.Children) //iterate the main grid
            {
                Grid grid = elem as Grid;
                if (grid != null)
                {
                    foreach (UIElement uiElement in grid.Children)  //iterate the single rows
                    {
                        btn = uiElement as Button;
                        if (btn != null) // if button contains only 1 character
                        {
                            if (btn.Content.ToString().Length == 1)
                            {
                                if (upperCaseRegex.Match(btn.Content.ToString()).Success) // if the char is a letter and uppercase
                                    btn.Content = btn.Content.ToString().ToLower();
                                else if (lowerCaseRegex.Match(btn.Content.ToString()).Success) // if the char is a letter and lower case
                                    btn.Content = btn.Content.ToString().ToUpper();
                            }
                        }
                    }
                }
            }
        }

        private void SEACC_Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                switch (button.CommandParameter.ToString())
                {
                    case "CAPS":
                        changeCaseKeypad();
                        break;

                    case "SHIFT":
                        if (!shiftPress)
                        {
                            shiftPress = true;
                            changeCaseKeypad();
                        }
                        else
                        {
                            shiftPress = false;
                            changeCaseKeypad();
                        }
                        break;

                    case "EXIT":
                        Window.GetWindow(this).Close();
                        break;

                    case "ALT":
                    case "CTRL":
                        break;

                    case "ENTER":
                        break;

                    case "TAB":
                        KeyboardOut += "    ";
                        break;

                    case "BACK":
                        if (KeyboardOut.Length > 0)
                        {
                            KeyboardOut = KeyboardOut.Remove(KeyboardOut.Length - 1);
                            //int index = KeyboardOut;
                            //focusedTextbox.Text = focusedTextbox.Text.Remove(focusedTextbox.SelectionStart - 1, 1);
                            //focusedTextbox.Select(index - 1, 1);
                            //focusedTextbox.Focus();
                        }
                        break;

                    case "NUM":
                        if (grdSymbolPadFirstRowForNums.Visibility == Visibility.Visible)
                        {
                            grdSymbolPadFirstRowForNums.Visibility = Visibility.Collapsed;
                            grdSymbolPadFirstRowForSymbol.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            grdSymbolPadFirstRowForNums.Visibility = Visibility.Visible;
                            grdSymbolPadFirstRowForSymbol.Visibility = Visibility.Collapsed;
                        }

                        break;

                    case "NUMKEY":

                        if (KeyPad.Visibility == Visibility.Visible)
                        {
                            KeyPad.Visibility = Visibility.Collapsed;
                            SymbalPad.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            KeyPad.Visibility = Visibility.Visible;
                            SymbalPad.Visibility = Visibility.Collapsed;
                        }

                        break;

                    default:
                        KeyboardOut += button.Content.ToString();
                        if (shiftPress)
                        {
                            changeCaseKeypad();
                            shiftPress = false;
                        }
                        break;
                }
            }
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.ActualWidth <= 440)
            {
                columnNUMPad.Width = new System.Windows.GridLength(0);
                this.FontSize = 10;
            }
            else if (this.ActualWidth > 440 && this.ActualWidth <= 640)
            {
                columnNUMPad.Width = new System.Windows.GridLength(1, GridUnitType.Star);
                this.FontSize = 10;
            }
            else if (this.ActualWidth > 640 && this.ActualWidth <= 940)
            {
                columnNUMPad.Width = new System.Windows.GridLength(1, GridUnitType.Star);
                this.FontSize = 14;
            }
            else if (this.ActualWidth > 940 )
            {
                columnNUMPad.Width = new System.Windows.GridLength(1, GridUnitType.Star);
                this.FontSize = 18;
            }
        }
    }
}
