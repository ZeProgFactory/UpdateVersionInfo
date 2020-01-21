//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Data;
//using System.Text;
//using System.Windows.Forms;
//using System.Drawing.Printing;

///// <summary>
///// Print ListView.
///// 
///// 30/12/06 - ME  - Creation based on "PrintableListView".
/////    05/08 - ME  - Use PrintToPrinterHelper
///// 12/06/10 - ME  - Bugfix: OnPrintPage( PrintPageEventArgs e )    
///// 27/06/10 - ME  - Add: Borders, ...    
///// 
///// <para>© 2008..2010 ZePocketForge.com.</para>
///// </summary>

//// http://www.codeproject.com/cs/miscctrl/PrintableListView.asp
//// http://www.codeproject.com/KB/miscctrl/ListViewPrinter.aspx

//public class PrintListView : PrintDocument
//{
//   private int m_nPageNumber=1;
//   private int m_nStartRow=0;
//   private int m_nStartCol=0;

//   private bool _PrintSelectedItems=false;

//   public bool PrintSelectedItems
//   {
//      get { return _PrintSelectedItems; }
//      set { _PrintSelectedItems = value; }
//   }

//   private bool m_bFitToPage=false;

//   private bool _Borders=true;

//   public bool Borders
//   {
//      get { return _Borders; }
//      set { _Borders = value; }
//   }

//   private float m_fListWidth=0.0f;
//   private float[] m_arColsWidth;

//   private float m_fDpi=96.0f;

//   // private string m_strTitle="";

//   public PrintListView()
//   {
//   }

//   ListView _ListView = null;

//   public ListView ListView
//   {
//      get { return _ListView; }
//      set { _ListView = value; }
//   }

//   /// <summary>
//   ///		Gets or sets whether to fit the list width on a single page
//   /// </summary>
//   /// <value>
//   ///		<c>True</c> if you want to scale the list width so it will fit on a single page.
//   /// </value>
//   /// <remarks>
//   ///		If you choose false (the default value), and the list width exceeds the page width, the list
//   ///		will be broken in multiple page.
//   /// </remarks>
//   public bool FitToPage
//   {
//      get { return m_bFitToPage; }
//      set { m_bFitToPage=value; }
//   }

//   protected override void OnBeginPrint( PrintEventArgs e )
//   {
//      PreparePrint();

//      PrintToPrinterHelper.Init();

//      this.DefaultPageSettings = PrintToPrinterHelper.DefaultPageSettings;

//      base.OnBeginPrint( e );
//   }

//   protected override void OnPrintPage( PrintPageEventArgs e )
//   {
//      base.OnPrintPage( e );

//      int nNumItems = GetItemsCount();  // Number of items to print

//      if( nNumItems==0 || m_nStartRow>=nNumItems )
//      {
//         e.HasMorePages = false;
//         return;
//      }

//      int nNextStartCol = 0; 			   // First column exeeding the page width
//      float x = 0.0f;					   // Current horizontal coordinate
//      float y = 0.0f;					   // Current vertical coordinate
//      float cx = 4.0f;                  // The horizontal space, in hundredths of an inch,
//      // of the padding between items text and
//      // their cell boundaries.
//      float fScale = 1.0f;             // Scale factor when fit to page is enabled
//      float fRowHeight = 0.0f;		   // The height of the current row
//      float fColWidth  = 0.0f;		   // The width of the current column

//      RectangleF rectFull;			      // The full available space
//      RectangleF rectBody;			      // Area for the list items

//      bool bUnprintable = false;

//      Graphics g = e.Graphics;

//      if( g.VisibleClipBounds.X<0 )	// Print preview
//      {
//         rectFull = e.MarginBounds;

