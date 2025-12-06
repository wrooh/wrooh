using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace Lab2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        ModelEF.Model1 model = new ModelEF.Model1();

        private void StartLoadData()
        {
            model.Users.Load();
            role_NameComboBox.DataSource = model.Roles.ToList();
            usersBindingSource.DataSource = model.Users.Local.ToBindingList();
        }

        private void SaveData()
        {
            try
            {
                Validate();
                usersBindingSource.EndEdit();
                usersBindingSource.ResetBindings(true);
                model.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                StartLoadData();
            }
        }

        private void usersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartLoadData();
        }

        private void usersBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }
        private void usersBindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            SaveData();
        }
        private void usersBindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            role_NameComboBox.SelectedIndex = 0;
        }
    }
}
