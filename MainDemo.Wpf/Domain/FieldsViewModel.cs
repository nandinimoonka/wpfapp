using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;

namespace MaterialDesignDemo.Domain
{
    private string? _name;
    private string? _name2;
    private string? _password1 = string.Empty;
    private string? _password2 = "pre-filled";
    private string? _password1Validated = "pre-filled";
    private string? _password2Validated = "pre-filled";
    private string? _text1;
    private string? _text2;

    public string? Name
    {
        private string? _name;
        private string? _name2;
        private string? _password1 = string.Empty;
        private string? _password2 = "pre-filled";
        private string? _password1Validated = "pre-filled";
        private string? _password2Validated = "pre-filled";
        private string? _text1;
        private string? _text2;
        private string _autoSuggestionTextBox1 = string.Empty;
        private string _autoSuggestionTextBox2 = string.Empty;
        private ObservableCollection<string> _listSuggestion = new ObservableCollection<string>();
        private ObservableCollection<string> _baseListSuggestion = new ObservableCollection<string>();
        private ObservableCollection<KeyValuePair<string, Brush>> _listColors = new ObservableCollection<KeyValuePair<string, Brush>>();

    public string? Name2
    {
        get => _name2;
        set => SetProperty(ref _name2, value);
    }

    public string? Text1
    {
        get => _text1;
        set => SetProperty(ref _text1, value);
    }

    public string? Text2
    {
        get => _text2;
        set => SetProperty(ref _text2, value);
    }

    public string? Password1
    {
        get => _password1;
        set => SetProperty(ref _password1, value);
    }

    public string? Password2
    {
        get => _password2;
        set => SetProperty(ref _password2, value);
    }

    public string? Password1Validated
    {
        get => _password1Validated;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Password cannot be empty");
            SetProperty(ref _password1Validated, value);
        }
    }

    public string? Password2Validated
    {
        get => _password2Validated;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Password cannot be empty");
            SetProperty(ref _password2Validated, value);
        }
    }

    public FieldsTestObject TestObject => new() { Name = "Mr. Test" };


        public string AutoSuggestionTextBox1
        {
            get { return _autoSuggestionTextBox1; }
            set { SetProperty(ref _autoSuggestionTextBox1, value); }
        }


        public string AutoSuggestionTextBox2
        {
            get { return _autoSuggestionTextBox2; }
            set { SetProperty(ref _autoSuggestionTextBox2, value); }
        }



        public ObservableCollection<string> ListSuggestion
        {
            get { return _listSuggestion; }
            set { SetProperty(ref _listSuggestion, value); }
        }



        public ObservableCollection<string> BaseListSuggestion
        {
            get { return _baseListSuggestion; }
            set { SetProperty(ref _baseListSuggestion, value); }
        }


        public ObservableCollection<KeyValuePair<string, Brush>> ListColors
        {
            get { return _listColors; }
            set { SetProperty(ref _listColors, value); }
        }

        public FieldsTestObject TestObject => new() { Name = "Mr. Test" };

        public ICommand AutoSuggestionTextBox1ChangedCommand { get; }
        public ICommand AutoSuggestionTextBox2ChangedCommand { get; }
        public ICommand SetPassword1FromViewModelCommand { get; }
        public ICommand SetPassword2FromViewModelCommand { get; }

        public FieldsViewModel()
        {
            SetPassword1FromViewModelCommand = new AnotherCommandImplementation(_ => Password1 = "Set from ViewModel!");
            SetPassword2FromViewModelCommand = new AnotherCommandImplementation(_ => Password2 = "Set from ViewModel!");
            BaseListSuggestion = new ObservableCollection<string>()
            {
                "Burger", "Fries", "Shake", "Lettuce"
            };
            ListColors = new ObservableCollection<KeyValuePair<string, Brush>>(GetColors());
            ListSuggestion = BaseListSuggestion;
            AutoSuggestionTextBox1ChangedCommand = new AnotherCommandImplementation(_ =>
            {
                ListSuggestion = new ObservableCollection<string>(BaseListSuggestion.Where(s => s.ToLower().Contains(AutoSuggestionTextBox1.ToLower())));
            });
            AutoSuggestionTextBox2ChangedCommand = new AnotherCommandImplementation(_ =>
            {
                ListColors = new ObservableCollection<KeyValuePair<string, Brush>>(GetColors().Where(s => s.Key.StartsWith(AutoSuggestionTextBox2)));
            });
        }

        private IEnumerable<KeyValuePair<string, Brush>> GetColors()
        {
            return typeof(Colors)
                .GetProperties()
                .Where(prop =>
                    typeof(Color).IsAssignableFrom(prop.PropertyType))
                .Select(prop =>
                    new KeyValuePair<string, Brush>(prop.Name, GenerateColorBrush(prop.GetValue(null))));
        }

        private SolidColorBrush GenerateColorBrush(object? prop)
        {
            if (prop is Color color)
                return new SolidColorBrush(color);
            return new SolidColorBrush(Colors.White);
        }
    }
}

public class FieldsTestObject : ViewModelBase
{
    private string? _name;
    private string? _content;

    public string? Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public string? Content
    {
        get => _content;
        set => SetProperty(ref _content, value);
    }
}
