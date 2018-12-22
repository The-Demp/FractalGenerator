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

namespace FractalArrowhead
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            selector.Items.Add(new VanKochSnowflake(canvas));
            selector.Items.Add(new SierpinskiTriangle(canvas));
            selector.Items.Add(new FractalTree(canvas, 2, 45));
            selector.Items.Add(new FractalTree(canvas, 5, 20));
            selector.Items.Add(new DragonOfEve(canvas));
            selector.Items.Add(new MinkowskiCurve(canvas));
            selector.Items.Add(new LevyC(canvas));
            selector.Items.Add(new HeighwayDragon(canvas));
            selector.Items.Add(new MandelbrotCurve(canvas));

            selector.SelectedIndex = 0;
        }

        private void Iterate_Click(object sender, RoutedEventArgs e)
        {
            FractalGenerator gen = selector.SelectedItem as FractalGenerator;
            //just to be extra safe
            gen?.Iterate();
            numLines.Text = canvas.Children.Count.ToString();
        }

        private void Selector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            canvas.Children.Clear();
            FractalGenerator gen = selector.SelectedItem as FractalGenerator;
            //just to be extra safe
            gen?.Setup();
            numLines.Text = canvas.Children.Count.ToString();
        }
    }
}