using System.Collections;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace MaterialDesignThemes.Wpf;

/// <summary>
/// Helper properties for working with text fields.
/// </summary>
public static class TextFieldAssist
{
    /// <summary>
    /// The text box view margin property
    /// </summary>
    public static class TextFieldAssist
    {
        private const string AutoSuggestionListBoxName = "AutoSuggestionListBox";
        private const string AutoSuggestionPart = "PART_AutoSuggestion";

        /// <summary>
        /// The text box view margin property
        /// </summary>
        public static readonly DependencyProperty TextBoxViewMarginProperty = DependencyProperty.RegisterAttached(
            "TextBoxViewMargin",
            typeof(Thickness),
            typeof(TextFieldAssist),
            new FrameworkPropertyMetadata(new Thickness(double.NegativeInfinity), FrameworkPropertyMetadataOptions.Inherits, TextBoxViewMarginPropertyChangedCallback));

    /// <summary>
    /// Sets the text box view margin.
    /// </summary>
    /// <param name="element">The element.</param>
    /// <param name="value">The value.</param>
    public static void SetTextBoxViewMargin(DependencyObject element, Thickness value) => element.SetValue(TextBoxViewMarginProperty, value);

    /// <summary>
    /// Gets the text box view margin.
    /// </summary>
    /// <param name="element">The element.</param>
    /// <returns>
    /// The <see cref="Thickness" />.
    /// </returns>
    public static Thickness GetTextBoxViewMargin(DependencyObject element) => (Thickness)element.GetValue(TextBoxViewMarginProperty);

    /// <summary>
    /// Controls the visibility of the underline decoration.
    /// </summary>
    public static readonly DependencyProperty DecorationVisibilityProperty = DependencyProperty.RegisterAttached(
        "DecorationVisibility", typeof(Visibility), typeof(TextFieldAssist), new PropertyMetadata(default(Visibility)));

    /// <summary>
    /// Controls the visibility of the underline decoration.
    /// </summary>
    public static void SetDecorationVisibility(DependencyObject element, Visibility value) => element.SetValue(DecorationVisibilityProperty, value);

    /// <summary>
    /// Controls the visibility of the underline decoration.
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    public static Visibility GetDecorationVisibility(DependencyObject element) => (Visibility)element.GetValue(DecorationVisibilityProperty);

    /// <summary>
    /// The attached WPF property for getting or setting the <see cref="Brush"/> value for an underline decoration.
    /// </summary>
    public static readonly DependencyProperty UnderlineBrushProperty = DependencyProperty.RegisterAttached(
        "UnderlineBrush", typeof(Brush), typeof(TextFieldAssist), new PropertyMetadata(Brushes.Transparent));

    /// <summary>
    /// Sets the <see cref="Brush"/> used for underline decoration.
    /// </summary>
    /// <param name="element"></param>
    /// <param name="value"></param>
    public static void SetUnderlineBrush(DependencyObject element, Brush value) => element.SetValue(UnderlineBrushProperty, value);

    /// <summary>
    /// Gets the <see cref="Brush"/> used for underline decoration.
    /// </summary>
    /// <param name="element"></param>
    public static Brush GetUnderlineBrush(DependencyObject element) => (Brush)element.GetValue(UnderlineBrushProperty);

    /// <summary>
    /// Controls the visibility of the text field box.
    /// </summary>
    public static readonly DependencyProperty HasFilledTextFieldProperty = DependencyProperty.RegisterAttached(
        "HasFilledTextField", typeof(bool), typeof(TextFieldAssist), new PropertyMetadata(false));

    public static void SetHasFilledTextField(DependencyObject element, bool value) => element.SetValue(HasFilledTextFieldProperty, value);

    public static bool GetHasFilledTextField(DependencyObject element) => (bool)element.GetValue(HasFilledTextFieldProperty);

    /// <summary>
    /// Controls the visibility of the text field area box.
    /// </summary>
    public static readonly DependencyProperty HasOutlinedTextFieldProperty = DependencyProperty.RegisterAttached(
        "HasOutlinedTextField", typeof(bool), typeof(TextFieldAssist), new PropertyMetadata(false));

    public static void SetHasOutlinedTextField(DependencyObject element, bool value) => element.SetValue(HasOutlinedTextFieldProperty, value);

