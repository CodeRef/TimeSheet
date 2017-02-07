using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class Class1
    {
        public void CreateDir(string subPath)
        {
            //string subPath ="ImagesPath"; // your code goes here
            bool exists = System.IO.Directory.Exists(@"C:\DevGeek\restmeet\tools\Template-Helper\Views\" + subPath);

            if (!exists)
                System.IO.Directory.CreateDirectory(@"C:\DevGeek\restmeet\tools\Template-Helper\Views\" + subPath);
            var outputFilePath = @"C:\DevGeek\restmeet\tools\Template-Helper\Views\" + subPath + @"\Index.cshtml";
            var content = System.IO.File.ReadAllText(@"C:\DevGeek\restmeet\tools\Template-Helper\cshtml-template.txt");
            content = content.Replace("{{NAME}}", subPath);
            File.WriteAllText(outputFilePath, content);
        }
    }
}
