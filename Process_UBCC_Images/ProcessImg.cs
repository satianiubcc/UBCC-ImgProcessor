using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Process_UBCC_Images
{
    public partial class ProcessImg : Form
    {
        List<string> imgFiles;

        #region Constructors

        public ProcessImg()
        {
            InitializeComponent();

        }
        #endregion

        #region Event Handlers

        private void btnSBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = fb_SDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                imgFiles = Directory.GetFiles(fb_SDialog.SelectedPath).ToList<string>();
            }
            txtSource.Text = fb_SDialog.SelectedPath;
        }

        private void btnDBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = fb_DDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtDestination.Text = fb_DDialog.SelectedPath;
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtDestination.Text))
            {
                MessageBox.Show("Destination path is empty");

            }
            else if (String.IsNullOrEmpty(txtSource.Text))
            {
                MessageBox.Show("Source path is empty");
            }
            else
            {
                //1. Gets all the images list from SQL Server. 
                ImgManager mgr = new ImgManager();
                List<Book> books = mgr.GetImgISBNList();
                List<Book> ISBNsImg = new List<Book>();
                Book bk = null;
                int c_ISBN13Image = 0;
                int c_ISBN10Image = 0;
                int c_NoImage = 0;

                //2. Goes through the list
                foreach (Book book in books)
                {
                    if (imgFiles.Contains(String.Format(@"{0}\{1}.jpg", txtSource.Text, book.ISBN13)))
                    {
                        bk = new Book(book.ISBN10, book.ISBN13, String.Format("{0}.jpg", book.ISBN13), String.Format("{0}_th.jpg", book.ISBN13));
                        //File.Move(String.Format(@"{0}\{1}", txtSource.Text, bk.IMAGE_NAME), String.Format(@"{0}\{1}", txtDestination.Text, bk.IMAGE_NAME));
                        c_ISBN13Image++;
                    }
                    else if (imgFiles.Contains(String.Format(@"{0}\{1}.jpg", txtSource.Text, book.ISBN10)))
                    {
                        bk = new Book(book.ISBN10, book.ISBN13, String.Format("{0}.jpg", book.ISBN10), String.Format("{0}_th.jpg", book.ISBN10));
                        //File.Move(String.Format(@"{0}\{1}", txtSource.Text, bk.IMAGE_NAME), String.Format(@"{0}\{1}", txtDestination.Text, bk.IMAGE_NAME));
                        c_ISBN10Image++;
                    }
                    else // No Image
                    {
                        bk = new Book(book.ISBN10, book.ISBN13, "no_image.jpg", "no_image_small.jpg");
                        c_NoImage++;
                    }
                    ISBNsImg.Add(bk);
                }
                //3. Updates DB with new entries (UBCC_SITE)
                mgr.UpdateBookImg(ISBNsImg);
                MessageBox.Show("Completed :), The number of books without image is: " + c_NoImage + ", with ISBN13 image is:" + c_ISBN13Image + ", and with ISBN10 is:" + c_ISBN10Image);
            }

        }


        #endregion




    }
}
