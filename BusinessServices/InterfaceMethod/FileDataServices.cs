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
using System.Transactions;
using System.IO;

namespace BusinessServices.InterfaceMethod
{
    public class FileDataServices : IFileData
    {
        
        private readonly UnitOfWork _u;

        public FileDataServices()
        {
            _u = new UnitOfWork();
        }

        #region local function ============================================================================================

        private dataFileEntities mappingToEntities(dataFile dt)
        {
            dataFileEntities ms = new dataFileEntities();
            ms.ID = dt.ID;
            ms.stream_id = dt.stream_id;
            ms.name = dt.name;
            ms.path_locator = dt.path_locator;
            ms.parent_path_locator = dt.parent_path_locator;
            ms.file_type = dt.file_type;
            ms.cached_file_size = dt.cached_file_size;
            ms.creation_time = dt.createTime;
            ms.last_write_time = dt.last_write_time;
            ms.last_access_time = dt.last_access_time;
            ms.is_directory = dt.is_directory;
            ms.is_offline = dt.is_offline;
            ms.is_hidden = dt.is_hidden;
            ms.is_readonly = dt.is_readonly;
            ms.is_archieve = dt.is_archieve;
            ms.is_system = dt.is_system;
            ms.is_temporary = dt.is_temporary;
            ms.vCreatedBy = dt.vCreatedBy;
            ms.vUpdateBy = dt.vUpdateBy;
            ms.createTime = dt.createTime;
            ms.updateTime = dt.updateTime;
            ms.isDeleted = dt.isDeleted;
            return ms;
        }

        private dataFile mappingToModel(dataFileEntities dt)
        {
            var px = new dataFile
            {
                ID = dt.ID,
                stream_id = dt.stream_id,
                name = dt.name,
                path_locator = dt.path_locator,
                parent_path_locator = dt.parent_path_locator,
                file_type = dt.file_type,
                cached_file_size = dt.cached_file_size,
                creation_time = dt.createTime,
                last_write_time = dt.last_write_time,
                last_access_time = dt.last_access_time,
                is_directory = dt.is_directory,
                is_offline = dt.is_offline,
                is_hidden = dt.is_hidden,
                is_readonly = dt.is_readonly,
                is_archieve = dt.is_archieve,
                is_system = dt.is_system,
                is_temporary = dt.is_temporary,
                vCreatedBy = dt.vCreatedBy,
                vUpdateBy = dt.vUpdateBy,
                createTime = dt.createTime,
                updateTime = dt.updateTime,
                isDeleted = dt.isDeleted
            };
            return px;
        }

        #endregion ========================================================================================================

        public Guid saveImageFile(MemoryStream fileModel, FileViewModel fileView)
        {
            var file = new fileEntities {
                name = fileView.Title,
                file_stream = fileModel.ToArray(),
                path_locator = "0xFD2E7419E6C99BEFC7D2372EA5F9BCF9B74F116220" // = at personImage
            };
            //_u.
            //db.FileModels.Add(file);
            //db.SaveChanges();
            return new Guid();
        }


        #region Upload File
        public IEnumerable<string> addFileDescription(FileSummaryEntities dt)
        {
            List<string> filenames = new List<string>();
            
            using (var scope = new TransactionScope())
            {
                for (int i = 0; i < dt.fileName.Count(); i++)
                {
                    var FileSummary = new dataFile
                    {
                        name = dt.fileName[i].ToString(),
                        file_type = dt.fileType[i].ToString(),
                        vCreatedBy = dt.vCreatedBy,
                        createTime = DateTime.Now
                    };
                    filenames.Add(dt.name[i].ToString());
                    _u.dataFileRepository.Insert(FileSummary);
                    _u.fileUploadRepository.GetUploadFileTable();
                    _u.Save();
                }
                
                scope.Complete();
                return filenames.AsEnumerable();
            }

        }

        public IEnumerable<LOVFile> getAllDirectories()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LOVFile> getAllFiles()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LOVFile> getAllItems()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FileSummaryEntities> getFileDescription()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LOVFileTree> getTree()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Profile Image
        public LOVFile getTempImage()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LOVFile> getAllImageFiles()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
