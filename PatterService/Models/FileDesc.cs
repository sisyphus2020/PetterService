using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatterService.Models
{
    public class FileDesc
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }

        public FileDesc(string name, string path, long size)
        {
            this.Name = name;
            this.Path = path;
            this.Size = size;

        }
    }
}