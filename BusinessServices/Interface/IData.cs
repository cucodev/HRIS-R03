﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using BusinessEntities.CrudEntities;

namespace BusinessServices.Interface
{
    public interface IData
    {
        int updateServiceYear(int IDV);
    }
    
    public interface ILeave
    {
        //IEnumerable<employeeLeaveEntities>
    }

    public interface calculateServiceYear
    {
        //int getServiceYear(int IDV);
    }

}
