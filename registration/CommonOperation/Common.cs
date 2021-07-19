using registration.Entities;
using registration.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace registration.CommonOperation
{
    public class Common
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public IEnumerable<City> GetCityList()
        {
            return  db.Cities.ToList();
        }
        public bool UploadImageInDataBase(HttpPostedFileBase file, Userdata userModel)
        {
            userModel.Image = ConvertToBytes(file);
            //var Content = new Content
            //{
            //    Title = contentViewModel.Title,
            //    Description = contentViewModel.Description,
            //    Contents = contentViewModel.Contents,
            //    Image = contentViewModel.Image
            //};
            db.Userdatas.Add(userModel);
            int i = db.SaveChanges();
            if (i == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
    }
}