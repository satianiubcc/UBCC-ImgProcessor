using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process_UBCC_Images
{
    /// <summary>
    /// Book ISBN
    /// </summary>
    public class Book
    {
        private string m_ISBN10;
        private string m_ISBN13;
        private string m_IMAGE_NAME;
        private string m_IMAGE_SMALL;

        public Book()
        {

        }

        public Book(string m_ISBN10, string m_ISBN13, string m_IMAGE_NAME, string m_IMAGE_SMALL)
        {
            this.m_ISBN10 = m_ISBN10;
            this.m_ISBN13 = m_ISBN13;
            this.m_IMAGE_NAME = m_IMAGE_NAME;
            this.m_IMAGE_SMALL = m_IMAGE_SMALL;
        }


        public string ISBN10
        {
            get { return m_ISBN10; }
            set { m_ISBN10 = value; }
        }

        public string ISBN13
        {
            get { return m_ISBN13; }
            set { m_ISBN13 = value; }
        }

        public string IMAGE_NAME
        {
            get { return m_IMAGE_NAME; }
            set { m_IMAGE_NAME = value; }
        }

        public string IMAGE_SMALL
        {
            get { return m_IMAGE_SMALL; }
            set { m_IMAGE_SMALL = value; }
        }
    }
}
