using LB_3_blog.Moldes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace LB_3_blog
{
    public partial class FormMain : Form
    {
        //Создаётся экземпляр контекста данныхБ который будет отслеживаться
        //для загрузки и отслеживания изменений о пользователях
        private BlogContext? db;
        public FormMain()
        {
            InitializeComponent();
        }

        //Метод OnLoad вызывается при загрузке формы
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.db = new BlogContext();

            //Метод Load расширения используется для загрузки всех пользователей из БД в BlogContext базу данных 
            this.db.Users.Load();
            this.dataGridViewUsers.DataSource = db.Users.Local.ToBindingList();
        }

        //Метод  OnClosing вызывается при закрытии формы
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
                    this.dataGridViewPosts.DataSource = user.Posts;
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //Этот код вызывает SaveChanges DbContext объект,
            //который сохраняет все изменения, внесённые в базу данных
            this.db!.SaveChanges();

            this.dataGridViewUsers.Refresh();
            this.dataGridViewPosts.Refresh();
        }
    }
}
