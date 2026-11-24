using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TaskManger
{
    public partial class MainWindow : Window
    {
        List<Tasks> activeTasks = new List<Tasks>
        {

        };
        List<Tasks> finishedTasks = new List<Tasks>
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
        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(newTaskTextBox.Text) == false)
            {
                //ActiveBorder.BorderBrush = Brushes.White;
                newTaskBoder.BorderBrush = Brushes.White;
                Tasks newTask = new Tasks();
                newTask.Name = newTaskTextBox.Text;
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
                priorityComboBox.SelectedItem = null;
            }
            else
            {
                //activeBorder.BorderBrush=Brushes.Red;
                newTaskBoder.BorderBrush = Brushes.Red;
            }
        }
        private void TaskCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox clickedCheckBox && clickedCheckBox.DataContext is Tasks selectedTask)
            {
                if (activeTasks.Remove(selectedTask))
                {
                    finishedTasks.Add(selectedTask);

                    taskListPanel.ItemsSource = null;
                    taskListPanel.ItemsSource = activeTasks;
                }

            }
        }

        private void FinishedTasksClicked(object sender, RoutedEventArgs e)
        {
            taskListPanel.ItemsSource = null;
            taskListPanel.ItemsSource = finishedTasks;
        }

        private void ActiveTasksClicked(object sender, RoutedEventArgs e)
        {
            taskListPanel.ItemsSource = null;
            taskListPanel.ItemsSource = activeTasks;
        }
    }
}