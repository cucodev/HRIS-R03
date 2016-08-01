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
    public interface IFile
    {
        IEnumerable<LOVFileTree> getTree();
        IEnumerable<LOVFile> getAllItems();

        //EMployee Related
        LOVFile getTempImage();
        IEnumerable<LOVFile> getAllImageFiles();

        IEnumerable<LOVFile> getAllFiles();
        IEnumerable<LOVFile> getAllDirectories();
        
    }

}
