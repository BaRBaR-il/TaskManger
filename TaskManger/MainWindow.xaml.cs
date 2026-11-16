using System;
using System.Windows;
using System.Windows.Controls;

namespace TaskManger
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowCalander(object sender, TextChangedEventArgs e)
        {
            if (newTaskTextBox.Text.ToString().Length > 0)
                taskCalander.Visibility = Visibility.Visible;
            else
                taskCalander.Visibility = Visibility.Collapsed;
        }

        // פונקציית ההוספה בלחיצה על הלחצן
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(newTaskTextBox.Text))
                return;

            string taskText = newTaskTextBox.Text;

            // בדיקת דחיפות מתוך ה-ComboBox
            if (priorityComboBox.SelectedItem is ComboBoxItem selectedPriority)
            {
                taskText += $" (דחיפות: {selectedPriority.Content})";
            }

            // בדיקת תאריך מתוך לוח השנה
            if (taskCalander.SelectedDate.HasValue)
            {
                string dateStr = taskCalander.SelectedDate.Value.ToString("dd/MM/yyyy");
                taskText += $" - תאריך יעד: {dateStr}";
            }

            // יצירת משימה חדשה ברשימה
            CheckBox newCheckBox = new CheckBox
            {
                Content = taskText
            };

            taskListPanel.Children.Add(newCheckBox);

            // איפוס התיבה ולוח השנה
            newTaskTextBox.Clear();
            taskCalander.SelectedDate = null;
        }
    }
}