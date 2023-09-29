using System.ComponentModel;

namespace MaterialDesignThemes.UITests.WPF.TreeListViews;

public class TreeListViewTests : TestBase
{
    public TreeListViewTests(ITestOutputHelper output)
        : base(output)
    { }

    [Fact]
    public async Task CanResetNestedElements()
    {
        await using var recorder = new TestRecorder(App);

        IVisualElement<Grid> root = (await LoadUserControl<TreeListViewDataBinding>()).As<Grid>();
        IVisualElement<TreeListView> treeListView = await root.GetElement<TreeListView>();
        IVisualElement<Button> addButton = await root.GetElement(ElementQuery.PropertyExpression<Button>(x => x.Content, "Add"));
        IVisualElement<Button> resetButton = await root.GetElement(ElementQuery.PropertyExpression<Button>(x => x.Content, "Reset"));

        IVisualElement<TreeListViewItem> secondItem = await treeListView.GetElement<TreeListViewItem>("/TreeListViewItem[1]");

        //Select second item and add three children
        await AddChildren(secondItem, 3, addButton);

        //Expand item and select second item
        await secondItem.LeftClickExpander();
        await secondItem.LeftClick();
        await Wait.For(() => secondItem.GetIsSelected());


        //Reset children
        await resetButton.LeftClick();

        await AssertTreeItemContent(treeListView, 0, "0");
        await AssertTreeItemContent(treeListView, 1, "1");
        await AssertTreeItemContent(treeListView, 2, "1_0_x");
        await AssertTreeItemContent(treeListView, 3, "1_1_x");
        await AssertTreeItemContent(treeListView, 4, "1_2_x");
        await AssertTreeItemContent(treeListView, 5, "2");

        recorder.Success();
    }

    [Fact]
    public async Task CanMoveNestedElement()
    {
        await using var recorder = new TestRecorder(App);

        IVisualElement<Grid> root = (await LoadUserControl<TreeListViewDataBinding>()).As<Grid>();
        IVisualElement<TreeListView> treeListView = await root.GetElement<TreeListView>();
        IVisualElement<Button> addButton = await root.GetElement(ElementQuery.PropertyExpression<Button>(x => x.Content, "Add"));
        IVisualElement<Button> moveDownButton = await root.GetElement(ElementQuery.PropertyExpression<Button>(x => x.Content, "Down"));

        IVisualElement<TreeListViewItem> secondItem = await treeListView.GetElement<TreeListViewItem>("/TreeListViewItem[1]");

        //Select second item and add three children
        await AddChildren(secondItem, 3, addButton);

        //Expand item
        await secondItem.LeftClickExpander();

        //Move child item
        IVisualElement<TreeListViewItem> childElement;
        await Wait.For(async () =>
        {
            childElement = await treeListView.GetElement<TreeListViewItem>("/TreeListViewItem[3]");
            await childElement.LeftClick();
            return await childElement.GetIsSelected();
        });
        await moveDownButton.LeftClick();

        await AssertTreeItemContent(treeListView, 0, "0");
        await AssertTreeItemContent(treeListView, 1, "1");
        await AssertTreeItemContent(treeListView, 2, "1_0");
        await AssertTreeItemContent(treeListView, 3, "1_2");
        await AssertTreeItemContent(treeListView, 4, "1_1");
        await AssertTreeItemContent(treeListView, 5, "2");

        recorder.Success();
    }

    [Fact]
    public async Task CanMoveTopLevelElement()
    {
        await using var recorder = new TestRecorder(App);

        IVisualElement<Grid> root = (await LoadUserControl<TreeListViewDataBinding>()).As<Grid>();
        IVisualElement<TreeListView> treeListView = await root.GetElement<TreeListView>();
        IVisualElement<Button> moveDownButton = await root.GetElement(ElementQuery.PropertyExpression<Button>(x => x.Content, "Down"));

        IVisualElement<TreeListViewItem> secondItem = await treeListView.GetElement<TreeListViewItem>("/TreeListViewItem[1]");

        //Replace item
        await Wait.For(async () =>
        {
            await secondItem.LeftClick();
            return await secondItem.GetIsSelected();
        });
        await moveDownButton.LeftClick();

        await AssertTreeItemContent(treeListView, 0, "0");
        await AssertTreeItemContent(treeListView, 1, "2");
        await AssertTreeItemContent(treeListView, 2, "1");

        recorder.Success();
    }

