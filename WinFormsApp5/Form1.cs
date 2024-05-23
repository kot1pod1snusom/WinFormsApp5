using Microsoft.VisualBasic.ApplicationServices;
using System.Media;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Windows.Forms.VisualStyles;

namespace WinFormsApp5
{
    public partial class Form1 : Form
    {
        PicrtureWork picture = new PicrtureWork();
        public Form1()
        {
            InitializeComponent();
            List<string> list = new List<string>() {"STALIN", "GITLER", "PUTIN" };
            comboBox1.DataSource = list;
            pictureBox1.Image = Image.FromFile(picture.pictures[0]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = "megakharosh.wav";
            player.Play();

            button1.Text = "ХАРОООООШ";
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(listBox1.SelectedItem.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string str = textBox1.Text;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.Items[i].ToString() == str)
                {
                    MessageBox.Show($"Имя {str} уже существует");
                    return;
                }
            }
             
            listBox1.Items.Add(str);
            button2.Text = "ПРОЖАТО";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void picture_left_Click(object sender, EventArgs e)
        {

            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = "siiiiiiiiiiu.wav";
            player.Play();

            pictureBox1.Image = Image.FromFile(picture.PictureLeft());
        }

        private void picture_right_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = "siiiiiiiiiiu.wav";
            player.Play();

            pictureBox1.Image = Image.FromFile(picture.PictureRight());
        }

    }
}


class PicrtureWork
{
    public string[] pictures;
    public int index = 0;
    public PicrtureWork()
    {
        pictures = Directory.GetFiles("C:\\Users\\Студент.TOP\\Desktop\\криснелох");


    }

    public string PictureLeft()
    {
        if (index == 0)
        {
            index = pictures.Length - 1;
            return pictures[index];
        }
        else
        {
            index--;
            return pictures[index];
        }

    }

    public string PictureRight()
    {
        if (index == (pictures.Length - 1))
        {
            index = 0;
            return pictures[index];
        }
        else
        {
            index++;
            return pictures[index];
        }
    }

}


