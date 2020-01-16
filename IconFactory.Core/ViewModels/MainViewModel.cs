using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Globalization;
using System.Windows.Media.Animation;
using ZPF;
using System.Windows.Data;
using System.Diagnostics;

class MainViewModel : BaseViewModel
{
   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - - 

   static MainViewModel _Instance = null;

   public static MainViewModel Instance
   {
      get
      {
         if (_Instance == null)
         {
            _Instance = new MainViewModel();
         }

         return _Instance;
      }
   }

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  -

   BitmapImage _ImageSource = new BitmapImage();
   public BitmapImage ImageSource
   {
      get { return _ImageSource; }
      set { _ImageSource = value; }
   }

   private string _IconInfo = "";
   public string IconInfo
   {
      get { return _IconInfo; }
      set { SetField(ref _IconInfo, value); }
   }

   private string _FileName = "";
   public string FileName
   {
      get { return _FileName; }
      set { _FileName = value; }
   }

   private bool _Transparent = true;
   public bool Transparent
   {
      get { return _Transparent; }
      set { SetField(ref _Transparent, value); }
   }

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  -

   public MainViewModel()
   {
      if (_Instance == null)
      {
         _Instance = this;
      };

      Icons = new List<Icon>();
   }

   internal void LoadImage(string FileName)
   {
      _FileName = FileName;

      _ImageSource = new BitmapImage();
      _ImageSource.BeginInit();
      _ImageSource.UriSource = new Uri(FileName);
      _ImageSource.EndInit();

      IconInfo = string.Format("{0} x {1}", (int)_ImageSource.Width, (int)_ImageSource.Height);

      // http://stackoverflow.com/questions/11536577/from-png-to-bitmapimage-transparency-issue
      Transparent = IsTransparent(_ImageSource);
   }

   internal void SetImageSource(Image grayImage)
   {
      grayImage.Source = ImageSource;

      //if (ImageSource.PixelHeight < 600 && ImageSource.PixelWidth < 800)
      //{
      //   grayImage.Width = ImageSource.PixelWidth;
      //   grayImage.Height = ImageSource.PixelHeight;
      //}
      //else
      //{
      //   grayImage.Width = 800;
      //   grayImage.Height = 600;
      //}
   }

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  -

   enum Orientation { Square, Landscape, Portrait }


