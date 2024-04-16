using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1;

namespace WpfApp1
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void SubtractTime_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // получение введенных значений из TextBox
                byte hours1 = byte.Parse(hoursTextBox1.Text);
                byte minutes1 = byte.Parse(minutesTextBox1.Text);
                byte hours2 = byte.Parse(hoursTextBox2.Text);
                byte minutes2 = byte.Parse(minutesTextBox2.Text);

                // создание объектов Time с введенными значениями
                Time time1 = new Time(hours1, minutes1);
                Time time2 = new Time(hours2, minutes2);

                // вычитание времени и вывод результата
                Time resultTime = time1.SubTime(time2);
                resultSubtractTimeTextBlock.Text = $"Результат: {resultTime}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void IncrementTime1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // получение введенных значений из TextBox
                byte hours = byte.Parse(hoursTextBox1.Text);
                byte minutes = byte.Parse(minutesTextBox1.Text);

                // создание объекта Time с введенными значениями
                Time currentTime = new Time(hours, minutes);

                // использование оператора ++
                currentTime++;

                // обновление hours и minutes из объекта currentTime
                hours = currentTime.Hours;
                minutes = currentTime.Minutes;

                // установка значений в текстовые поля
                hoursTextBox1.Text = hours.ToString();
                minutesTextBox1.Text = minutes.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DowngradeTime1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // получение введенных значений из TextBox
                byte hours = byte.Parse(hoursTextBox1.Text);
                byte minutes = byte.Parse(minutesTextBox1.Text);

                // создание объекта Time с введенными значениями
                Time currentTime = new Time(hours, minutes);

                // использование оператора --
                currentTime--;

                // обновление hours и minutes из объекта currentTime
                hours = currentTime.Hours;
                minutes = currentTime.Minutes;

                // установка значений в текстовые поля
                hoursTextBox1.Text = hours.ToString();
                minutesTextBox1.Text = minutes.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OverloadInt1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // получение введенных значений из TextBox
                byte hours = byte.Parse(hoursTextBox1.Text);
                byte minutes = byte.Parse(minutesTextBox1.Text);

                // создание объекта Time с введенными значениями
                Time currentTime = new Time(hours, minutes);

                // использование оператора int
                int intMinutes = currentTime;
                resultOverloadInt1TextBlock.Text = $"Результат: {intMinutes}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OverloadBool1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // получение введенных значений из TextBox
                byte hours = byte.Parse(hoursTextBox1.Text);
                byte minutes = byte.Parse(minutesTextBox1.Text);

                // создание объекта Time с введенными значениями
                Time currentTime = new Time(hours, minutes);

                // использование оператора bool
                bool boolTime = (bool)currentTime;
                resultOverloadBool1TextBlock.Text = $"Результат: {boolTime}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OverloadLess_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // получение введенных значений из TextBox
                byte hours1 = byte.Parse(hoursTextBox1.Text);
                byte minutes1 = byte.Parse(minutesTextBox1.Text);
                byte hours2 = byte.Parse(hoursTextBox2.Text);
                byte minutes2 = byte.Parse(minutesTextBox2.Text);

                // создание объектов Time с введенными значениями
                Time time1 = new Time(hours1, minutes1);
                Time time2 = new Time(hours2, minutes2);

                resultOverloadLessTextBlock.Text = $"{time1} < {time2}: {time1 < time2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OverloadMore_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // получение введенных значений из TextBox
                byte hours1 = byte.Parse(hoursTextBox1.Text);
                byte minutes1 = byte.Parse(minutesTextBox1.Text);
                byte hours2 = byte.Parse(hoursTextBox2.Text);
                byte minutes2 = byte.Parse(minutesTextBox2.Text);

                // создание объектов Time с введенными значениями
                Time time1 = new Time(hours1, minutes1);
                Time time2 = new Time(hours2, minutes2);

                resultOverloadMoreTextBlock.Text = $"{time1} > {time2}: {time1 > time2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}