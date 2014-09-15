using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process_UBCC_Images
{
    class ISBNManager
    {

        #region Constructors

        #endregion

        #region Methods



        /// <summary>
        /// Updates Empty ISBNs
        /// </summary>
        /// <param name="books"></param>
        public static string UpdateISBN10(string i_ISBN13, OleDbConnection conn)
        {
            string conv_ISBN10 = Isbn13to10(i_ISBN13);
            OleDbCommand command = new OleDbCommand("UPDATE BOOKS_WEB SET ISBN=@ISBN WHERE ISBN13=@ISBN13", conn);
            try
            {
                //conn.Open();
                command.Parameters.Add("@ISBN", System.Data.SqlDbType.Text);
                command.Parameters["@ISBN"].Value = conv_ISBN10;

                command.Parameters.Add("@ISBN13", System.Data.SqlDbType.Text);
                command.Parameters["@ISBN13"].Value = i_ISBN13;

                command.ExecuteNonQuery();

            }
            catch (OleDbException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            /*finally
            {
                conn.Close();
            }*/
            return conv_ISBN10;
        }
        #endregion

        #region Helpers

        /// <summary>
        /// Converts ISBN-13 to ISBN-10
        /// </summary>
        /// <param name="isbn13"></param>
        /// <returns></returns>
        static String Isbn13to10(String isbn13)
        {
            if (String.IsNullOrEmpty(isbn13))
                throw new ArgumentNullException("isbn13");
            isbn13 = isbn13.Replace("-", "").Replace(" ", "");
            if (isbn13.Length != 13)
                return isbn13;

            string isbn10 = isbn13.Substring(3, 9);
            int checksum = 0;
            int weight = 10;

            foreach (Char c in isbn10)
            {
                checksum += (int)Char.GetNumericValue(c) * weight;
                weight--;
            }

            checksum = 11 - (checksum % 11);
            if (checksum == 10)
                isbn10 += "X";
            else if (checksum == 11)
                isbn10 += "0";
            else
                isbn10 += checksum;

            return isbn10;
        }
        #endregion

    }
}