//         // Convert to hundredths of an inch
//         rectFull = new RectangleF( rectFull.X/m_fDpi*100.0f,
//            rectFull.Y/m_fDpi*100.0f,
//            rectFull.Width/m_fDpi*100.0f,
//            rectFull.Height/m_fDpi*100.0f );
//      }
//      else							// Print
//      {
//         // Printable area (approximately) of the page, taking into account the user margins
//         rectFull = new RectangleF(
//            e.MarginBounds.Left - (e.PageBounds.Width  - g.VisibleClipBounds.Width)/2,
//            e.MarginBounds.Top  - (e.PageBounds.Height - g.VisibleClipBounds.Height)/2,
//            e.MarginBounds.Width,
//            e.MarginBounds.Height );
//      }

//      rectBody = RectangleF.Inflate( rectFull, 0, -2 * _ListView.Font.GetHeight( g ) );

//      //
//      // - - - Draw page top & bottom- - -

//      float PageTop = PrintToPrinterHelper.PrintPageTop( g, rectFull, new Font( _ListView.Font.Name, (int)(_ListView.Font.Size * 2), FontStyle.Bold ), this.DocumentName, false );
//      float PageBottom = PrintToPrinterHelper.PrintPageBottom( g, rectFull, _ListView.Font, m_nPageNumber, false );
//      if( PrintToPrinterHelper.Watermark != "" ) PrintToPrinterHelper.PrintWatermark( e.Graphics, rectFull, PrintToPrinterHelper.Watermark );

//      //
//      // - - -  - - -

//      if( m_nStartCol==0 && m_bFitToPage && m_fListWidth>rectBody.Width )
//      {
//         // Calculate scale factor
//         fScale = rectBody.Width / m_fListWidth;
//      }

//      // Scale the printable area
//      rectFull = new RectangleF( rectFull.X/fScale,
//                        rectFull.Y/fScale,
//                        rectFull.Width/fScale,
//                        rectFull.Height/fScale );

//      rectBody = new RectangleF( rectBody.X/fScale,
//                          rectBody.Y/fScale,
//                          rectBody.Width/fScale,
//                          rectBody.Height/fScale );

//      // Setting scale factor and unit of measure
//      g.ScaleTransform( fScale, fScale );
//      g.PageUnit = GraphicsUnit.Inch;
//      g.PageScale = 0.01f;

//      // Start print
//      nNextStartCol=0;
//      y = rectBody.Top;

//      // Columns headers ----------------------------------------
//      Brush brushHeader = new SolidBrush( Color.LightGray );
//      Font fontHeader = new Font( _ListView.Font, FontStyle.Bold );
//      fRowHeight = fontHeader.GetHeight( g )*3.0f;
//      x = rectBody.Left;

//      for( int i=m_nStartCol; i<_ListView.Columns.Count; i++ )
//      {
//         ColumnHeader ch = _ListView.Columns[ i ];
//         fColWidth = m_arColsWidth[ i ];

//         if( (x + fColWidth) <= rectBody.Right )
//         {
//            // Rectangle

//            if( _Borders )
//            {
//               g.FillRectangle( brushHeader, x, y, fColWidth, fRowHeight );
//               g.DrawRectangle( Pens.Black, x, y, fColWidth, fRowHeight );
//            };

//            // Text
//            StringFormat sf = new StringFormat();
//            if( ch.TextAlign == HorizontalAlignment.Left )
//               sf.Alignment = StringAlignment.Near;
//            else if( ch.TextAlign == HorizontalAlignment.Center )
//               sf.Alignment = StringAlignment.Center;
//            else
//               sf.Alignment = StringAlignment.Far;

//            sf.LineAlignment = StringAlignment.Center;
//            sf.FormatFlags = StringFormatFlags.NoWrap;
//            sf.Trimming = StringTrimming.EllipsisCharacter;

//            RectangleF rectText = new RectangleF( x+cx, y, fColWidth-1-2*cx, fRowHeight );
//            g.DrawString( ch.Text, fontHeader, Brushes.Black, rectText, sf );
//            x += fColWidth;
//         }
//         else
//         {
//            if( i==m_nStartCol )
//               bUnprintable=true;

