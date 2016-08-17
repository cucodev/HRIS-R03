using BusinessEntities.CrudEntities;
using BusinessServices.Interface;
using BusinessServices.InterfaceMethod;
using DataModel;
using HRIS.Controllers.api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
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
            var streamProvider = new CustomMultipartFormDataStreamProvider(UploadPath);
            
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
        [Route("api/file/UploadImageFiles")]
        [ActionName("UploadImageFiles")]
        public Task<IEnumerable<FileDesc>> UploadImageFiles(HttpRequestMessage request)
        {
            string UploadPath = "\\\\HLSCP\\sqlserver\\HRIS\\personImage\\";
            FileSummaryEntities files = new FileSummaryEntities();
            var rootUrl = Request.RequestUri.AbsoluteUri.Replace(Request.RequestUri.AbsolutePath, String.Empty);
            if (Request.Content.IsMimeMultipartContent())
            {
                var streamProvider = new CustomMultipartFormDataStreamProvider(UploadPath);
                var task = Request.Content.ReadAsMultipartAsync(streamProvider).ContinueWith<IEnumerable<FileDesc>>(t =>
                {
                    
                    if (t.IsFaulted || t.IsCanceled)
                    {
                        System.Diagnostics.Debug.WriteLine("t status: " + t.Status.ToString() + ':' + t.Result);
                        throw new HttpResponseException(HttpStatusCode.InternalServerError);
                    };

                    var fileInfo = streamProvider.FileData.Select(i => {
                        var info = new FileInfo(i.LocalFileName);
                        return new FileDesc(info.Name, UploadPath + info.Name, info.Length / 1024);
                    });
                    return fileInfo;
                });

                return task;
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));
            }
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

    public class FileDesc
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }

        public FileDesc(string n, string p, long s)
        {
            Name = n;
            Path = p;
            Size = s;
        }
    }

    public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public CustomMultipartFormDataStreamProvider(string path) : base(path)
        { }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            var name = !string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName) ? headers.ContentDisposition.FileName : "NoName";
            System.Diagnostics.Debug.WriteLine("Custom: getlocalfilename: " + name);
            return name.Replace("\"",string.Empty); //this is here because Chrome submits files in quotation marks which get treated as part of the filename and get escaped
        }
    }

}