    [Fact]
    public async Task CanReplaceTopLevelElement()
    {
        await using var recorder = new TestRecorder(App);

        IVisualElement<Grid> root = (await LoadUserControl<TreeListViewDataBinding>()).As<Grid>();
        IVisualElement<TreeListView> treeListView = await root.GetElement<TreeListView>();
        IVisualElement<Button> replaceButton = await root.GetElement(ElementQuery.PropertyExpression<Button>(x => x.Content, "Replace"));

        IVisualElement<TreeListViewItem> secondItem = await treeListView.GetElement<TreeListViewItem>("/TreeListViewItem[1]");

        //Replace item
        await Wait.For(async () =>
        {
            await secondItem.LeftClick();
            return await secondItem.GetIsSelected();
        });
        await replaceButton.LeftClick();

        await AssertTreeItemContent(treeListView, 0, "0");
        await AssertTreeItemContent(treeListView, 1, "1_r");
        await AssertTreeItemContent(treeListView, 2, "2");

        recorder.Success();
    }

    [Fact]
    public async Task CanReplaceNestedChildElement()
    {
        await using var recorder = new TestRecorder(App);

        IVisualElement<Grid> root = (await LoadUserControl<TreeListViewDataBinding>()).As<Grid>();
        IVisualElement<TreeListView> treeListView = await root.GetElement<TreeListView>();
        IVisualElement<Button> addButton = await root.GetElement(ElementQuery.PropertyExpression<Button>(x => x.Content, "Add"));
        IVisualElement<Button> replaceButton = await root.GetElement(ElementQuery.PropertyExpression<Button>(x => x.Content, "Replace"));

        IVisualElement<TreeListViewItem> secondItem = await treeListView.GetElement<TreeListViewItem>("/TreeListViewItem[1]");

        //Select second item and add three children
        await AddChildren(secondItem, 3, addButton);

        //Expand item
        await secondItem.LeftClickExpander();

        //Replace child item
        IVisualElement<TreeListViewItem> childElement;
        await Wait.For(async () =>
        {
            childElement = await treeListView.GetElement<TreeListViewItem>("/TreeListViewItem[3]");
            await childElement.LeftClick();
            return await childElement.GetIsSelected();
        });
        await replaceButton.LeftClick();


        await AssertTreeItemContent(treeListView, 3, "1_1_r");

        recorder.Success();
    }

    [Fact]
    public async Task WithHierarchicalDataTemplate_CanRemoveTopLevelElement()
    {
        await using var recorder = new TestRecorder(App);

        IVisualElement<Grid> root = (await LoadUserControl<TreeListViewDataBinding>()).As<Grid>();
        IVisualElement<TreeListView> treeListView = await root.GetElement<TreeListView>();
        IVisualElement<Button> addButton = await root.GetElement(ElementQuery.PropertyExpression<Button>(x => x.Content, "Add"));
        IVisualElement<Button> removeButton = await root.GetElement(ElementQuery.PropertyExpression<Button>(x => x.Content, "Remove"));

        IVisualElement<TreeListViewItem> secondItem = await treeListView.GetElement<TreeListViewItem>("/TreeListViewItem[1]");

        //Select second item and add three children
        await AddChildren(secondItem, 3, addButton);

        //Expand item
        await secondItem.LeftClickExpander();

        //Remove second item
        await removeButton.LeftClick();

        await AssertTreeItemContent(treeListView, 0, "0");
        await AssertTreeItemContent(treeListView, 1, "2");
        
        recorder.Success();
    }

    [Fact]
    public async Task WithHierarchicalDataTemplate_CanRemoveNestedElement()
    {
        await using var recorder = new TestRecorder(App);

        //Arrange
        IVisualElement<Grid> root = (await LoadUserControl<TreeListViewDataBinding>()).As<Grid>();
        IVisualElement<TreeListView> treeListView = await root.GetElement<TreeListView>();
        IVisualElement<Button> addButton = await root.GetElement(ElementQuery.PropertyExpression<Button>(x => x.Content, "Add"));
        IVisualElement<Button> removeButton = await root.GetElement(ElementQuery.PropertyExpression<Button>(x => x.Content, "Remove"));

        //Act
        IVisualElement<TreeListViewItem> secondItem = await treeListView.GetElement<TreeListViewItem>("/TreeListViewItem[1]");

        //Select and expand second item
        await AddChildren(secondItem, 3, addButton);

        //Expand it
        await secondItem.LeftClickExpander();

        //Add two child to each of the existing children
        IVisualElement<TreeListViewItem> child1 = await treeListView.GetElement<TreeListViewItem>("/TreeListViewItem[2]");
        await AddChildren(child1, 2, addButton);
        await child1.LeftClickExpander();

        IVisualElement<TreeListViewItem> child2 = await treeListView.GetElement<TreeListViewItem>("/TreeListViewItem[5]");
        await AddChildren(child2, 2, addButton);
        await child2.LeftClickExpander();

        //Remove second item
        await child1.LeftClick();
        await removeButton.LeftClick();

        //Assert
        await AssertTreeItemContent(treeListView, 0, "0");
        await AssertTreeItemContent(treeListView, 1, "1");
        await AssertTreeItemContent(treeListView, 2, "1_1");
        await AssertTreeItemContent(treeListView, 3, "1_1_0");
        await AssertTreeItemContent(treeListView, 4, "1_1_1");
        await AssertTreeItemContent(treeListView, 5, "1_2");
        await AssertTreeItemContent(treeListView, 6, "2");

        recorder.Success();
    }

