using Corporate_Training_Management;
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
    public partial class InstructorWindow : Window
    {
        private AppDbContext _context;

        public InstructorWindow()
        {
            InitializeComponent();
            _context = new AppDbContext();
            LoadInstructors();
        }

        private void LoadInstructors()
        {
            InstructorsGrid.ItemsSource = _context.Instructors.ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var name = NameBox.Text.Trim();
            var expertise = ExpertiseBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(expertise))
            {
                MessageBox.Show("Please enter both name and expertise.");
                return;
            }

            var instructor = new Instructor { Name = name, Expertise = expertise };
            _context.Instructors.Add(instructor);
            _context.SaveChanges();
            LoadInstructors();

            NameBox.Clear();
            ExpertiseBox.Clear();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (InstructorsGrid.SelectedItem is Instructor selected)
            {
                var name = NameBox.Text.Trim();
                var expertise = ExpertiseBox.Text.Trim();

                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(expertise))
                {
                    MessageBox.Show("Please enter both name and expertise.");
                    return;
                }

                selected.Name = name;
                selected.Expertise = expertise;

                _context.SaveChanges();
                LoadInstructors();

                NameBox.Clear();
                ExpertiseBox.Clear();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (InstructorsGrid.SelectedItem is Instructor selected)
            {
                _context.Instructors.Remove(selected);
                _context.SaveChanges();
                LoadInstructors();

                NameBox.Clear();
                ExpertiseBox.Clear();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var mainWin = new MainWindow();
            mainWin.Show();
            this.Close();
        }
    }
}

