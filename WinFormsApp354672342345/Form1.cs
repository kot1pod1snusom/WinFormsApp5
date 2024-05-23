using System.Net.Http.Headers;

namespace WinFormsApp354672342345
{
    public partial class Form1 : Form
    {
        PicrtureWork picture = new PicrtureWork();
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(picture.picturesPath[0]);
            listBox1.Items.AddRange(picture.picturesNames);
            trackBar1.Maximum = listBox1.Items.Count - 1;
        }


        private void picture_left_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(picture.PictureLeft());
        }

        private void picture_right_Click(object sender, EventArgs e)
        {

            pictureBox1.Image = Image.FromFile(picture.PictureRight());
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(picture.ChousePicture(listBox1.SelectedIndex));
        }

        private void directoryChange_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(picture.ChangeDirectory(dialog.SelectedPath));

                listBox1.Items.Clear();
                listBox1.Items.AddRange(picture.picturesNames);
                trackBar1.Maximum = listBox1.Items.Count - 1;
            }
            


        }
    }
}


class PicrtureWork
{
    public string[] picturesPath;
    public string[] picturesNames;
    public int index = 0;
    public PicrtureWork()
    {
        string[] picturesJPG = Directory.GetFiles("C:\\Users\\Студент.TOP\\Desktop\\криснелох", "*.jpg");
        string[] picturesPNG = Directory.GetFiles("C:\\Users\\Студент.TOP\\Desktop\\криснелох", "*.png");
        string[] picturesJPEG = Directory.GetFiles("C:\\Users\\Студент.TOP\\Desktop\\криснелох", "*.jpeg");

        picturesPath = new[] { picturesJPG, picturesPNG, picturesJPEG }.SelectMany(item => item).ToArray();

        picturesNames = new string[picturesPath.Length];
        for (int i = 0; i < picturesPath.Length; i++)
        {
            picturesNames[i] = Path.GetFileName(picturesPath[i]);
        }
    }

    public string ChangeDirectory(string path)
    {
        string[] picturesJPG = Directory.GetFiles(path, "*.jpg");
        string[] picturesPNG = Directory.GetFiles(path, "*.png");
        string[] picturesJPEG = Directory.GetFiles(path, "*.jpeg");

        picturesPath = new[] { picturesJPG, picturesPNG, picturesJPEG }.SelectMany(item => item).ToArray();

        picturesNames = new string[picturesPath.Length];
        for (int i = 0; i < picturesPath.Length; i++)
        {
            picturesNames[i] = Path.GetFileName(picturesPath[i]);
        }

        return picturesPath[0];
    }

    public string ChousePicture(int index)
    {
        this.index = index;
        return picturesPath[index];
    }

    public string PictureLeft()
    {
        if (index == 0)
        {
            index = picturesPath.Length - 1;
            return picturesPath[index];
        }
        else
        {
            index--;
            return picturesPath[index];
        }

    }

    public string PictureRight()
    {
        if (index == (picturesPath.Length - 1))
        {
            index = 0;
            return picturesPath[index];
        }
        else
        {
            index++;
            return picturesPath[index];
        }
    }

}