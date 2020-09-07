using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace testSudoku
{
    public partial class Form1 : Form
    {
        public TextBox tb ;
        public int depth = 0;
        List<int> sudo;
        public Form1()
        {
            InitializeComponent();
            tb = new TextBox()
            {
                Location = new Point(1, 1),
                Size = new Size(500, 500),
                Font = new Font("Consolas", 20.0F),
                Multiline = true
            };
            this.Controls.Add(tb);
            sudo = new List<int>() {
                8, 0, 0, 4, 0, 6, 0, 0, 7,
                0, 0, 0, 0, 0, 0, 4, 0, 0,
                0, 1, 0, 0, 0, 0, 6, 5, 0,
                5, 0, 9, 0, 3, 0, 7, 8, 0,
                0, 0, 0, 0, 7, 0, 0, 0, 0,
                0, 4, 8, 0, 2, 0, 1, 0, 3,
                0, 5, 2, 0, 0, 0, 0, 9, 0, 
                0, 0, 1, 0, 0, 0, 0, 0, 0,
                3, 0, 0, 9, 0, 2, 0, 0, 5 };

            //tb.Text = Acceptable(sudo, 1, 9).ToString();
            
            this.Shown += Form1_Shown;
            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            SolveSudoku(sudo);
        }

        public bool Acceptable(List<int> sudoku, int pos, int num)
        {
            //if (sudoku[pos] != 0) return false;


            for(int i = 0; i<81; i++)
            {
                if (i / 9 == pos / 9 && sudoku[i] == num) return false;
                if (i % 9 == pos % 9 && sudoku[i] == num) return false;
                if (i / 9 / 3 == pos / 9 / 3 && i % 9 / 3 == pos % 9 / 3 && sudoku[i] == num) return false;
            }
            return true;
        }

        public void SolveSudoku(List<int> sudoku)
        {
            depth++;
            for (int pos = 0; pos < 81; pos++)
            {
                if (sudoku[pos] == 0)
                {
                    for (int val = 1; val < 10; val++)
                    {

                        if (Acceptable(sudoku, pos, val))
                        {
                            sudoku[pos] = val;
                            tb.Text = PrintSudoku(sudoku);
                            tb.Refresh();
                            Thread.Sleep(100);
                            SolveSudoku(sudoku);
                            depth--;
                            sudoku[pos] = 0;
                        }
                    }
                    return;
                }
                    
            }
            tb.Text = PrintSudoku(sudoku);
        }
        public string PrintSudoku(List<int> sudoku)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 1; i <82; i++)
            {
                sb.Append(sudoku[i - 1] == 0 ? " " : sudoku[i - 1].ToString());
                sb.Append(" ");

                if (i % 9 == 0)
                    sb.Append(Environment.NewLine);
                else if (i % 3 == 0)
                    sb.Append("| ");

                if (i % 27 == 0)
                    sb.Append("- - -   - - -   - - - "+ Environment.NewLine);
            }
            return sb.ToString();
        }

    }
}
