using System.Collections.Specialized;
using System.Windows.Media;

namespace MaterialDesignThemes.Wpf;

public static class DataGridAssist
{
    private static readonly Thickness DefaultCellPaddingThickness = new Thickness(16, 8, 16, 8);
    private static readonly Thickness DefaultColumnHeaderPadding = new Thickness(16, 10, 16, 10);
    private static readonly CornerRadius DefaultCornerRadius = new CornerRadius(4);

    #region AttachedProperty : AutoGeneratedCheckboxStyleProperty
    public static readonly DependencyProperty AutoGeneratedCheckBoxStyleProperty
        = DependencyProperty.RegisterAttached("AutoGeneratedCheckBoxStyle", typeof(Style), typeof(DataGridAssist),
            new PropertyMetadata(default(Style), AutoGeneratedCheckBoxStylePropertyChangedCallback));

    public static Style GetAutoGeneratedCheckBoxStyle(DataGrid element)
        => (Style)element.GetValue(AutoGeneratedCheckBoxStyleProperty);
    public static void SetAutoGeneratedCheckBoxStyle(DataGrid element, Style value)
        => element.SetValue(AutoGeneratedCheckBoxStyleProperty, value);

    private static void AutoGeneratedCheckBoxStylePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var dataGrid = (DataGrid)d;

