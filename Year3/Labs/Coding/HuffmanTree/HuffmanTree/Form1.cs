using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HuffmanTree
{
    public partial class Form1 : Form
    {
        private Dictionary<char, double> _symbols;
        private Dictionary<char, double> _periodOfSymbols;
        private Dictionary<char, string> _codeOfSymbols;
        private Dictionary<string, char> _symbolsByCodes;
        private long _countOfSymbols;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Code_Click(object sender, EventArgs e)
        {
            rtb_Output.Clear();
            LB_Codes.Items.Clear();
            CountPeriodOfSymbols();

            var HT = new HuffmanTree(_periodOfSymbols);
            _codeOfSymbols = HT.GetCode();
            _symbolsByCodes = new Dictionary<string, char>();

            var sortedSymbols = _codeOfSymbols.OrderBy(x => x.Key);

            foreach (var item in _codeOfSymbols.OrderBy(x => x.Key))
            {
                LB_Codes.Items.Add($"{item.Key} - {item.Value}");
                _symbolsByCodes.Add(item.Value, item.Key);
            }

            var sb = new StringBuilder();

            foreach (var c in rtb_Input.Text)
                sb.Append(_codeOfSymbols[c]);

            rtb_Output.Text = sb.ToString();

            GetAverageLength();
            GetCompressionDegree();
            GetEntropy();
        }

        private void GetAverageLength()
        {
            double averageLength = 0;

            foreach(var item in _codeOfSymbols)
            {
                var length = item.Value.Length;
                var period = _periodOfSymbols[item.Key];

                averageLength += length * period;
            }

            label_AvLength.Text = $"Средняя длина: {string.Format("{0:0.00}", averageLength)}";
        }

        private void GetCompressionDegree()
        {
            double inputLength = rtb_Input.Text.Length * 8;
            double outputLength = rtb_Output.Text.Length;

            var compressionDegree = inputLength / outputLength;
            var compressionRatio = (1 - outputLength / inputLength) * 100;

            label_CompDegree.Text = $"Текст сжался в {string.Format("{0:0.00}", compressionDegree)} раз";
            label_CompRatio.Text = $"Коэффициент сжатия: {string.Format("{0:0.00}", compressionRatio)} % ";
        }

        private void GetEntropy()
        {
            double entropy = 0;

            foreach(var item in _periodOfSymbols)
            {
                var period = item.Value;

                entropy += period * Math.Log(period, 2);
            }

            label_Entropy.Text = $"Энтропия: {string.Format("{0:0.00}", -entropy)}";
        }

        private void CountPeriodOfSymbols()
        {
            _symbols = new Dictionary<char, double>();
            _periodOfSymbols = new Dictionary<char, double>();
            _countOfSymbols = 0;

            var text = rtb_Input.Text;

            foreach (var c in text)
            {
                if (_symbols.ContainsKey(c))
                    _symbols[c]++;
                else
                    _symbols.Add(c, 1);

                _countOfSymbols++;
            }

            foreach (var item in _symbols)
            {
                var c = item.Key;
                double period = item.Value / _countOfSymbols;

                _periodOfSymbols.Add(c, period);
            }
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
            LB_Codes.Items.Clear();
            label_AvLength.Text = "";
            label_CompDegree.Text = "";
            label_CompRatio.Text = "";
            label_Entropy.Text = "";
        }

        private void btn_Decode_Click(object sender, EventArgs e)
        {
            rtb_Output.Clear();

            var sb = new StringBuilder();
            var inputText = new StringBuilder(rtb_Input.Text);
            var outputText = new StringBuilder();

            while (inputText.Length > 0)
            {
                for (int i = 0; i < inputText.Length; i++)
                {
                    sb.Append(inputText[i]);

                    if (_symbolsByCodes.ContainsKey(sb.ToString()))
                    {
                        outputText.Append(_symbolsByCodes[sb.ToString()]);
                        inputText.Remove(0, sb.Length);
                        sb.Clear();

                        break;
                    }
                }
            }

            rtb_Output.Text = outputText.ToString();
        }
    }
}
