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

        const string lov_skillLevel = "pSkillLevel";
        const string lov_marital = "pMarital";
        const string lov_gender = "pGender";
        const string lov_religion = "pReligion";
        const string lov_ID = "pID";
        const string lov_relationType = "pRelType";
        const string lov_orgDivision = "empDiv";
        const string lov_orgDepartemen = "empDep";
        const string lov_orgPosition = "empPos";


        public ListService()
        {
            _unitOfWork = new UnitOfWork();
        }
       
        public IEnumerable<LOV> getDivision()
        {
            List<LOV> ms = new List<LOV>();
            var vparentID = _unitOfWork.categoryParentRepository.GetByCode(b => (b.catCode).Trim() == lov_orgDivision);
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
            var vparentID = _unitOfWork.categoryParentRepository.GetByCode(b => (b.catCode).Trim() == lov_orgDepartemen);
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
            var vparentID = _unitOfWork.categoryParentRepository.GetByCode(b => (b.catCode).Trim() == lov_orgPosition);
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
            } else { System.Diagnostics.Debug.WriteLine("vparentID is null, Variable lov_orgPosition: " + lov_orgPosition + " vparentID: "  ) ; }
            

            return null; 

        }

        public IEnumerable<LOV> getOrg()
        {

            List<LOV> ms = new List<LOV>();
            var vparentID = _unitOfWork.categoryParentRepository.GetByCode(b => (b.catCode).Trim() == lov_orgDivision);
            var vDataDiv = _unitOfWork.categoryParentRepository.GetMany(b => b.catParentID == vparentID.catID);

            if (vDataDiv.Any())
            {
                foreach (categoryParent n in vDataDiv)
                {
                    LOV xx = new LOV();

                    xx.label = n.catName;
                    xx.value = n.catID;


                    var vDataDep = _unitOfWork.categoryRepository.GetMany(b => b.catParentID == n.catID);
                    List<LOV> dep = new List<LOV>();
                    foreach (category nn in vDataDep)
                    {
                        LOV pI = new LOV();
                        pI.value = nn.catID;
                        pI.label = nn.catName;
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
            var vparentID = _unitOfWork.categoryParentRepository.GetByCode(b => (b.catCode).Trim() == lov_skillLevel);
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
            var vparentID = _unitOfWork.categoryParentRepository.GetByCode(b => (b.catCode).Trim() == lov_marital);
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
            var vparentID = _unitOfWork.categoryParentRepository.GetByCode(b => (b.catCode).Trim() == lov_gender);
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
            var vparentID = _unitOfWork.categoryParentRepository.GetByCode(b => (b.catCode).Trim() == lov_religion);
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
            var vparentID = _unitOfWork.categoryParentRepository.GetByCode(b => (b.catCode).Trim() == lov_ID);
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