   public void EncodeAndSave(Icon i, string name, string filePath)
   {
      bool PixelArt = true;

      int Width = i.Width;
      int Height = i.Height;
      int Scale = i.Scale;

      if (string.IsNullOrEmpty(_FileName))
      {
         MessageBox.Show("You should load an image first");
         return;
      };

      if (string.IsNullOrEmpty(filePath))
      {
         filePath = System.IO.Path.GetDirectoryName(_FileName);
      }
      else
      {
         if (!filePath.Contains(":"))
         {
            filePath = System.IO.Path.ChangeExtension(_FileName, "").TrimEnd(new char[] { '.' }) + @"\" + filePath;
         };
      };

      if (!System.IO.Directory.Exists(filePath))
      {
         System.IO.Directory.CreateDirectory(filePath);
      };

      // - - -  - - - 

      Orientation orientation = Orientation.Square;

      if (Width > Height)
      {
         orientation = Orientation.Landscape;
         Width = Height;
      };

      if (Width < Height)
      {
         orientation = Orientation.Portrait;
         Height = Width;
      };

      int width = Width * Scale / 100;
      int height = Height * Scale / 100;

      // Create BitmapFrame for Icon

      RenderTargetBitmap rtb = new RenderTargetBitmap(i.Width, i.Height, 96.0, 96.0, PixelFormats.Pbgra32);

      // Use DrawingGroup for high quality rendering
      // See: http://www.olsonsoft.com/blogs/stefanolson/post/Workaround-for-low-quality-bitmap-resizing-in-WPF-4.aspx
      var group = new DrawingGroup();

      //if (PixelArt)
      //{
      //   RenderOptions.SetBitmapScalingMode(group, BitmapScalingMode.LowQuality);
      //}
      //else
      {
         RenderOptions.SetBitmapScalingMode(group, BitmapScalingMode.HighQuality);
      };

      switch (orientation)
      {
         case Orientation.Square:
            group.Children.Add(new ImageDrawing(ImageSource, new Rect(new Point(), new Size(Width, Height))));
            break;

         case Orientation.Landscape:
            group.Children.Add(new ImageDrawing(ImageSource, new Rect(new Point((i.Width - width) / 2, (i.Height - height) / 2), new Size(width, height))));
            break;

         case Orientation.Portrait:
            group.Children.Add(new ImageDrawing(ImageSource, new Rect(new Point((i.Width - width) / 2, (i.Height - height) / 2), new Size(width, height))));
            break;
      };

      var dv = new DrawingVisual();
      using (DrawingContext dc = dv.RenderOpen())
      {
         if (orientation != Orientation.Square)
         {
            if (!IsTransparent(this.ImageSource))
            {
               Color color = GetPixel(this.ImageSource, 0, 0);
               // Color color = Colors.Azure;

               Brush brush = new SolidColorBrush(color);
               Pen pen = new Pen(brush, 1);

               dc.DrawRectangle(brush, pen, new Rect(new Point(), new Size(i.Width, i.Height)));
            };
         };

         if( Glow )
         {
            Brush _whiteBrush = new RadialGradientBrush(Color.FromArgb(255, 255, 255, 255), Color.FromArgb(0, 255, 255, 255));
            var pen = new Pen(new SolidColorBrush(Colors.Transparent), 1);

            dc.DrawEllipse(_whiteBrush, pen, new Point(i.Width / 2, i.Height / 2), i.Width / 2, i.Height / 2);
         };

         dc.DrawDrawing(group);
      };

      rtb.Render(dv);
      BitmapFrame bmf = BitmapFrame.Create(rtb);
      bmf.Freeze();

      // - - -  - - - 

      if (name.Contains(@"\"))
      {
         filePath = filePath + "\\" + name.Split(new char[] { '\\' })[0];
         name = name.Split(new char[] { '\\' })[1];

         if (!System.IO.Directory.Exists(filePath))
         {
            System.IO.Directory.CreateDirectory(filePath);
         };
      };

      // - - -  - - - 

      string fileOut = filePath + "\\" + name;
      FileStream stream = new FileStream(fileOut, FileMode.Create);

      PngBitmapEncoder encoder = new PngBitmapEncoder();
      encoder.Frames.Add(bmf);
      encoder.Save(stream);
      stream.Close();
   }

   public Color GetPixel(BitmapSource bitmap, int x, int y)
   {
      Debug.Assert(bitmap != null);
      Debug.Assert(x >= 0);
      Debug.Assert(y >= 0);
      Debug.Assert(x < bitmap.PixelWidth);
      Debug.Assert(y < bitmap.PixelHeight);
      Debug.Assert(bitmap.Format.BitsPerPixel >= 24);

      CroppedBitmap cb = new CroppedBitmap(bitmap, new Int32Rect(x, y, 1, 1));
      byte[] pixel = new byte[bitmap.Format.BitsPerPixel / 8];
      cb.CopyPixels(pixel, bitmap.Format.BitsPerPixel / 8, 0);
      return Color.FromRgb(pixel[2], pixel[1], pixel[0]);
   }

   public bool IsTransparent(BitmapSource bitmap)
   {
      // Copy the single pixel into a new byte array representing RGBA
      var pixel = new byte[4];
      bitmap.CopyPixels(new Int32Rect(0, 0, 1, 1), pixel, 4, 0);

      // Check the alpha (transparency) of the pixel
      // - threshold can be adjusted from 0 to 255

      return (pixel[3] < 10);
   }

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  -

   internal void SaveIcons()
   {
      foreach (var i in Icons)
      {
         if (i.Selected)
         {
            try
            {
               EncodeAndSave(i, i.Name, i.Section);
            }
            catch { };
         };
      };
   }

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  -

   public static string TemplatesFileName = "IconFactory.IconFactory.Templates.ini";
   public static string IniFileName = "IconFactory.ini";
   public List<Icon> Icons { get; private set; }
   public bool Glow { get; set; }

   public bool Load()
   {
      {
         TIniFile IniFile = new TIniFile(IniFileName);
         FileName = IniFile.ReadString("General", "FileName", FileName);
         Glow = IniFile.ReadBool("General", "Glow", Glow);
      };

      // - - -  - - - 

      using (Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(TemplatesFileName))
      using (StreamReader reader = new StreamReader(stream))
      {
         TStrings text = new TStrings();
         text.Text = reader.ReadToEnd();
         text.SaveToFile("Templates.ini");

         TIniFile IniFile = new TIniFile("Templates.ini");
#if PCL
      await IniFile.LoadValues();
#else
         IniFile.LoadValues();
#endif

         TStrings Sections = IniFile.ReadSections();

         Icons.Clear();

         for (int s = 0; s < Sections.Count; s++)
         {
            if (Sections[s].StartsWith("#"))
            {
               TStrings l = IniFile.ReadSectionValues(Sections[s]);

               for (int i = 0; i < l.Count; i++)
               {
                  var o = new Icon();
                  o.Section = Sections[s].Substring(1);
                  o.Name = l.Names(i);

                  string st = l.ValueFromIndex(i);
                  o.Width = int.Parse(st.Split(new char[] { 'x', 'X' })[0]);
                  o.Height = int.Parse(st.Split(new char[] { 'x', 'X', ',' })[1]);

                  if (st.Split(new char[] { 'x', 'X', ',' }).Length > 2)
                  {
                     o.Scale = int.Parse(st.Split(new char[] { 'x', 'X', ',' })[2]);
                  };

                  Application.Current.Dispatcher.Invoke(new Action(() =>
                  {
                     Icons.Add(o);
                  }));
               };
            };
         };

         OnPropertyChanged("Icons");
      };

      return true;
   }

   public bool Save()
   {
      TIniFile IniFile = new TIniFile(IniFileName);

      IniFile.WriteString("General", "FileName", FileName);
      IniFile.WriteBool("General", "Glow", Glow);

      IniFile.UpdateFile();

      return true;
   }

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - - 

   public static void ReadFormPos(Window window, bool PosOnly, bool FromBorder)
   {
      TIniFile IniFile = new TIniFile(IniFileName);
      TStrings Strings = new TStrings();

      if (FromBorder)
      {
         bool AlignLeft = IniFile.ReadBool(window.Name, "AlignLeft", false);
         bool AlignTop = IniFile.ReadBool(window.Name, "AlignTop", false);
         int MarginX = IniFile.ReadInteger(window.Name, "MarginX", 15);
         int MarginY = IniFile.ReadInteger(window.Name, "MarginY", 15);

         if (MarginX < 0) MarginX = 0;
         if (MarginY < 0) MarginY = 0;

         if (AlignLeft)
         {
            window.Left = MarginX;
         }
         else
         {
            window.Left = System.Windows.SystemParameters.PrimaryScreenWidth - window.Width - MarginX;
         };

         if (AlignTop)
         {
            window.Top = MarginY;
         }
         else
         {
            window.Top = System.Windows.SystemParameters.PrimaryScreenHeight - window.Height - MarginY;
         };

         return;
      };

      window.Left = IniFile.ReadInteger(window.Name, "Left", (int)window.Left);
      window.Top = IniFile.ReadInteger(window.Name, "Top", (int)window.Top);

      if (!PosOnly)
      {
         window.Width = IniFile.ReadInteger(window.Name, "Width", (int)window.Width);
         window.Height = IniFile.ReadInteger(window.Name, "Height", (int)window.Height);
      };

      //if (window.Left < 0)
      if (window.Left < System.Windows.SystemParameters.VirtualScreenLeft)
      {
         window.Left = 0;
      };

      //if (window.Top < 0)
      if (window.Top < System.Windows.SystemParameters.VirtualScreenTop)
      {
         window.Top = 0;
      };

      if (!PosOnly)
      {
         if (window.Left > System.Windows.SystemParameters.WorkArea.Width)
         {
            window.Left = System.Windows.SystemParameters.WorkArea.Width - window.Width;
         };

         if (window.Top > System.Windows.SystemParameters.WorkArea.Height)
         {
            window.Top = System.Windows.SystemParameters.WorkArea.Height - window.Height;
         };

         if (window.Width > System.Windows.SystemParameters.WorkArea.Width)
         {
            window.Width = System.Windows.SystemParameters.WorkArea.Width;
         };

         if (window.Height > System.Windows.SystemParameters.WorkArea.Height)
         {
            window.Height = System.Windows.SystemParameters.WorkArea.Height;
         };
      };

      int windowState = IniFile.ReadInteger(window.Name, "WindowState", (int)(WindowState.Normal));

      if (windowState == (int)(WindowState.Maximized))
      {
         window.WindowState = WindowState.Maximized;
      }
   }

   public static void WriteFormPos(Window window, bool FromBorder)
   {
      if (IniFileName != "")
      {
         try
         {
            if (FromBorder)
            {
               bool AlignLeft = true;
               bool AlignTop = true;
               double MarginX = 0;
               double MarginY = 0;

               if ((window.Left + (window.Width / 2)) > System.Windows.SystemParameters.PrimaryScreenWidth / 2)
               {
                  // right border
                  AlignLeft = false;
                  MarginX = System.Windows.SystemParameters.PrimaryScreenWidth - window.Left - window.Width;
               }
               else
               {
                  MarginX = window.Left;
               };

               if ((window.Top + (window.Height / 2)) > System.Windows.SystemParameters.PrimaryScreenHeight / 2)
               {
                  // bottom border
                  AlignTop = false;
                  MarginY = System.Windows.SystemParameters.PrimaryScreenHeight - window.Top - window.Height;
               }
               else
               {
                  MarginY = window.Top;
               };

               TIniFile IniFile = new TIniFile(IniFileName);

               try
               {
                  IniFile.WriteBool(window.Name, "AlignLeft", AlignLeft);
                  IniFile.WriteBool(window.Name, "AlignTop", AlignTop);
                  IniFile.WriteInteger(window.Name, "MarginX", (int)MarginX);
                  IniFile.WriteInteger(window.Name, "MarginY", (int)MarginY);

                  IniFile.UpdateFile();
               }
               catch
               {
                  //on E: Exception do
                  //{
                  //   MessageDlg('Erreur fatale (WriteFormPos): '  + #13 + #10
                  //               + E.Message, mtError, [mbOk], 0);
                  //   Application.Terminate;
                  //};
               };
            }
            else
            {
               {
                  TIniFile IniFile = new TIniFile(IniFileName);

                  try
                  {
                     IniFile.WriteInteger(window.Name, "WindowState", (int)(window.WindowState));
                     IniFile.WriteInteger(window.Name, "Left", (int)window.Left);
                     IniFile.WriteInteger(window.Name, "Top", (int)window.Top);
                     IniFile.WriteInteger(window.Name, "Width", (int)window.Width);
                     IniFile.WriteInteger(window.Name, "Height", (int)window.Height);

                     IniFile.UpdateFile();
                  }
                  catch
                  {
                     //on E: Exception do
                     //{
                     //   MessageDlg('Erreur fatale (WriteFormPos): '  + #13 + #10
                     //               + E.Message, mtError, [mbOk], 0);
                     //   Application.Terminate;
                     //};
                  };
               };
            };
         }
         catch
         {
         };
      };
   }

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  -
   // http://www.codeproject.com/Articles/7122/Dynamically-Generating-Icons-safely
   // http://www.codeproject.com/Articles/16178/IconLib-Icons-Unfolded-MultiIcon-and-Windows-Vista

   //using System.Drawing.IconLib;
   //using System.Drawing.IconLib.ColorProcessing;

   public void SaveIcon(string FileName)
   {
      //Stream IconStream = System.IO.File.OpenWrite(FileName);

      //Bitmap bitmap = new Bitmap(pbImage.Image);
      //bitmap.SetResolution(72, 72);

      //Icon icon = System.Drawing.Icon.FromHandle(bitmap.GetHicon());
      //this.Icon = icon;
      //icon.Save(IconStream);
   }

   // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  -
}