    public static bool GetHasOutlinedTextField(DependencyObject element) => (bool)element.GetValue(HasOutlinedTextFieldProperty);

    /// <summary>
    /// Controls the corner radius of the surrounding box.
    /// </summary>
    public static readonly DependencyProperty TextFieldCornerRadiusProperty = DependencyProperty.RegisterAttached(
        "TextFieldCornerRadius", typeof(CornerRadius), typeof(TextFieldAssist), new PropertyMetadata(new CornerRadius(0.0)));

    public static void SetTextFieldCornerRadius(DependencyObject element, CornerRadius value) => element.SetValue(TextFieldCornerRadiusProperty, value);

    public static CornerRadius GetTextFieldCornerRadius(DependencyObject element) => (CornerRadius)element.GetValue(TextFieldCornerRadiusProperty);

    /// <summary>
    /// Controls the corner radius of the bottom line of the surrounding box.
    /// </summary>
    public static readonly DependencyProperty UnderlineCornerRadiusProperty = DependencyProperty.RegisterAttached(
        "UnderlineCornerRadius", typeof(CornerRadius), typeof(TextFieldAssist), new PropertyMetadata(new CornerRadius(0.0)));

    public static void SetUnderlineCornerRadius(DependencyObject element, CornerRadius value) => element.SetValue(UnderlineCornerRadiusProperty, value);

    public static CornerRadius GetUnderlineCornerRadius(DependencyObject element) => (CornerRadius)element.GetValue(UnderlineCornerRadiusProperty);

    /// <summary>
    /// Controls the highlighting style of a text box.
    /// </summary>
    public static readonly DependencyProperty NewSpecHighlightingEnabledProperty = DependencyProperty.RegisterAttached(
        "NewSpecHighlightingEnabled", typeof(bool), typeof(TextFieldAssist), new PropertyMetadata(false));

    public static void SetNewSpecHighlightingEnabled(DependencyObject element, bool value) => element.SetValue(NewSpecHighlightingEnabledProperty, value);

    public static bool GetNewSpecHighlightingEnabled(DependencyObject element) => (bool)element.GetValue(NewSpecHighlightingEnabledProperty);

    /// <summary>
    /// Enables a ripple effect on focusing the text box.
    /// </summary>
    public static readonly DependencyProperty RippleOnFocusEnabledProperty = DependencyProperty.RegisterAttached(
        "RippleOnFocusEnabled", typeof(bool), typeof(TextFieldAssist), new PropertyMetadata(false));

    public static void SetRippleOnFocusEnabled(DependencyObject element, bool value) => element.SetValue(RippleOnFocusEnabledProperty, value);

    public static bool GetRippleOnFocusEnabled(DependencyObject element) => (bool)element.GetValue(RippleOnFocusEnabledProperty);

    /// <summary>
    /// Automatically inserts spelling suggestions into the text box context menu.
    /// </summary>
    public static readonly DependencyProperty IncludeSpellingSuggestionsProperty = DependencyProperty.RegisterAttached(
        "IncludeSpellingSuggestions", typeof(bool), typeof(TextFieldAssist), new PropertyMetadata(default(bool), IncludeSpellingSuggestionsChanged));

    public static void SetIncludeSpellingSuggestions(TextBoxBase element, bool value) => element.SetValue(IncludeSpellingSuggestionsProperty, value);

    public static bool GetIncludeSpellingSuggestions(TextBoxBase element) => (bool)element.GetValue(IncludeSpellingSuggestionsProperty);

    /// <summary>
    /// SuffixText dependency property
    /// </summary>
    public static readonly DependencyProperty SuffixTextProperty = DependencyProperty.RegisterAttached(
        "SuffixText", typeof(string), typeof(TextFieldAssist), new PropertyMetadata(default(string?)));

    public static void SetSuffixText(DependencyObject element, string? value)
        => element.SetValue(SuffixTextProperty, value);

    public static string? GetSuffixText(DependencyObject element)
        => (string?)element.GetValue(SuffixTextProperty);

    /// <summary>
    /// PrefixText dependency property
    /// </summary>
    public static readonly DependencyProperty PrefixTextProperty = DependencyProperty.RegisterAttached(
        "PrefixText", typeof(string), typeof(TextFieldAssist), new PropertyMetadata(default(string?)));