//            nNextStartCol=i;
//            break;
//         }
//      }

//      y += fRowHeight;

//      // Rows ---------------------------------------------------
//      int nRow = m_nStartRow;
//      bool bEndOfPage = false;
//      string LastGroup = "";

//      while( !bEndOfPage && nRow<nNumItems )
//      {
//         ListViewItem item = GetItem( nRow );

//         fRowHeight = item.Bounds.Height/m_fDpi*100.0f + 5.0f;

//         if( _ListView.ShowGroups )
//         {
//            if( item.Group != null && LastGroup != item.Group.ToString() )
//            {
//               RectangleF rect = rectBody;
//               rect.Y = y;
//               rect.Height = fRowHeight * 2.5f;
//               y += rect.Height;

//               PrintToPrinterHelper.PrintTitle( g, rect, new Font( _ListView.Font.Name, (int)(_ListView.Font.Size * 1.5), FontStyle.Bold ), item.Group.ToString(), item.Group.HeaderAlignment, false );

//               LastGroup = item.Group.ToString();
//            };
//         };

//         if( y+fRowHeight>rectBody.Bottom )
//         {
//            bEndOfPage=true;
//         }
//         else
//         {
//            x = rectBody.Left;

//            for( int i=m_nStartCol; i<_ListView.Columns.Count; i++ )
//            {
//               ColumnHeader ch = _ListView.Columns[ i ];
//               fColWidth = m_arColsWidth[ i ];

//               if( (x + fColWidth) <= rectBody.Right )
//               {
//                  // Rectangle
//                  if( _Borders )
//                  {
//                     g.DrawRectangle( Pens.Black, x, y, fColWidth, fRowHeight );
//                  };

//                  // Text
//                  StringFormat sf = new StringFormat();
//                  if( ch.TextAlign == HorizontalAlignment.Left ) sf.Alignment = StringAlignment.Near;
//                  else if( ch.TextAlign == HorizontalAlignment.Center ) sf.Alignment = StringAlignment.Center;
//                  else sf.Alignment = StringAlignment.Far;

//                  sf.LineAlignment = StringAlignment.Center;
//                  sf.FormatFlags = StringFormatFlags.NoWrap;
//                  sf.Trimming = StringTrimming.EllipsisCharacter;

//                  if( (i == 0) && (_ListView.SmallImageList != null) )
//                  {
//                     // Image
//                     //_ListView.SmallImageList.Draw( g, new Point( (int)(x+cx), (int)(y) ), item.ImageIndex );
//                     g.DrawImage( _ListView.SmallImageList.Images[ item.ImageIndex ], new Point( (int)(x+cx), (int)(y + 3) ) );
//                     x += fColWidth;
//                  }
//                  else
//                  {
//                     // Text
//                     if( i < item.SubItems.Count )
//                     {
//                        string strText = i==0 ? item.Text : item.SubItems[ i ].Text;
//                        Font font = i==0 ? item.Font : item.SubItems[ i ].Font;

//                        RectangleF rectText = new RectangleF( x+cx, y, fColWidth-1-2*cx, fRowHeight );
//                        g.DrawString( strText, font, Brushes.Black, rectText, sf );
//                        x += fColWidth;
//                     };
//                  };

//               }
//               else
//               {
//                  nNextStartCol=i;
//                  break;
//               }
//            }

//            if( _Borders )
//            {
//               y += fRowHeight;
//            }
//            else
//            {
//               // Values for FileSync
//               y += fRowHeight-10;
//            };

//            nRow++;
//         }
//      }

//      if( nNextStartCol==0 )
//         m_nStartRow = nRow;

//      m_nStartCol = nNextStartCol;

//      m_nPageNumber++;

//      e.HasMorePages = (!bUnprintable && (m_nStartRow>0 && m_nStartRow<nNumItems) || m_nStartCol>0);

