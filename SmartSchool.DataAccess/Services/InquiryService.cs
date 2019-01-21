using SmartSchool.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.DataAccess.Services
{
    public class InquiryService
    {
        public int Insert(Inquiry inquiry)
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {
                dataModel.Inquiries.Add(inquiry);
                dataModel.SaveChanges();
                return inquiry.Id;
            }
        }
        public int Update(Inquiry inquiry)
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {
                try
                {
                    var oldinquiry = (from a in dataModel.Inquiries
                                      where a.Id == inquiry.Id
                                      select a).FirstOrDefault();

                    oldinquiry.IsInterestedInBass = inquiry.IsInterestedInBass;
                    oldinquiry.IsInterestedInDrums = inquiry.IsInterestedInDrums;
                    oldinquiry.IsInterestedInGuitar = inquiry.IsInterestedInGuitar;
                    oldinquiry.IsInterestedInKeyBoard = inquiry.IsInterestedInKeyBoard;
                    oldinquiry.IsInterestedInRecording = inquiry.IsInterestedInRecording;
                    oldinquiry.IsInterestedInVocals = inquiry.IsInterestedInVocals;
                    oldinquiry.IsMorning = inquiry.IsMorning;
                    oldinquiry.IsEvening = inquiry.IsEvening;
                    oldinquiry.Remarks = inquiry.Remarks;
                   
                    dataModel.SaveChanges();
                    return oldinquiry.StudentId;
                }
                catch (Exception ex)
                {
                    return 0;
                }

            }
        }

        public int getGuitarInquiryCount()
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {
                return (from a in dataModel.Inquiries
                        where a.IsInterestedInGuitar
                        select a.IsInterestedInGuitar).Count();
            }
        }
        public int getKeyBoardInquiryCount()
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {
                return (from a in dataModel.Inquiries
                        where a.IsInterestedInKeyBoard
                        select a.IsInterestedInKeyBoard).Count();
            }
        }
        public int getBassInquiryCount()
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {
                return (from a in dataModel.Inquiries
                        where a.IsInterestedInBass
                        select a.IsInterestedInBass).Count();
            }
        }
        public int getDrumInquiryCount()
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {
                return (from a in dataModel.Inquiries
                        where a.IsInterestedInDrums
                        select a.IsInterestedInDrums).Count();

            }
        }
        public int getVocalInquiryCount()
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {
                return (from a in dataModel.Inquiries
                        where a.IsInterestedInVocals
                        select a.IsInterestedInVocals).Count();

            }
        }
        public int getRecordingInquiryCount()
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {
                return (from a in dataModel.Inquiries
                        where a.IsInterestedInRecording
                        select a.IsInterestedInRecording).Count();
            }
        }

        public int getStudentIdByInquiryId(int inquiryId)
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {
                return (from a in dataModel.Inquiries
                        where a.Id == inquiryId
                        select a.StudentId).FirstOrDefault();
            }
        }

        public int?[] getStudentProgramsID(int studentId)
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {
                return (from a in dataModel.StudentPrograms
                        where a.StudentId == studentId
                        select a.ProgramId).ToArray();
            }
        }

        public object getInquiryById(int id)
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
                {
                int studentID = getStudentIdByInquiryId(id);
              
                var programDetails = (from a in dataModel.StudentPrograms
                                      where a.StudentId == studentID
                                      select a.Program.Name).ToList();
                var Programs = string.Join(" , ", programDetails);

            

                dynamic data= (from a in dataModel.Inquiries
                        where a.Id == id
                        select new
                        {
                            Id = a.Id,
                            studentId=a.StudentId,
                            FirstName = a.Student.FirstName,
                            MiddleName = a.Student.MiddleName,
                            LastName = a.Student.LastName,
                            Address = a.Student.CurrentAddress,
                            City = a.Student.City,
                            Pincode = a.Student.Pincode,
                            Mobile = a.Student.Mobile,
                            DOB = a.Student.DOB,
                            Email = a.Student.Email,
                            School = a.Student.School,
                            SchoolAddress = a.Student.SchoolAddress,
                            College = a.Student.College,
                            CollegeAddress = a.Student.CollegeAddress,
                            ContactPersonName = a.Student.ContactPersonName,
                            ContactPersonPhone = a.Student.ContactPersonPhone,
                            ContactPersonRelationship = a.Student.ContactPersonRelationship,
                            HasPhoto = a.Student.HasPhoto,
                            IsRegistered = a.Student.IsRegistered,
                            IsActive = a.Student.IsActive,
                            IsInterestedInGuitar = a.IsInterestedInGuitar,
                            IsInterestedInKeyBoard = a.IsInterestedInKeyBoard,
                            IsInterestedInBass = a.IsInterestedInBass,
                            IsInterestedInDrums = a.IsInterestedInDrums,
                            IsInterestedInVocals = a.IsInterestedInVocals,
                            IsInterestedInRecording = a.IsInterestedInRecording,
                            //programs = ((a.IsInterestedInGuitar ? ",Guitar" : "") + (a.IsInterestedInKeyBoard ? ",KeyBoard" : "") + (a.IsInterestedInBass ? ",Bass" : "") + (a.IsInterestedInDrums ? ",Drum" : "") + (a.IsInterestedInVocals ? ",Vocal" : "") + (a.IsInterestedInRecording ? ",Recording & Mixing" : "")).Substring(1),
                            Programs= Programs,
                            PreferedBatch = ((a.IsEvening.Value ? ",Evening" : "") + (a.IsMorning.Value ? ",Morning" : "")).Substring(1),
                            IsEvening = a.IsEvening,
                            IsMorning = a.IsMorning,
                            PhoneNumber = a.Student.Mobile,
                            InquiryDate = a.InquiryDate,
                            ImageName=a.Student.ImageName,
                            Note = a.Remarks
                        }).FirstOrDefault();

               
                return data;
            }
        }

        public IEnumerable<Object> getInquiries(string Name, string program, string Duration, int RegisterValue)
        {

            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {
                var allData = (from a in dataModel.Inquiries
                               select new
                               {
                                   Id = a.Id,
                                   StudentId = a.Student.Id,
                                   Name = a.Student.FirstName + " " + a.Student.MiddleName + " " + a.Student.LastName,
                                   Course = ((a.IsInterestedInGuitar ? ",Guitar" : "") + (a.IsInterestedInKeyBoard ? ",KeyBoard" : "") + (a.IsInterestedInBass ? ",Bass" : "") + (a.IsInterestedInDrums ? ",Drum" : "") + (a.IsInterestedInVocals ? ",Vocal" : "") + (a.IsInterestedInRecording ? ",Recording & Mixing" : "")).Substring(1),
                                   PreferedBatch = ((a.IsEvening.Value ? ",Evening" : "") + (a.IsMorning.Value ? ",Morning" : "")).Substring(1),
                                   PhoneNumber = a.Student.Mobile,
                                   InquiryDate = a.InquiryDate,
                                   Note = a.Remarks,
                                   IsRegistered=a.Student.IsRegistered
                               }).OrderBy(o=>o.InquiryDate).ToList();
                if (Name != null)
                {
                    allData = allData.Where(w => w.Name.ToLower().Contains(Name.Trim().ToLower())).ToList();
                }
                if (program != null)
                {
                    allData = allData.Where(w => w.Course.Contains(program)).ToList();
                }
                if(RegisterValue==1)
                {
                    allData = allData.Where(w => w.IsRegistered==true).ToList();
                }else
                if (RegisterValue == 2)
                {
                    allData = allData.Where(w => w.IsRegistered == false).ToList();
                }
                if (Duration != null)
                {
                    if (Duration == "Today")
                    {
                        allData = allData.Where(w => w.InquiryDate.Date == DateTime.Now.Date).ToList();
                    }
                    else if (Duration == "Last 10 Days")
                    {
                        DateTime smallDate = DateTime.Now.AddDays(-10);
                        allData = allData.Where(w => w.InquiryDate >= smallDate).ToList();
                    }
                    else if (Duration == "Current Month")
                    {
                        allData = allData.Where(w => w.InquiryDate.Month == DateTime.Now.Month).Where(w => w.InquiryDate.Year == DateTime.Now.Year).ToList();
                    }
                    else if (Duration == "Last Month")
                    {
                        var month = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                        var first = month.AddMonths(-1);
                        allData = allData.Where(w => w.InquiryDate.Month == first.Month).Where(w => w.InquiryDate.Year == first.Year).ToList();
                    }
                    else if (Duration == "Current Year")
                    {
                        allData = allData.Where(w => w.InquiryDate.Year == DateTime.Now.Year).ToList();
                    }
                    else if (Duration == " Last Year")
                    {
                        DateTime year = DateTime.Now.AddYears(-1);
                        allData = allData.Where(w => w.InquiryDate.Year == year.Year).ToList();
                    }
                }
                return allData;

            }
        }

        public IEnumerable<object> getLatestInquiries(int totRecords)
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {
                var allData = (from a in dataModel.Inquiries
                               select new
                               {
                                   Id = a.Id,
                                   StudentId = a.Student.Id,
                                   Name = a.Student.FirstName + " " + a.Student.MiddleName + " " + a.Student.LastName,
                                   Course = ((a.IsInterestedInGuitar ? ",Guitar" : "") + (a.IsInterestedInKeyBoard ? ",KeyBoard" : "") + (a.IsInterestedInBass ? ",Bass" : "") + (a.IsInterestedInDrums ? ",Drum" : "") + (a.IsInterestedInVocals ? ",Vocal" : "") + (a.IsInterestedInRecording ? ",Recording & Mixing" : "")).Substring(1),
                                   PreferedBatch = ((a.IsEvening.Value ? ",Evening" : "") + (a.IsMorning.Value ? ",Morning" : "")).Substring(1),
                                   PhoneNumber = a.Student.Mobile,
                                   InquiryDate = a.InquiryDate,
                                   Note = a.Remarks,
                                   IsRegistered = a.Student.IsRegistered
                               }).Where(w=>w.IsRegistered==false).OrderBy(o => o.InquiryDate).Take(10).ToList();
                return allData;
            }
        }
     
    }
}
