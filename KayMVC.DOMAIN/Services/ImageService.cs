using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;//Image class and Bitmap
using System.Drawing.Imaging; //Pixel Format
using System.Drawing.Drawing2D; //Graphics (using Block) below
using System.IO; //fileInfo object (used in the delete)

namespace KayMVC.DOMAIN.Services
{
   public class ImageService
    {
        //these are helper methods for the resize image
        //GetNewSize()
        //DoResizeImage()
        //Delete()
        public static int[] GetNewSize(int imgWidth, int imgHeight,
        int maxImageSize)
        {
            //calculate which dimension is being changed the most and
            //use that as the aspect ratio for both sides
            float ratioX = (float)maxImageSize / (float)imgWidth;
            float ratioY = (float)maxImageSize / (float)imgHeight;

            float ratio = Math.Min(ratioX, ratioY);

            //calculate the new width and height based on apsect ratio
            int[] newImageSizes = new int[2];
            newImageSizes[0] = (int)(imgWidth * ratio);
            newImageSizes[1] = (int)(imgHeight * ratio);

            //return the proportional image SIZES
            return newImageSizes;
        }

        public static Bitmap DoResizeImage(int imgWidth, int imgHeight,
        Image image)
        {
            //convert other formats to RGB
            Bitmap newImage = new Bitmap(imgWidth, imgHeight,
            PixelFormat.Format24bppRgb);

            //if the image format supports transparency apply it
            newImage.MakeTransparent();

            //set image to screen resolution of 72 dpi (resolution of monitors)
            newImage.SetResolution(72, 72);

            //resize the image
            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(image, 0, 0, imgWidth, imgHeight);
            }
            //return the resized image
            return newImage;
        }

        public static void ResizeImage(string savePath, string fileName,
        Image image, int maxImageSize, int maxThumbSize)
        {
            //get the new proportional image dimensions based off of the 
            //current image size and the max image size
            int[] newImageSizes =
            GetNewSize(image.Width, image.Height, maxImageSize);

            //resize the image to the new dimensions returned above
            Bitmap newImage = DoResizeImage(newImageSizes[0], newImageSizes[1],
            image);

            //save the new image to the specified path with the specified
            //fileName
            newImage.Save(savePath + fileName);

            //calculate the proportional size for the thumbnail based off of 
            //the max thumbnail size
            int[] newThumbSizes = GetNewSize(newImage.Width, newImage.Height,
            maxThumbSize);

            //create thumbnail image
            Bitmap newThumb = DoResizeImage(newThumbSizes[0], newThumbSizes[1],
            image);

            //save the thumbnail with t_ prefix
            newThumb.Save(savePath + "t_" + fileName);

            //clean up any items from this process with Dispose.
            newImage.Dispose();
            newThumb.Dispose();
            image.Dispose();

        }

        public static void Delete(string path, string imgName)
        {
            //get info about the full and thumbnail images
            FileInfo fullImg = new FileInfo(path + imgName);
            FileInfo thumbImg = new FileInfo(path + "t_" + imgName);

            //check to see if the images exist if so delete
            if (fullImg.Exists)
            {
                fullImg.Delete();
            }
            if (thumbImg.Exists)
            {
                thumbImg.Delete();
            }

        }
    }
}
