using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Interface;
using BusinessEntities.CrudEntities;
using System.Transactions;
using DataModel;
using DataModel.UnitOfWork;
using BusinessEntities;

namespace BusinessServices.InterfaceMethod
{
    public class ListServices : IList
    {
        private readonly UnitOfWork _unitOfWork;
        
        public ListServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        public IEnumerable<LOV> getValueType()
        {
            //return null;
            var vparentID = _unitOfWork.categoryParentRepository.GetByCode(b => (b.catCode).Trim() == GlobalVariable.lov_valueType);
            //If id has tree
            if (isHasSubTreeInCategory(vparentID.catID))
            {
                getSubinCategory(vparentID.catID);
            }

            return msLOV.AsEnumerable();
        }

        public IEnumerable<LOV> getRelationFamilyType()
        {
            List<LOV> ms = new List<LOV>();
            var vparentID = _unitOfWork.categoryParentRepository.GetByCode(b => (b.catCode).Trim() == GlobalVariable.lov_relationTypeFamily);
            var vData = _unitOfWork.categoryRepository.GetMany(b => (b.catParentID == vparentID.catID));

            if (vData.Any())
            {
                foreach (category n in vData)
                {
                    LOV xx = new LOV();
                    xx.label = n.catName;
                    xx.value = n.catID;
                    ms.Add(xx);
                }
            }
           
            return ms.AsEnumerable();
        }


        public IEnumerable<LOV> getEdu()
        {
            //return null;
            var vparentID = _unitOfWork.categoryParentRepository.GetByCode(b => (b.catCode).Trim() == GlobalVariable.lov_edu);
            //If id has tree
            if (isHasSubTreeInCategory(vparentID.catID))
            {
                getSubinCategory(vparentID.catID);
            }

            return msLOV.AsEnumerable();
        }

        public IEnumerable<LOV> getName()
        {

            List<LOV> ms = new List<LOV>();
            var vDataDiv = _unitOfWork.personDetailRepository.GetMany(b => b.isDeleted != 1);
            //var vDataDiv = _unitOfWork.categoryParentRepository.GetMany(b => b.catParentID == vparentID.catID);

            if (vDataDiv.Any())
            {
                foreach (personDetail n in vDataDiv)
                {
                    LOV xx = new LOV();

                    xx.label = (n.Name).TrimEnd();
                    xx.value = n.IDV.HasValue ? n.IDV.Value : 0;

                    ms.Add(xx);
                }

                return ms.AsEnumerable();
            }
            else { return null; };

        }

        public IEnumerable<LOV> getPurpose()
        {

            List<LOV> ms = new List<LOV>();
            var vDataDiv = _unitOfWork.purposeRepository.GetAll();

            if (vDataDiv.Any())
            {
                foreach (C_purpose n in vDataDiv)
                {
                    LOV xx = new LOV();

                    xx.label = (n.purposeName).TrimEnd();
                    xx.value = n.purposeID;

                    ms.Add(xx);
                }

                return ms.AsEnumerable();
            }
            else { return null; };

        }


        public IEnumerable<LOV> getNameSuperior()
        {

            List<LOV> ms = new List<LOV>();
            var vDataDiv = _unitOfWork.personDetailRepository.GetMany(b => b.isDeleted != 1);
            //var vDataDiv = _unitOfWork.categoryParentRepository.GetMany(b => b.catParentID == vparentID.catID);

            if (vDataDiv.Any())
            {
                foreach (personDetail n in vDataDiv)
                {
                    LOV xx = new LOV();

                    xx.label = (n.Name).TrimEnd();
                    xx.value = n.IDV.HasValue ? n.IDV.Value : 0;

                    ms.Add(xx);
                }

                return ms.AsEnumerable();
            }
            else { return null; };

        }