    public static void SetPrefixText(DependencyObject element, string? value)
        => element.SetValue(PrefixTextProperty, value);

    public static string? GetPrefixText(DependencyObject element)
        => (string?)element.GetValue(PrefixTextProperty);

    /// <summary>
    /// Controls the visibility of the clear button.
    /// </summary>
    public static readonly DependencyProperty HasClearButtonProperty = DependencyProperty.RegisterAttached(
        "HasClearButton", typeof(bool), typeof(TextFieldAssist), new PropertyMetadata(false));

    public static void SetHasClearButton(DependencyObject element, bool value)
        => element.SetValue(HasClearButtonProperty, value);

    public static bool GetHasClearButton(DependencyObject element)
        => (bool)element.GetValue(HasClearButtonProperty);

    /// <summary>
    /// Controls visibility of the leading icon
    /// </summary>
    public static readonly DependencyProperty HasLeadingIconProperty = DependencyProperty.RegisterAttached(
        "HasLeadingIcon", typeof(bool), typeof(TextFieldAssist), new PropertyMetadata(default(bool)));

    public static void SetHasLeadingIcon(DependencyObject element, bool value)
        => element.SetValue(HasLeadingIconProperty, value);

    public static bool GetHasLeadingIcon(DependencyObject element)
        => (bool)element.GetValue(HasLeadingIconProperty);

    /// <summary>
    /// Controls the leading icon
    /// </summary>
    public static readonly DependencyProperty LeadingIconProperty = DependencyProperty.RegisterAttached(
        "LeadingIcon", typeof(PackIconKind), typeof(TextFieldAssist), new PropertyMetadata());

    public static void SetLeadingIcon(DependencyObject element, PackIconKind value)
        => element.SetValue(LeadingIconProperty, value);

    public static PackIconKind GetLeadingIcon(DependencyObject element)
        => (PackIconKind)element.GetValue(LeadingIconProperty);

    /// <summary>
    /// Controls the size of the leading icon
    /// </summary>
    public static readonly DependencyProperty LeadingIconSizeProperty = DependencyProperty.RegisterAttached(
        "LeadingIconSize", typeof(double), typeof(TextFieldAssist), new PropertyMetadata(20.0));

    public static void SetLeadingIconSize(DependencyObject element, double value)
        => element.SetValue(LeadingIconSizeProperty, value);

    public static double GetLeadingIconSize(DependencyObject element)
        => (double)element.GetValue(LeadingIconSizeProperty);

    /// <summary>
    /// Controls visibility of the trailing icon
    /// </summary>
    public static readonly DependencyProperty HasTrailingIconProperty = DependencyProperty.RegisterAttached(
        "HasTrailingIcon", typeof(bool), typeof(TextFieldAssist), new PropertyMetadata(default(bool)));

    public static void SetHasTrailingIcon(DependencyObject element, bool value)
        => element.SetValue(HasTrailingIconProperty, value);

    public static bool GetHasTrailingIcon(DependencyObject element)
        => (bool)element.GetValue(HasTrailingIconProperty);

    /// <summary>
    /// Controls the trailing icon
    /// </summary>
    public static readonly DependencyProperty TrailingIconProperty = DependencyProperty.RegisterAttached(
        "TrailingIcon", typeof(PackIconKind), typeof(TextFieldAssist), new PropertyMetadata());

    public static void SetTrailingIcon(DependencyObject element, PackIconKind value)
        => element.SetValue(TrailingIconProperty, value);

    public static PackIconKind GetTrailingIcon(DependencyObject element)
        => (PackIconKind)element.GetValue(TrailingIconProperty);

    /// <summary>
    /// Controls the size of the trailing icon
    /// </summary>
    public static readonly DependencyProperty TrailingIconSizeProperty = DependencyProperty.RegisterAttached(
        "TrailingIconSize", typeof(double), typeof(TextFieldAssist), new PropertyMetadata(20.0));

    public static void SetTrailingIconSize(DependencyObject element, double value)
        => element.SetValue(TrailingIconSizeProperty, value);

    public static double GetTrailingIconSize(DependencyObject element)
        => (double)element.GetValue(TrailingIconSizeProperty);

