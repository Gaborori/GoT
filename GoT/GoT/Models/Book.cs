using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoT.Models
{

    public class Book
    {
        public string url { get; set; }
        public string name { get; set; }
        public string isbn { get; set; }
        public string[] authors { get; set; }
        public int numberOfPages { get; set; }
        public string publisher { get; set; }
        public string country { get; set; }
        public string mediaType { get; set; }
        public DateTime released { get; set; }
        public string[] characters { get; set; }
        public string[] povCharacters { get; set; }
        public string imagePath {
            get
            {
                string imageId = "/Assets/book_";
                if (url.Substring(url.Length - 2,1) == "/")
                {
                    imageId += url.Substring(url.Length - 1,1);
                } else
                {
                    imageId += url.Substring(url.Length - 2,2);
                }
                imageId += ".jpg";
                return imageId;
            } 
            set {}
        }

    }

}
