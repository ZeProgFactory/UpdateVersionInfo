using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics;

namespace ZPF
{
   internal partial class wFindDlg : Form
   {
      /// <summary>
      /// Record of the FindDialog
      /// </summary>

      /// <summary>
      /// Make a simple find dialog
      /// </summary>
      /// <param name="defaultText">Default text for the input box</param>
      /// <param name="formatter">Formatter to read the above</param>
      /// <param name="replaceMode">Start in replace mode?</param>
      /// <param name="offerReplace">Offer the user the chance to switch to Replace mode?</param>
      public wFindDlg( string defaultText, bool replaceMode, bool offerReplace )
      {
         InitializeComponent();

         replaceModeCheckBox.Visible = offerReplace;

         // Populate searchTypeComboBox
         foreach( wFindDlg.SearchType searchType in Enum.GetValues( typeof( wFindDlg.SearchType ) ) )
         {
            // convert StringsThatLookLikeThis to Strings that look like this
            searchTypeComboBox.Items.Add( searchType.ToString()[ 0 ] + Regex.Replace( searchType.ToString().Substring( 1 ), @"(\B[A-Z])", " $1" ).ToLower() );
         }

         searchTypeComboBox.SelectedIndex = 0;

         replaceModeCheckBox.Checked = replaceMode; // apply this attribute here because it can change the size of the form

         //
         // - - -  - - - 

         Point p = _textBox.GetPositionFromCharIndex( _textBox.SelectionStart );
         p = _textBox.PointToScreen( p );

       Left = p.X;
       Top  = p.Y - this.Height - 10;
         if( this.Top < 0 )
         {
          Top  = p.Y + 20;
         };

         //
         // - - -  - - - 

         searchHistoryComboBox.Items.Clear();
         for( int i=0; i < _Find.Count; i++ )
         {
            searchHistoryComboBox.Items.Add( _Find[ i ] );
         };

         replaceHistoryComboBox.Items.Clear();
         for( int i=0; i < _Replace.Count; i++ )
         {
            replaceHistoryComboBox.Items.Add( _Replace.ValueFromIndex( i ) );
         };

         if( defaultText != null )
         {
            searchHistoryComboBox.Text = defaultText;

            if( replaceMode )
            {
               replaceHistoryComboBox.Text = _Replace[ defaultText ];
            };
         }

         Reshow();
      }

      /// <summary>
      /// Search button has been pressed
      /// </summary>
      private void searchButton_Click( object sender, EventArgs e )
      {
         // Add text to history
         if( (searchHistoryComboBox.Items.Count == 0) || !searchHistoryComboBox.Text.Equals( searchHistoryComboBox.Items[ searchHistoryComboBox.Items.Count - 1 ] ) )
         {
            searchHistoryComboBox.Items.Add( searchHistoryComboBox.Text );
         }

         SearchPressed( false );
      }

      /// <summary>
      /// Replace button has been pressed
      /// </summary>
      private void replaceButton_Click( object sender, EventArgs e )
      {
         Debug.WriteLine( "replaceButton_Click" );

         // Add text to history
         if( (replaceHistoryComboBox.Items.Count == 0) || !replaceHistoryComboBox.Text.Equals( replaceHistoryComboBox.Items[ replaceHistoryComboBox.Items.Count - 1 ] ) )
         {
            replaceHistoryComboBox.Items.Add( replaceHistoryComboBox.Text );
         }

         //if( _textBox.SelectedText == searchHistoryComboBox.Text )
         if( SearchPressed( true ) )
         {
            // _textBox.SelectedText = replaceHistoryComboBox.Text;
         };

         if( SearchPressed( false ) )
         {
         };
      }

      static int numberFindAllReplaces = 0;

