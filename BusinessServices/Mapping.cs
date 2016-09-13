using BusinessEntities.CrudEntities;
using BusinessServices.InterfaceMethod;
using DataModel;
using DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessServices
{
    public class Mapping
    {
        public employeeRoleBasedEntities EmployeeRoleBasedFromModel(employeeRoleBased px)
        {
            employeeRoleBasedEntities t = new employeeRoleBasedEntities();
            t.ID = px.ID;
            t.IDV = px.IDV;
            t.policyType = px.policyType;
            t.valueType = px.valueType;
            t.roleBasedValue = px.roleBasedValue;
            t.currentValue = px.currentValue;
            t.balanceValue = px.balanceValue;
            t.remainingValue = px.remainingValue;
            t.validDateStart = px.validDateStart;
            t.validDateStop = px.validDateStop;
            t.decription = px.decription;
            t.vCreatedBy = px.vCreatedBy;
            t.vUpdatedBy = px.vUpdatedBy;
            t.updateTime = px.updateTime;
            t.createTime = px.createTime;
            
            return t;
        }

        public employeeRoleBased EmployeeRoleBasedFromEntities(employeeRoleBasedEntities px)
        {
            employeeRoleBased t = new employeeRoleBased();


            return t;
        }
    }

    
    
}
