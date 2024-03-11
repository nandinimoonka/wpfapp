﻿using System.Globalization;
using System.Windows.Data;

namespace MaterialDesignThemes.Wpf.Converters;

public class TextFieldPrefixTextVisibilityConverter : IMultiValueConverter
{
    public Visibility HiddenState { get; set; } = Visibility.Hidden;
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        string prefixText = (string)values[1];
        if (string.IsNullOrEmpty(prefixText))
        {
            return Visibility.Collapsed;
        }
        if (values.Length >= 2 && values[2] is PrefixSuffixVisibility.Always)
        {
            return Visibility.Visible;
        }

        bool isHintInFloatingPosition = (bool)values[0];
        return isHintInFloatingPosition ? Visibility.Visible : HiddenState;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotImplementedException();
}
