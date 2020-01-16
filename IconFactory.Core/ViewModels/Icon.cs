using ZPF;

public class Icon : BaseViewModel
{
   public Icon()
   {
      Scale = 100;
   }

   public int Height { get; internal set; }
   public string Name { get; internal set; }
   public string Section { get; internal set; }
   public int Width { get; internal set; }
   public int Scale { get; internal set; }


   public string DisplayInfos
   {
      get
      {
         if (Scale == 100)
         {
            return string.Format("{0}x{1}", Width, Height );
         }
         else
         {
            return string.Format("{0}x{1},{2}", Width, Height, Scale);
         };
      }
   }

   bool _Selected = true;
   public bool Selected
   {
      get { return _Selected; }
      set { SetField(ref _Selected, value); }
   }
}