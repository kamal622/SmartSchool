using SmartSchool.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.DataAccess.Services
{
  public class FeesDetailService
    {
        public int Insert(FeesDetail fees)
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {
                try
                {
                    dataModel.FeesDetails.Add(fees);
                    dataModel.SaveChanges();
                    return fees.Id;
                }
                catch (Exception ex)
                {
                    return 0;
                }

            }
        }

        
        public IEnumerable<Object> GetFeesDetail(int studentId)
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {
                return (from a in dataModel.FeesDetails
                        where a.StudentProgram.Student.Id == studentId
                        select new
                        {
                            Id = a.Id,
                            ProgramId = a.StudentProgram.ProgramId,
                            ProgramName = a.StudentProgram.Program.Name,
                            FeesPaid = a.FeesPaid,
                            Duration = a.Duration.ToString() + ((a.Duration==1)? " month" : " months"),
                            PaidOn = a.PaidOn,
                            ValidTill=a.ValidTill
                        }).ToList();
            }
        }
    }
}
