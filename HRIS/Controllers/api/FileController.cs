using BusinessEntities.CrudEntities;
using BusinessServices.Interface;
using BusinessServices.InterfaceMethod;
using DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace HRIS.Controllers.api
{
    public class FileController : ApiController
    {
        private readonly IFileData _pServices;

        public FileController()
        {
            _pServices = new FileDataServices();// ProductServices();
        }

        private static readonly string UploadPath = "\\\\HLSCP\\sqlserver\\HRIS\\upload\\"; //Path.GetTempPath();
        private static readonly string UploadImagePath = "\\\\HLSCP\\sqlserver\\HRIS\\personImage\\"; //Path.GetTempPath();

        [HttpPost]
        [Route("api/file/UploadMultiFiles")]
        [ActionName("UploadMultiFiles")]
        public IEnumerable<String> UploadMultiFiles()
        {
            List<string> Fx = new List<string>();
            var streamProvider = new MultipartFormDataStreamProvider(UploadPath);
            
            Request.Content.ReadAsMultipartAsync(streamProvider);

            

            var files = new FileSummaryEntities
            {
                fileName = streamProvider.FileData.Select(entry => entry.LocalFileName.Replace(UploadPath + "\\", "")).ToList(),
                //name = streamProvider.FileData.Select(entry => entry.Headers.ContentDisposition.FileName).ToList(),
                name = streamProvider.FileData.Select(entry => entry.LocalFileName).ToList(),
                fileType = streamProvider.FileData.Select(entry => entry.Headers.ContentType.MediaType).ToList(),
                Description = streamProvider.FormData["description"],
                createTime = DateTime.UtcNow
            };
            
            return _pServices.addFileDescription(files);
        }


        [HttpPost]
        [Route("api/file/UploadFiles")]
        [ActionName("UploadFiles")]
        public IEnumerable<String> UploadImageFiles(FileViewModel fileModel)
        {
            var files = new FileSummaryEntities();
            var streamProvider = new MultipartFormDataStreamProvider(UploadImagePath);
            Request.Content.ReadAsMultipartAsync(streamProvider);

            var fileData = new MemoryStream();
            fileModel.File.InputStream.CopyTo(fileData);
            fileModel.File.FileName.ToString();

            return _pServices.addFileDescription(files);
        }


        // GET: api/list
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getFileTree")]
        [System.Web.Http.Route("api/file/getFileTree")]
        public IEnumerable<LOVFileTree> getFileTree()
        {
            var p = _pServices.getTree();
            if (p != null)
            {
                var pEntities = p as List<LOVFileTree> ?? p.ToList();
                if (pEntities.Any())
                    return pEntities;
            }
            // return null;
            return null;
        }

        // GET: api/list
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getTempImage")]
        [System.Web.Http.Route("api/file/getTempImage")]
        public LOVFile getTempImage()
        {
            var p = _pServices.getTempImage();
            if (p != null)
            {
                var pEntities = p;
                if (pEntities.value != null)
                    return pEntities;
            }
            // return null;
            return null;
        }

        // GET: api/list
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("getAllImage")]
        [System.Web.Http.Route("api/file/getAllImage")]
        public IEnumerable<LOVFile> getAllImage()
        {
            System.Diagnostics.Debug.WriteLine("File Controller Called");
            var p = _pServices.getAllImageFiles();
            if (p != null)
            {
                System.Diagnostics.Debug.WriteLine(" - Data Founds ");
                var pEntities = p as List<LOVFile> ?? p.ToList();
                if (pEntities.Any())
                    return pEntities.ToList();
            }
            // return null;
            return null;
        }

    }
}
