using System;
using System.Transactions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using AutoMapper;

namespace BusinessServices
{
    public class personServices:IpersonServices 
    {
        private readonly UnitOfWork _unitOfWork;

        public personServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        public personEntities GetPersonById(int personIDV)
        {
            //throw new NotImplementedException();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<person, personEntities>();
            });

            IMapper mapper = config.CreateMapper();
            
            var p = _unitOfWork.personRepository.GetByID(personIDV);
            if (p != null)
            {
                //Mapper.CreateMap<person, personEntities>();
                var pModel = mapper.Map<person, personEntities>(p);
                //Mapper.Map<person, personEntities>(p);
                return pModel;
            }
            return null;
        }

        public IEnumerable<personEntities> GetAllPersons()
        {
            //throw new NotImplementedException();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<person, personEntities>();
            });

            IMapper mapper = config.CreateMapper();

            var p = _unitOfWork.personRepository.GetAll().ToList();
            if (p.Any())
            {
                //Mapper.CreateMap<person, personEntities>();
                var pModel = mapper.Map<List<person>, List<personEntities>>(p);
                return pModel;
            }
            return null;

        }

        public int CreatePerson(personEntities personEntity)
        {
            using (var scope = new TransactionScope())
            {
                var p = new person
                {
                   IDV  = personEntity.IDV,
                   OrganizationID = personEntity.OrganizationID,
                   vCreatedBy = personEntity.vCreatedBy,
                   createTime = DateTime.Now

                };
                _unitOfWork.personRepository.Insert(p);
                _unitOfWork.Save();
                scope.Complete();
                return p.IDV;
            }
        }

        public bool DeletePerson(int personIDV, int vUpdatedBy)
        {
            var vUpdateIDV = vUpdatedBy;
            var success = false;
            using (var scope = new TransactionScope())
                {
                    var p = _unitOfWork.personRepository.GetByID(personIDV);//.ProductRepository.GetByID(productId);
                    if (p != null)
                    {
                        p.isDeleted = 1;
                        p.vUpdatedBy = vUpdateIDV; //personEntity.vUpdatedBy; 
                        p.updateTime = DateTime.Now;
                         _unitOfWork.personRepository.Update(p);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            return success;
        }

        


        public bool UpdatePerson(int personIDV, personEntities personEntity)
        {
            //throw new NotImplementedException();
            var success = false;
            if (personEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var p = _unitOfWork.personRepository.GetByID(personIDV);//.ProductRepository.GetByID(productId);
                    if (p != null)
                    {
                        //DeletePerson(personIDV, personEntity.vUpdatedBy);
                        //CreatePerson(personEntity);
                        p.OrganizationID = personEntity.OrganizationID;
                        p.updateTime = DateTime.Now;
                        p.vUpdatedBy = personEntity.vUpdatedBy;
                        _unitOfWork.personRepository.Update(p);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
    }
}
