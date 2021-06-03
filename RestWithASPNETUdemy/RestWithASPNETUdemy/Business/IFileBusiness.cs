using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RestWithASPNETUdemy.Data.VO;

namespace RestWithASPNETUdemy.Business
{
    public interface IFileBusiness
    {
        public byte[] GetFile(string filename);
        public Task<FileDetailVO> SaveFileToDisk(IFormFile file); 
        public Task<List<FileDetailVO>> SaveFilesToDisk(IList<IFormFile> file); 
    }
}