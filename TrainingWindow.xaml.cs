using Corporate_Training_Management.Data;
using Corporate_Training_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Corporate_Training_Management
{
    public partial class TrainingWindow : Window
    {
        private AppDbContext _context;

        public TrainingWindow()
        {
            InitializeComponent();
            _context = new AppDbContext();
            LoadInstructors();
            LoadTrainings();
        }

        private void LoadInstructors()
        {
            InstructorDropdown.ItemsSource = _context.Instructors.ToList();
        }

        private void LoadTrainings()
        {
            var trainings = _context.Trainings
                .Select(t => new
                {
                    t.Id,
                    t.Name,
                    t.StartDate,
                    t.EndDate,
                    t.Location,
                    Instructor = t.Instructor.Name
                }).ToList();

            TrainingGrid.ItemsSource = trainings;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameBox.Text) ||
                string.IsNullOrWhiteSpace(LocationBox.Text) ||
                StartDatePicker.SelectedDate == null ||
                EndDatePicker.SelectedDate == null ||
                InstructorDropdown.SelectedValue == null)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (EndDatePicker.SelectedDate < StartDatePicker.SelectedDate)
            {
                MessageBox.Show("End date cannot be earlier than start date.");
                return;
            }

            var training = new Training
            {
                Name = NameBox.Text.Trim(),
                Location = LocationBox.Text.Trim(),
                StartDate = StartDatePicker.SelectedDate.Value,
                EndDate = EndDatePicker.SelectedDate.Value,
                InstructorId = (int)InstructorDropdown.SelectedValue
            };

            _context.Trainings.Add(training);
            _context.SaveChanges();
            LoadTrainings();
            ClearInputs();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (TrainingGrid.SelectedItem == null) return;

            dynamic selectedRow = TrainingGrid.SelectedItem;
            int trainingId = selectedRow.Id;

            var training = _context.Trainings.Find(trainingId);
            if (training == null) return;

            if (string.IsNullOrWhiteSpace(NameBox.Text) ||
                string.IsNullOrWhiteSpace(LocationBox.Text) ||
                StartDatePicker.SelectedDate == null ||
                EndDatePicker.SelectedDate == null ||
                InstructorDropdown.SelectedValue == null)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (EndDatePicker.SelectedDate < StartDatePicker.SelectedDate)
            {
                MessageBox.Show("End date cannot be earlier than start date.");
                return;
            }

            training.Name = NameBox.Text.Trim();
            training.Location = LocationBox.Text.Trim();
            training.StartDate = StartDatePicker.SelectedDate.Value;
            training.EndDate = EndDatePicker.SelectedDate.Value;
            training.InstructorId = (int)InstructorDropdown.SelectedValue;

            _context.SaveChanges();
            LoadTrainings();
            ClearInputs();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (TrainingGrid.SelectedItem == null) return;

            dynamic selectedRow = TrainingGrid.SelectedItem;
            int trainingId = selectedRow.Id;

            var training = _context.Trainings.Find(trainingId);
            if (training == null) return;

            _context.Trainings.Remove(training);
            _context.SaveChanges();
            LoadTrainings();
            ClearInputs();
        }

        private void ClearInputs()
        {
            NameBox.Clear();
            LocationBox.Clear();
            StartDatePicker.SelectedDate = null;
            EndDatePicker.SelectedDate = null;
            InstructorDropdown.SelectedIndex = -1;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
           
                var mainWin = new MainWindow();
                mainWin.Show();
                this.Close();
            

        }
    }
}

