using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ProjectManagementSystem
{
    public partial class ProjectPage : Page
    {
        private List<Project> _projects = new List<Project>();
        private Project _selected;

        public ProjectPage()
        {
            InitializeComponent();
            LoadProjects();
        }

        private void LoadProjects()
        {
            ProjectsListBox.ItemsSource = null;
            ProjectsListBox.ItemsSource = _projects;
        }

        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(NameInput.Text) || string.IsNullOrWhiteSpace(DescriptionInput.Text))
                    throw new Exception("All fields are required.");

                Project p = new Project
                {
                    ProjectId = _projects.Count + 1,
                    Name = NameInput.Text.Trim(),
                    Description = DescriptionInput.Text.Trim()
                };

                _projects.Add(p);
                LoadProjects();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void UpdateProject_Click(object sender, RoutedEventArgs e)
        {
            if (_selected == null)
            {
                MessageBox.Show("Please select a project to update.");
                return;
            }

            try
            {
                if (string.IsNullOrWhiteSpace(NameInput.Text) || string.IsNullOrWhiteSpace(DescriptionInput.Text))
                    throw new Exception("All fields are required.");

                _selected.Name = NameInput.Text.Trim();
                _selected.Description = DescriptionInput.Text.Trim();
                LoadProjects();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteProject_Click(object sender, RoutedEventArgs e)
        {
            if (_selected != null)
            {
                _projects.Remove(_selected);
                LoadProjects();
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Please select a project to delete.");
            }
        }

        private void ProjectsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selected = (Project)ProjectsListBox.SelectedItem;
            if (_selected != null)
            {
                NameInput.Text = _selected.Name;
                DescriptionInput.Text = _selected.Description;
            }
        }

        private void ClearInputs()
        {
            NameInput.Text = "";
            DescriptionInput.Text = "";
            _selected = null;
        }
    }

    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Description}";
        }
    }
}
