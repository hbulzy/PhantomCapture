using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace PhantomCapture.Models
{
    public class CaptureModel
    {
                private string phantomjsDirPath;
        public CaptureModel(string phantomjsDirPath)
        {
            this.phantomjsDirPath = phantomjsDirPath;
        }

        public Byte[] Captur(string url,CaptureFormat format = CaptureFormat.PNG , CaptureSize captureSize = null)
        {
            var tmpDir = Path.GetTempPath();
            var imagePath = Path.Combine(tmpDir, Guid.NewGuid().ToString() + ".data");
            var argment = string.Empty;
            if(captureSize == null)
            {
                argment = string.Format("Captuer.js {0} {1} {2}", url, imagePath,format);
            }
            else
            {
                argment = string.Format("Captuer.js {0} {1} {2} {3} {4}", url, imagePath,format,captureSize.Width,captureSize.Height);
            }

            var psi = new ProcessStartInfo();
            psi.FileName = Path.Combine(phantomjsDirPath,"phantomjs.exe");
            psi.WorkingDirectory = phantomjsDirPath;
            psi.Arguments = argment;
            psi.ErrorDialog = false;
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;

            var p = Process.Start(psi);
            p.WaitForExit();

            var bytes = File.ReadAllBytes(imagePath);
            File.Delete(imagePath);
            return bytes;
        }

    }


    public enum CaptureFormat
    {
        PNG,
        GIF,
        //      JPEG,
        //      PDF,
    }

    public class CaptureSize
    {
        public CaptureSize(int width, int heigh)
        {
            this.Width = width;
            this.Height = Height;
        }

        public int Width { get; private set; }
        public int Height { get; private set; }
    }

}