      /// <summary>
      /// User pressed 'Replace All;
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void replaceAllButton_Click( object sender, EventArgs e )
      {
         Debug.WriteLine( "replaceButton_Click" );
         Canceled = false;

         // Add text to history
         if( (replaceHistoryComboBox.Items.Count == 0) || !replaceHistoryComboBox.Text.Equals( replaceHistoryComboBox.Items[ replaceHistoryComboBox.Items.Count - 1 ] ) )
         {
            replaceHistoryComboBox.Items.Add( replaceHistoryComboBox.Text );
         }

         numberFindAllReplaces = 0;

         do
         {
            if( SearchPressed( true ) )
            {
               numberFindAllReplaces += 1;
            };
         }
         while( SearchPressed( false ) && ! Canceled );

         if( numberFindAllReplaces > 0 )
         {
            MessageBox.Show( String.Format( "{0} occurance(s) replaced", numberFindAllReplaces ));
            numberFindAllReplaces = 0;
         }

         cancelButton.Enabled = true;
      }


      bool Canceled = false;
      /// <summary>
      /// Cancel button clicked
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void cancelButton_Click( object sender, EventArgs e )
      {
         // findDialog.CancelReplace();
         Canceled = true;
         cancelButton.Enabled = false; // cancelled now - can't do it again
      }

      /// <summary>
      /// User is typing in the text string box... make sure label doesn't say 'Find Again' any more
      /// </summary>
      private void searchHistoryComboBox_TextChanged( object sender, EventArgs e )
      {
         // Grey out the search button if there is no text
         if( searchHistoryComboBox.Text.Length > 0 )
         {
            searchButton.Enabled = true;
            replaceButton.Enabled = true;
            replaceAllButton.Enabled = true;
         }
         else
         {
            searchButton.Enabled = false;
            replaceButton.Enabled = false;
            replaceAllButton.Enabled = false;
         }
      }

      /// <summary>
      /// User changed search type... re-enable search button.
      /// </summary>
      private void searchTypeComboBox_SelectedIndexChanged( object sender, EventArgs e )
      {
         //         findDialog.SearchMode = FindDialog.SearchModes.Ready; // re-enable the search state
      }

      /// <summary>
      /// User checked ignore case checkbox... re-enable search button.
      /// </summary>
      private void ignoreCaseCheckBox_CheckedChanged( object sender, EventArgs e )
      {
         //         findDialog.SearchMode = FindDialog.SearchModes.Ready; // re-enable the search state
      }

      /// <summary>
      /// User has pressed a key in the text box
      /// </summary>
      private void FindDialog_KeyDown( object sender, KeyEventArgs e )
      {
         if( (e.KeyCode == Keys.F) && (e.Modifiers == Keys.Control) )
         {
            if( replaceModeCheckBox.Checked )
            {
               // Switch to find mode
               replaceModeCheckBox.Checked = false;
            }
            else
            {
               searchHistoryComboBox.SelectAll(); // Prepare for new text entry
               // findDialog.SearchMode = FindDialog.SearchModes.Ready; // Re-enable search button
            }

            e.SuppressKeyPress = true;
         }

         if( (e.KeyCode == Keys.H) && (e.Modifiers == Keys.Control) )
         {
            if( replaceModeCheckBox.Visible && !replaceModeCheckBox.Checked )
            {
               // Switch to replace mode
               replaceModeCheckBox.Checked = true;
            }
            else
            {
               searchHistoryComboBox.SelectAll(); // Prepare for new text entry
               // findDialog.SearchMode = FindDialog.SearchModes.Ready; // Re-enable search button   
            }

            e.SuppressKeyPress = true;
         }

         if( (e.KeyCode == Keys.A) && (e.Modifiers == Keys.Control) )
         {
            searchHistoryComboBox.SelectAll(); // Select all the text
            e.SuppressKeyPress = true; // Re-enable search button
         }
         else if( (e.KeyCode == Keys.F3) && (e.Modifiers == Keys.None) )
         {
            SearchPressed( false ); // Activate the search
            e.SuppressKeyPress = true;  // Do not process key in parent
         }
         else if( e.KeyCode == Keys.Escape )
         {
            Close();
            e.SuppressKeyPress = true; // Do not process key in parent
         }
      }

