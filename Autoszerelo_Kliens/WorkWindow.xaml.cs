using Autoszerelo_Kliens.DataProviders;
using Autoszerelo_Kliens.Models;
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

namespace Autoszerelo_Kliens
{
    /// <summary>
    /// Interaction logic for WorkWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window
    {

        private readonly Work _work;

        public WorkWindow(Work work)
        {
            InitializeComponent();

            //Ha már létező work-öt akarunk update-elni vagy delete-elni, akkor át kell adni az infókat, hogy a felnyíló ablakba már be legyenek írva.
            if (work != null)
            {
                _work = work;

                FirstNameTextBox.Text = _work.FirstName;
                LastNameTextBox.Text = _work.LastName;
                TypeofcarTextBox.Text = _work.TypeOfCar;
                LicencePlateTextBox.Text = _work.CarLicencePlate;
                IssuesTextBox.Text = _work.Issues;
                StateOfWorkCombobox.Text = _work.StateOfWork;

                //CreateButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                _work = new Work();

                UpdateButton.Visibility = Visibility.Collapsed;
                //DeleteButton.Visibility = Visibility.Collapsed;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

            _work.StateOfWork = StateOfWorkCombobox.Text;

            WorkDataProvider.UpdateWork(_work);

            DialogResult = true;
            Close();
        }
    }
}