    public static Style GetCharacterCounterStyle(DependencyObject obj) => (Style)obj.GetValue(CharacterCounterStyleProperty);

    public static void SetCharacterCounterStyle(DependencyObject obj, Style value) => obj.SetValue(CharacterCounterStyleProperty, value);

    public static readonly DependencyProperty CharacterCounterStyleProperty =
        DependencyProperty.RegisterAttached("CharacterCounterStyle", typeof(Style), typeof(TextFieldAssist), new PropertyMetadata(null));

    public static Visibility GetCharacterCounterVisibility(DependencyObject obj)
        => (Visibility)obj.GetValue(CharacterCounterVisibilityProperty);

    public static void SetCharacterCounterVisibility(DependencyObject obj, Visibility value)
        => obj.SetValue(CharacterCounterVisibilityProperty, value);

    public static readonly DependencyProperty CharacterCounterVisibilityProperty =
        DependencyProperty.RegisterAttached("CharacterCounterVisibility", typeof(Visibility), typeof(TextFieldAssist),
            new PropertyMetadata(Visibility.Collapsed, CharacterCounterVisibilityChanged));

    private static void CharacterCounterVisibilityChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
    {
        if (element is PasswordBox passwordBox)
        {
            passwordBox.PasswordChanged -= PasswordBoxOnPasswordChanged;
            if (Equals(Visibility.Visible, e.NewValue))
            {
                SetPasswordBoxCharacterCount(passwordBox, passwordBox.SecurePassword.Length);
                passwordBox.PasswordChanged += PasswordBoxOnPasswordChanged;
            }
        }
    }

    private static void PasswordBoxOnPasswordChanged(object sender, RoutedEventArgs e)
    {
        PasswordBox passwordBox = (PasswordBox)sender;
        SetPasswordBoxCharacterCount(passwordBox, passwordBox.SecurePassword.Length);
    }

        internal static readonly DependencyProperty PasswordBoxCharacterCountProperty = DependencyProperty.RegisterAttached(
            "PasswordBoxCharacterCount", typeof(int), typeof(TextFieldAssist), new PropertyMetadata(default(int)));
        internal static void SetPasswordBoxCharacterCount(DependencyObject element, int value) => element.SetValue(PasswordBoxCharacterCountProperty, value);
        internal static int GetPasswordBoxCharacterCount(DependencyObject element) => (int)element.GetValue(PasswordBoxCharacterCountProperty);

        /// <summary>
        /// List AutoSuggestion
        /// </summary>
        public static readonly DependencyProperty AutoSuggestionItemsSourceProperty = DependencyProperty.RegisterAttached(
            "AutoSuggestionItemsSource", typeof(object), typeof(TextFieldAssist), new PropertyMetadata(null, AutoSuggestionItemsSourceChanged));

        public static void SetAutoSuggestionItemsSource(DependencyObject element, object value)
            => element.SetValue(AutoSuggestionItemsSourceProperty, value);

        public static object GetAutoSuggestionItemsSource(DependencyObject element)
            => element.GetValue(AutoSuggestionItemsSourceProperty);

        /// <summary>
        /// Controls the AutoSuggestion for a TextBox
        /// </summary>
        public static readonly DependencyProperty AutoSuggestionEnabledProperty = DependencyProperty.RegisterAttached(
            "AutoSuggestionEnabled", typeof(bool), typeof(TextFieldAssist), new PropertyMetadata(default(bool), AutoSuggestionEnabledChanged));

        public static void SetAutoSuggestionEnabled(DependencyObject element, bool value)
            => element.SetValue(AutoSuggestionEnabledProperty, value);

        public static bool GetAutoSuggestionEnabled(DependencyObject element)
            => (bool)element.GetValue(AutoSuggestionEnabledProperty);

        /// <summary>
        /// Controls the AutoSuggestion item template
        /// </summary>
        public static readonly DependencyProperty AutoSuggestionItemTemplateProperty = DependencyProperty.RegisterAttached(
            "AutoSuggestionItemTemplate", typeof(DataTemplate), typeof(TextFieldAssist), new PropertyMetadata(null));

