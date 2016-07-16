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
    public class ListService : IList
    {
        private readonly UnitOfWork _unitOfWork;
        
        public ListService()
        {
            _unitOfWork = new UnitOfWork();
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

        public IEnumerable<listEntities> getParentCategory()
        {

            List<listEntities> ms = new List<listEntities>();
            var vparent = _unitOfWork.categoryParentRepository.GetAll();
            if (vparent.Any())
            {
                foreach (categoryParent nn in vparent)
                {
                    listEntities x = new listEntities();
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
    }
}
