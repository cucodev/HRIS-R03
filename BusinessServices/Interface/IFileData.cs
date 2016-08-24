using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using BusinessEntities.CrudEntities;
using BusinessEntities.DataEntities;

namespace BusinessServices.Interface
{
    public interface IFileData
    {
        IEnumerable<string> addFileDescription(FileSummaryEntities Fx);
        IEnumerable<FileSummaryEntities> getFileDescription();

        //File Handling
        byte[] ReadImageFile(string imageLocation);
        string ImagePath(string NIP);

        //EMployee Related
        LOVFile getTempImage();
        IEnumerable<LOVFile> getAllImageFiles();

        IEnumerable<LOVFileTree> getTree();
        IEnumerable<LOVFile> getAllItems();
        IEnumerable<LOVFile> getAllFiles();
        IEnumerable<LOVFile> getAllDirectories();

    }
}
