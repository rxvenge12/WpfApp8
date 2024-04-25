using System.Text; // Импортируем пространство имен System.Text для использования класса StringBuilder
using System.Windows; // Импортируем пространство имен System.Windows для работы с элементами пользовательского интерфейса

namespace WpfApp8
{
    // Абстрактный класс для смартфона
    abstract class Smartphone
    {
        public abstract string Info { get; } // Абстрактное свойство для получения информации о смартфоне
    }

    // Конкретные классы смартфонов
    class AppleSmartphone : Smartphone // Класс для представления смартфона от Apple
    {
        public override string Info => "Apple Smartphone: iOS, Retina Display"; // Реализация свойства Info для смартфона от Apple
    }

    class SamsungSmartphone : Smartphone // Класс для представления смартфона от Samsung
    {
        public override string Info => "Samsung Smartphone: Android, AMOLED Display"; // Реализация свойства Info для смартфона от Samsung
    }

    // Абстрактный класс фабрики смартфонов
    abstract class SmartphoneFactory
    {
        public abstract Smartphone CreateSmartphone(); // Абстрактный метод для создания смартфона
    }

    // Конкретные фабрики смартфонов
    class AppleSmartphoneFactory : SmartphoneFactory // Фабрика для создания смартфонов от Apple
    {
        public override Smartphone CreateSmartphone() // Реализация метода создания смартфона
        {
            return new AppleSmartphone(); // Возвращает экземпляр смартфона от Apple
        }
    }

    class SamsungSmartphoneFactory : SmartphoneFactory // Фабрика для создания смартфонов от Samsung
    {
        public override Smartphone CreateSmartphone() // Реализация метода создания смартфона
        {
            return new SamsungSmartphone(); // Возвращает экземпляр смартфона от Samsung
        }
    }

    public partial class MainWindow : Window // Основной класс окна приложения
    {
        public MainWindow()
        {
            InitializeComponent(); // Инициализация компонентов окна
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e) // Обработчик события нажатия кнопки создания смартфона
        {
            // Проверяем выбранный производитель
            SmartphoneFactory factory = null; // Создаем переменную для хранения фабрики смартфонов
            if (appleRadioButton.IsChecked == true) // Если выбран Apple
                factory = new AppleSmartphoneFactory(); // Создаем фабрику смартфонов от Apple
            else if (samsungRadioButton.IsChecked == true) // Если выбран Samsung
                factory = new SamsungSmartphoneFactory(); // Создаем фабрику смартфонов от Samsung

            // Создаем смартфон с выбранными характеристиками
            if (factory != null) // Если фабрика смартфонов была успешно создана
            {
                Smartphone smartphone = factory.CreateSmartphone(); // Создаем смартфон с помощью фабрики
                textBoxInfo.Text = $"Создается смартфон: {smartphone.Info}"; // Выводим информацию о создаваемом смартфоне
            }
        }

        private void ManufacturerRadioButton_Checked(object sender, RoutedEventArgs e) // Обработчик события изменения выбранного производителя
        {
            textBoxInfo.Clear(); // Очищаем поле информации при изменении выбранного производителя
        }
    }
}
