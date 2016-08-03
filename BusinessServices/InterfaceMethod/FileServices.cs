using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using DataModel.UnitOfWork;
using BusinessEntities;
using BusinessServices.Interface;
using BusinessEntities.CrudEntities;

namespace BusinessServices.InterfaceMethod
{
    public class FileServices : IFile
    {
        private static readonly string path = "\\\\HLSCP\\mssqlserver\\HRIS\\personImage\\"; //Path.GetTempPath();

        private readonly UnitOfWork _u;

        public FileServices()
        {
            _u = new UnitOfWork();
        }

        #region local function ============================================================================================
        private string GuidToString(Guid t)
        {
            return t.ToString();
        } 

        private Guid StringToGuid(string t)
        {
            return new Guid(t);
        }

        private fileEntities map(filePersonImage px)
        {
            fileEntities ms = new fileEntities();
            ms.stream_id = px.stream_id;
            ms.file_stream = px.file_stream;
            ms.name = px.name;
            ms.path_locator = px.path_locator;
            ms.parent_path_locator = px.parent_path_locator;
            ms.file_type = px.file_type;
            ms.cached_file_size = px.cached_file_size;
            ms.creation_time = px.creation_time;
            ms.last_write_time = px.last_write_time;
            ms.last_access_time = px.last_access_time;
            ms.is_directory = px.is_directory;
            ms.is_offline = px.is_offline;
            ms.is_hidden = px.is_hidden;
            ms.is_readonly = px.is_readonly;
            ms.is_archive = px.is_archive;
            ms.is_system = px.is_system;
            ms.is_temporary = px.is_temporary;

            return ms;
        }

        private LOVFile maplov(filePersonImage px)
        {
            LOVFile ms = new LOVFile();
            ms.label = px.name;
            ms.value = px.stream_id.ToString();
            ms.url = path + px.name;
            return ms;
        }

        private LOVFileTree mapLOVTree(dataFile px)
        {
            LOVFileTree ms = new LOVFileTree();

            ms.stream_id = px.stream_id.ToString();
            ms.name = px.name;
            ms.path_locator = px.path_locator.ToString();
            ms.parent_path_locator = px.parent_path_locator.ToString();
            ms.url = path + px.name;
            return ms;
        }

        private bool isDirectory(Guid stream_id)
        {
            var get = _u.filePersonImageRepository.GetByCode(b => b.stream_id == stream_id && b.is_directory == true);
            if (get.stream_id != null)
                return true;
            return false;
        }

        #endregion ========================================================================================================

        #region crud function ============================================================================================
        List<LOVFileTree> topTree = new List<LOVFileTree>();
        public IEnumerable<LOVFileTree> getTree()
        {
            var get = _u.fileUploadRepository.GetAll();
            if (get.Any())
            {
                foreach (dataFile px in get)
                {
                    LOVFileTree sub = new LOVFileTree();
                    sub = mapLOVTree(px);
                    topTree.Add(sub);
                    
                }
                return topTree.AsEnumerable();
            }
            return null;
        }

        List<LOVFile> top = new List<LOVFile>();
        public IEnumerable<LOVFile> getAllItems()
        {
            var get = _u.filePersonImageRepository.GetAll();
            if (get.Any())
            {
                foreach (filePersonImage px in get)
                {
                    if (isDirectory(px.stream_id))
                    {
                        getAllItems();
                    } else
                    {
                        LOVFile sub = new LOVFile();
                        sub = maplov(px);
                        top.Add(sub);
                    }
                }
                return top.AsEnumerable();
            }
            return null;
        }

        public IEnumerable<fileEntities> getAllFiles()
        {
            throw new NotImplementedException();
        }

        IEnumerable<LOVFile> IFile.getAllFiles()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LOVFile> getAllDirectories()
        {
            throw new NotImplementedException();
        }


        public LOVFile getTempImage()
        {
            LOVFile ms = new LOVFile();
            var get = _u.filePersonImageRepository.GetByCode(b => (b.name).Trim() == "person" && b.file_type == "png");
            //var get = _u.filePersonImageRepository.GetByCode(b => (b.catCode).Trim() == catCode.Trim());

            if (get != null)
            {
                ms = maplov(get);
            }
            return ms;
        }