        public static void SetAutoSuggestionItemTemplate(DependencyObject element, DataTemplate value)
            => element.SetValue(AutoSuggestionItemTemplateProperty, value);

        public static DataTemplate GetAutoSuggestionItemTemplate(DependencyObject element)
            => (DataTemplate)element.GetValue(AutoSuggestionItemTemplateProperty);


        /// <summary>
        /// Controls the AutoSuggestion Item template selector
        /// </summary>
        public static readonly DependencyProperty AutoSuggestionItemTemplateSelectorProperty = DependencyProperty.RegisterAttached(
            "AutoSuggestionItemTemplateSelector", typeof(DataTemplate), typeof(TextFieldAssist), new PropertyMetadata(null));

        public static void SetAutoSuggestionItemTemplateSelector(DependencyObject element, DataTemplate value)
            => element.SetValue(AutoSuggestionItemTemplateSelectorProperty, value);

        public static DataTemplate GetAutoSuggestionItemTemplateSelector(DependencyObject element)
            => (DataTemplate)element.GetValue(AutoSuggestionItemTemplateSelectorProperty);

        /// <summary>
        /// Controls the AutoSuggestion value member
        /// </summary>
        public static readonly DependencyProperty AutoSuggestionValueMemberProperty = DependencyProperty.RegisterAttached(
            "AutoSuggestionValueMember", typeof(string), typeof(TextFieldAssist), new PropertyMetadata(default(string)));

        public static void SetAutoSuggestionValueMember(DependencyObject element, string value)
            => element.SetValue(AutoSuggestionValueMemberProperty, value);

        public static string GetAutoSuggestionValueMember(DependencyObject element)
            => (string)element.GetValue(AutoSuggestionValueMemberProperty);

        /// <summary>
        /// Controls the AutoSuggestion display member
        /// </summary>
        public static readonly DependencyProperty AutoSuggestionDisplayMemberProperty = DependencyProperty.RegisterAttached(
            "AutoSuggestionDisplayMember", typeof(string), typeof(TextFieldAssist), new PropertyMetadata(default(string)));

        public static void SetAutoSuggestionDisplayMember(DependencyObject element, string value)
            => element.SetValue(AutoSuggestionDisplayMemberProperty, value);

        public static string GetAutoSuggestionDisplayMember(DependencyObject element)
            => (string)element.GetValue(AutoSuggestionDisplayMemberProperty);

        #region Methods

    private static void IncludeSpellingSuggestionsChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
    {
        if (element is TextBoxBase textBox)
        {
            if ((bool)e.NewValue)
            {
                textBox.ContextMenuOpening += TextBoxOnContextMenuOpening;
                textBox.ContextMenuClosing += TextBoxOnContextMenuClosing;
            }
            else
            {
                textBox.ContextMenuOpening -= TextBoxOnContextMenuOpening;
                textBox.ContextMenuClosing -= TextBoxOnContextMenuClosing;
            }
        }
    }

    private static void TextBoxOnContextMenuOpening(object sender, ContextMenuEventArgs e)
    {
        var textBoxBase = sender as TextBoxBase;

        ContextMenu? contextMenu = textBoxBase?.ContextMenu;
        if (contextMenu is null) return;

        RemoveSpellingSuggestions(contextMenu);

        if (!SpellCheck.GetIsEnabled(textBoxBase)) return;

        SpellingError? spellingError = GetSpellingError(textBoxBase);
        if (spellingError != null)
        {
            Style? spellingSuggestionStyle =
                contextMenu.TryFindResource(Spelling.SuggestionMenuItemStyleKey) as Style;

            int insertionIndex = 0;
            bool hasSuggestion = false;
            foreach (string suggestion in spellingError.Suggestions)
            {
                hasSuggestion = true;
                var menuItem = new MenuItem
                {
                    CommandTarget = textBoxBase,
                    Command = EditingCommands.CorrectSpellingError,
                    CommandParameter = suggestion,
                    Style = spellingSuggestionStyle,
                    Tag = typeof(Spelling)
                };
                contextMenu.Items.Insert(insertionIndex++, menuItem);
            }
            if (!hasSuggestion)
            {
                contextMenu.Items.Insert(insertionIndex++, new MenuItem
                {
                    Style = contextMenu.TryFindResource(Spelling.NoSuggestionsMenuItemStyleKey) as Style,
                    Tag = typeof(Spelling)
                });
            }

            contextMenu.Items.Insert(insertionIndex++, new Separator
            {
                Style = contextMenu.TryFindResource(Spelling.SeparatorStyleKey) as Style,
                Tag = typeof(Spelling)
            });

            contextMenu.Items.Insert(insertionIndex++, new MenuItem
            {
                Command = EditingCommands.IgnoreSpellingError,
                CommandTarget = textBoxBase,
                Style = contextMenu.TryFindResource(Spelling.IgnoreAllMenuItemStyleKey) as Style,
                Tag = typeof(Spelling)
            });

            contextMenu.Items.Insert(insertionIndex, new Separator
            {
                Style = contextMenu.TryFindResource(Spelling.SeparatorStyleKey) as Style,
                Tag = typeof(Spelling)
            });
        }
    }

