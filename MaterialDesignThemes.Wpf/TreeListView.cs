﻿using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace MaterialDesignThemes.Wpf;

internal class TreeListViewItemsCollection<T> : ObservableCollection<T>
{
    private List<int> ItemLevels { get; } = new();

    public TreeListViewItemsCollection(object wrappedSource)
    {
        if (wrappedSource is IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                Add(item);
            }
        }
        if (wrappedSource is INotifyCollectionChanged newCollectionChanged)
        {
            newCollectionChanged.CollectionChanged += ItemsSource_CollectionChanged;
        }
    }

    public int GetLevel(int index)
        => ItemLevels[index];

    public void Insert(int index, T item, int level)
    {
        Insert(index, item);
        ItemLevels[index] = level;
        if (Count != ItemLevels.Count)
        {

        }
    }

    protected override void RemoveItem(int index)
    {
        int currentLevel = ItemLevels[index];
        ItemLevels.RemoveAt(index);
        base.RemoveItem(index);
        while (index < Count && ItemLevels[index] > currentLevel)
        {
            RemoveItem(index);
        }
        if (Count != ItemLevels.Count)
        {

        }
    }

    protected override void InsertItem(int index, T item)
    {
        ItemLevels.Insert(index, 0);
        base.InsertItem(index, item);
        if (Count != ItemLevels.Count)
        {

        }
    }

    private void ItemsSource_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                for (int i = 0; i < e.NewItems?.Count; i++)
                {
                    Insert(e.NewStartingIndex + i, (T)e.NewItems[i]!);
                }
                break;
            case NotifyCollectionChangedAction.Remove:
                for (int i = 0; i < e.OldItems?.Count; i++)
                {
                    RemoveAt(e.OldStartingIndex + i);
                }
                break;
            case NotifyCollectionChangedAction.Replace:
                for (int i = 0; i < e.NewItems?.Count; i++)
                {
                    this[e.NewStartingIndex + i] = (T)e.NewItems[i]!;
                }
                break;
            case NotifyCollectionChangedAction.Move:
                for (int i = 0; i < e.NewItems?.Count; i++)
                {
                    Move(e.OldStartingIndex + i, e.NewStartingIndex + i);
                }
                break;
            case NotifyCollectionChangedAction.Reset:
                Clear();
                ItemLevels.Clear();
                foreach (var item in sender as IEnumerable<T> ?? Enumerable.Empty<T>())
                {
                    Add(item);
                }
                break;
        }
    }
}

//TODO: Implement bindable property for getting selected items
//Disallow setting GridView
public class TreeListView : ListView
{
    public double LevelIndentSize
    {
        get => (double)GetValue(LevelIndentSizeProperty);
        set => SetValue(LevelIndentSizeProperty, value);
    }

    // Using a DependencyProperty as the backing store for LevelIndentSize.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty LevelIndentSizeProperty =
        DependencyProperty.Register("LevelIndentSize", typeof(double), typeof(TreeListView), new PropertyMetadata(16.0));

    private TreeListViewItemsCollection<object?>? InternalItemsSource { get; set; }

    static TreeListView()
    {
        ItemsSourceProperty.OverrideMetadata(typeof(TreeListView), new FrameworkPropertyMetadata()
        {
            CoerceValueCallback = CoerceItemsSource
        });
    }

    public TreeListView()
    {
    }

    private static object CoerceItemsSource(DependencyObject d, object baseValue)
    {
        if (d is TreeListView treeListView)
        {
            return treeListView.InternalItemsSource = new(baseValue);
        }
        return baseValue;
    }

    protected override DependencyObject GetContainerForItemOverride()
        => new TreeListViewItem(this);

    protected override bool IsItemItsOwnContainerOverride(object? item)
        => item is TreeListViewItem;

    protected override void PrepareContainerForItemOverride(DependencyObject element, object? item)
    {
        base.PrepareContainerForItemOverride(element, item);
        if (element is TreeListViewItem treeListViewItem &&
            InternalItemsSource is { } itemsSource)
        {
            int index = ItemContainerGenerator.IndexFromContainer(treeListViewItem);
            treeListViewItem.Level = itemsSource.GetLevel(index);
        }
    }

