using System;
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

namespace DrawSurface
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<int> distances = new List<int>()
            {
                56,57,58,59,71,73,75,78,82,82,78,75,73,71,59,58,57,56,
                56,57,58,59,71,73,75,78,82,82,78,75,73,71,59,58,57,56,
                56,57,58,59,71,73,75,78,82,82,78,75,73,71,59,58,57,56,
                56,57,58,59,71,73,75,78,82,82,78,75,73,71,59,58,57,56, 56
            };
            DrawPolygone(distances);
        }

        public void DrawPolygone(List<int> distances)
        {

            List<Point> points = TransformDistanceToPoint(distances);
            var polyline = new Polyline();
            polyline.Stroke = Brushes.Black;
            polyline.Points = new PointCollection(points);
            CanvaPolygone.Children.Add(polyline);
        }

        public List<Point> TransformDistanceToPoint(List<int> distances)
        {
            List<Point> points = new List<Point>();
            if (distances != null)
            {
                int counter = 0;
                foreach (var distance in distances)
                {
                    double degree = DegreeToRadian(counter * 5);
                    // a little bit of trigonometry :
                    double x = 0;
                    double y = 0;
                    if (degree >= 0 && degree < Math.PI/2.0)
                    {
                        x = Math.Cos(degree) * distance;
                        y = Math.Cos(Math.PI / 2.0 - degree) * distance;
                    } else if( degree >= Math.PI / 2.0 && degree < Math.PI)
                    {
                        x = -Math.Cos(degree - Math.PI / 2.0) * distance;
                        y = -Math.Cos(degree) * distance;
                    } else if (degree >= Math.PI && degree < Math.PI * 1.5)
                    {
                        x = Math.Cos(Math.PI * 1.5 - degree) * distance;
                        y = Math.Cos(degree - Math.PI) * distance;
                    } else if (degree >= Math.PI * 1.5 && degree <= Math.PI * 2)
                    {
                        x = Math.Cos(degree - Math.PI / 2.0) * distance;
                        y = -Math.Cos(Math.PI - degree) * distance;
                        
                    }

                    points.Add(new Point(x + 150, y + 150));

                    counter++;
                }
            }
            return points;
        }

        public double DegreeToRadian(double degree)
        {
            return degree * (Math.PI / 180.0);
        }
    }
}