    private static SpellingError? GetSpellingError(TextBoxBase? textBoxBase)
    {
        if (textBoxBase is TextBox textBox)
        {
            return textBox.GetSpellingError(textBox.CaretIndex);
        }

        if (textBoxBase is RichTextBox richTextBox)
        {
            return richTextBox.GetSpellingError(richTextBox.CaretPosition);
        }
        return null;
    }

    private static void TextBoxOnContextMenuClosing(object sender, ContextMenuEventArgs e)
    {
        var contextMenu = (sender as TextBoxBase)?.ContextMenu;
        if (contextMenu != null)
        {
            RemoveSpellingSuggestions(contextMenu);
        }
    }

    private static void RemoveSpellingSuggestions(ContextMenu menu)
    {
        foreach (FrameworkElement item in
            (from item in menu.Items.OfType<FrameworkElement>()
             where ReferenceEquals(item.Tag, typeof(Spelling))
             select item).ToList())
        {
            menu.Items.Remove(item);
        }
    }

    /// <summary>
    /// Applies the text box view margin.
    /// </summary>
    /// <param name="textBox">The text box.</param>
    /// <param name="margin">The margin.</param>
    private static void ApplyTextBoxViewMargin(Control textBox, Thickness margin)
    {
        if (margin.Equals(new Thickness(double.NegativeInfinity))
            || textBox.Template is null)
        {
            return;
        }

        if (textBox is ComboBox
            && textBox.Template.FindName("PART_EditableTextBox", textBox) is TextBox editableTextBox)
        {
            textBox = editableTextBox;
            if (textBox.Template is null) return;
            textBox.ApplyTemplate();
        }

        if (textBox.Template.FindName("PART_ContentHost", textBox) is ScrollViewer scrollViewer
            && scrollViewer.Content is FrameworkElement frameworkElement)
        {
            frameworkElement.Margin = margin;
        }
    }

    /// <summary>
    /// The text box view margin property changed callback.
    /// </summary>
    /// <param name="dependencyObject">The dependency object.</param>
    /// <param name="dependencyPropertyChangedEventArgs">The dependency property changed event args.</param>
    private static void TextBoxViewMarginPropertyChangedCallback(
        DependencyObject dependencyObject,
        DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
    {
        if (dependencyObject is not Control box)
        {
            return;
        }
        /// <summary>
        /// The AutoSuggestion enabled property changed callback.
        /// </summary>
        /// <param name="element">The dependency object.</param>
        /// <param name="e">The dependency property changed event args.</param>
        private static void AutoSuggestionEnabledChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            if (element is TextBox textBox)
            {
                if ((bool)e.NewValue)
                {
                    textBox.LostFocus += AutoSuggestionTextBox_LostFocus;
                    textBox.PreviewKeyDown += AutoSuggestionTextBox_KeyDown;
                    textBox.Loaded += AutoSuggestionTextBox_Loaded;
                }
                else
                {
                    textBox.LostFocus -= AutoSuggestionTextBox_LostFocus;
                    textBox.PreviewKeyDown -= AutoSuggestionTextBox_KeyDown;
                    textBox.Loaded -= AutoSuggestionTextBox_Loaded;
                    if (textBox.Template != null && textBox.Template.FindName(AutoSuggestionListBoxName, textBox) is ListBox listBox)
                    {
                        listBox.PreviewMouseDown -= AutoSuggestionListBox_PreviewMouseDown;
                    }
                }
            }
        }

        /// <summary>
        /// The AutoSuggestion ItemsSource property changed callback.
        /// </summary>
        /// <param name="element">The dependency object.</param>
        /// <param name="e">The dependency property changed event args.</param>
        private static void AutoSuggestionItemsSourceChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            if (element is TextBox textBox && GetAutoSuggestionEnabled(textBox) && textBox.Template.FindName(AutoSuggestionPart, textBox) is Popup popup && e.NewValue is ICollection items)
            {
                if ((textBox.Text.Length == 0 || items.Count == 0) && popup.IsOpen)
                    popup.IsOpen = false;
                else if (textBox.Text.Length > 0 && !popup.IsOpen && textBox.IsFocused && items.Count > 0)
                    popup.IsOpen = true;

            }
        }

