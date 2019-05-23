using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoT.Models
{

    public class Character
    {
        public string url { get; set; }
        public string name { get; set; }
        public string culture { get; set; }
        public string gender { get; set; }
        public string born { get; set; }
        public string died { get; set; }
        public string[] titles { get; set; }
        public string[] aliases { get; set; }
        public string father { get; set; }
        public string mother { get; set; }
        public string spouse { get; set; }
        public string[] allegiances { get; set; }
        public string[] books { get; set; }
        public string[] povBooks { get; set; }
        public string[] tvSeries { get; set; }
        public string[] playedBy { get; set; }
        public string imagePath
        {
            get
            {
                string[] characterImages = { "1052", "1303", "148", "208", "232", "339", "583", "957" };
                string imageId = "/Assets/Characters/";
                string imageNumber = url.Split('/')[5];
                if (!characterImages.Contains(imageNumber))
                {
                    imageNumber = "default";
                }
                imageId += imageNumber;
                imageId += ".jpg";
                return imageId;
            }
            set { }
        }

    }

}
