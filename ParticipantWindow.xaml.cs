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
    public partial class ParticipantWindow : Window
    {
        private AppDbContext _context;

        public ParticipantWindow()
        {
            InitializeComponent();
            _context = new AppDbContext();
            LoadParticipants();
        }

        private void LoadParticipants()
        {
            ParticipantsGrid.ItemsSource = _context.Participants.ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var name = NameBox.Text.Trim();
            var job = JobBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(job))
            {
                MessageBox.Show("Please fill out both name and job title.");
                return;
            }

            var participant = new Participant { Name = name, JobTitle = job };
            _context.Participants.Add(participant);
            _context.SaveChanges();
            LoadParticipants();

            NameBox.Clear();
            JobBox.Clear();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (ParticipantsGrid.SelectedItem is Participant selected)
            {
                var name = NameBox.Text.Trim();
                var job = JobBox.Text.Trim();

                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(job))
                {
                    MessageBox.Show("Please fill out both name and job title.");
                    return;
                }

                selected.Name = name;
                selected.JobTitle = job;

                _context.SaveChanges();
                LoadParticipants();

                NameBox.Clear();
                JobBox.Clear();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ParticipantsGrid.SelectedItem is Participant selected)
            {
                _context.Participants.Remove(selected);
                _context.SaveChanges();
                LoadParticipants();

                NameBox.Clear();
                JobBox.Clear();
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



