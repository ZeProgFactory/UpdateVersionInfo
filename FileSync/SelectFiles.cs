using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FileSync
{
   public partial class SelectFiles : Form
   {
      public SelectFiles()
      {
         InitializeComponent();
      }

      private void buttonFile1_Click( object sender, EventArgs e )
      {
         openFileDialog.FileName = comboBoxFile1.Text;

         try
         {
            openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName( comboBoxFile1.Text );
         }
         catch{};

         if( openFileDialog.ShowDialog() == DialogResult.OK )
         {
            comboBoxFile1.Text = openFileDialog.FileName;
         };
      }

      private void buttonFile2_Click( object sender, EventArgs e )
      {
         openFileDialog.FileName = comboBoxFile2.Text;

         try
         {
            openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName( comboBoxFile2.Text );
         }
         catch {};

         if( openFileDialog.ShowDialog() == DialogResult.OK )
         {
            comboBoxFile2.Text = openFileDialog.FileName;
         };
      }
   }
}