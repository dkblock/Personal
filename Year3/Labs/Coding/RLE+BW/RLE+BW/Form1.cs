using System;
using System.Linq;
using System.Windows.Forms;

namespace RLE_BW
{
    public partial class Form1 : Form
    {
        private BWConverter _bw;
        private RLEConverter _rle;

        public Form1()
        {
            InitializeComponent();

            _bw = new BWConverter();
            _rle = new RLEConverter();
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

            var bwAnswer = _bw.Encode(rtb_Input.Text);
            var rleAnswer = _rle.Encode(bwAnswer.Key);

            rtb_Output.AppendText($"BW-преобразование: ({bwAnswer.Key} | {bwAnswer.Value})\n");
            rtb_Output.AppendText($"RLE-код: {rleAnswer}");

            GetCompressionDegree(rleAnswer);
        }

        private void btn_DecodeRLE_Click(object sender, EventArgs e)
        {
            rtb_Output.Clear();
            label_CompDegree.Text = "";
            label_CompRatio.Text = "";

            var rleAnswer = _rle.Decode(rtb_Input.Text);

            rtb_Output.AppendText(rleAnswer);
        }

        private void btn_DecodeBW_Click(object sender, EventArgs e)
        {
            rtb_Output.Clear();
            label_CompDegree.Text = "";
            label_CompRatio.Text = "";

            var bwInput = rtb_Input.Text.Split('|');
            bwInput[0] = bwInput[0].Remove(0, 1);
            bwInput[0] = bwInput[0].Remove(bwInput[0].Length - 1, 1);
            bwInput[1] = bwInput[1].Remove(bwInput[1].Length - 1, 1);
            bwInput[1] = bwInput[1].Remove(0, 1);

            var bwAnswer = _bw.Decode(bwInput[0], int.Parse(bwInput[1]));

            rtb_Output.AppendText(bwAnswer);
        }

        private void GetCompressionDegree(string rleCode)
        {
            var dict = _rle.GetSymbolsPeriod(rleCode);
            var maxSize = GetSizeForNumbers(dict.Max(x => x.Value));

            double inputLength = rtb_Input.Text.Length * 8;
            double outputLength = dict.Count * 8 + dict.Count * maxSize;

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
