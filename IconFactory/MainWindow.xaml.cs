using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IconFactory
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();

         // - - -  - - - 

         //AnalyticsHelper.DI DeviceInfo = new AnalyticsHelper.DI();
         //DeviceInfo.OS = Environment.OSVersion.VersionString;
         //DeviceInfo.DM = "???";
         //DeviceInfo.DN = Environment.MachineName;
         //DeviceInfo.ID = Environment.UserName;
         //DeviceInfo.APP = "IconFactory";
         //DeviceInfo.AV = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

         ////if (ApplicationDeployment.IsNetworkDeployed)
         ////{
         ////   DeviceInfo.AV = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
         ////}
         ////else
         ////{
         ////   DeviceInfo.AV = "debug";
         ////};

         //AnalyticsHelper.Init(DeviceInfo);
         //AnalyticsHelper.Send("");

         //AuditTrail.Clean();
         //AuditTrail.WriteHeader(DeviceInfo.APP, DeviceInfo.AV, DeviceInfo.OS);

         // - - -  - - - 
      }

      private void Open_Click(object sender, RoutedEventArgs e)
      {
         Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
         dlg.Filter = "Image Files (*.png, *.jpg)|*.png;*.jpg|All files (*.*)|*.*";

         Nullable<bool> result = dlg.ShowDialog();

         if (result.Value)
         {
            ShowImage(dlg.FileName);
         };
      }

      // Show Image for file load and drag
      private void ShowImage(string FileName)
      {
         MainViewModel.Instance.LoadImage(FileName);

         MainViewModel.Instance.SetImageSource(grayImage);

         NewImageDisplayed();
      }

      private void UC_MouseMove(object sender, MouseEventArgs e)
      {
#if resize
         p2 = e.GetPosition(grayImage);
         if (e.LeftButton == MouseButtonState.Pressed)
         {
            double w = Math.Abs(p1.X - p2.X);
            double h = Math.Abs(p1.Y - p2.Y);
            if (w > h)
               p2.Y = (p2.Y > p1.Y) ? p1.Y + w : p1.Y - w;
            else
               p2.X = (p2.X > p1.X) ? p1.X + h : p1.X - w;

            Point lt = new Point((p1.X > p2.X) ? p2.X : p1.X, (p1.Y > p2.Y) ? p2.Y : p1.Y);
            Point rb = new Point((p1.X > p2.X) ? p1.X : p2.X, (p1.Y > p2.Y) ? p1.Y : p2.Y);

            // rabber band
            myCanvas.Children.Remove(rectFrame);
            rectFrame.Stroke = Brushes.Gray;
            rectFrame.StrokeThickness = 1.0;
            rectFrame.Width = rb.X - lt.X;
            rectFrame.Height = rb.Y - lt.Y;
            rectFrame.RenderTransform = new TranslateTransform(lt.X, lt.Y);
            myCanvas.Children.Add(rectFrame);

            // UpdatePreviewIcons(lt, rb);
         }
#endif
      }

      private void myCanvas_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
      {
         // CompleteNotice.Content = "Click [Save Icons] button if satisfied";
      }

      private Point p1 = new Point();
      private Point p2 = new Point();

      private void UC_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
      {
         p1 = e.GetPosition(grayImage);
         // CompleteNotice.Content = "Trim area to be Icon by Mouse";
      }

      private Rectangle rectFrame = new Rectangle();

      private void grayImage_SizeChanged(object sender, SizeChangedEventArgs e)
      {
         NewImageDisplayed();
      }

      private void Save_Click(object sender, RoutedEventArgs e)
      {
         if (string.IsNullOrEmpty(MainViewModel.Instance.FileName))
         {
            MessageBox.Show("You should load an image first");
            return;
         };

         (sender as Button).IsEnabled = false;
         MainViewModel.Instance.SaveIcons();
         MessageBox.Show("Done... :-)");
         (sender as Button).IsEnabled = true;
      }

      double scale = 1.0;

      private void NewImageDisplayed()
      {
         //ToDo NewImageDisplayed

#if resize
         scale = MainViewModel.Instance.ImageSource.Width / grayImage.ActualWidth;
#endif
         string name = System.IO.Path.GetFileNameWithoutExtension(MainViewModel.Instance.FileName);
         projectName.Text = name;
         // CompleteNotice.Content = "Trim area to be Icon by Mouse";
      }

      private void Window_Loaded(object sender, RoutedEventArgs e)
      {
         this.DataContext = MainViewModel.Instance;

         MainViewModel.Instance.Load();

         if (System.IO.File.Exists(MainViewModel.IniFileName))
         {
            MainViewModel.ReadFormPos(this, false, false);
         };

         if (System.IO.File.Exists(MainViewModel.Instance.FileName))
         {
            ShowImage(MainViewModel.Instance.FileName);
         };

         listViewIcons.ItemsSource = MainViewModel.Instance.Icons;

         CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listViewIcons.ItemsSource);
         PropertyGroupDescription groupDescription = new PropertyGroupDescription("Section");
         view.GroupDescriptions.Add(groupDescription);
      }

      private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
      {
         var c = sender as CheckBox;

         foreach (var i in MainViewModel.Instance.Icons)
         {
            if (i.Section == c.CommandParameter.ToString())
            {
               i.Selected = c.IsChecked == true;
            };
         };
      }

      private void listViewIcons_SelectionChanged(object sender, SelectionChangedEventArgs e)
      {
         if (listViewIcons.SelectedItem != null)
         {
            if (string.IsNullOrEmpty(MainViewModel.Instance.FileName))
            {
               MessageBox.Show("You should load an image first");
               return;
            };

            var i = listViewIcons.SelectedItem as Icon;

            string p = System.IO.Path.GetTempPath();
            string f = System.IO.Path.GetFileName(System.IO.Path.GetTempFileName());

            MainViewModel.Instance.EncodeAndSave(i, f, p);

            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.CacheOption = BitmapCacheOption.OnLoad;
            logo.UriSource = new Uri(p + f);
            logo.EndInit();

            var image = new Image();
            image.StretchDirection = StretchDirection.DownOnly;
            image.HorizontalAlignment = HorizontalAlignment.Center;
            image.VerticalAlignment = VerticalAlignment.Center;
            image.Source = logo;

            //canvasPreview.Children.Clear();
            //canvasPreview.Children.Add(image);

            borderPreview.Child = image;
         };
      }

      private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {
         MainViewModel.Instance.Save();
         MainViewModel.WriteFormPos(this, false);
      }

      private void About_Click(object sender, RoutedEventArgs e)
      {
         new AboutWindow().ShowDialog();
      }
   }
}
