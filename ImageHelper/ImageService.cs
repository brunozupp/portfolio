using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ImageHelper
{
    public class ImageService
    {
        public string GetDirectory() => Directory.GetCurrentDirectory();

        public string GetDirectory(string folder) => Path.Combine(Directory.GetCurrentDirectory(), folder);

        // Verifica se tal pasta existe, caso não exista, vai criar
        public bool ExistFolder(string path) => Directory.Exists(path);

        public bool ExistFile(string file) => File.Exists(file);

        public async Task<ImageModel> Save(IFormFile file, string folder = "Temp")
        {
            try
            {
                if (file == null) return null;

                string pathFolder = GetDirectory(folder);

                if (!ExistFolder(pathFolder))
                {
                    Directory.CreateDirectory(pathFolder);
                }

                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];

                var newFileName = DateTime.Now.Ticks + extension;

                ImageModel image = new ImageModel();
                image.Alias = file.FileName;
                image.Path = folder;
                image.Filename = newFileName;

                using (var stream = new FileStream(image.CompletePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return image;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<ImageModel>> SaveAll(List<IFormFile> files, string folder = "Temp")
        {
            try
            {
                if (files == null || files?.Count == 0) return null;

                string pathFolder = GetDirectory(folder);

                if (!ExistFolder(pathFolder))
                {
                    Directory.CreateDirectory(pathFolder);
                }

                List<ImageModel> images = new List<ImageModel>();

                foreach (var file in files)
                {
                    var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];

                    var newFileName = DateTime.Now.Ticks + extension;

                    ImageModel image = new ImageModel();
                    image.Alias = file.FileName;
                    image.Path = pathFolder;
                    image.Filename = newFileName;

                    using (var stream = new FileStream(image.CompletePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    images.Add(image);
                }

                return images;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Delete(string pathComplete)
        {
            try
            {
                if (ExistFile(pathComplete))
                {
                    File.Delete(pathComplete);
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(string filename, string path)
        {
            var pathComplete = Path.Combine(GetDirectory(path), filename);

            try
            {
                if (ExistFile(pathComplete))
                {
                    File.Delete(pathComplete);
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