      /// <summary>
      /// Invoke a search.
      /// </summary>
      protected bool SearchPressed( bool Replace )
      {
         Debug.WriteLine( "SearchPressed " + Replace.ToString() );

         bool Result = false;

         if( searchButton.Enabled ) // only do if searching is enabled
         {
            string text;

            // Set up the regular expression to search with
            // Using regular expressions allows us massive power to customize search behavior
            // with out having to change the individuals' controls search code.
            RegexOptions options = RegexOptions.None;

            // Ignore case is simply a regular expression parameter
            if( ignoreCaseCheckBox.Checked )
            {
               options |= RegexOptions.IgnoreCase;
            }

            switch( (SearchType)searchTypeComboBox.SelectedIndex )
            {
               case SearchType.RegularExpression:
                  // If user selected Regular Expression, just pass the text directly
                  text = Regex.Escape( searchHistoryComboBox.Text ).Replace( @"\*", ".*" ).Replace( @"\?", "." );
                  break;

               case SearchType.Wildcards:
                  // Escapes the text, then converts wildcard tokens to regex equivalents
                  text = searchHistoryComboBox.Text;
                  break;

               case SearchType.PlainTextSearch:
               default:
                  // Just a plain text search... 'escape' the text so it can be used in the regular expression
                  text = Regex.Escape( searchHistoryComboBox.Text );
                  break;
            }

            Regex searchRegularExpression = null;

            try
            {
               searchRegularExpression = new Regex( text, options );
            }
            catch( Exception exception )
            {
               // relay the error to the user
               MessageBox.Show( this, exception.Message, "Regular expression error" );
            }

            if( searchRegularExpression != null )
            {
               // findDialog.SearchRegularExpression = searchRegularExpression;
               Result = Search( searchRegularExpression, Replace );
               searchHistoryComboBox.SelectAll();
            }
         }

         return Result;
      }

      protected bool Search( Regex SearchRegularExpression, bool Replace )
      {
         Debug.WriteLine( String.Format( "Search ( ...,{0}" , Replace.ToString() ) );

         int startSearch;
         int endSearch;
         int originalSelectionStart;

         if( _textBox.SelectionLength == 0 )
         {
            startSearch = _textBox.SelectionStart;
            endSearch   = _textBox.Text.Length - startSearch;
            endSearch   = _textBox.Text.Length;
            originalSelectionStart = _textBox.SelectionStart;
         }
         else
         {
            if( Replace )
            {
               startSearch = _textBox.SelectionStart;
            }
            else
            {
               startSearch = _textBox.SelectionStart + _textBox.SelectionLength;
            };

            endSearch   = _textBox.Text.Length - startSearch;
            endSearch   = _textBox.Text.Length;
            originalSelectionStart = _textBox.SelectionStart;
         };

         bool match = SubSearch( SearchRegularExpression, startSearch, endSearch, Replace );

         if( !match && endSearch == Text.Length ) // no match? retry from the beginning if the original start position is before or equal to the current search
         {
            // second search is from the start of the document to the original search position (exclusive)

            match = SubSearch( SearchRegularExpression, 0, originalSelectionStart, Replace );

            if( match )
            {
               //               e.RestartedFromDocumentTop = true; // The user is informed that the search started from the top
            }
         }

         if( match )
         {
            //            e.Successful = true;
         }

         return match;
      }

