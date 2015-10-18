﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MaterialDesignColors.WpfExample
{
    /// <summary>
    /// Interaction logic for Grids.xaml
    /// </summary>
    public partial class Grids : UserControl
    {
        public Grids()
        {
            InitializeComponent();
        }

        private void DataGrid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            DataGridCheckBoxColumn column = e.Column as DataGridCheckBoxColumn;
            if (column != null)
            {
                var binding = column.Binding as Binding;
                if (binding != null)
                {
                    binding.NotifyOnTargetUpdated = true;
                    binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                }
            }
        }
    }
}
