
namespace demka2
{
    public partial class FormAddDelUpd : Form
    {
        string type = "";
        Form1 form1;

        public FormAddDelUpd(string type, Form1 form1)
        {
            InitializeComponent();
            this.type = type;
            this.form1 = form1;
            if (type == "upd")
            {
                textBox6.ReadOnly = false;
                textBox6.Enabled = true;
            }
            if (type == "del")
            {
                textBox6.ReadOnly = false;
                textBox6.Enabled = true;
                textBox1.ReadOnly = true;
                textBox1.Enabled = false;
                textBox2.ReadOnly = true;
                textBox2.Enabled = false;
                textBox3.ReadOnly = true;
                textBox3.Enabled = false;
                textBox4.ReadOnly = true;
                textBox4.Enabled = false;
                textBox5.ReadOnly = true;
                textBox5.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (type == "add")
                {
                    if (textBox1.Text.Trim(' ') != "" && textBox2.Text.Trim(' ') != "" && textBox3.Text.Trim(' ') != "" && textBox4.Text.Trim(' ') != "" && textBox5.Text.Trim(' ') != "")
                    {
                        DBCON.sqlToDbWithChanges($"INSERT INTO public.tovar(name_t, prise, articul, photo, quantity) VALUES ('{textBox1.Text}', {Convert.ToDouble(textBox2.Text)}, '{textBox3.Text}', '{textBox4.Text}', {Convert.ToInt32(textBox5.Text)});");
                        this.Close();
                    }
                }
                if (type == "upd")
                {
                    if (textBox1.Text.Trim(' ') != "" && textBox2.Text.Trim(' ') != "" && textBox3.Text.Trim(' ') != "" && textBox4.Text.Trim(' ') != "" && textBox5.Text.Trim(' ') != "" && textBox6.Text.Trim(' ') != "")
                    {
                        DBCON.sqlToDbWithChanges($"UPDATE public.tovar SET name_t='{textBox1.Text}', prise={Convert.ToDouble(textBox2.Text)}, articul='{textBox3.Text}', photo='{textBox4.Text}', quantity={Convert.ToInt32(textBox5.Text)} WHERE id = {Convert.ToInt32(textBox6.Text)};");
                        this.Close();
                    }
                }
                if (type == "del")
                {
                    if (textBox6.Text.Trim(' ') != "")
                    {
                        DBCON.sqlToDbWithChanges($"DELETE FROM public.tovar WHERE id = {textBox6.Text};");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormAddDelUpd_FormClosed(object sender, FormClosedEventArgs e)
        {
            form1.tovarsToFLP();
        }
    }
}
