using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Process_UBCC_Images
{
    /// <summary>
    /// Handles all image's related processes
    /// </summary>
    public class ImgManager
    {
        #region Members&Constants
        OleDbConnection conn = null;

        #endregion

        #region
        public ImgManager()
        {
            conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["UBCC_SITE"].ConnectionString);
        }


        #endregion

        #region Methods
        /// <summary>
        /// Gets the list of ISBNs
        /// </summary>
        /// <returns></returns>
        public List<Book> GetImgISBNList()
        {
            List<Book> l_ISBNs = new List<Book>();
            OleDbCommand command = new OleDbCommand("SELECT ISBN , ISBN13 FROM BOOKS_WEB", conn);
            Book isbn = null;
            OleDbDataReader reader = null;
            try
            {
                conn.Open();
                reader = command.ExecuteReader();
                int ind_ISBN10 = 0;
                int ind_ISBN13 = 0;
                bool updateISBNFlag = false;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        updateISBNFlag = false;
                        isbn = new Book();
                        ind_ISBN10 = reader.GetOrdinal("ISBN");
                        ind_ISBN13 = reader.GetOrdinal("ISBN13");


                        if (!reader.IsDBNull(ind_ISBN10))
                        {
                            isbn.ISBN10 = reader.GetString(ind_ISBN10);
                        }
                        else
                        {
                            updateISBNFlag = true;
                        }

                        if (!reader.IsDBNull(ind_ISBN13))
                        {
                            isbn.ISBN13 = reader.GetString(ind_ISBN13);
                        }

                        if (updateISBNFlag)
                        {
                            isbn.ISBN10 = ISBNManager.UpdateISBN10(isbn.ISBN13, conn);
                        }

                        l_ISBNs.Add(isbn);

                    }
                }
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
            finally
            {
                reader.Close();
                conn.Close();
            }
            return l_ISBNs;
        }

        /// <summary>
        /// Updates the image's name for both large and thumbnail.
        /// </summary>
        /// <param name="books"></param>
        public void UpdateBookImg(List<Book> books)
        {
            List<Book> ISBNs = new List<Book>();
            OleDbCommand command = new OleDbCommand("UPDATE BOOKS_WEB SET IMAGE_NAME=@IMAGE_NAME,IMAGE_SMALL=@IMAGE_SMALL WHERE ISBN13=@ISBN13", conn);
            try
            {
                int counter = 0;
                conn.Open();
                foreach (Book book in books)
                {
                    command.CommandText = String.Format("UPDATE Books_web SET IMAGE_NAME='{0}',IMAGE_SMALL='{1}' where ISBN13='{2}'", book.IMAGE_NAME, book.IMAGE_SMALL, book.ISBN13);
                    command.ExecuteNonQuery();
                    counter++;
                }
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion
    }
}
