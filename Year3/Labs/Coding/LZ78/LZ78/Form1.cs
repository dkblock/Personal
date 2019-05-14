using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LZ78
{
    public partial class Form1 : Form
    {
        private LZ78 _lz78;

        public Form1()
        {
            InitializeComponent();
            _lz78 = new LZ78();
        }

        private void btn_Swap_Click(object sender, EventArgs e)
        {
            rtb_Input.Clear();
            rtb_Input.Text += rtb_Output.Text;
            rtb_Output.Clear();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            rtb_Input.Clear();
            rtb_Output.Clear();
            label_CompDegree.Text = "";
            label_CompRatio.Text = "";
        }

        private void btn_Code_Click(object sender, EventArgs e)
        {
            rtb_Output.Clear();
            _lz78 = new LZ78();

            var answer = _lz78.Encode(rtb_Input.Text);

            for (int i = 0; i < answer.Count; i++)
            {
                for (int j = 1; j < answer[i].Length - 1; j++)
                {
                    rtb_Output.AppendText($"({answer[i][j].Key} , {answer[i][j].Value})\n");
                }
            }

            GetCompressionDegree(answer);
        }

        private void btn_Decode_Click(object sender, EventArgs e)
        {
            rtb_Output.Clear();
            label_CompDegree.Text = "";
            label_CompRatio.Text = "";

            var answer = _lz78.Decode();

            rtb_Output.AppendText(answer);
        }

        private void GetCompressionDegree(List<KeyValuePair<int, string>[]> codeList)
        {
            double inputLength = rtb_Input.Text.Length * 8;
            double outputLength = (GetSizeForNumbers(codeList[0].Max(x => x.Key)) + 8) * (codeList[0].Length - 2);

            var compressionDegree = inputLength / outputLength;
            var compressionRatio = (1 - outputLength / inputLength) * 100;

            label_CompDegree.Text = $"Текст сжался в {string.Format("{0:0.00}", compressionDegree)} раз";
            label_CompRatio.Text = $"Коэффициент сжатия: {string.Format("{0:0.00}", compressionRatio)} % ";
        }

        private int GetSizeForNumbers(int maxNumber)
        {
            return Convert.ToString(maxNumber, 2).Length;
        }
    }
}
