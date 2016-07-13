using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Entities
{
    public class personTrainingEntities
    {
        public int ID { get; set; }
        public Nullable<int> IDV { get; set; }
        public string TrainingName { get; set; }
        public string TrainingSponsor { get; set; }
        public Nullable<int> Certificate { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        public Nullable<int> vCreatedBy { get; set; }
        public Nullable<int> vUpdatedBy { get; set; }
        public Nullable<int> isDeleted { get; set; }
        public Nullable<System.DateTime> createTime { get; set; }
        public Nullable<System.DateTime> updateTime { get; set; }


    }
}