        private static void AutoSuggestionTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Template.FindName(AutoSuggestionListBoxName, textBox) is ListBox listBox)
            {
                listBox.PreviewMouseDown += AutoSuggestionListBox_PreviewMouseDown;
            }
        }

        private static void AutoSuggestionListBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListBox listBox && listBox.TemplatedParent is TextBox textBox && e.OriginalSource is FrameworkElement element)
            {
                if (!listBox.Items.Contains(element.DataContext))
                    return;
                listBox.SelectedItem = element.DataContext;
                CommitValueSelection(textBox);
            }
        }

        private static void AutoSuggestionTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                switch (e.Key)
                {
                    case Key.Down:
                        IncrementSelection(textBox);
                        break;
                    case Key.Up:
                        DecrementSelection(textBox);
                        break;
                    case Key.Enter:
                        CommitValueSelection(textBox);
                        break;
                    case Key.Escape:
                        CloseAutoSuggestionPopUp(textBox);
                        break;
                    case Key.Tab:
                        CommitValueSelection(textBox);
                        break;
                    default:
                        return;
                }
            }
            e.Handled = true;
        }

        private static void AutoSuggestionTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                CloseAutoSuggestionPopUp(textBox);
            }
        }

        /// <summary>
        /// Close AutoSuggestion Popup
        /// </summary>
        /// <param name="textBox">TextBox used</param>
        private static void CloseAutoSuggestionPopUp(TextBox textBox)
        {
            if (textBox.Template.FindName(AutoSuggestionPart, textBox) is Popup popup && popup.IsOpen)
                popup.IsOpen = false;
        }

        /// <summary>
        /// Commit the selected value
        /// </summary>
        /// <param name="textBox"></param>
        private static void CommitValueSelection(TextBox textBox)
        {
            if (textBox.Template.FindName(AutoSuggestionListBoxName, textBox) is ListBox listBox && listBox.SelectedValue != null)
            {
                textBox.Text = listBox.SelectedValue.ToString();
                if (textBox.Text != null)
                    textBox.CaretIndex = textBox.Text.Length;
                CloseAutoSuggestionPopUp(textBox);
            }
        }

        /// <summary>
        /// The Keyup navigation for the ListBox.
        /// </summary>
        /// <param name="textBox">The current TextBox.</param>
        private static void DecrementSelection(TextBox textBox)
        {
            if (textBox.Template.FindName(AutoSuggestionListBoxName, textBox) is ListBox listBox)
            {
                if (listBox.SelectedIndex == 0 || listBox.SelectedIndex == -1)
                    listBox.SelectedIndex = listBox.Items.Count - 1;
                else
                    listBox.SelectedIndex -= 1;
                listBox.ScrollIntoView(listBox.SelectedItem);
            }
        }
        /// <summary>
        /// The Keydown navigation for the ListBox
        /// </summary>
        /// <param name="textBox">The current TextBox.</param>
        private static void IncrementSelection(TextBox textBox)
        {
            if (textBox.Template.FindName(AutoSuggestionListBoxName, textBox) is ListBox listBox)
            {
                if (listBox.SelectedIndex == listBox.Items.Count - 1)
                    listBox.SelectedIndex = 0;
                else
                    listBox.SelectedIndex += 1;
                listBox.ScrollIntoView(listBox.SelectedItem);
            }
        }
        #endregion
    }

    #endregion
}
