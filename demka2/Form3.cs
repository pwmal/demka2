
namespace demka2
{
    public partial class Form3 : Form
    {
        int capchacount = 0;

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim(' ') != "" && textBox2.Text.Trim(' ') != "")
                {
                    DBCON.sqlToDb($"SELECT * FROM users WHERE login_user = '{textBox1.Text}'");
                    string login = DBCON.dt.Rows[0][2].ToString();
                    string password = DBCON.dt.Rows[0][3].ToString();
                    if (login == textBox1.Text && password == textBox2.Text)
                    {
                        this.Hide();
                        Form1 f1 = new Form1(login);
                        f1.ShowDialog();
                    }
                    else
                    {
                        throw new Exception("InputError");
                    }
                }
                else
                {
                    throw new Exception("InputError");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "InputError")
                {
                    capchacount++;
                    if (capchacount == 3)
                    {
                        Form4 f4 = new Form4(this);
                        f4.ShowDialog();
                        textBox1.ReadOnly = true;
                        textBox1.Enabled = false;
                        textBox2.ReadOnly = true;
                        textBox2.Enabled = false;
                        this.Enabled = false;
                        System.Threading.Thread.Sleep(30000);
                        textBox1.ReadOnly = false;
                        textBox1.Enabled = true;
                        textBox2.ReadOnly = false;
                        textBox2.Enabled = true;
                        this.Enabled = true;
                    }
                    if (capchacount > 3) 
                    {
                        Application.Exit();
                    }
                }
            }
        }
    }
}