        public IEnumerable<LOVFile> getAllImageFiles()
        {
            List<LOVFile> rt = new List<LOVFile>();
            var File = _u.filePersonImageRepository.GetAll();
            if (File.Any())
            {

                foreach (filePersonImage px in File)
                {
                    System.Diagnostics.Debug.WriteLine("File Services: File Found: " + px.name);
                    LOVFile ms = new LOVFile();
                    ms = maplov(px);
                    rt.Add(ms);
                }
                return rt;
            }
            System.Diagnostics.Debug.WriteLine("File Services: File Not Found: ");

            return null;
        }
        #endregion ========================================================================================================



        #region later use


        public string getItemGuid(string name, string file_type)
        {
            LOVFile ms = new LOVFile();
            var get = _u.filePersonImageRepository.GetByCode(b => b.name == name && b.file_type == file_type);
            if (get.stream_id != null)
            {
                return get.stream_id.ToString();
            }
            return get.stream_id.ToString();
        }

        public LOVFile getItemByID(string stream_id)
        {
            LOVFile ms = new LOVFile();
            var id = new Guid(stream_id);
            var get = _u.filePersonImageRepository.GetByCode(b => b.stream_id == id);
            if (get.stream_id != null)
            {
                ms.label = get.name;
                ms.value = get.stream_id.ToString();
                ms.url = path + get.name;
                return ms;
            }
            return null;
        }

        public LOVFile getItemByName(string name)
        {
            LOVFile ms = new LOVFile();
            var get = _u.filePersonImageRepository.GetByCode(b => b.name == name);
            if (get.stream_id != null)
            {
                //ms = map(get);
                ms.label = get.name;
                ms.value = (get.stream_id).ToString();
                ms.url = path + get.name;
                return ms;
            }
            return ms;
        }

        public LOVFile getDirectoryByID(string stream_id)
        {
            LOVFile ms = new LOVFile();
            var id = new Guid(stream_id);
            var get = _u.filePersonImageRepository.GetByCode(b => b.stream_id == id && b.is_directory== true);
            if (get.stream_id != null)
            {
                ms.label = get.name;
                ms.value = get.stream_id.ToString();
                ms.url = path + get.name;
                return ms;
            }
            return null;
        }

        public fileEntities getDirectoryByName(string name)
        {
            throw new NotImplementedException();
        }
        
        public IEnumerable<fileEntities> getAllDirectory()
        {
            throw new NotImplementedException();
        }

        public fileEntities getCurrentFolder()
        {
            throw new NotImplementedException();
        }

        public Guid deleteFile(Guid stream_id, fileEntities fileEntities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<fileEntities> getAllFilesInFolder(Guid parent_path_locator)
        {
            throw new NotImplementedException();
        }

        public fileEntities getFile(Guid stream_id)
        {
            fileEntities ms = new fileEntities();
            var get = _u.filePersonImageRepository.GetByCode(b => b.stream_id == stream_id);
            if (get.stream_id != null)
            {
                var px = get;
                ms.stream_id = px.stream_id;
                ms.file_stream = px.file_stream;
                ms.name = px.name;
                ms.path_locator = px.path_locator;
                ms.parent_path_locator = px.parent_path_locator;
                ms.file_type = px.file_type;
                ms.cached_file_size = px.cached_file_size;
                ms.creation_time = px.creation_time;
                ms.last_write_time = px.last_write_time;
                ms.last_access_time = px.last_access_time;
                ms.is_directory = px.is_directory;
                ms.is_offline = px.is_offline;
                ms.is_hidden = px.is_hidden;
                ms.is_readonly = px.is_readonly;
                ms.is_archive = px.is_archive;
                ms.is_system = px.is_system;
                ms.is_temporary = px.is_temporary;

            }
            return ms;
        }
        
        public Guid getFileGuid(string filename, string file_type)
        {
            //throw new NotImplementedException();
            var getGUID = _u.filePersonImageRepository.GetByCode(b => (b.name).Trim() == filename.Trim() && b.file_type == file_type.Trim());
            //var get = _u.filePersonImageRepository.GetByCode(b => (b.catCode).Trim() == catCode.Trim());
            return getGUID.stream_id;
        }

        public Guid uploadFile(fileEntities fileEntities)
        {
            throw new NotImplementedException();
        }

        public fileEntities getFileByType(string file_type)
        {
            throw new NotImplementedException();
        }
        
        #endregion

    }
}
