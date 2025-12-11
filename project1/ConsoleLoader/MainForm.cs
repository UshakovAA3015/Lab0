using System;
using System.ComponentModel;
using System.Windows.Forms;
using Model;
using System.IO;
using System.Xml.Serialization;
using Model.Figures;
using System.Linq;
using System.Text;

namespace Lab4
{
    /// <summary>
    /// Класс главная форма
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Инициализация формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            DataFigureView.AllowUserToAddRows = false;
            DataFigureView.RowHeadersVisible = false;
            DropFilterButton.Enabled = false;
            DataFigureView.MultiSelect = false;
            DataFigureView.KeyDown += DataFigureView_KeyDown;
        }

        /// <summary>
        /// Cписок фигур
        /// </summary>
        private BindingList<FigureBase> _figureList =
            new BindingList<FigureBase>();

        /// <summary>
        /// Лист фильтрованных фигур
        /// </summary>
        private readonly BindingList<FigureBase> _listForSearch =
            new BindingList<FigureBase>();


        /// <summary>
        /// Для файлов
        /// </summary>
        private readonly XmlSerializer _serializer =
            new XmlSerializer(typeof(BindingList<FigureBase>));

        /// <summary>
        /// Событие при загрузке формы
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            CreateTable(_figureList, DataFigureView);
        }

        /// <summary>
        /// Событие при добавлении фигуры
        /// </summary>
        private void AddFigureButton_Click(object sender, EventArgs e)
        {
            var figureForm = new AddFigureForm();

            if (figureForm.ShowDialog() == DialogResult.OK)
            {
                var newFigure = figureForm.FigureData;
                _figureList.Add(newFigure);
            }
        }

        /// <summary>
        /// Метод проверки на пустоту списка
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private bool EnsureFigureListNotEmpty(string message = null)
        {
            if (_figureList.Count == 0)
            {
                MessageBox.Show(
                    message ?? "Список фигур пуст.",
                    "Информация",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return false;
            }
            return true;
        }

        /// <summary>
        /// Создание быстрой клавиши для удаления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataFigureView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                DeleteFigureButton_Click(sender, e);
            }
        }

        /// <summary>
        /// Проверяет, находится ли сейчас DataGridView в режиме фильтрации
        /// </summary>
        /// <returns>True если показывается фильтрованный список</returns>
        private bool IsFilteredView()
        {
            return DataFigureView.DataSource == _listForSearch;
        }

        /// <summary>
        /// Формирует сообщение для удаления одной фигуры
        /// </summary>
        /// <param name="figure">Фигура для удаления</param>
        /// <param name="fromFilteredList">Удаляется из фильтрованного списка</param>
        /// <returns>Сформированное сообщение</returns>
        private string BuildDeleteSingleFigureMessage(FigureBase figure, bool fromFilteredList)
        {
            var messageBuilder = new StringBuilder();

            messageBuilder.Append($"Вы уверены, что хотите удалить фигуру ");
            messageBuilder.Append($"'{figure.GetType().Name}' ");
            messageBuilder.Append($"(Объём: {figure.Volume:F3})");

            if (fromFilteredList)
            {
                messageBuilder.Append(" из фильтрованного списка");
            }

            messageBuilder.Append("?");

            return messageBuilder.ToString();
        }

        /// <summary>
        /// Формирует сообщение для удаления всех фигур
        /// </summary>
        /// <param name="count">Количество фигур для удаления</param>
        /// <param name="fromFilteredList">Удаляются из фильтрованного списка</param>
        /// <returns>Сформированное сообщение</returns>
        private string BuildDeleteAllFiguresMessage(int count, bool fromFilteredList)
        {
            var messageBuilder = new StringBuilder();

            messageBuilder.Append($"Вы уверены, что хотите удалить все фигуры ");
            messageBuilder.Append($"({count} шт.)");

            if (fromFilteredList)
            {
                messageBuilder.Append(" из фильтрованного списка");
            }

            messageBuilder.Append("?");

            return messageBuilder.ToString();
        }

        /// <summary>
        /// Показывает сообщение с подтверждением удаления
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        /// <returns>Результат диалога</returns>
        private DialogResult ShowDeleteConfirmation(string message)
        {
            return MessageBox.Show(
                message,
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Удаляет одну выбранную фигуру
        /// </summary>
        /// <param name="selectedIndex">Индекс выбранной фигуры</param>
        /// <param name="isFilteredView">Флаг фильтрованного списка</param>
        /// <returns>True если удаление выполнено</returns>
        private bool DeleteSingleFigure(int selectedIndex, bool isFilteredView)
        {
            if (isFilteredView)
            {
                if (_listForSearch.Count == 0)
                {
                    MessageBox.Show("Фильтрованный список пуст.",
                        "Информация", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return false;
                }

                if (selectedIndex < 0 || selectedIndex >= _listForSearch.Count)
                {
                    MessageBox.Show("Некорректный выбор фигуры.",
                        "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }

                var selectedFigure = _listForSearch[selectedIndex];
                var message = BuildDeleteSingleFigureMessage(selectedFigure, true);
                var result = ShowDeleteConfirmation(message);

                if (result == DialogResult.Yes)
                {
                    _listForSearch.RemoveAt(selectedIndex);
                    _figureList.Remove(selectedFigure);

                    if (_listForSearch.Count == 0)
                    {
                        DropFilterButton_Click(this, EventArgs.Empty);
                    }
                    else
                    {
                        CreateTable(_listForSearch, DataFigureView);
                    }
                    return true;
                }
            }
            else
            {
                if (!EnsureFigureListNotEmpty()) return false;

                if (selectedIndex < 0 || selectedIndex >= _figureList.Count)
                {
                    MessageBox.Show("Некорректный выбор фигуры.",
                        "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }

                var selectedFigure = _figureList[selectedIndex];
                var message = BuildDeleteSingleFigureMessage(selectedFigure, false);
                var result = ShowDeleteConfirmation(message);

                if (result == DialogResult.Yes)
                {
                    _figureList.RemoveAt(selectedIndex);

                    if (_listForSearch.Contains(selectedFigure))
                    {
                        _listForSearch.Remove(selectedFigure);
                    }

                    if (_figureList.Count == 0)
                    {
                        _listForSearch.Clear();
                        CreateTable(_figureList, DataFigureView);
                    }
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Удаляет все фигуры из текущего списка
        /// </summary>
        /// <param name="isFilteredView">Флаг фильтрованного списка</param>
        /// <returns>Количество удаленных фигур, -1 если удаление отменено</returns>
        private int DeleteAllFigures(bool isFilteredView)
        {
            if (isFilteredView)
            {
                if (_listForSearch.Count == 0)
                {
                    MessageBox.Show("Фильтрованный список пуст.",
                        "Информация", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return 0;
                }

                var count = _listForSearch.Count;
                var message = BuildDeleteAllFiguresMessage(count, true);
                var result = ShowDeleteConfirmation(message);

                if (result == DialogResult.Yes)
                {
                    var deletedCount = 0;

                    foreach (var figure in _listForSearch.ToList())
                    {
                        if (_figureList.Remove(figure))
                        {
                            deletedCount++;
                        }
                    }

                    _listForSearch.Clear();

                    if (_figureList.Count == 0)
                    {
                        CreateTable(_figureList, DataFigureView);
                        DropFilterButton_Click(this, EventArgs.Empty);
                    }
                    else
                    {
                        CreateTable(_listForSearch, DataFigureView);
                    }

                    return deletedCount;
                }
            }
            else
            {
                if (!EnsureFigureListNotEmpty()) return 0;

                var count = _figureList.Count;
                var message = BuildDeleteAllFiguresMessage(count, false);
                var result = ShowDeleteConfirmation(message);

                if (result == DialogResult.Yes)
                {
                    var deletedCount = _figureList.Count;

                    _figureList.Clear();
                    _listForSearch.Clear();

                    DataFigureView.DataSource = null;
                    CreateTable(_figureList, DataFigureView);

                    return deletedCount;
                }
            }

            return -1; 
        }

        /// <summary>
        /// Обработчик нажатия кнопки Удалить выбранную фигуру
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteFigureButton_Click(object sender, EventArgs e)
        {
            if (DataFigureView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите фигуру для удаления.",
                    "Информация", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            int selectedIndex = DataFigureView.SelectedRows[0].Index;
            bool isFilteredView = IsFilteredView();

            DeleteSingleFigure(selectedIndex, isFilteredView);
        }

        /// <summary>
        /// Событие при загрузке файла
        /// </summary>
        private void LoadToolStripMenuItemClick(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Файлы (*.di)|*.di|Все файлы (*.*)|*.*",
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            var path = openFileDialog.FileName.ToString();
            try
            {
                using (FileStream fileStream = new FileStream(path,
                    FileMode.OpenOrCreate))
                {
                    _figureList = (BindingList<FigureBase>)_serializer.
                        Deserialize(fileStream);
                }
                DataFigureView.DataSource = _figureList;
                DataFigureView.CurrentCell = null;
                MessageBox.Show("Файл успешно загружен.",
                    "Загрузка завершена",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Файл повреждён или не соответствует " +
                    $"формату.\n\nОшибка:\n{ex.Message}" +
                    $"\n\nСтек вызовов:\n{ex.StackTrace}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }

        /// <summary>
        /// Событие при сохранении файла
        /// </summary>
        private void SaveToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (!EnsureFigureListNotEmpty("Отсутствуют данные для сохранения.")) return;

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Файлы (*.di)|*.di|Все файлы (*.*)|*.*",
                AddExtension = true,
                DefaultExt = ".di"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var path = saveFileDialog.FileName.ToString();
                using (FileStream fileStream = new FileStream(path,
                    FileMode.OpenOrCreate))
                {
                    _serializer.Serialize(fileStream, _figureList);
                }
                MessageBox.Show("Файл успешно сохранён.",
                    "Сохранение завершено",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Событие при генерации случайной фигуры
        /// </summary>
        private void RandomFigureButton_Click(object sender, EventArgs e)
        {
            var newFigure = RandomFigure.GetRandomFigure();
            _figureList.Add(newFigure);
        }

        /// <summary>
        /// Событие при поиске фигуры
        /// </summary>
        private void SearchFigureButton_Click(object sender, EventArgs e)
        {
            var figureSearch = new SearchFigureForm(_figureList);
            figureSearch.SendDataFromFormEvent += AddSearchFigureEvent;
            SearchFigureButton.Enabled = false;
            figureSearch.FormClosed += (s, args) =>
            {

                SearchFigureButton.Enabled = true;
            };
            figureSearch.Show();
        }

        /// <summary>
        /// Обработчик события получения данных из формы поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddSearchFigureEvent(object sender, FigureEventArgs e)
        {
            if (e.SendingFigure == null)
            {
                _listForSearch.Clear();
                return;
            }
            if (!_listForSearch.Contains(e.SendingFigure))
            {
                _listForSearch.Add(e.SendingFigure);
            }
            CreateTable(_listForSearch, DataFigureView);
            DropFilterButton.Enabled = true;
            SearchFigureButton.Enabled = false;
            AddFigureButton.Enabled = false;
            RandomFigureButton.Enabled = false;
        }

        /// <summary>
        /// Обработчик события при сбросе фильтрации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DropFilterButton_Click(object sender, EventArgs e)
        {
            DataFigureView.DataSource = null;
            CreateTable(_figureList, DataFigureView);
            DeleteFigureButton.Enabled = true;
            SearchFigureButton.Enabled = true;
            AddFigureButton.Enabled = true;
            RandomFigureButton.Enabled = true;
            DropFilterButton.Enabled = false;
            _listForSearch.Clear();
        }

        /// <summary>
        /// Обработчик нажатия кнопки Удалить все фигуры
        /// </summary>
        private void DeleteAllFugureButton_Click(object sender, EventArgs e)
        {
            bool isFilteredView = IsFilteredView();
            int deletedCount = DeleteAllFigures(isFilteredView);

            if (deletedCount > 0)
            {
                var message = isFilteredView ?
                    $"Удалено {deletedCount} фигур из фильтрованного списка." :
                    $"Удалено {deletedCount} фигур. Список фигур успешно очищен.";

                MessageBox.Show(message,
                    "Успех", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Метод создания таблицы желаемого формата
        /// </summary>
        /// <param name="figures">Список фигур</param>
        /// <param name="dataGridView">Таблица с фигурами</param>
        private static void CreateTable(BindingList<FigureBase> figures,
DataGridView dataGridView)
        {
            dataGridView.DataSource = null;
            dataGridView.DataSource = figures;

            if (dataGridView.Columns.Count > 1 && dataGridView.Columns[1] != null)
            {
                dataGridView.Columns[0].HeaderText = "Фигура";
                dataGridView.Columns[1].HeaderText = "Объём (м)";
                dataGridView.Columns[1].DefaultCellStyle.Format = "F3";
                dataGridView.Columns[1].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;
            }

            dataGridView.AutoSizeColumnsMode =
               DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dataGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
        }
    }
}