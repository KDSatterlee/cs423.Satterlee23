using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Reflection.Emit;

namespace lab02
{
    public partial class MainWindow : Window
    {
        int treeDepth = 0;
        int animationCounter = 0;
        int depthLimit = 10;

        private double lengthScale = 0.75;
        private double deltaTheta = Math.PI / 5;

        public MainWindow()
        {
            InitializeComponent(); // You need to call InitializeComponent to initialize the window components.

            // Start the animation when the window loads.
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Start the animation when the window loads.
            CompositionTarget.Rendering += StartAnimation;
        }

        private void DrawBinaryTree(Canvas canvas, int depth, Point pt, double length, double theta)
        {
            double x1 = pt.X + length * Math.Cos(theta);
            double y1 = pt.Y + length * Math.Sin(theta);
            Line line = new Line();
            line.Stroke = Brushes.Blue;
            line.X1 = pt.X;
            line.Y1 = pt.Y;
            line.X2 = x1;
            line.Y2 = y1;
            canvas.Children.Add(line);
            if (depth < depthLimit)
            {
                DrawBinaryTree(canvas, depth + 1, new Point(x1, y1), length * lengthScale, theta + deltaTheta);
                DrawBinaryTree(canvas, depth + 1, new Point(x1, y1), length * lengthScale, theta - deltaTheta);
            }
        }

        private void StartAnimation(object sender, EventArgs e)
        {
            animationCounter += 1;
            if (animationCounter % 60 == 0)
            {
                DrawBinaryTree(canvas1, treeDepth, new Point(canvas1.Width / 2, 0.83 * canvas1.Height), 0.2 * canvas1.Width, -Math.PI / 2);
                string str = "Binary Tree - Depth = " + treeDepth.ToString();
                tblade.Text = str;
                treeDepth += 1;
                if (treeDepth > depthLimit)
                {
                    tblade.Text = "Binary Tree - Depth = 10. Finished";
                    CompositionTarget.Rendering -= StartAnimation;
                }
            }
        }
    }
}
