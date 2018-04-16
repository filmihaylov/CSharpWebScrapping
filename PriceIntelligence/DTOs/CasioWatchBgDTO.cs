using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PriceIntelligence.DTOs
{
    public class CasioWatchBgDTO
    {

        public CasioWatchBgDTO(decimal Price, string Name, string Description)
        {
            this.Price = Price;
            this.Name = Name;
            this.Description = Description;
        }

        public decimal Price { get;}
        public string Name { get;}
        public string Description { get;}

        public void SaveImage(ImageFormat format, string ImageUrl)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(ImageUrl);
            Bitmap bitmap = new Bitmap(stream);

            if (bitmap != null)
                bitmap.Save(this.Name , format);

            stream.Flush();
            stream.Close();
            client.Dispose();
        }

        public Byte[] ReadImageBytes()
        {
            Byte[] image = File.ReadAllBytes(this.Name);

            return image;
        }
    }
}
