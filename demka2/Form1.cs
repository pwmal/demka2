namespace demka2
{
    public partial class Form1 : Form
    {
        int endpage = 1;
        int currentMinPage = 0;
        int currentPage = 1;
        string sqlCommand = "SELECT * FROM tovar ORDER BY id ASC";


        public Form1(string str)
        {
            InitializeComponent();
            this.label1.Text = str;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pagesToFLP();
            tovarsToFLP();
            comboBox1.Items.AddRange(new string[] { "Тип1", "Тип2" });
            comboBox2.Items.AddRange(new string[] { "ASC", "DESC" });
        }

        public void setEndPage()
        {
            List<tovar> list = DBCON.getSelectedTovars(sqlCommand);
            if (list.Count % 5 != 0)
            {
                endpage = list.Count / 5 + 1;
            }
            else
            {
                endpage = list.Count / 5;
            }
        }

        public void labelChangePage_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            if (label.Text == "<")
            {
                if (currentMinPage != 0)
                {
                    currentMinPage--;
                    pagesToFLP();
                }
            }
            else if (label.Text == ">")
            {
                if (currentMinPage + 4 < endpage)
                {
                    currentMinPage++;
                    pagesToFLP();
                }
            }
            else
            {
                currentPage = Convert.ToInt32(label.Text);
                tovarsToFLP();
            }
        }

        public void pagesToFLP()
        {
            flowLayoutPanel2.Controls.Clear();
            Label label = new Label();
            label.Size = new Size(15, 15);
            label.Text = "<";
            label.Click += labelChangePage_Click;
            flowLayoutPanel2.Controls.Add(label);
            for (int i = 0 + currentMinPage; i < 4 + currentMinPage; i++)
            {
                label = new Label();
                label.Size = new Size(25, 25);
                label.Text = $"{i + 1}";
                label.Click += labelChangePage_Click;
                flowLayoutPanel2.Controls.Add(label);
            }
            label = new Label();
            label.Size = new Size(15, 15);
            label.Text = ">";
            label.Click += labelChangePage_Click;
            flowLayoutPanel2.Controls.Add(label);
        }

        public void tovarsToFLP()
        {
            flowLayoutPanel1.Controls.Clear();
            int iEnd = 5;
            setEndPage();
            List<tovar> list = DBCON.getSelectedTovars(sqlCommand);
            if (currentPage == endpage)
            {
                if (list.Count % 5 != 0)
                {
                    iEnd = list.Count % 5;
                }
            }
            if (currentPage > endpage)
            {
                iEnd = 0;
            }

            for (int i = 0 + (5 * (currentPage - 1)); i < iEnd + (5 * (currentPage - 1)); i++)
            {
                UserControlTovar uct = new UserControlTovar();
                uct.Size = new Size(589, 150);
                uct.id = list[i].id;
                uct.labelName.Text = list[i].name_t.ToString();
                uct.labelPrice.Text = list[i].price.ToString();
                uct.labelArt.Text = list[i].articul.ToString();

                if (list[i].photo.StartsWith("\\"))
                {
                    uct.pictureBox1.ImageLocation = $"C:\\Users\\USER_2.1\\Desktop\\Выходной ДЭ{list[i].photo}";
                }
                else
                {
                    uct.pictureBox1.ImageLocation = "C:\\Users\\USER_2.1\\Desktop\\Выходной ДЭ\\picture.jpg";
                }

                uct.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                flowLayoutPanel1.Controls.Add(uct);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAddDelUpd f2 = new FormAddDelUpd("add", this);
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormAddDelUpd f2 = new FormAddDelUpd("upd", this);
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormAddDelUpd f2 = new FormAddDelUpd("del", this);
            f2.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void Search()
        {
            string main = "SELECT * FROM product";
            bool where = false;
            string searchLetters = "";
            string sortType = "";
            string result = "";

            if (textBox1.Text != "")
            {
                sqlCommand = $"SELECT EXISTS ({main} WHERE name_t ILIKE '%{textBox1.Text}%');";
                DBCON.sqlToDb(sqlCommand);
                if (DBCON.dt.Rows[0][0].ToString() == "True")
                {
                    searchLetters = $" title ILIKE '%{textBox1.Text}%'";
                    where = true;
                }
            }

            switch (comboBox2.SelectedIndex)
            {
                case -1:
                    sortType = " ORDER BY ID ASC";
                    break;
                case 0:
                    sortType = " ORDER BY ID ASC";
                    break;
                case 1:
                    sortType = " ORDER BY ID DESC";
                    break;
            }


            if (where)
            {
                result = $"{main} WHERE {searchLetters} {sortType}";
            }
            else
            {
                result = $"{main} {sortType}";
            }

            sqlCommand = result;
            tovarsToFLP();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}
