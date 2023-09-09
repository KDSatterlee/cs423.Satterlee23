using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Linq;

namespace TurtleGraphics
{
    public partial class MainWindow : Window
    {
        private bool penDown = false; // Track pen state
        private int currentX = 0;     // Current turtle X position
        private int currentY = 0;     // Current turtle Y position
        private int gridSize = 50;    // Grid size (default 50)

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            string command = inputTextBox.Text;
            ProcessCommand(command);
        }

        private void ProcessCommand(string command)
        {
            string[] parts = command.Split(',');

            if (int.TryParse(parts[0], out int cmd))
            {
                switch (cmd)
                {
                    case 1:
                        penDown = false;
                        break;
                    case 2:
                        penDown = true;
                        break;
                    case 3:
                        // Implement Turn Right
                        break;
                    case 4:
                        // Implement Turn Left
                        break;
                    case 5:
                        if (parts.Length > 1 && int.TryParse(parts[1], out int steps))
                        {
                            MoveTurtle(steps);
                        }
                        break;
                    case 6:
                        ClearCanvas();
                        break;
                    case 9:
                        // Terminate program
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private void MoveTurtle(int steps)
        {
            if (penDown)
            {
                // Get the canvas' drawing context
                var drawingContext = canvas.Children.OfType<UIElement>().LastOrDefault()?.RenderTransform as TranslateTransform;
                if (drawingContext == null)
                {
                    drawingContext = new TranslateTransform();
                    canvas.Children.Add(new Rectangle { RenderTransform = drawingContext });
                }

                // Calculate the new position
                double newX = currentX + steps;
                double newY = currentY;

                // Draw a line from the current position to the new position
                Line line = new Line
                {
                    X1 = currentX,
                    Y1 = currentY,
                    X2 = newX,
                    Y2 = newY,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1
                };

                canvas.Children.Add(line);

                // Update the current position
                currentX = (int)newX;
                currentY = (int)newY;
            }
            else
            {
                // If the pen is up, just move the turtle without drawing
                currentX += steps;
            }
        }

        private void ClearCanvas()
        {
            // Clear the canvas by removing all drawings
            canvas.Children.Clear();

            // Reset the turtle's position and pen state
            currentX = 0;
            currentY = 0;
            penDown = false;
        }

    }
}
