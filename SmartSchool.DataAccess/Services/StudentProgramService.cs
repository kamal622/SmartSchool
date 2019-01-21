using SmartSchool.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.DataAccess.Services
{
   public class StudentProgramService
    {
        public int Insert(StudentProgram program)
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {
                try
                {
                    dataModel.StudentPrograms.Add(program);
                    dataModel.SaveChanges();
                    return program.Id;
                }
                catch (Exception ex)
                {
                    return 0;
                }
               
            }
        }

        public bool Update(StudentProgram program)
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {
                try
                {
                    var oldProgram = (from a in dataModel.StudentPrograms
                                      where a.Id == program.Id
                                      select a).FirstOrDefault();
                    oldProgram.BatchId = program.BatchId;
                    oldProgram.EndDate = program.EndDate;
                    oldProgram.StartDate = program.StartDate;
                    oldProgram.UpdatedOn = program.UpdatedOn;
                    oldProgram.IsActive = program.IsActive;

                    dataModel.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }

        public bool UpdateValidDate(int StudentProgramId,DateTime validTill)
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {
                try
                {
                    var oldProgram = (from a in dataModel.StudentPrograms
                                      where a.Id == StudentProgramId
                                      select a).FirstOrDefault();
                   
                    oldProgram.EndDate = validTill;
                 
                    oldProgram.UpdatedOn =DateTime.Now;


                    dataModel.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }
        public string getProgramDetails(int studentID)
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {
                var programs= (from a in dataModel.StudentPrograms
                        where a.StudentId == studentID
                        select a.Program.Name).ToList();
                if (programs != null)
                    return string.Join(" , ", programs);
                else
                    return "";
            }
        }
        public IEnumerable<object> getStudentProgramsDetail(int studentId)
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {
                return (from a in dataModel.StudentPrograms
                        where a.StudentId == studentId
                        select new
                        {
                            Id=a.Id,
                            ProgramId = a.ProgramId,
                            ProgramName = a.Program.Name,
                            BatchId = a.BatchId,
                            BatchTitle = a.Batch.Title,
                            BatchTimeFrom= a.Batch.TimeFrom,
                            BatchTimeTo= a.Batch.TimeTo,
                            StartDate=a.StartDate,
                            EndDate=a.EndDate,
                            IsActive=a.IsActive
                        }).ToList();
            }
        }

        public int? getStudentProgramId(int StudentId, int ProgramId)
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {
                return (from a in dataModel.StudentPrograms
                                where a.StudentId == StudentId && a.ProgramId==ProgramId
                                select a.Id).FirstOrDefault();
            }
        }

        public int getActiveProgramCount(int ProgramId)
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {
                return (from a in dataModel.StudentPrograms
                        where a.ProgramId==ProgramId && a.IsActive==true && a.Student.IsActive==true
                        select a.ProgramId).Count();
            }
        }
        public int GetValidityOverCounts(int ProgramId)
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {
                return (from a in dataModel.StudentPrograms
                        where a.ProgramId == ProgramId && a.IsActive == true && a.Student.IsActive == true && a.EndDate<DateTime.Now
                        select a.ProgramId).Count();
            }
        }

        public IEnumerable<object> GetRenewalRequiredDetail()
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {
                return (from a in dataModel.StudentPrograms
                        where  a.IsActive == true && a.Student.IsActive == true && a.EndDate < DateTime.Now
                        select new
                        {
                            Id = a.Id,
                            StudentId=a.Student.Id,
                            Name = a.Student.FirstName+" "+ a.Student.MiddleName + " "+ a.Student.LastName,
                            Course = a.Program.Name,
                            PreferedBatch =a.Batch.Title,
                            PhoneNumber = a.Student.Mobile,
                            RegistrationDate = a.StartDate,
                            ExpiryDate =a.EndDate,
                            Note = a.Remarks
                        }).ToList();

           
            }
        }
    }
}