    internal void ItemExpandedChanged(TreeListViewItem item)
    {
        if (InternalItemsSource is { } itemsSource)
        {
            int index = ItemContainerGenerator.IndexFromContainer(item);
            var children = item.GetChildren().ToList();
            if (item.IsExpanded)
            {
                int parentLevel = itemsSource.GetLevel(index);
                for (int i = 0; i < children.Count; i++)
                {
                    itemsSource.Insert(i + index + 1, children[i], parentLevel + 1);
                }
            }
            else
            {
                for (int i = 0; i < children.Count; i++)
                {
                    itemsSource.RemoveAt(index + 1);
                }
            }
        }
    }

    internal void ItemsChildrenChanged(TreeListViewItem item, NotifyCollectionChangedEventArgs e)
    {
        /* Helper method used to determine the number of visible items that are prior siblings
         * or children/grand-children of expanded siblings.
         *
         * This is used to determine the correct offset into the InternalItemsSource when adding/removing items
         */
        static int GetPriorSiblingsAndChildrenCount(TreeListViewItemsCollection<object?> collection, int startingIndex, int expectedPriorSiblingCount)
        {
            int additionalOffset = 0;
            int index = 0;
            int siblingCount = 0;

            // Determine the level expected of siblings (used for comparison)
            int siblingLevel = collection.GetLevel(startingIndex - 1) + 1;

            // Iterate while we haven't:
            //  - Exceeded the expected number of prior siblings, or
            //  - Reached the end of the InternalItemsSource, or
            //  - Reached an item with a level less than the sibling level
            while (siblingCount <= expectedPriorSiblingCount)
            {
                // Bail out if we've reached the end of the itemsSource
                if (startingIndex + index >= collection.Count)
                    break;

                // Bail out if we've reached an item with a level less than the sibling level
                int level = collection.GetLevel(startingIndex + index);
                if (level < siblingLevel)
                    break;

                if (level == siblingLevel)
                {
                    siblingCount++;
                }
                additionalOffset++;
                index++;
            }
            return additionalOffset;
        }

        if (item.IsExpanded && InternalItemsSource is { } itemsSource)
        {
            int index = ItemContainerGenerator.IndexFromContainer(item);
            if (index < 0) return;
            //We push the index forward by 1 to be on the first element of the item's children
            index++;
            int offset = 0;
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    offset = GetPriorSiblingsAndChildrenCount(itemsSource, index, e.NewStartingIndex);
                    for (int i = 0; i < e.NewItems?.Count; i++)
                    {
                        itemsSource.Insert(index + offset, e.NewItems[i]!);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    offset = GetPriorSiblingsAndChildrenCount(itemsSource, index, e.OldStartingIndex) - 1; // The -1 is because the item being removed is also taken into account, which in this case is not needed.
                    for (int i = 0; i < e.OldItems?.Count; i++)
                    {
                        itemsSource.RemoveAt(index + offset);
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    for (int i = 0; i < e.NewItems?.Count; i++)
                    {
                        itemsSource[e.NewStartingIndex + i + index] = e.NewItems[i]!;
                    }
                    break;
                case NotifyCollectionChangedAction.Move:
                    for (int i = 0; i < e.NewItems?.Count; i++)
                    {
                        itemsSource.Move(e.OldStartingIndex + i + index, e.NewStartingIndex + i);
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    int itemLevel = itemsSource.GetLevel(index - 1);
                    var children = item.GetChildren().ToList();
                    while (index < InternalItemsSource?.Count &&
                          itemsSource.GetLevel(index) == itemLevel + 1)
                    {
                        itemsSource.RemoveAt(index);
                    }

                    for (int i = 0; i < children.Count; i++)
                    {
                        itemsSource.Insert(i + index, children[i], itemLevel + 1);
                    }
                    break;
            }
        }
    }

    internal void MoveSelectionToParent(TreeListViewItem item)
    {
        if ((IsKeyboardFocused || IsKeyboardFocusWithin)
            && InternalItemsSource is { } itemsSource)
        {
            int index = ItemContainerGenerator.IndexFromContainer(item);
            if (index < 0) return;
            int itemLevel = itemsSource.GetLevel(index);
            for (int i = index; i > 0; i--)
            {
                if (itemsSource.GetLevel(i) == itemLevel - 1)
                {
                    SetSelectedItems(new[] { itemsSource[i] });
                    if (ItemContainerGenerator.ContainerFromIndex(i) is TreeListViewItem container)
                    {
                        container.Focus();
                    }
                    break;
                }
            }
        }
    }
}