        dataGrid.AutoGeneratingColumn -= SetGeneratedCheckboxColumnStyle;
        dataGrid.AutoGeneratingColumn += SetGeneratedCheckboxColumnStyle;
    }

    private static void SetGeneratedCheckboxColumnStyle(object? sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.Column is DataGridCheckBoxColumn column &&
            sender is DataGrid dataGrid)
        {
            column.ElementStyle = GetAutoGeneratedCheckBoxStyle(dataGrid);
        }
    }
    #endregion

    #region AttachedProperty : AutoGeneratedEditingCheckBoxStyleProperty
    public static readonly DependencyProperty AutoGeneratedEditingCheckBoxStyleProperty
        = DependencyProperty.RegisterAttached("AutoGeneratedEditingCheckBoxStyle", typeof(Style), typeof(DataGridAssist),
            new PropertyMetadata(default(Style), AutoGeneratedEditingCheckBoxStylePropertyChangedCallback));

    public static Style GetAutoGeneratedEditingCheckBoxStyle(DataGrid element)
        => (Style)element.GetValue(AutoGeneratedEditingCheckBoxStyleProperty);
    public static void SetAutoGeneratedEditingCheckBoxStyle(DataGrid element, Style value)
        => element.SetValue(AutoGeneratedEditingCheckBoxStyleProperty, value);

    private static void AutoGeneratedEditingCheckBoxStylePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var dataGrid = (DataGrid)d;

        dataGrid.AutoGeneratingColumn -= SetGeneratedCheckBoxEditingStyle;
        dataGrid.AutoGeneratingColumn += SetGeneratedCheckBoxEditingStyle;
    }

    private static void SetGeneratedCheckBoxEditingStyle(object? sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.Column is DataGridCheckBoxColumn column &&
            sender is DataGrid dataGrid)
        {
            column.EditingElementStyle = GetAutoGeneratedEditingCheckBoxStyle(dataGrid);
        }
    }
    #endregion

    #region AttachedProperty : AutoGeneratedTextStyleProperty
    public static readonly DependencyProperty AutoGeneratedTextStyleProperty
        = DependencyProperty.RegisterAttached("AutoGeneratedTextStyle", typeof(Style), typeof(DataGridAssist),
            new PropertyMetadata(default(Style), AutoGeneratedTextStylePropertyChangedCallback));

    public static Style GetAutoGeneratedTextStyle(DataGrid element)
        => (Style)element.GetValue(AutoGeneratedTextStyleProperty);
    public static void SetAutoGeneratedTextStyle(DataGrid element, Style value)
        => element.SetValue(AutoGeneratedTextStyleProperty, value);

    private static void AutoGeneratedTextStylePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var dataGrid = (DataGrid)d;

        dataGrid.AutoGeneratingColumn -= SetGeneratedTextColumnStyle;
        dataGrid.AutoGeneratingColumn += SetGeneratedTextColumnStyle;
    }

    private static void SetGeneratedTextColumnStyle(object? sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.Column is System.Windows.Controls.DataGridTextColumn column &&
            sender is DataGrid dataGrid)
        {
            column.ElementStyle = GetAutoGeneratedTextStyle(dataGrid);
        }
    }
    #endregion

    #region AttachedProperty : AutoGeneratedEditingTextStyleProperty
    public static readonly DependencyProperty AutoGeneratedEditingTextStyleProperty
        = DependencyProperty.RegisterAttached("AutoGeneratedEditingTextStyle", typeof(Style), typeof(DataGridAssist),
            new PropertyMetadata(default(Style), AutoGeneratedEditingTextStylePropertyChangedCallback));

    public static Style GetAutoGeneratedEditingTextStyle(DataGrid element)
        => (Style)element.GetValue(AutoGeneratedEditingTextStyleProperty);
    public static void SetAutoGeneratedEditingTextStyle(DataGrid element, Style value)
        => element.SetValue(AutoGeneratedEditingTextStyleProperty, value);

    private static void AutoGeneratedEditingTextStylePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var dataGrid = (DataGrid)d;

        dataGrid.AutoGeneratingColumn -= SetGeneratedTextColumnEditingStyle;
        dataGrid.AutoGeneratingColumn += SetGeneratedTextColumnEditingStyle;
    }

    private static void SetGeneratedTextColumnEditingStyle(object? sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.Column is System.Windows.Controls.DataGridTextColumn column &&
            sender is DataGrid dataGrid)
        {
            column.EditingElementStyle = GetAutoGeneratedEditingTextStyle(dataGrid);
        }
    }
    #endregion

    #region AttachedProperty : AutoGeneratedComboBoxStyleProperty
    public static readonly DependencyProperty AutoGeneratedComboBoxStyleProperty
        = DependencyProperty.RegisterAttached("AutoGeneratedComboBoxStyle", typeof(Style), typeof(DataGridAssist),
            new PropertyMetadata(default(Style), AutoGeneratedComboBoxStylePropertyChangedCallback));

    public static Style GetAutoGeneratedComboBoxStyle(DataGrid element)
        => (Style)element.GetValue(AutoGeneratedComboBoxStyleProperty);
    public static void SetAutoGeneratedComboBoxStyle(DataGrid element, Style value)
        => element.SetValue(AutoGeneratedComboBoxStyleProperty, value);

    private static void AutoGeneratedComboBoxStylePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var dataGrid = (DataGrid)d;

        dataGrid.AutoGeneratingColumn -= SetGeneratedComboBoxColumnStyle;
        dataGrid.AutoGeneratingColumn += SetGeneratedComboBoxColumnStyle;
    }

    private static void SetGeneratedComboBoxColumnStyle(object? sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.Column is System.Windows.Controls.DataGridComboBoxColumn column &&
            sender is DataGrid dataGrid)
        {
            column.ElementStyle = GetAutoGeneratedComboBoxStyle(dataGrid);
        }
    }
    #endregion

    #region AttachedProperty : AutoGeneratedEditingComboBoxStyleProperty
    public static readonly DependencyProperty AutoGeneratedEditingComboBoxStyleProperty
        = DependencyProperty.RegisterAttached("AutoGeneratedEditingComboBoxStyle", typeof(Style), typeof(DataGridAssist),
            new PropertyMetadata(default(Style), AutoGeneratedEditingComboBoxStylePropertyChangedCallback));

    public static Style GetAutoGeneratedEditingComboBoxStyle(DataGrid element)
        => (Style)element.GetValue(AutoGeneratedEditingComboBoxStyleProperty);
    public static void SetAutoGeneratedEditingComboBoxStyle(DataGrid element, Style value)
        => element.SetValue(AutoGeneratedEditingComboBoxStyleProperty, value);

    private static void AutoGeneratedEditingComboBoxStylePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var dataGrid = (DataGrid)d;

        dataGrid.AutoGeneratingColumn -= SetGeneratedComboBoxColumnEditingStyle;
        dataGrid.AutoGeneratingColumn += SetGeneratedComboBoxColumnEditingStyle;
    }

    private static void SetGeneratedComboBoxColumnEditingStyle(object? sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.Column is System.Windows.Controls.DataGridComboBoxColumn column &&
            sender is DataGrid dataGrid)
        {
            column.EditingElementStyle = GetAutoGeneratedEditingComboBoxStyle(dataGrid);
        }
    }
    #endregion

    #region AttachedProperty : ApplyMaterialDesignColumnStylesProperty
    public static readonly DependencyProperty ApplyMaterialDesignColumnStylesProperty
        = DependencyProperty.RegisterAttached("ApplyMaterialDesignColumnStyles", typeof(bool), typeof(DataGridAssist),
            new PropertyMetadata(default(bool), ApplyMaterialDesignColumnStylesPropertyChangedCallback));

    public static void SetApplyMaterialDesignColumnStyles(DataGrid element, bool value)
        => element.SetValue(ApplyMaterialDesignColumnStylesProperty, value);

    public static bool GetApplyMaterialDesignColumnStyles(DataGrid element)
        => (bool) element.GetValue(ApplyMaterialDesignColumnStylesProperty);


    private static readonly DependencyProperty ColumnUpdaterProperty
        = DependencyProperty.RegisterAttached("ColumnUpdater", typeof(ColumnUpdater), typeof(DataGridAssist),
            new PropertyMetadata(default(ColumnUpdater)));
    private static void SetColumnUpdater(DependencyObject element, ColumnUpdater? value) => element.SetValue(ColumnUpdaterProperty, value);
    private static ColumnUpdater? GetColumnUpdater(DependencyObject element) => (ColumnUpdater?) element.GetValue(ColumnUpdaterProperty);

    private static void ApplyMaterialDesignColumnStylesPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var dataGrid = (DataGrid)d;
        ColumnUpdater? columnUpdater = GetColumnUpdater(dataGrid);
        if (columnUpdater is not null)
        {
            columnUpdater = new ColumnUpdater(dataGrid);
        }
        dataGrid.Columns.CollectionChanged -= columnUpdater.Columns_CollectionChanged;
        if (Equals(true, e.NewValue))
        {
            SetColumnUpdater(dataGrid, columnUpdater);
            dataGrid.Columns.CollectionChanged += columnUpdater.Columns_CollectionChanged;    // Auto-generated columns are added later in the chain, thus we subscribe to changes.
            foreach (var column in dataGrid.Columns)
            {
                ColumnUpdater.ApplyMaterialDesignColumnStyleForColumn(dataGrid, column);
            }
        }
        else
        {
            dataGrid.ClearValue(ColumnUpdaterProperty);
        }
    }

    private class ColumnUpdater
    {
        private readonly DataGrid _dataGrid;

        public ColumnUpdater(DataGrid dataGrid) => _dataGrid = dataGrid;

        public void Columns_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            foreach (DataGridColumn column in e.NewItems?.OfType<DataGridColumn>() ?? Enumerable.Empty<DataGridColumn>())
            {
                ApplyMaterialDesignColumnStyleForColumn(_dataGrid, column);
            }
        }

        public static void ApplyMaterialDesignColumnStyleForColumn(DataGrid dataGrid, DataGridColumn column)
        {
            Style defaultElementStyle = (Style)DataGridBoundColumn.ElementStyleProperty.GetMetadata(column.GetType()).DefaultValue;
            Style defaultEditingElementStyle = (Style)DataGridBoundColumn.EditingElementStyleProperty.GetMetadata(column.GetType()).DefaultValue;

            bool applyElementStyle;
            bool applyEditingElementStyle;
            switch (column)
            {
                case DataGridCheckBoxColumn checkBoxColumn:
                    applyElementStyle = Equals(checkBoxColumn.ElementStyle, defaultElementStyle);
                    applyEditingElementStyle = Equals(checkBoxColumn.EditingElementStyle, defaultEditingElementStyle);
                    if (applyElementStyle && GetAutoGeneratedCheckBoxStyle(dataGrid) is { } checkBoxElementStyle)
                    {
                        checkBoxColumn.ElementStyle = checkBoxElementStyle;
                    }

                    if (applyEditingElementStyle && GetAutoGeneratedEditingCheckBoxStyle(dataGrid) is { } checkBoxEditingElementStyle)
                    {
                        checkBoxColumn.EditingElementStyle = checkBoxEditingElementStyle;
                    }
                    break;
                case System.Windows.Controls.DataGridTextColumn textColumn:
                    applyElementStyle = Equals(textColumn.ElementStyle, defaultElementStyle);
                    applyEditingElementStyle = Equals(textColumn.EditingElementStyle, defaultEditingElementStyle);
                    if (applyElementStyle && GetAutoGeneratedTextStyle(dataGrid) is { } textElementStyle)
                    {
                        textColumn.ElementStyle = textElementStyle;
                    }

                    if (applyEditingElementStyle && GetAutoGeneratedEditingTextStyle(dataGrid) is { } textEditingElementStyle)
                    {
                        textColumn.EditingElementStyle = textEditingElementStyle;
                    }
                    break;
                case System.Windows.Controls.DataGridComboBoxColumn comboBoxColumn:
                    applyElementStyle = Equals(comboBoxColumn.ElementStyle, defaultElementStyle);
                    applyEditingElementStyle = Equals(comboBoxColumn.EditingElementStyle, defaultEditingElementStyle);
                    if (applyElementStyle && GetAutoGeneratedComboBoxStyle(dataGrid) is { } comboBoxElementStyle)
                    {
                        comboBoxColumn.ElementStyle = comboBoxElementStyle;
                    }

                    if (applyEditingElementStyle && GetAutoGeneratedEditingComboBoxStyle(dataGrid) is { } comboBoxEditingElementStyle)
                    {
                        comboBoxColumn.EditingElementStyle = comboBoxEditingElementStyle;
                    }
                    break;
            }
        }
    }

    #endregion

    #region AttachedProperty : CellPaddingProperty
    public static readonly DependencyProperty CellPaddingProperty
        = DependencyProperty.RegisterAttached("CellPadding", typeof(Thickness), typeof(DataGridAssist),
            new FrameworkPropertyMetadata(DefaultCellPaddingThickness, FrameworkPropertyMetadataOptions.Inherits));

    public static Thickness GetCellPadding(DataGrid element)
        => (Thickness)element.GetValue(CellPaddingProperty);
    public static void SetCellPadding(DataGrid element, Thickness value)
        => element.SetValue(CellPaddingProperty, value);
    #endregion

    #region AttachedProperty : SelectedCellBorderBrushProperty
    public static readonly DependencyProperty SelectedCellBorderBrushProperty
        = DependencyProperty.RegisterAttached("SelectedCellBorderBrush", typeof(Brush), typeof(DataGridAssist),
            new PropertyMetadata(null));

    public static Brush GetSelectedCellBorderBrush(DataGrid element)
        => (Brush)element.GetValue(SelectedCellBorderBrushProperty);
    public static void SetSelectedCellBorderBrush(DataGrid element, Brush value)
        => element.SetValue(SelectedCellBorderBrushProperty, value);
    #endregion

    #region AttachedProperty : ColumnHeaderPaddingProperty
    public static readonly DependencyProperty ColumnHeaderPaddingProperty
        = DependencyProperty.RegisterAttached("ColumnHeaderPadding", typeof(Thickness), typeof(DataGridAssist),
            new FrameworkPropertyMetadata(DefaultColumnHeaderPadding, FrameworkPropertyMetadataOptions.Inherits));

    public static Thickness GetColumnHeaderPadding(DataGrid element)
        => (Thickness)element.GetValue(ColumnHeaderPaddingProperty);
    public static void SetColumnHeaderPadding(DependencyObject element, Thickness value)
        => element.SetValue(ColumnHeaderPaddingProperty, value);
    #endregion

    #region AttachedProperty : EnableEditBoxAssistProperty
    public static readonly DependencyProperty EnableEditBoxAssistProperty
        = DependencyProperty.RegisterAttached("EnableEditBoxAssist", typeof(bool), typeof(DataGridAssist),
            new PropertyMetadata(default(bool), EnableEditBoxAssistPropertyChangedCallback));

    public static bool GetEnableEditBoxAssist(DataGrid element)
        => (bool)element.GetValue(EnableEditBoxAssistProperty);
    public static void SetEnableEditBoxAssist(DataGrid element, bool value)
        => element.SetValue(EnableEditBoxAssistProperty, value);

    private static void EnableEditBoxAssistPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var dataGrid = (DataGrid)d;
        var enableCheckBoxAssist = (bool)e.NewValue;

        if (enableCheckBoxAssist)
        {
            // Register for bubbling events from cells, even when the cell handles them (thus the 'true' parameter)
            dataGrid.AddHandler(UIElement.MouseLeftButtonDownEvent, (RoutedEventHandler)OnMouseLeftButtonDown, true);
            dataGrid.PreviewKeyDown += EditOnSpacebarPress;
        }
        else
        {
            dataGrid.RemoveHandler(UIElement.MouseLeftButtonDownEvent, (RoutedEventHandler)OnMouseLeftButtonDown);
            dataGrid.PreviewKeyDown -= EditOnSpacebarPress;
        }
    }

    // This relay is only needed because the UIElement.AddHandler() has strict requirements for the signature of the passed Delegate
    private static void OnMouseLeftButtonDown(object sender, RoutedEventArgs e) => AllowDirectEditWithoutFocus(sender, (MouseButtonEventArgs)e);

    #endregion

    #region AttachedProperty : CornerRadiusProperty
    public static readonly DependencyProperty CornerRadiusProperty
        = DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(DataGridAssist),
            new PropertyMetadata(DefaultCornerRadius));

    public static CornerRadius GetCornerRadius(DataGrid element)
        => (CornerRadius)element.GetValue(CornerRadiusProperty);
    public static void SetCornerRadius(DataGrid element, CornerRadius value)
        => element.SetValue(CornerRadiusProperty, value);
    #endregion

    private static void EditOnSpacebarPress(object sender, KeyEventArgs e)
    {
        var dataGrid = (DataGrid)sender;
        if (e.Key == Key.Space && e.OriginalSource is DataGridCell { IsReadOnly: false } cell)
        {
            if (cell.Column is DataGridComboBoxColumn ||
                cell.Column is System.Windows.Controls.DataGridTextColumn)
            {
                dataGrid.BeginEdit();
                e.Handled = true;
            }
        }
    }

    /// <summary>
    /// Allows editing of components inside of a data grid cell with a single left click.
    /// </summary>
    private static void AllowDirectEditWithoutFocus(object sender, MouseButtonEventArgs mouseArgs)
    {
        var originalSource = (DependencyObject)mouseArgs.OriginalSource;
        var dataGridCell = originalSource
            .GetVisualAncestry()
            .OfType<DataGridCell>()
            .FirstOrDefault();

        // Readonly has to be handled as the pass-through ignores the
        // cell and interacts directly with the content
        if (dataGridCell?.IsReadOnly ?? true)
        {
            return;
        }

        if (dataGridCell.Content is UIElement element)
        {
            var dataGrid = (DataGrid)sender;
            // If it is a DataGridTemplateColumn we want the
            // click to be handled naturally by the control
            if (dataGridCell.Column.GetType() == typeof(DataGridTemplateColumn))
            {
                return;
            }
            if (dataGridCell.IsEditing)
            {
                // If the cell is already being edited, we don't want to (re)start editing
                return;
            }
            //NB: Issue 2852 - Don't handle events from nested data grids
            var parentDataGrid = dataGridCell
                .GetVisualAncestry()
                .OfType<DataGrid>()
                .FirstOrDefault();
            if (parentDataGrid != dataGrid)
            {
                return;
            }

            dataGrid.CurrentCell = new DataGridCellInfo(dataGridCell);
            dataGrid.BeginEdit();

            switch (dataGridCell.Content)
            {
                case TextBoxBase textBox:
                    {
                        // Send a 'left-click' routed event to the TextBox to place the I-beam at the position of the mouse cursor
                        var mouseDownEvent = new MouseButtonEventArgs(mouseArgs.MouseDevice, mouseArgs.Timestamp, mouseArgs.ChangedButton)
                        {
                            RoutedEvent = Mouse.MouseDownEvent,
                            Source = mouseArgs.Source
                        };
                        textBox.RaiseEvent(mouseDownEvent);
                        break;
                    }

                case ToggleButton toggleButton:
                    {
                        // Check if the cursor actually hit the checkbox and not just the cell
                        var mousePosition = mouseArgs.GetPosition(element);
                        var elementHitBox = new Rect(element.RenderSize);
                        if (elementHitBox.Contains(mousePosition))
                        {
                            // Send a 'left click' routed command to the toggleButton to toggle the state
                            var newMouseEvent = new MouseButtonEventArgs(mouseArgs.MouseDevice, mouseArgs.Timestamp, mouseArgs.ChangedButton)
                            {
                                RoutedEvent = Mouse.MouseDownEvent,
                                Source = dataGrid
                            };

                            toggleButton.RaiseEvent(newMouseEvent);
                        }
                        break;
                    }

                // Open the dropdown explicitly. Left clicking is not
                // viable, as it would edit the text and not open the
                // dropdown
                case ComboBox comboBox:
                    {
                        comboBox.IsDropDownOpen = true;
                        break;
                    }
            }
        }
    }
}
