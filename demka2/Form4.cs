
namespace demka2
{
    public partial class Form4 : Form
    {
        string rigthText = "";
        Form3 f3;

        public Form4(Form3 f3)
        {
            InitializeComponent();
            pictureBox1.Image = capcha(pictureBox1.Width, pictureBox1.Height);
            this.f3 = f3;
        }

        public Bitmap capcha(int width, int height)
        {
            Random rnd = new Random();

            Bitmap bmp = new Bitmap(width, height);

            Graphics g = Graphics.FromImage(bmp);

            double xpos = width * 0.2;
            double ypos = height * 0.2;

            string nums = "1234567890";
            string letters = "QWERTYUIOPASDFGHJKLZXCVBNM";
            string text = "";

            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    text += letters[rnd.Next(letters.Length)];
                }
                else
                {
                    text += nums[rnd.Next(nums.Length)];
                }
            }

            rigthText = text;

            g.DrawString(text,
                         new Font("Times New Roman", 25),
                         Brushes.Aqua,
                         new PointF(Convert.ToInt32(xpos), Convert.ToInt32(ypos)));

            return bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == rigthText)
            {
                this.Close();
            }
            else
            {
                pictureBox1.Image = capcha(pictureBox1.Width, pictureBox1.Height);
            }
        }
    }
}
