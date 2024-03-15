
namespace demka2
{
    public partial class UserControlTovar : UserControl
    {
        public int id;

        public UserControlTovar()
        {
            InitializeComponent();
        }

        private void UserControlTovar_Click(object sender, EventArgs e)
        {
            UserControlTovar uct = (UserControlTovar)sender;
            if (uct.BackColor != Color.AliceBlue)
            {
                uct.BackColor = Color.AliceBlue;
            }
            else
            {
                uct.BackColor = Color.White;
            }
        }
    }
}