        public IEnumerable<LOV> getNameEmployee()
        {

            List<LOV> ms = new List<LOV>();
            var vDataDiv = _unitOfWork.personDetailRepository.GetMany(b => b.isDeleted != 1);
            //var vDataDiv = _unitOfWork.categoryParentRepository.GetMany(b => b.catParentID == vparentID.catID);

            if (vDataDiv.Any())
            {
                foreach (personDetail n in vDataDiv)
                {
                    LOV xx = new LOV();

                    xx.label = (n.Name).TrimEnd();
                    xx.value = n.IDV.HasValue ? n.IDV.Value : 0;

                    ms.Add(xx);
                }

                return ms.AsEnumerable();
            }
            else { return null; };

        }

        public IEnumerable<LOV> getDivision()
        {
            List<LOV> ms = new List<LOV>();
            var vparentID = _unitOfWork.categoryParentRepository.GetByCode(b => (b.catCode).Trim() == GlobalVariable.lov_orgDivision);
            var vData = _unitOfWork.categoryParentRepository.GetMany(b => b.catParentID == vparentID.catID);
            
            if (vData.Any())
            {
                foreach ( categoryParent n in vData)
                {
                    LOV x = new LOV();
                    x.value = n.catID;
                    x.label = n.catName;
                    ms.Add(x);
                }
                
                return ms.AsEnumerable();
            } else { return null; };
            
        }

        public IEnumerable<LOV> getDepartment()
        {
            List<LOV> ms = new List<LOV>();
            var vparentID = _unitOfWork.categoryParentRepository.GetByCode(b => (b.catCode).Trim() == GlobalVariable.lov_orgDepartemen);
            var vData = _unitOfWork.categoryRepository.GetMany(b => b.catParentID == vparentID.catID);

            if (vData.Any())
            {
                foreach (category n in vData)
                {
                    LOV x = new LOV();
                    x.value = n.catID;
                    x.label = n.catName;
                    ms.Add(x);
                }

                return ms.AsEnumerable();
            } else { return null; };
        }

        public IEnumerable<LOV> getPosition()
        {
            
            List<LOV> ms = new List<LOV>();
            var vparentID = _unitOfWork.categoryParentRepository.GetByCode(b => (b.catCode).Trim() == GlobalVariable.lov_orgPosition);
            if (vparentID.catID != 0)
            {
                var vData = _unitOfWork.categoryRepository.GetMany(b => b.catParentID == vparentID.catID);
                
                if (vData.Any())
                {
                    foreach (category n in vData)
                    {
                        LOV x = new LOV();
                        x.value = n.catID;
                        x.label = n.catName;
                        ms.Add(x);
                    }

                    return ms.AsEnumerable();
                }
                System.Diagnostics.Debug.WriteLine("vData: " , vData.ToString());
            } else { System.Diagnostics.Debug.WriteLine("vparentID is null, Variable lov_orgPosition: " + GlobalVariable.lov_orgPosition + " vparentID: "  ) ; }
            

            return null; 

        }

        public IEnumerable<LOV> getOrg()
        {

            List<LOV> ms = new List<LOV>();
            var vparentID = _unitOfWork.categoryParentRepository.GetByCode(b => (b.catCode).Trim() == GlobalVariable.lov_orgDivision);
            var vDataDiv = _unitOfWork.categoryParentRepository.GetMany(b => b.catParentID == vparentID.catID);

            if (vDataDiv.Any())
            {
                foreach (categoryParent n in vDataDiv)
                {
                    LOV xx = new LOV();

                    xx.label = (n.catName).TrimEnd();
                    xx.value = n.catID;


                    var vDataDep = _unitOfWork.categoryRepository.GetMany(b => b.catParentID == n.catID);
                    List<LOV> dep = new List<LOV>();
                    foreach (category nn in vDataDep)
                    {
                        LOV pI = new LOV();
                        pI.value = nn.catID;
                        pI.label = (nn.catName).TrimEnd();
                        dep.Add(pI);
                    }
                    xx.child = dep;
                    ms.Add(xx);
                }

                return ms.AsEnumerable();
            }
            else { return null; };

        }