//      if( PrinterSettings.ToPage > 0 )
//      {
//         e.HasMorePages = e.HasMorePages && (m_nPageNumber < PrinterSettings.ToPage);
//      };

//      if( !e.HasMorePages )
//      {
//         m_nPageNumber=1;
//         m_nStartRow=0;
//         m_nStartCol=0;
//      }

//      brushHeader.Dispose();
//   }

//   //private void PrintPageTop( Graphics g, RectangleF rectFull, string Title )
//   //{
//   //   StringFormat sfmt = new StringFormat();
//   //   sfmt.Alignment = StringAlignment.Center;

//   //   Font font = new Font( _ListView.Font.Name, (int)(_ListView.Font.Size * 1.1), FontStyle.Bold );

//   //   // Display title at top
//   //   g.DrawString( Title, font, Brushes.Black, rectFull, sfmt );
//   //}

//   //private void PrintPageBottom( Graphics g, RectangleF rectFull, int m_nPageNumber )
//   //{
//   //   StringFormat sfmt = new StringFormat();
//   //   sfmt.Alignment = StringAlignment.Center;
//   //   sfmt.LineAlignment = StringAlignment.Far;

//   //   // Display page number at bottom
//   //   g.DrawString( "Page " + m_nPageNumber, _ListView.Font, Brushes.Black, rectFull, sfmt );
//   //}

//   protected override void OnEndPrint( PrintEventArgs e )
//   {
//      base.OnEndPrint( e );
//   }

//   // - - - -

//   private int GetItemsCount()
//   {
//      return _PrintSelectedItems ? _ListView.SelectedItems.Count : _ListView.Items.Count;
//   }

//   private ListViewItem GetItem( int index )
//   {
//      return _PrintSelectedItems ? _ListView.SelectedItems[ index ] : _ListView.Items[ index ];
//   }

//   private void PreparePrint()
//   {
//      // Gets the list width and the columns width in units of hundredths of an inch.
//      this.m_fListWidth = 0.0f;
//      this.m_arColsWidth = new float[ this._ListView.Columns.Count ];

//      Graphics g = _ListView.CreateGraphics();
//      m_fDpi = g.DpiX;
//      g.Dispose();

//      for( int i=0; i < _ListView.Columns.Count; i++ )
//      {
//         ColumnHeader ch = _ListView.Columns[ i ];
//         float fWidth = ch.Width/m_fDpi*100 + 1; // Column width + separator
//         m_fListWidth += fWidth;
//         m_arColsWidth[ i ] = fWidth;
//      }

//      m_fListWidth += 1; // separator
//   }

//   //
//   // - - -  - - - 

//   /// <summary>
//   ///		Show the standard page setup dialog box that lets the user specify
//   ///		margins, page orientation, page sources, and paper sizes.
//   /// </summary>
//   static public void PageSetup()
//   {
//      //m_setupDlg.ShowDialog();
//   }

//   /// <summary>
//   ///		Show the standard print preview dialog box.
//   /// </summary>
//   static public void PrintPreview()
//   {
//      //m_printDoc.DocumentName = "List View";

//      //m_nPageNumber = 1;
//      //m_bPrintSel	  = false;

//      //m_previewDlg.ShowDialog( this );
//   }

//   /// <summary>
//   ///		Start the print process.
//   /// </summary>
//   static public void Print_()
//   {
//      //m_printDlg.AllowSelection = this.SelectedItems.Count>0;

//      //// Show the standard print dialog box, that lets the user select a printer
//      //// and change the settings for that printer.
//      //if( m_printDlg.ShowDialog( this ) == DialogResult.OK )
//      //{
//      //   m_printDoc.DocumentName = m_strTitle;
//      //   m_bPrintSel = m_printDlg.PrinterSettings.PrintRange==PrintRange.Selection;
//      //   m_nPageNumber = 1;

//      //   // Start print
//      //   m_printDoc.Print();
//      //}
//   }

//}
