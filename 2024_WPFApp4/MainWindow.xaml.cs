using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _2024_WPFApp4
{
    /// <summary>
    /// 主視窗的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        // 畫筆顏色和畫筆畫刷的初始值
        Color strokecolor = Colors.Black;
        Brush strokebrush = Brushes.Black;

        // 起始點和終點的座標
        Point start, dest;

        // 主視窗建構函式
        public MainWindow()
        {
            InitializeComponent();
            // 初始化顏色選擇器為黑色
            strokeColorPicker.SelectedColor = strokecolor;
        }

        /// <summary>
        /// 滑鼠進入畫布時更改滑鼠游標為畫筆圖示
        /// </summary>
        private void myCanvas_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            myCanvas.Cursor = Cursors.Pen;
        }

        /// <summary>
        /// 當滑鼠在畫布上移動時，不斷更新終點座標並顯示起點與終點的座標
        /// </summary>
        private void myCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            // 更新終點座標
            dest = e.GetPosition(myCanvas);
            // 更新狀態欄顯示的座標資訊
            statusPoint.Content = $"({Convert.ToInt32(start.X)}, {Convert.ToInt32(start.Y)}) - ({Convert.ToInt32(dest.X)}, {Convert.ToInt32(dest.Y)})";
        }

        /// <summary>
        /// 當滑鼠左鍵在畫布上放開時，繪製從起點到終點的直線
        /// </summary>
        private void myCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // 使用選擇的顏色創建畫筆畫刷
            var brush = new SolidColorBrush(strokecolor);

            // 創建並設定直線的屬性
            Line line = new Line()
            {
                X1 = start.X,            // 起點 X 座標
                Y1 = start.Y,            // 起點 Y 座標
                X2 = dest.X,             // 終點 X 座標
                Y2 = dest.Y,             // 終點 Y 座標
                Stroke = brush,          // 使用選擇的顏色填充直線
                StrokeThickness = 2      // 設定線條寬度為 2
            };

            // 將直線添加到畫布上
            myCanvas.Children.Add(line);
        }

        /// <summary>
        /// 當顏色選擇器的顏色改變時，更新直線的畫筆顏色
        /// </summary>
        private void strokeColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            // 更新畫筆顏色為選擇器選中的顏色
            strokecolor = strokeColorPicker.SelectedColor.Value;
        }

        /// <summary>
        /// 當滑鼠左鍵按下時，記錄起點座標並更改游標為十字圖示
        /// </summary>
        private void myCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // 獲取起點座標
            start = e.GetPosition(myCanvas);
            // 更改游標為十字圖示
            myCanvas.Cursor = Cursors.Cross;
        }
    }
}
