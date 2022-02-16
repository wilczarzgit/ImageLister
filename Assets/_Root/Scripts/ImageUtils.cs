using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

namespace _Root.Scripts
{
    public class ImageUtils
    {
        // //we init this once so that if the function is repeatedly called
        // //it isn't stressing the garbage man
        // private static Regex r = new Regex(":");
        //
        // //retrieves the datetime WITHOUT loading the whole image
        // public static DateTime GetDateTakenFromImage(string path)
        // {
        //     using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        //     using (Image myImage = Image.FromStream(fs, false, false))
        //     {
        //         PropertyItem propItem = myImage.GetPropertyItem(36867);
        //         string dateTaken = r.Replace(Encoding.UTF8.GetString(propItem.Value), "-", 2);
        //         return DateTime.Parse(dateTaken);
        //     }
        // }
    }
}