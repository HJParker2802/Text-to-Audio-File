using System.Speech.Synthesis;

namespace TextToSpeechFile
{

    public partial class Form1 : Form
    {
        SpeechSynthesizer SpeechS;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            SpeechS = new SpeechSynthesizer();
            //SpeechS.SpeakAsync(textBox1.Text);

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Wave Files |  *.wav";
            sfd.ShowDialog();
            string fname;
            fname = sfd.FileName;
            SpeechSynthesizer ss = new SpeechSynthesizer();
            if (fname == "")
            {
                MessageBox.Show("No location path selected. Please try again and select a path!");
            }
            else
            {
                SpeechS.SetOutputToWaveFile(fname);
                SpeechS.Speak(TBox_TTS.Text);
                SpeechS.SetOutputToDefaultAudioDevice();
                MessageBox.Show("Text recorded as wave file");
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "text files| *.txt";
            ofd.ShowDialog();
            string fname = ofd.FileName;
            if (fname == "")
            {
                MessageBox.Show("No location path selected. Please try again and select a path!");
            }
            else
            {
                StreamReader sr = new StreamReader(fname);
                TBox_TTS.Text = sr.ReadToEnd();
                sr.Close();
            }
        }
    }
}