﻿using System.Reflection;
using MaterialDesignColors;

namespace MaterialDesignThemes.UITests;

public class AllStyles : TestBase
{
    public AllStyles(ITestOutputHelper output)
        : base(output)
    { }

    [Theory]
    [InlineData("ComboBox", "MaterialDesignComboBox")]
    public async Task LoadStyleInIsolation_CanBeLoaded(string controlName, string styleName)
    {
        await using var recorder = new TestRecorder(App);

        string applicationResourceXaml = $$"""
<ResourceDictionary 
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes">
  <ResourceDictionary.MergedDictionaries>
    <materialDesign:BundledTheme BaseTheme="{{BaseTheme.Inherit}}" PrimaryColor="{{PrimaryColor.Purple}}" SecondaryColor="{{SecondaryColor.Blue}}" />

    <ResourceDictionary Source="pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.{{controlName}}.xaml" />
  </ResourceDictionary.MergedDictionaries>

  <Style TargetType="{x:Type {{controlName}}}" BasedOn="{StaticResource {{styleName}}}" />
</ResourceDictionary>
""";

        await App.Initialize(applicationResourceXaml,
            Path.GetFullPath("MaterialDesignColors.dll"),
            Path.GetFullPath("MaterialDesignThemes.Wpf.dll"),
            Assembly.GetExecutingAssembly().Location);

        IWindow window = await App.CreateWindow("""
             <Window
                    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
                    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
                    xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes"
                    mc:Ignorable="d"
                    Height="800" Width="1100"
                    TextElement.Foreground="{DynamicResource MaterialDesignBody}"
                    TextElement.FontWeight="Regular"
                    TextElement.FontSize="13"
                    TextOptions.TextFormattingMode="Ideal" 
                    TextOptions.TextRenderingMode="Auto"
                    Background="{DynamicResource MaterialDesignPaper}"
                    FontFamily="{materialDesign:MaterialDesignFont}" 
                    Title="Test Window"
                    Topmost="True"
                    WindowStartupLocation="CenterScreen">
            </Window>
            """);

        Assert.True(await window.GetIsVisible());
    }
}