    [Fact]
    public async Task DoubleClickOnTreeListViewItem_TogglesExpansion()
    {
        await using var recorder = new TestRecorder(App);

        IVisualElement<Grid> root = (await LoadUserControl<TreeListViewDataBinding>()).As<Grid>();
        IVisualElement<TreeListView> treeListView = await root.GetElement<TreeListView>();
        IVisualElement<Button> addButton = await root.GetElement(ElementQuery.PropertyExpression<Button>(x => x.Content, "Add"));
        IVisualElement<Button> removeButton = await root.GetElement(ElementQuery.PropertyExpression<Button>(x => x.Content, "Remove"));

        IVisualElement<TreeListViewItem> secondItem = await treeListView.GetElement<TreeListViewItem>("/TreeListViewItem[1]");

        //Select and expand second item
        await AddChildren(secondItem, 3, addButton);

        //NB: Needs to be long enough delay so the first click below does not register as a double click (and the third click as another which effectively collapses the item again)
        await Task.Delay(500);

        //Double click to expand
        await secondItem.LeftClick();
        await secondItem.LeftClick();

        await Wait.For(() => secondItem.GetIsExpanded());

        //NB: Needs to be long enough delay so the next clicks register as a new double click
        await Task.Delay(500);

        //Double click to collapse
        await secondItem.LeftClick();
        await secondItem.LeftClick();

        await Wait.For(async () => await secondItem.GetIsExpanded() == false);

        recorder.Success();
    }

    [Fact]
    public async Task LeftAndRightArrowKeys_CollapseAndExpand()
    {
        await using var recorder = new TestRecorder(App);

        IVisualElement<Grid> root = (await LoadUserControl<TreeListViewDataBinding>()).As<Grid>();
        IVisualElement<TreeListView> treeListView = await root.GetElement<TreeListView>();
        IVisualElement<Button> addButton = await root.GetElement(ElementQuery.PropertyExpression<Button>(x => x.Content, "Add"));
        IVisualElement<Button> removeButton = await root.GetElement(ElementQuery.PropertyExpression<Button>(x => x.Content, "Remove"));

        IVisualElement<TreeListViewItem> secondItem = await treeListView.GetElement<TreeListViewItem>("/TreeListViewItem[1]");

        //Select and expand second item
        await AddChildren(secondItem, 3, addButton);

        //Right arrow to expand
        await secondItem.LeftClick();
        await Wait.For(() => secondItem.GetIsSelected());
        await secondItem.SendKeyboardInput($"{Key.Right}");

        await Wait.For(() => secondItem.GetIsExpanded());

        //Add child items to test double left arrow
        IVisualElement<TreeListViewItem> nestedItem = await treeListView.GetElement<TreeListViewItem>("/TreeListViewItem[3]");
        await AddChildren(nestedItem, 2, addButton);

        await nestedItem.LeftClick();
        await Wait.For(() => nestedItem.GetIsSelected());

        //Left arrow to collapse
        await nestedItem.SendKeyboardInput($"{Key.Left}");
        await Wait.For(async () => await nestedItem.GetIsExpanded() == false);

        //Allow for collapsed animation to complete
        await Task.Delay(500);

        //Left arrow to jump to parent
        await nestedItem.SendKeyboardInput($"{Key.Left}");
        await Wait.For(() => secondItem.GetIsSelected(), message: "Parent item is not selected");

        recorder.Success();
    }

