﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;

namespace bLOG.Web.Framework.Services
{
  public class FileService
  {
    public static string SaveFileToDisk(byte[] bytes, string extension)
    {
      string relative = "~/files/" + Guid.NewGuid() + "." + extension.Trim('.');
      string file = HostingEnvironment.MapPath(relative);

      File.WriteAllBytes(file, bytes);

      //var cruncher = new ImageCruncher.Cruncher();
      //cruncher.CrunchImages(file);

      return VirtualPathUtility.ToAbsolute(relative);
    }
  }
}
