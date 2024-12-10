using LB_3_blog.Moldes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace LB_3_blog
{
    public partial class FormMain : Form
    {
        //�������� ��������� ��������� ������� ������� ����� �������������
        //��� �������� � ������������ ��������� � �������������
        private BlogContext? db;
        public FormMain()
        {
            InitializeComponent();
        }

        //����� OnLoad ���������� ��� �������� �����
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.db = new BlogContext();

            //����� Load ���������� ������������ ��� �������� ���� ������������� �� �� � BlogContext ���� ������ 
            this.db.Users.Load();
            this.dataGridViewUsers.DataSource = db.Users.Local.ToBindingList();
        }

        //�����  OnClosing ���������� ��� �������� �����
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            this.db?.Dispose();
            this.db = null;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void DataGridViewUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (this.db != null)
            {
                var user = (User)this.dataGridViewUsers.CurrentRow.DataBoundItem;
                if (user != null)
                {
                    this.db.Entry(user).Collection(e => e.Posts).Load();
                }
            }
        }
    }
}
