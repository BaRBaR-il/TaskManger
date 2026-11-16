using System;
using System.Windows;
using System.Windows.Controls;

namespace TaskManger
{
    public partial class MainWindow : Window
    {
        List<Tasks> activeTasks = new List<Tasks>
        {

        };
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
            if (string.IsNullOrEmpty(newTaskTextBox.Text) == false)
            {
                Tasks newTask = new Tasks();
                newTask.Name = newTaskTextBox.Text;

                // בדיקת דחיפות מתוך ה-ComboBox
                {   if(priorityComboBox.SelectedItem==null)
                        newTask.Priorty = "גבוהה"; //ברירת מחדל
                    else if (priorityComboBox.SelectedItem is ComboBoxItem selectedPriority)
                    {
                        newTask.Priorty = selectedPriority.Content.ToString();
                    }
                }

                // בדיקת תאריך מתוך לוח השנה
                if (taskCalander.SelectedDate.HasValue)
                {
                    newTask.Date = taskCalander.SelectedDate.Value;
                }
                else
                {
                    newTask.Date = DateTime.Now; // ברירת מחדל אם לא נבחר תאריך אז תאריך של היום
                }

                // יצירת משימה חדשה ברשימה
                CheckBox newCheckBox = new CheckBox
                {
                    Content = newTask
                };
                activeTasks.Add(newTask);
                taskListPanel.ItemsSource = null;
                taskListPanel.ItemsSource = activeTasks;

                //   איפוס התיבה ולוח השנה והמשימה
                newTaskTextBox.Clear();
                taskCalander.SelectedDate = null;
            }
        }
    }
}