      /// <summary>
      /// Search a sub-portion of the text
      /// </summary>
      internal bool SubSearch( Regex regularExpression, int start, int end, bool Replace )
      {
         Debug.WriteLine( String.Format( "SubSearch ( ...,{0}", Replace.ToString() ) );
         Match match = regularExpression.Match( _textBox.Text, start, end - start );

         if( match.Success )
         {
            // We need to show search results even when the FindDialog is active
            // This means turning off HideSelection if it is set.
            // This unfortunately causes a slight flicker. One way to avoid this is to turn off HideSelection
            // in individual control instances.
            if( _textBox.HideSelection )
            {
               // ensure that the property is restored when the FindDialog is deactivated
             Deactivate += new EventHandler( RestoreHideSelection );
               _textBox.HideSelection = false;
            }

            if( Replace )
            {
               Debug.WriteLine( "SubSearch 1" );
               _textBox.SelectedText = replaceHistoryComboBox.Text;
            }
            else
            {
               Debug.WriteLine( "SubSearch 2" );
               _textBox.Select( match.Index, match.Length );
            };

            try
            {
               _textBox.ScrollToCaret(); // try/caught because this has been known to fail unexpectedly
            }
            catch( Exception exception )
            {
               MessageBox.Show( exception.Message );
            }
            return true;
         }
         else
         {
            return false;
         }
      }

      /// <summary>
      /// Put this control's HideSelection property back to normal when the FindDialog is deactivated
      /// </summary>
      /// <remarks>
      /// This unfortunately causes a slight flicker. One way to avoid this is to turn off HideSelection
      /// in individual control instances.
      /// </remarks>
      void RestoreHideSelection( object sender, EventArgs e )
      {
         _textBox.HideSelection = true;

         _Find.Clear();
         for( int i=0; i < searchHistoryComboBox.Items.Count; i++ )
         {
            _Find.Add( searchHistoryComboBox.Items[ i ].ToString() );
         };

         if( replaceHistoryComboBox.Text != "" )
         {
            _Replace.Add( searchHistoryComboBox.Text + "=" + replaceHistoryComboBox.Text );
         };
      }

      /// <summary>
      /// Bring the dialog to the front and select all the text
      /// </summary>
      public void Reshow()
      {
         Show();
         BringToFront();
         searchHistoryComboBox.SelectAll(); // most Windows dialogs do this
         searchHistoryComboBox.Focus();
      }

      /// <summary>
      /// Search types for the combo box
      /// </summary>
      private enum SearchType
      {
         PlainTextSearch,
         Wildcards,
         RegularExpression
      }

      /// <summary>
      /// A generaral-purpose function to serialise a list to a stream
      /// </summary>
      /// <param name="stream">The stream to write the data into</param>
      /// <param name="formatter">The formatter to use</param>
      /// <param name="list">The list to serialise</param>
      private static void SerializeList( Stream stream, IFormatter formatter, IList list )
      {
         formatter.Serialize( stream, list.Count );
         foreach( object listMember in list )
         {
            formatter.Serialize( stream, listMember );
         }
      }

      /// <summary>
      /// A general-purpose function to deserialize a list from a stream
      /// </summary>
      /// <param name="stream">The stream to read the data from</param>
      /// <param name="formatter">The formatter to use</param>
      /// <param name="list">The list to deserialize</param>
      private static void DeserializeList( Stream stream, IFormatter formatter, IList list )
      {
         int count = (int)formatter.Deserialize( stream );
         for( int idx = 0; idx != count; idx++ )
         {
            list.Add( formatter.Deserialize( stream ) );
         }
         if( count != list.Count )
         {
            throw new Exception( "List did not deserialize to correct size" );
         }
      }

      /// <summary>
      /// Record the user-changable settings and apperance of the form for later restoration
      /// </summary>
      /// <param name="stream">A stream to write the data into</param>
      /// <param name="formatter">The formatter to use</param>
      internal void GetRestoreData( Stream stream, IFormatter formatter )
      {
         formatter.Serialize( stream, Bounds );
         formatter.Serialize( stream, ignoreCaseCheckBox.Checked );
         formatter.Serialize( stream, searchTypeComboBox.SelectedIndex );
         formatter.Serialize( stream, searchHistoryComboBox.Text );
         SerializeList( stream, formatter, searchHistoryComboBox.Items );
         formatter.Serialize( stream, replaceHistoryComboBox.Text );
         SerializeList( stream, formatter, replaceHistoryComboBox.Items );
         formatter.Serialize( stream, replaceModeCheckBox.Checked );
      }