    [Fact]
    [Description("Denoted as Issue 1 in the PR")]
    public async Task AddingChildrenToItemWithAlreadyExpandedChildren_InsertsNewChildAtCorrectIndex()
    {
        await using var recorder = new TestRecorder(App);

        IVisualElement<Grid> root = (await LoadUserControl<TreeListViewDataBinding>()).As<Grid>();
        IVisualElement<TreeListView> treeListView = await root.GetElement<TreeListView>();
        IVisualElement<Button> addButton = await root.GetElement(ElementQuery.PropertyExpression<Button>(x => x.Content, "Add"));
        IVisualElement<Button> removeButton = await root.GetElement(ElementQuery.PropertyExpression<Button>(x => x.Content, "Remove"));

        IVisualElement<TreeListViewItem> secondItem = await treeListView.GetElement<TreeListViewItem>("/TreeListViewItem[1]");

        //Add child to second item and expand
        await AddChildren(secondItem, 1, addButton);
        await Task.Delay(250);  // TODO: Unsure why this is needed, I suspect it is the double-click that could be interfering. Needed for consistent test results.
        await secondItem.LeftClickExpander();

        //NB: Needs to be long enough delay so the next clicks does not register as a double click
        await Task.Delay(250);

        //Add child to newly added child and expand
        IVisualElement<TreeListViewItem> newChild1 = await treeListView.GetElement<TreeListViewItem>("/TreeListViewItem[2]");
        await AddChildren(newChild1, 1, addButton);
        await Task.Delay(250);  // TODO: Unsure why this is needed, I suspect it is the double-click that could be interfering. Needed for consistent test results.
        await newChild1.LeftClickExpander();

        //NB: Needs to be long enough delay so the next clicks does not register as a double click
        await Task.Delay(250);

        //Select secondItem again, and add another child
        await AddChildren(secondItem, 1, addButton);

        //Assert the child added last is below the child added first (and its children)
        await AssertTreeItemContent(treeListView, 4, "1_1");

        recorder.Success();
    }

    [Fact]
    [Description("Denoted as Issue 2 in the PR")]
    public async Task RemovingChildrenFromItemWithAlreadyExpandedChildren_ShouldDeleteSelectedChild()
    {
        await using var recorder = new TestRecorder(App);

        IVisualElement<Grid> root = (await LoadUserControl<TreeListViewDataBinding>()).As<Grid>();
        IVisualElement<TreeListView> treeListView = await root.GetElement<TreeListView>();
        IVisualElement<Button> addButton = await root.GetElement(ElementQuery.PropertyExpression<Button>(x => x.Content, "Add"));
        IVisualElement<Button> removeButton = await root.GetElement(ElementQuery.PropertyExpression<Button>(x => x.Content, "Remove"));

        IVisualElement<TreeListViewItem> secondItem = await treeListView.GetElement<TreeListViewItem>("/TreeListViewItem[1]");

        //Add child to second item and expand
        await AddChildren(secondItem, 3, addButton);
        await Task.Delay(250);  // TODO: Unsure why this is needed, I suspect it is the double-click that could be interfering. Needed for consistent test results.
        await secondItem.LeftClickExpander();

        //NB: Needs to be long enough delay so the next clicks does not register as a double click
        await Task.Delay(250);

        //Add child to newly added child and expand
        IVisualElement<TreeListViewItem> newChild1 = await treeListView.GetElement<TreeListViewItem>("/TreeListViewItem[2]");
        await AddChildren(newChild1, 1, addButton);
        await Task.Delay(250);  // TODO: Unsure why this is needed, I suspect it is the double-click that could be interfering. Needed for consistent test results.
        await newChild1.LeftClickExpander();

        //NB: Needs to be long enough delay so the next clicks does not register as a double click
        await Task.Delay(250);

        // Remove item "1_2"
        IVisualElement<TreeListViewItem> item1_2 = await treeListView.GetElement<TreeListViewItem>("/TreeListViewItem[5]");
        await item1_2.LeftClick();
        await Wait.For(() => item1_2.GetIsSelected());
        await removeButton.LeftClick();

        //NB: Needs to be long enough delay so the next clicks does not register as a double click
        await Task.Delay(250);

        // Remove item "1_1" (this fails)
        IVisualElement<TreeListViewItem> item1_1 = await treeListView.GetElement<TreeListViewItem>("/TreeListViewItem[4]");
        await item1_1.LeftClick();
        await Wait.For(() => item1_1.GetIsSelected());
        await removeButton.LeftClick();

        //NB: Needs to be long enough delay so the next clicks does not register as a double click
        await Task.Delay(250);

        //Assert the 2 children were successfully removed
        await AssertTreeItemContent(treeListView, 4, "2");

        recorder.Success();
    }

    private static async Task AssertTreeItemContent(IVisualElement<TreeListView> treeListView, int index, string content)
    {
        await Wait.For(async () =>
        {
            IVisualElement<TreeListViewItem> foundFirstItem = await treeListView.GetElement<TreeListViewItem>($"/TreeListViewItem[{index}]");
            Assert.Equal(content, await foundFirstItem.GetContentText());
        });
    }

    private static async Task AddChildren(IVisualElement<TreeListViewItem> item, int numChildren, IVisualElement<Button> addButton)
    {
        await item.LeftClick();
        for(int i = 0; i < numChildren; i++)
        {
            await addButton.LeftClick();
        }
    }
}
