using schoolManagmentAPI.Helper;

namespace schoolManagmentAPI.Services
{
    public class ImageService
    {

                  public async Task<string> UploadImage(IFormFile file)
            {
                if (CheckIfImageFile(file))
                {
                    return await WriteFile(file);
                }

                return "Invalid image file";
            }

            /// <summary>
            /// Method to check if file is image file
            /// </summary>
            /// <param name="file"></param>
            /// <returns></returns>
            private bool CheckIfImageFile(IFormFile file)
            {
                byte[] fileBytes;
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    fileBytes = ms.ToArray();
                }

                return ImageHelper.GetImageFormat(fileBytes) != ImageHelper.ImageFormat.unknown;
            }

            /// <summary>
            /// Method to write file onto the disk
            /// </summary>
            /// <param name="file"></param>
            /// <returns></returns>
            public async Task<string> WriteFile(IFormFile file,String folderName="images")
            {
                string fileName;
                try
                {
                    var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                    fileName = Guid.NewGuid().ToString() + extension; //Create a new Name 
                                                                      //for the file due to security reasons.
                    var path = Path.Combine(Directory.GetCurrentDirectory(), folderName, fileName);

                    using (var bits = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(bits);
                    }
                }
                catch (Exception e)
                {
                //return e.Message;
                return "Invalid image file";
                }

                return fileName;
            }
        }
    

}
