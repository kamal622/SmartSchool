using SmartSchool.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.DataAccess.Services
{
    public class BatchService
    {
        public int Insert(Batch batch)
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {
                dataModel.Batches.Add(batch);
                dataModel.SaveChanges();
                return batch.Id;
            }
        }
        public bool Update(Batch batch)
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {
                try
                {
                    var oldBatch = (from a in dataModel.Batches
                                    where a.Id == batch.Id
                                    select a).FirstOrDefault();

                    oldBatch.Title = batch.Title;
                    oldBatch.BatchCapacity = batch.BatchCapacity;
                    oldBatch.TimeFrom = batch.TimeFrom;
                    oldBatch.TimeTo = batch.TimeTo;
                    oldBatch.IsActive = batch.IsActive;
                    oldBatch.OnSunday = batch.OnSunday;
                    oldBatch.OnMonday = batch.OnMonday;
                    oldBatch.OnTuesday = batch.OnTuesday;
                    oldBatch.OnWednesday = batch.OnWednesday;
                    oldBatch.OnThursday = batch.OnThursday;
                    oldBatch.OnFriday = batch.OnFriday;
                    oldBatch.OnSaturday = batch.OnSaturday;
                    oldBatch.Description = batch.Description;

                    dataModel.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
             
            }
        }
        public IEnumerable<Object> getBatches()
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {
                return (from a in dataModel.Batches
                        select new
                        {
                            Id = a.Id,
                            Title = a.Title+"("+a.TimeFrom.Hour+":"+a.TimeFrom.Minute+" - "+ a.TimeTo.Hour + ":" + a.TimeTo.Minute + ")"
                        }).ToList();
            }
        }

        public Object getBatchDetailById(int batchId)
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {
                return (from a in dataModel.Batches
                        where a.Id == batchId
                        select new
                        {
                            Id = a.Id,
                            Title = a.Title,
                            TimeFrom = a.TimeFrom,
                            TimeTo = a.TimeTo,
                            BatchCapacity = a.BatchCapacity,
                            OnSunday = a.OnSunday,
                            OnMonday = a.OnMonday,
                            OnTuesday = a.OnTuesday,
                            OnWednesday = a.OnWednesday,
                            OnThursday = a.OnThursday,
                            OnFriday = a.OnFriday,
                            OnSaturday = a.OnSaturday,
                            Description = a.Description
                        }).FirstOrDefault();
            }
        }
    }
}
