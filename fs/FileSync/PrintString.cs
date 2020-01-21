using System;
using System.Text;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;

/// <summary>
/// Print PrintString.
/// 
/// 30/12/06 - ME  - Creation based on "MultiPadPrintDocument".
/// 
/// <para>© 2006 ZePocketForge.com.</para>
/// </summary>
// http://www.codeproject.com/csharp/multipadprintdocument.asp

/// <example>
/* 
      private void pageSetupToolStripMenuItem_Click( object sender, EventArgs e )
      {
         PrintString ps = new PrintString();
         ps.Text = textEdit.Text;
         ps.Font = textEdit.Font;
         ps.DocumentName = textEdit.FileName;

         pageSetupDialog.Document = ps;
         if( pageSetupDialog.ShowDialog() == DialogResult.OK )
         {
            ps.Print();
         };
      }

      private void printPreviewToolStripMenuItem_Click( object sender, EventArgs e )
      {
         PrintString ps = new PrintString();
         ps.Text = textEdit.Text;
         ps.Font = textEdit.Font;
         ps.DocumentName = textEdit.FileName;

         printPreviewDialog.Document = ps;
         printPreviewDialog.ShowDialog();
      }

      private void printToolStripMenuItem_Click( object sender, EventArgs e )
      {
         PrintString ps = new PrintString();
         ps.Text = textEdit.Text;
         ps.Font = textEdit.Font;
         ps.DocumentName = textEdit.FileName;

         printDialog.Document = ps;
         if ( printDialog.ShowDialog() == DialogResult.OK )
         {
            ps.Print();
         };
      }

*/
///</example>

class PrintString : PrintDocument
{
	String _text = "";
	Font _font = null;
	Int32 _offset = 0;
	Int32 _PageNo = 0;

	public PrintString()
	{
	}

	public String Text
	{
		get { return _text; }
		set { _text = value; }
	}

	public Font Font
	{
		get { return _font; }
		set { _font = value; }
	}

	protected override void OnBeginPrint(PrintEventArgs e)
	{
		_offset = 0;
		_PageNo = 1;

		base.OnBeginPrint(e);
	}

	Boolean NextCharIsNewLine()
	{
		Int32 nl = Environment.NewLine.Length;
		Int32 tl = _text.Length - _offset;

		if (tl < nl) return false;

		String newline = Environment.NewLine;

		for (Int32 i = 0; i < nl; i++) 
      {
			if (_text[_offset + i] != newline[i])
				return false;
		}

		return true;
	}

	const Int32 Eos = -1;
	const Int32 NewLine = -2;

	Int32 NextChar()
	{
		if (_offset >= this._text.Length)
			return -1;

		if (NextCharIsNewLine()) 
      {
			_offset += Environment.NewLine.Length;
			return -2;
		}

		return (Int32)_text[_offset++];
	}

	protected override void OnPrintPage(PrintPageEventArgs e)
	{
		base.OnPrintPage(e);

		Single pagewidth = e.MarginBounds.Width * 3.0f;
		Single pageheight = e.MarginBounds.Height * 3.0f;

		Single textwidth = 0.0f;
		Single textheight = 0.0f;

		Single offsetx = e.MarginBounds.Left * 3.0f;
		Single offsety = e.MarginBounds.Top * 3.0f;

		Single x = offsetx;
		Single y = offsety;

		StringBuilder line = new StringBuilder(256);
		StringFormat sf = StringFormat.GenericTypographic;
		sf.FormatFlags = StringFormatFlags.DisplayFormatControl;
		sf.SetTabStops(0.0f, new Single[]{300.0f});

		RectangleF r;

		Graphics g = e.Graphics;
		g.PageUnit = GraphicsUnit.Document;

		SizeF size = g.MeasureString("X", _font, 1, sf);
		Single lineheight = size.Height;

		// make sure we can print at least 1 line (font too big?)
		if (lineheight + (lineheight * 3) > pageheight) 
      {

			// cannot print at least 1 line and footer
			g.Dispose();

			e.HasMorePages = false;

			return;
		}

		// don't include footer
		pageheight -= lineheight * 3;

		// last whitespace in line buffer
		Int32 lastws = -1;

		// next character
		Int32 c = Eos;

		for (;;) 
      {
         // get next character
			c = NextChar();

			// append c to line if not NewLine or Eos
			if ((c != NewLine) && (c != Eos)) 
         {
				Char ch = Convert.ToChar(c);
				line.Append(ch);

				// if ch is whitespace, remember pos and continue
				if (ch == ' ' || ch == '\t') 
            {
					lastws = line.Length - 1;
					continue;
				}
			}

			// measure string if line is not empty
			if (line.Length > 0) 
         {
				size = g.MeasureString(line.ToString(), _font, Int32.MaxValue, StringFormat.GenericTypographic);
				textwidth = size.Width;
			}

			// draw line if line is full, if NewLine or if last line
			if (c == Eos || (textwidth > pagewidth) || (c == NewLine)) 
         {
				if (textwidth > pagewidth) 
            {
					if (lastws != -1) 
               {
						_offset -= line.Length - lastws - 1;
						line.Length = lastws + 1;
					} 
               else 
               {
						line.Length--;
						_offset--;
					}
				}

				// there's something to draw
				if (line.Length > 0) 
            {
					r = new RectangleF(x, y, pagewidth, lineheight);
					sf.Alignment = StringAlignment.Near;
					g.DrawString(line.ToString(), _font, Brushes.Black, r, sf);
				}

				// increase ypos
				y += lineheight;
				textheight += lineheight;

				// empty line buffer
				line.Length = 0;
				textwidth = 0.0f;
				lastws = -1;
			}

			// if next line doesn't fit on page anymore, exit loop
			if (textheight > (pageheight - lineheight))
				break;

			if (c == Eos)
				break;
		}

		// print footer
		x = offsetx;
		y = offsety + pageheight + (lineheight * 2);
		r = new RectangleF(x, y, pagewidth, lineheight);
		sf.Alignment = StringAlignment.Center;
		g.DrawString(_PageNo.ToString(), _font, Brushes.Black, r, sf);

		g.Dispose();

		_PageNo++;

		e.HasMorePages = (c != Eos);
	}

	protected override void OnEndPrint(PrintEventArgs e)
	{
		base.OnEndPrint(e);
	}

}

