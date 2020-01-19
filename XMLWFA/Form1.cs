using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace XMLWFA
{
    public partial class Books : Form
    {
        XmlSerializer xs;
        List<BooksClass> ls;
        public Books()
        {
            InitializeComponent();
            xs = new XmlSerializer(typeof(List<BooksClass>));
            ls = new List<BooksClass>();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void saveButton(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("books.xml", FileMode.Create, FileAccess.Write);
            BooksClass booksClass = new BooksClass();
            booksClass.Name = nameText.Text;
            booksClass.Author = authorText.Text;
            booksClass.Publisher = publisherText.Text;
            ls.Add(booksClass);
            xs.Serialize(fs, ls);
            string message = "Successfully Added";
            MessageBox.Show(message);
            fs.Close();
         
        }

        private void retrieveButton(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("books.xml", FileMode.Open, FileAccess.Read);
            ls = (List<BooksClass>)xs.Deserialize(fs);
            dataGridView1.DataSource = ls;
            fs.Close();

        }
    }
}