        public IEnumerable<LOV> getPolicyRootType()
        {
            List<LOV> ms = new List<LOV>();
            var vRootID = _unitOfWork.categoryParentRepository.GetByCode(b => (b.catCode).Trim() == GlobalVariable.policyTypeRoot);
            var vParentID = _unitOfWork.categoryParentRepository.GetMany(b => b.catParentID == vRootID.catID);

            if (vRootID.catID != 0)
            {
                if (vParentID.Any())
                {
                    foreach (categoryParent n in vParentID)
                    {
                        LOV xx = new LOV();
                        xx.value = n.catID;
                        xx.label = (n.catName).TrimEnd();
                        ms.Add(xx);
                    }

                }

            }
            return ms.AsEnumerable();
        }

        public IEnumerable<LOV> getPolicyType()
        {
            List<LOV> ms = new List<LOV>();
            var vRootID = _unitOfWork.categoryParentRepository.GetByCode(b => (b.catCode).Trim() == GlobalVariable.policyTypeRoot);
            var vParentID = _unitOfWork.categoryParentRepository.GetMany(b => b.catParentID == vRootID.catID);

            if (vRootID.catID != 0)
            {
                if (vParentID.Any())
                {
                    foreach (categoryParent n in vParentID)
                    {
                        
                        var vDataID = _unitOfWork.roleBasedMatrixRepository.GetMany(b => b.PolicyType == n.catID);
                        if (vDataID.Any())
                        {
                            foreach (roleBasedMatrix nn in vDataID)
                            {
                                LOV xx = new LOV();
                                xx.value = nn.ID;
                                xx.label = (n.catName).TrimEnd() + " - " + (nn.PolicyName).TrimEnd();
                                ms.Add(xx);
                            }
                        }

                    }

                }

            }
            return ms.AsEnumerable();
        }

        public IEnumerable<LOV> getPolicyTypeByParentID(int parentID)
        {
            List<LOV> ms = new List<LOV>();
            
                        var vDataID = _unitOfWork.roleBasedMatrixRepository.GetMany(b => b.PolicyType == parentID);
                        if (vDataID.Any())
                        {
                            foreach (roleBasedMatrix nn in vDataID)
                            {
                                LOV xx = new LOV();
                                xx.value = nn.ID;
                                xx.label = (nn.PolicyName).TrimEnd();
                                ms.Add(xx);
                            }
                        }

            return ms.AsEnumerable();
        }

        public IEnumerable<LOV> getSkillLevel()
        {

            List<LOV> ms = new List<LOV>();
            var vparentID = _unitOfWork.categoryParentRepository.GetByCode(b => (b.catCode).Trim() == GlobalVariable.lov_skillLevel);
            var vDataDiv = _unitOfWork.categoryRepository.GetMany(b => b.catParentID == vparentID.catID);

            if (vDataDiv.Any())
            {
                foreach (category n in vDataDiv)
                {
                    LOV xx = new LOV();

                    xx.label = n.catName;
                    xx.value = n.catID;
                    ms.Add(xx);
                }

                return ms.AsEnumerable();
            }
            else { return null; };

        }

        List<LOV> msLOV = new List<LOV>();
        public IEnumerable<LOV> getLevel()
        {
            //return null;
            var vparentID = _unitOfWork.categoryParentRepository.GetByCode(b => (b.catCode).Trim() == GlobalVariable.lov_levelRoot);
            //If id has tree
            if (isHasSubTreeInparentCategory(vparentID.catID))
            {
                getSubinParentCategory(vparentID.catID);
            }

            return msLOV.AsEnumerable();
        }

