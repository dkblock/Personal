using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;

namespace Arithmetic
{
    public partial class Form1 : Form
    {
        private Arithmetic _ath;

        public Form1()
        {
            InitializeComponent();
            _ath = new Arithmetic();
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
            _ath = new Arithmetic();

            var answer = _ath.Encode(rtb_Input.Text);

            rtb_Output.AppendText(answer);
            GetCompressionDegree();
        }

        private void btn_Decode_Click(object sender, EventArgs e)
        {
            rtb_Output.Clear();
            label_CompDegree.Text = "";
            label_CompRatio.Text = "";

            var answer = _ath.Decode(rtb_Input.Text);

            rtb_Output.AppendText(answer);
        }

        private void GetCompressionDegree()
        {
            double inputLength = rtb_Input.Text.Length * 8;
            double outputLength = GetSize(rtb_Output.Text);

            var compressionDegree = inputLength / outputLength;
            var compressionRatio = (1 - outputLength / inputLength) * 100;

            label_CompDegree.Text = $"Текст сжался в {string.Format("{0:0.00}", compressionDegree)} раз";
            label_CompRatio.Text = $"Коэффициент сжатия: {string.Format("{0:0.00}", compressionRatio)} % ";
        }

        private int GetSize(string code)
        {
            var number = BigInteger.Parse(code);
            var binlen = 2;
            var pow = 1;

            while (binlen <= number)
            {
                pow++;
                binlen *= 2;
            }

            return pow * 2;
        }
    }
}
