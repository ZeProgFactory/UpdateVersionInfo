using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using ZPF;

namespace FileSync
{
   class CompareFiles
   {
      // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

      const int EqualLines = 4;
      const string DiffSign = "#";
      const bool DoTrimRight = true;
      const bool DoTrimLeft = true;

      // Die beiden Textdateien; Datei[1] wird in der ersten Spalte von 'Grid' angezeigt, 
      // Datei[2] in der zweiten. 
      // Datei : array[1..2] of Textfile;  
      static TStrings Lines;
      static TStrings File1;
      static TStrings File2;

      // 'Last[i]" ist die letzte belegte Zeile in der Spalte i von 'Grid'. 
      // Darin steht also die letzte aus Datei[i] gelesene Zeile. 
      // static int[] Last = new int[ 2 + 1 ];

      // Die letzte Zeile von 'Grid', in der die beiden Spalten übereinstimmen. 
      static int LastEqualLine;  // sync;

      // Die aktuelle Zeilennummer (die in der Spalte 0 von 'Grid' angezeigt wird). 
      static int Nr;

      static string _FileName1;
      static string _FileName2;

      // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
      // ---------- Vergleichsoperationen 

      static void InsertEmptyCells(int col, int row, int num)
      {
         for (int i = 0; i < num; i++)
         {
            if (col == 1)
            {
               File1.Insert(row, "");
            }
            else
            {
               File2.Insert(row, "");
            };
         };

         //int i;

         //if( Last[ col ] + num >= Grid.RowCount )
         //{
         //   Grid.RowCount = Last[ col ] + num +1;
         //}

         //// for ( i = Last[col] downto row )
         //for( i = Last[ col ]; i >row; i-- )
         //{
         //   Grid.Cells[ col, i+num ] = Grid.Cells[ col, i ];
         //   Grid.Cells[ col, i ] = "";

         //   if( col=1 )
         //   {
         //      Grid.Cells[ 0, i+num ]  = Grid.Cells[ 0, i ];
         //      Grid.Cells[ 0, i ]      = DiffSign;
         //   }
         //}

         //Inc( Last[ col ], num );

         //if( Last[ col ]>=Grid.RowCount )
         //{
         //   Grid.RowCount = Last[ col ]+1;
         //}
      }
      /*
            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            // ---------- Vergleich beenden
            // Wenn aus irgendeinem Grund nicht mehr weiter syncronisier werden kann, dann schließt
            // diese Methode den Dateivergleich ab: Alle Zeilen nach 'sync' werden als abweichend
            // markiert. 

            static void Beenden()
            {
               int p;

               if( !EoF( Datei[ 1 ] ) ) ReadLines( 1, 30000 );
               if( !EoF( Datei[ 2 ] ) ) ReadLines( 2, 30000 );

               for( int p = sync+1; GAIS <= Grid.RowCount; p++ )
               {
                  Grid.Cells[ 0, p ] = DiffSign + Copy( Grid.Cells[ 0, p ], 2, 20 );
               };
            }
*/
      // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
      // Solange Zeilenweise mit der Marke 'LastEqualLine' weiterlaufen, bis eine Abweichung entdeckt
      // wird. 'LastEqualLine' wird dann auf die letzte übereinstimmende Zeile gesetzt.
      // Falls ein Syncronisieren der Dateien sicher nicht möglich ist (weil mindestens
      // eine der Dateien endet), dann wird 'false' sonst 'true' zurückgegeben. 

      static bool ReadUntilDiff()
      {
         bool Result = false;

         if ((LastEqualLine < File1.Count) && ((LastEqualLine < File2.Count)))
         {
            do
            {
               Lines.Add("=");
               LastEqualLine += 1;
            }
            while (
                     (LastEqualLine < File1.Count)
                  && (LastEqualLine < File2.Count)
                  && (GetCell(1, LastEqualLine) == GetCell(2, LastEqualLine))
                  );

            // Jetzt gibt's zwei Möglichkeiten
            //   1) Es wurde eine Abweichung gefunden und es sind noch Zeilen in den Dateien, so das ein
            //      Versuch zum Syncronisieren gestartet werden kann.
            //   2) Die Schleife wurde beendet, aber weil in einer Datei keine Zeilen mehr sind. 

            if ((LastEqualLine >= File1.Count) || (LastEqualLine >= File2.Count))
            {
               if (GetCell(1, LastEqualLine) != GetCell(2, LastEqualLine))
               {
                  LastEqualLine -= 1;
               };
            }
            else
            {
               LastEqualLine -= 1;
               Result = true;
            };
         }

         return Result;
      }
      // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

      static int SearchLines(int c1, int r1, int c2, int r2a, int r2b)
      {
         int SearchCount;

         do
         {
            SearchCount = 0;

            while (
                     (SearchCount < EqualLines)
                     && (GetCell(c1, r1 + SearchCount) == GetCell(c2, r2a + SearchCount))
                  )
            {
               SearchCount += 1;
            };

            r2a += 1;
         }
         while ((SearchCount < EqualLines) && (r2a <= r2b));

         if (SearchCount == EqualLines)
         {
            return r2a - 1;
         }
         else
         {
            return -1;
         };
      }

      // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

