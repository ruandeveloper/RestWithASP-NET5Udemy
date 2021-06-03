using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RestWithASPNETUdemy.Data.VO;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class FileBusinessImplementation : IFileBusiness
    {
        private readonly string _basePath;
        private readonly IHttpContextAccessor _context;

        public FileBusinessImplementation(IHttpContextAccessor context)
        {
            _context = context;
            _basePath = Directory.GetCurrentDirectory() + "\\UploadDir\\";
        }

        public byte[] GetFile(string filename)
        {
            throw new System.NotImplementedException();
        }

        public async Task<FileDetailVO> SaveFileToDisk(IFormFile file)
        {
            FileDetailVO fileDetail = new FileDetailVO();

            var fileType = Path.GetExtension(file.FileName);
            var baseUrl = _context.HttpContext?.Request.Host;

            if (fileType.ToLower() != ".pdf" && fileType.ToLower() != ".jpg" && fileType.ToLower() != ".png" &&
                fileType.ToLower() != ".jpeg") return fileDetail;
            
            var docName = Path.GetFileName(file.FileName);

            if (file.Length <= 0) return fileDetail;
                
            var destination = Path.Combine(_basePath, "", docName);
            fileDetail.DocumentName = docName;
            fileDetail.DocType = fileType;
            fileDetail.DocUrl = Path.Combine(baseUrl + "/api/file/v1" + fileDetail.DocumentName);

            await using var stream = new FileStream(destination, FileMode.Create);
            await file.CopyToAsync(stream);

            return fileDetail;
        }

        public Task<List<FileDetailVO>> SaveFilesToDisk(IList<IFormFile> file)
        {
            throw new System.NotImplementedException();
        }
    }
}