        //categoryParent Only
        private bool isHasSubTreeInCategory(int parentID)
        {
            //subTreeID;
            var memberID = _unitOfWork.categoryRepository.GetMany(b => b.catParentID == parentID);

            if (memberID.Any())
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        //categoryParent Only
        private bool isHasSubTreeInparentCategory(int parentID)
        {
            //subTreeID;
            var memberID = _unitOfWork.categoryParentRepository.GetMany(b => b.catParentID == parentID);

            if (memberID.Any())
            {
                return true;
            } else
            {
                return false;
            }
            
        }

        //categoryParent Only, get member in parentCategory
        private void getSubinParentCategory(int parentID)
        {
            var rootID = _unitOfWork.categoryParentRepository.GetMany(b => b.catParentID == parentID);
            if (rootID.Any())
            {

                foreach (categoryParent n in rootID)
                {
                    if (isHasSubTreeInparentCategory(n.catID))
                    {
                        getSubinParentCategory(n.catID);
                    }
                   
                    LOV xx = new LOV();
                    System.Diagnostics.Debug.WriteLine("Code: " + n.catCode);
                    if ( (n.catCode).TrimEnd() != "empLevel")
                    {
                        xx.value = n.catID;
                        xx.label = (n.catName).TrimEnd();
                        msLOV.Add(xx);
                    }
                }

            }
        }

        //category Only, get member in parentCategory
        private void getSubinCategory(int parentID)
        {
            var rootID = _unitOfWork.categoryRepository.GetMany(b => b.catParentID == parentID);
            if (rootID.Any())
            {

                foreach (category n in rootID)
                {
                    if (isHasSubTreeInparentCategory(n.catID))
                    {
                        getSubinCategory(n.catID);
                    }

                    LOV xx = new LOV();
                    xx.value = n.catID;
                    xx.label = (n.catName).TrimEnd();
                    msLOV.Add(xx);
                }

            }
        }

        //categoryParent Only
        private void getSubTree(int parentID)
        {
            var rootID = _unitOfWork.categoryParentRepository.GetMany(b => b.catParentID == parentID);
            if (rootID.Any())
            {
               
                foreach (categoryParent n in rootID)
                {
                    if (isHasSubTreeInparentCategory(n.catID))
                    {
                        getSubTree(n.catID);
                    }

                    LOVTree xx = new LOVTree();
                    xx.id = n.catID;
                    xx.parentid = n.catParentID.HasValue ? n.catParentID.Value : 0;
                    xx.text = n.catName;
                    xx.value = n.catID;
                    msTree.Add(xx);
                }

            }
        }

        List<LOVTree> msTree = new List<LOVTree>();
        public IEnumerable<LOVTree> getLevelTree()
        {

            var vparentID = _unitOfWork.categoryParentRepository.GetByCode(b => (b.catCode).Trim() == GlobalVariable.lov_levelRoot);
            
            //If id has tree
            if (isHasSubTreeInparentCategory(vparentID.catID))
            {
                getSubTree(vparentID.catID);
            }

            return msTree.AsEnumerable();
           
        }

        public IEnumerable<LOV> getEmpStatus()
        {

            List<LOV> ms = new List<LOV>();
            var vparentID = _unitOfWork.categoryParentRepository.GetByCode(b => (b.catCode).Trim() == GlobalVariable.lov_employeeStatus);
            var vDataDiv = _unitOfWork.categoryRepository.GetMany(b => b.catParentID == vparentID.catID);

            if (vDataDiv.Any())
            {
                foreach (category n in vDataDiv)
                {
                    LOV xx = new LOV();

                    xx.label = n.catName;
                    xx.value = n.catID;
                    ms.Add(xx);
                }

                return ms.AsEnumerable();
            }
            else { return null; };

        }

        public IEnumerable<LOV> getMarital()
        {
            List<LOV> ms = new List<LOV>();
            var vparentID = _unitOfWork.categoryParentRepository.GetByCode(b => (b.catCode).Trim() == GlobalVariable.lov_marital);
            var vDataDiv = _unitOfWork.categoryRepository.GetMany(b => b.catParentID == vparentID.catID);

            if (vDataDiv.Any())
            {
                foreach (category n in vDataDiv)
                {
                    LOV xx = new LOV();

                    xx.label = n.catName;
                    xx.value = n.catID;
                    ms.Add(xx);
                }

                return ms.AsEnumerable();
            }
            else { return null; };
        }

        public IEnumerable<LOV> getGender()
        {
            List<LOV> ms = new List<LOV>();
            var vparentID = _unitOfWork.categoryParentRepository.GetByCode(b => (b.catCode).Trim() == GlobalVariable.lov_gender);
            var vDataDiv = _unitOfWork.categoryRepository.GetMany(b => b.catParentID == vparentID.catID);

            if (vDataDiv.Any())
            {
                foreach (category n in vDataDiv)
                {
                    LOV xx = new LOV();

                    xx.label = n.catName;
                    xx.value = n.catID;
                    ms.Add(xx);
                }

                return ms.AsEnumerable();
            }
            else { return null; };
        }

        public IEnumerable<LOV> getReligion()
        {
            List<LOV> ms = new List<LOV>();
            var vparentID = _unitOfWork.categoryParentRepository.GetByCode(b => (b.catCode).Trim() == GlobalVariable.lov_religion);
            var vDataDiv = _unitOfWork.categoryRepository.GetMany(b => b.catParentID == vparentID.catID);

            if (vDataDiv.Any())
            {
                foreach (category n in vDataDiv)
                {
                    LOV xx = new LOV();

                    xx.label = n.catName;
                    xx.value = n.catID;
                    ms.Add(xx);
                }

                return ms.AsEnumerable();
            }
            else { return null; };
        }

        public IEnumerable<LOV> getID()
        {
            List<LOV> ms = new List<LOV>();
            var vparentID = _unitOfWork.categoryParentRepository.GetByCode(b => (b.catCode).Trim() == GlobalVariable.lov_ID);
            var vDataDiv = _unitOfWork.categoryRepository.GetMany(b => b.catParentID == vparentID.catID);

            if (vDataDiv.Any())
            {
                foreach (category n in vDataDiv)
                {
                    LOV xx = new LOV();

                    xx.label = n.catName;
                    xx.value = n.catID;
                    ms.Add(xx);
                }

                return ms.AsEnumerable();
            }
            else { return null; };
        }

        public IEnumerable<LOVLocation> getCountry()
        {
            List<LOVLocation> ms = new List<LOVLocation>();
            var vparentID = _unitOfWork.categoryRepository.GetByCode(b => (b.catCode).Trim() == GlobalVariable.lov_country);
            if (vparentID.catID != 0)
            {
                System.Diagnostics.Debug.WriteLine("Country parentID:" + vparentID.catID);
                var vDataDiv = _unitOfWork.locationParentRepository.GetMany(b => b.locationType == vparentID.catID);
                if (vDataDiv.Any())
                {
                    foreach (location n in vDataDiv)
                    {
                        LOVLocation xx = new LOVLocation();
                        System.Diagnostics.Debug.WriteLine("Label:" + vparentID.catName + "Value: " + vparentID.catID);
                        xx.label = n.locationName;
                        xx.value = n.codeNum;
                        ms.Add(xx);
                    }
                    return ms.AsEnumerable();
                } else {
                    System.Diagnostics.Debug.WriteLine("locationparent Repository Not Found:");
                }
            } else {
                System.Diagnostics.Debug.WriteLine("Not Found:");
               
            };
            return null;
        }

        public IEnumerable<LOVLocation> getLocation(long parentID)
        {
            List<LOVLocation> ms = new List<LOVLocation>();
            //var vparentID = _unitOfWork.categoryParentRepository.GetByCode(b => (b.catCode).Trim() == lov_country);
            var vDataDiv = _unitOfWork.locationParentRepository.GetMany(b => b.codeNumParent == parentID);

            if (vDataDiv.Any())
            {
                foreach (location n in vDataDiv)
                {
                    LOVLocation xx = new LOVLocation();

                    xx.label = n.locationName;
                    xx.value = n.codeNum;
                    ms.Add(xx);
                }

                return ms.AsEnumerable();
            }
            else { return null; };
        }

        public IEnumerable<LOVLocation> getProvince()
        {
            List<LOVLocation> ms = new List<LOVLocation>();
            var vparentID = _unitOfWork.categoryRepository.GetByCode(b => (b.catCode).Trim() == GlobalVariable.lov_province);
            if (vparentID.catID != 0)
            {
                var vDataDiv = _unitOfWork.locationParentRepository.GetMany(b => b.locationType == vparentID.catID);

                if (vDataDiv.Any())
                {
                    foreach (location n in vDataDiv)
                    {
                        LOVLocation xx = new LOVLocation();

                        xx.label = n.locationName;
                        xx.value = n.codeNum;
                        ms.Add(xx);
                    }

                    return ms.AsEnumerable();
                }
                else { return null; };
            } else {
                System.Diagnostics.Debug.WriteLine("category parent not found !!!");
                return null;
            };

        }

        public IEnumerable<LOVLocation> getKabupaten()
        {
            List<LOVLocation> ms = new List<LOVLocation>();
            var vparentID = _unitOfWork.categoryRepository.GetByCode(b => (b.catCode).Trim() == GlobalVariable.lov_kabupaten);
            var vDataDiv = _unitOfWork.locationParentRepository.GetMany(b => b.locationType == vparentID.catID);

            if (vDataDiv.Any())
            {
                foreach (location n in vDataDiv)
                {
                    LOVLocation xx = new LOVLocation();

                    xx.label = n.locationName;
                    xx.value = n.codeNum;
                    ms.Add(xx);
                }

                return ms.AsEnumerable();
            }
            else { return null; };
        }

        public IEnumerable<LOVLocation> getKecamatan()
        {
            List<LOVLocation> ms = new List<LOVLocation>();
            var vparentID = _unitOfWork.categoryRepository.GetByCode(b => (b.catCode).Trim() == GlobalVariable.lov_kecamatan);
            var vDataDiv = _unitOfWork.locationParentRepository.GetMany(b => b.locationType == vparentID.catID);

            if (vDataDiv.Any())
            {
                foreach (location n in vDataDiv)
                {
                    LOVLocation xx = new LOVLocation();

                    xx.label = n.locationName;
                    xx.value = n.codeNum;
                    ms.Add(xx);
                }

                return ms.AsEnumerable();
            }
            else { return null; };
        }

        public IEnumerable<LOVTree> getRoleBasedTree()
        {
            List<LOVTree> ms = new List<LOVTree>();
            var vRootID = _unitOfWork.categoryParentRepository.GetByCode(b => (b.catCode).Trim() == GlobalVariable.policyTypeRoot);
            var vParentID = _unitOfWork.categoryParentRepository.GetMany(b => b.catParentID == vRootID.catID);

            if (vRootID.catID != 0)
            {
                if (vParentID.Any())
                {
                    foreach (categoryParent n in vParentID)
                    {
                        LOVTree x = new LOVTree();
                        x.id = n.catID;
                        x.parentid = n.catParentID.HasValue ? n.catParentID.Value : 0;
                        x.text = (n.catName).TrimEnd();
                        x.value = n.catID;
                        ms.Add(x);

                        var vDataID = _unitOfWork.categoryRepository.GetMany(b => b.catParentID == n.catID);
                        if (vDataID.Any())
                        {
                            foreach (category nn in vDataID)
                            {
                                LOVTree xx = new LOVTree();
                                xx.id = nn.catID;
                                xx.parentid = nn.catParentID.HasValue ? nn.catParentID.Value : 0;
                                xx.text = (nn.catName).TrimEnd();
                                xx.value = nn.catID;
                                ms.Add(xx);
                            }
                        }
                        
                    }
                    
                }

            }
            return ms.AsEnumerable();
        }

        public IEnumerable<classificationEntities> getParentCategory()
        {

            List<classificationEntities> ms = new List<classificationEntities>();
            var vparent = _unitOfWork.categoryParentRepository.GetAll();
            if (vparent.Any())
            {
                foreach (categoryParent nn in vparent)
                {
                    classificationEntities x = new classificationEntities();
                    x.catID = nn.catID;
                    x.catCode = nn.catCode;
                    x.catParentID = nn.catParentID;
                    x.catName = nn.catName;
                    ms.Add(x);
                }
                return ms.AsEnumerable();
                //System.Diagnostics.Debug.WriteLine("vData: "); //, vData.ToString());
            }
            else { System.Diagnostics.Debug.WriteLine("not found"); }


            return null;

        }


        //Dynamic Column, used in JobLevel
        List<DynamicColumn> dynamicCol = new List<DynamicColumn>();
        public IEnumerable<DynamicColumn> columnJobLevel()
        {
            DynamicColumn xx = new DynamicColumn();

            xx.text = "ID";
            xx.datafield = 1;
            xx.width = 10;
            dynamicCol.Add(xx);

            xx = new DynamicColumn();
            xx.text = "Type";
            xx.datafield = 2;
            xx.width = 70;
            dynamicCol.Add(xx);

            xx = new DynamicColumn();
            xx.text = "Description";
            xx.datafield = 3;
            xx.width = 200;
            dynamicCol.Add(xx);


            var vparentID = _unitOfWork.categoryParentRepository.GetByCode(b => (b.catCode).Trim() == GlobalVariable.lov_levelRoot);
            //If id has tree
            if (isHasSubTreeInparentCategory(vparentID.catID))
            {
                getSubColumninParentCategory(vparentID.catID);
            }

            return dynamicCol.AsEnumerable();
        }

        private void getSubColumninParentCategory(int parentID)
        {
            var rootID = _unitOfWork.categoryParentRepository.GetMany(b => b.catParentID == parentID);
            if (rootID.Any())
            {

                foreach (categoryParent n in rootID)
                {
                    if (isHasSubTreeInparentCategory(n.catID))
                    {
                        getSubColumninParentCategory(n.catID);
                    }

                    DynamicColumn xx = new DynamicColumn();
                    System.Diagnostics.Debug.WriteLine("Code: " + n.catCode);
                    if ((n.catCode).TrimEnd() != "empLevel")
                    {
                        xx.text = n.catName;
                        xx.datafield = n.catID;
                        xx.width = 100;
                        dynamicCol.Add(xx);
                    }
                }

            }
        }


        //Dynamic Datafield, used in Joblevel
        List<DynamicDatafield> dynamicRow = new List<DynamicDatafield>();
        public IEnumerable<DynamicDatafield> datafieldJobLevel()
        {
            dynamicRow = new List<DynamicDatafield>();
            DynamicDatafield xx = new DynamicDatafield();

            xx.name = "ID";
            xx.type = "number";
            dynamicRow.Add(xx);

            xx = new DynamicDatafield();
            xx.name = "policyType";
            xx.type = "number";
            dynamicRow.Add(xx);

            xx = new DynamicDatafield();
            xx.name = "policyName";
            xx.value = "policyType";
            xx.values = getPolicyType();
            dynamicRow.Add(xx);

            var vparentID = _unitOfWork.categoryParentRepository.GetByCode(b => (b.catCode).Trim() == GlobalVariable.lov_levelRoot);
            //If id has tree
            if (isHasSubTreeInparentCategory(vparentID.catID))
            {
                getSubDatafieldinParentCategory(vparentID.catID);
            }

            return dynamicRow.AsEnumerable();
        }

        private void getSubDatafieldinParentCategory(int parentID)
        {
            var rootID = _unitOfWork.categoryParentRepository.GetMany(b => b.catParentID == parentID);
            if (rootID.Any())
            {

                foreach (categoryParent n in rootID)
                {
                    if (isHasSubTreeInparentCategory(n.catID))
                    {
                        getSubDatafieldinParentCategory(n.catID);
                    }

                    DynamicDatafield xx = new DynamicDatafield();
                    System.Diagnostics.Debug.WriteLine("Code: " + n.catCode);
                    if ((n.catCode).TrimEnd() != "empLevel")
                    {
                        xx.name = (n.catID).ToString();
                        xx.type = "number";
                        dynamicRow.Add(xx);
                    }
                }

            }
        }

        
    }
}