      static bool ReSync()
      {
         bool Result = true;

         // inv : array[1..2] of int = (2, 1);
         int[] inv = new int[3];
         inv[1] = 2;
         inv[2] = 1;

         int[] Marker = new int[3];
         bool[] Ende = new bool[3];

         int c, p;

         // Die beiden "Marker" M[1] und M[2] geben an, bis zu welcher Zeile im Gitter das Programm
         // schaut, um 'EqualLines' übereinstimmende Zeilen nach der Zeile 'LastEqualLine' zu finden. 
         Marker[1] = LastEqualLine + EqualLines;
         Marker[2] = LastEqualLine + EqualLines;

         // Im Gitter müssen sich mindestens soviele Zeilen finden, wie die Marker angeben; ggf. müssen
         // weitere Zeilen eingelesen werden. Es ist aber (durch vorangegangenes Einfügen von Zeilen) auch
         // möglich, daß sich in einer oder beiden Spalten schon genug oder sogar mehr Zeilen befinden. 
         //if( Marker[ 1 ]> Last[ 1 ] ) ReadLines( 1, Marker[ 1 ]-Last[ 1 ] );
         //if( Marker[ 2 ]> Last[ 2 ] ) ReadLines( 2, Marker[ 2 ]-Last[ 2 ] );

         // Wenn eine der Dateien nicht mehr genug Zeilen enthält, dann muß die Suche abgebrochen werden. 
         if ((Marker[1] >= File1.Count) || (Marker[2] >= File2.Count))
         {
            return false;
         }

         Ende[1] = (Marker[1] >= File1.Count);
         Ende[2] = (Marker[2] >= File2.Count);

         if (Ende[1])
         {
            c = 2;
         }
         else
         {
            c = 1;
         };

         p = -1;

         while ((p < 0) && (!Ende[1] || !Ende[2]))
         {
            // Marker eine Zeile weitersetzen; ggf. eine Zeile einlesen. 
            Marker[c] += 1;
            //if( Marker[ c ]>Last[ c ] ) ReadLines( c, 1 );

            // Testen, ob das Ende der Datei erreicht ist. 
            Ende[c] = (Marker[c] == (c == 1 ? File1.Count : File2.Count));

            // Prüfen, ob syncronisiert werden kann. 
            p = SearchLines(c, Marker[c] - EqualLines + 1, inv[c], LastEqualLine + 1, Marker[inv[c]] - EqualLines + 1);

            // Wenn das Ende der anderen Datei noch nicht erreicht ist: Übergeben 
            if ((p < 0) && !Ende[inv[c]])
            {
               c = inv[c];
            };
         }

         if (p > 0)
         {
            if (Marker[c] - EqualLines + 1 - p > 0)
            {
               InsertEmptyCells(inv[c], p, Marker[c] - EqualLines + 1 - p);
            };

            for (int i = LastEqualLine + 1; i <= Marker[c] - EqualLines; i++)
            {
               if (i >= Lines.Count)
               {
                  while (i >= Lines.Count)
                  {
                     Lines.Add(" ");
                  };
               };

               Lines[i] = DiffSign;
               //Lines[ i ] = ( c == 1 ? "<" : ">" );
            };

            LastEqualLine = Marker[c];
         }
         else
         {
            for (int i = LastEqualLine + 1; i < Math.Max(File1.Count, File2.Count); i++)
            {
               while (i >= Lines.Count)
               {
                  Lines.Add(" ");
               };

               Lines[i] = DiffSign;
            };

            Result = false;
         }

         return Result;
      }

      // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

      static public void Exec(TStrings _Lines, TStrings Text1, TStrings Text2)
      {
         bool Continue;

         Lines = _Lines;
         File1 = Text1;
         File2 = Text2;

         //ToDo: //ToDo: Basics.ShowWaitCursor(true);

         try
         {
            //
            // - - -  - - -

            //Last[ 1 ]      = 0;
            //Last[ 2 ]      = 0;
            LastEqualLine = 0;
            Nr = 0;

            Continue = true;

            while (Continue)
            {
               Continue = ReadUntilDiff();

               if (Continue)
               {
                  Continue = ReSync();
               }
            }

            //if( !Continue ) Beenden();
         }
         finally
         {
         }

         while (Lines.Count < File1.Count)
         {
            Lines.Add("=");
         };

         while (Lines.Count < File2.Count)
         {
            Lines.Add("=");
         };

         for (int i = 0; i < Lines.Count; i++)
         {
            try
            {
               if ((Lines[i] == "#") && (File1.GetObject(i) == null)) Lines[i] = ">";
            }
            catch
            {
               Lines[i] = ">";
            };

            try
            {
               if ((Lines[i] == "#") && (File2.GetObject(i) == null)) Lines[i] = "<";
            }
            catch
            {
               Lines[i] = "<";
            };
         };

         //ToDo: Basics.ShowWaitCursor(false);
      }

      // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

      static String GetCell(int Col, int Row)
      {
         string Result = "";

         switch (Col)
         {
            case 0:
               {
                  if (Row < Lines.Count)
                  {
                     Result = Lines[Row].ToString();
                  }
                  else
                  {
                     Result = "";
                  };
                  break;
               };
            case 1:
               {
                  if (Row < File1.Count)
                  {
                     Result = File1[Row].ToString();
                  }
                  else
                  {
                     Result = "";
                  };
                  break;
               };
            case 2:
               {
                  if (Row < File2.Count)
                  {
                     Result = File2[Row].ToString();
                  }
                  else
                  {
                     Result = "";
                  };
                  break;
               };
         };

         if (DoTrimLeft)
         {
            Result = Result.Trim();
         }

         return Result;
      }
   } // Class

   // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

} // NameSpace