      /// <summary>
      /// Apply the dialog settings that have previously been serialized
      /// </summary>
      /// <param name="stream">The stream to apply the settings from</param>
      /// <param name="formatter">The formatter to use</param>
      private void ApplyRestoreData( Stream stream, IFormatter formatter )
      {
         Bounds = (Rectangle)formatter.Deserialize( stream );
         ignoreCaseCheckBox.Checked = (bool)formatter.Deserialize( stream );
         searchTypeComboBox.SelectedIndex = (int)formatter.Deserialize( stream );
         searchHistoryComboBox.Text = (string)formatter.Deserialize( stream );
         DeserializeList( stream, formatter, searchHistoryComboBox.Items );
         replaceHistoryComboBox.Text = (string)formatter.Deserialize( stream );
         DeserializeList( stream, formatter, replaceHistoryComboBox.Items );
         replaceModeCheckBox.Checked = (bool)formatter.Deserialize( stream );
      }

      /// <summary>
      /// User has switched search/replace mode
      /// </summary>
      private void replaceModeCheckBox_CheckedChanged( object sender, EventArgs e )
      {
         SetAppearanceFromReplaceMode();
      }

      /// <summary>
      /// Is the dialog showing options relating to Find and Replace?
      /// </summary>
      internal bool ReplaceMode
      {
         get
         {
            return replaceModeCheckBox.Checked;
         }
         set
         {
            replaceModeCheckBox.Checked = value;
         }
      }

      /// <summary>
      /// Reposition the dialog elements to the positions appropriate to the search/replace mode
      /// </summary>
      private void SetAppearanceFromReplaceMode()
      {
         if( replaceModeCheckBox.Checked )
         {
            // dress dialog for search/replace mode
            searchButton.Location = new Point( searchButton.Location.X, 24 );
            searchHistoryComboBox.Size = new Size( ClientSize.Width - 96, searchButton.Width );
            label2.Visible = true;
            replaceHistoryComboBox.Visible = true;
            replaceButton.Visible = true;
            replaceAllButton.Visible = true;
            cancelButton.Visible = true;
            MaximumSize = new Size( MaximumSize.Width, int.MaxValue );
            ClientSize = new Size( ClientSize.Width, 130 );
            MinimumSize = new Size( MinimumSize.Width, Size.Height );
            MaximumSize = new Size( MaximumSize.Width, Size.Height );
            Text = "Find and Replace Text";
         }
         else
         {
            // dress dialog for search mode
            searchButton.Location = new Point( searchButton.Location.X, 54 );
            searchHistoryComboBox.Size = new Size( ClientSize.Width - 12, searchHistoryComboBox.Width );
            label2.Visible = false;
            replaceHistoryComboBox.Visible = false;
            replaceButton.Visible = false;
            replaceAllButton.Visible = false;
            cancelButton.Visible = false;
            MinimumSize = new Size( MinimumSize.Width, 0 );
            ClientSize = new Size( ClientSize.Width, 84 );
            MinimumSize = new Size( MinimumSize.Width, Size.Height );
            MaximumSize = new Size( MaximumSize.Width, Size.Height );
            Text = "Find Text";
         }
      }

      static RichTextBox _textBox;
      static TStrings _Find = new TStrings();
      static TStrings _Replace = new TStrings();

      internal static void Find( RichTextBox textBox )
      {
         _textBox = textBox;
         wFindDlg dlg = new wFindDlg( textBox.SelectedText, false, true );

      }

      internal static void Replace( RichTextBox textBox )
      {
         _textBox = textBox;
         wFindDlg dlg = new wFindDlg( textBox.SelectedText, true, true );
      }
   }
}
