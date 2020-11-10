using System;
using System.Collections.Generic;
using System.Text;

namespace ImageHelper
{
    public class ImageModel
    {
        public int Id { get; set; }

        public string Filename { get; set; }

        public string Alias { get; set; }

        public string Path { get; set; }

        public int Order { get; set; }

        public string CompletePath
        {
            get
            {
                return System.IO.Path.Combine(Path, Filename);
            }
        }

        public string PartialPath(string folder) => System.IO.Path.Combine(folder, Filename);
    }
}
