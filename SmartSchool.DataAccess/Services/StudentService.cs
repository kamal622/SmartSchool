using SmartSchool.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.DataAccess.Services
{
    public class StudentService
    {
        public int Insert(Student student)
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {
                dataModel.Students.Add(student);
                dataModel.SaveChanges();
                return student.Id;
            }

        }

        public bool Update(Student student)
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {

                try
                {
                    var oldStudent = (from a in dataModel.Students
                                      where a.Id == student.Id
                                      select a).FirstOrDefault();
                    oldStudent.FirstName = student.FirstName;
                    oldStudent.MiddleName = student.MiddleName;
                    oldStudent.LastName = student.LastName;
                    oldStudent.CurrentAddress = student.CurrentAddress;
                    oldStudent.City = student.City;
                    oldStudent.Pincode = student.Pincode;
                    // oldStudent.StateId = "";
                    // oldStudent.CountryId = "";
                    oldStudent.Mobile = student.Mobile;
                    oldStudent.DOB = student.DOB;
                    oldStudent.Email = student.Email;
                    oldStudent.School = student.School;
                    oldStudent.SchoolAddress = student.SchoolAddress;
                    oldStudent.College = student.College;
                    oldStudent.CollegeAddress = student.CollegeAddress;
                    oldStudent.ContactPersonName = student.ContactPersonName;
                    oldStudent.ContactPersonPhone = student.ContactPersonPhone;
                    oldStudent.ContactPersonRelationship = student.ContactPersonRelationship;
                    oldStudent.HasPhoto = false;
                    oldStudent.IsRegistered = true;
                    if (oldStudent.RegistrationDate == null)
                        oldStudent.RegistrationDate = student.RegistrationDate;
                    oldStudent.IsActive = true;
                    oldStudent.ImageName = student.ImageName;
                    dataModel.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }

            }
        }

        public bool UpdatePersonalDetails(Student student)
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {

                try
                {
                    var oldStudent = (from a in dataModel.Students
                                      where a.Id == student.Id
                                      select a).FirstOrDefault();
                    oldStudent.FirstName = student.FirstName;
                    oldStudent.MiddleName = student.MiddleName;
                    oldStudent.LastName = student.LastName;
                    oldStudent.DOB = student.DOB;
                    oldStudent.School = student.School;
                    oldStudent.SchoolAddress = student.SchoolAddress;
                    oldStudent.College = student.College;
                    oldStudent.CollegeAddress = student.CollegeAddress;
                    oldStudent.IsActive = student.IsActive;
                    oldStudent.RegistrationDate = student.RegistrationDate;
                    oldStudent.UpdatedOn = student.UpdatedOn;
                    oldStudent.UpdatedBy = student.UpdatedBy;
                   
                    dataModel.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }

            }
        }
        public bool UpdateContactDetails(Student student)
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {
                try
                {
                    var oldStudent = (from a in dataModel.Students
                                      where a.Id == student.Id
                                      select a).FirstOrDefault();
                    oldStudent.CurrentAddress = student.CurrentAddress;
                    oldStudent.City = student.City;
                    oldStudent.Pincode = student.Pincode;
                    oldStudent.Email = student.Email;
                    oldStudent.Mobile = student.Mobile;
                    oldStudent.ContactPersonName = student.ContactPersonName;
                    oldStudent.ContactPersonPhone = student.ContactPersonPhone;
                    oldStudent.ContactPersonRelationship = student.ContactPersonRelationship;
                   
                    oldStudent.UpdatedOn = student.UpdatedOn;
                    oldStudent.UpdatedBy = student.UpdatedBy;

                    dataModel.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }

        public bool UpdatePhoto(Student student)
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {

                try
                {
                    var oldStudent = (from a in dataModel.Students
                                      where a.Id == student.Id
                                      select a).FirstOrDefault();
                    oldStudent.HasPhoto = student.HasPhoto;
                    oldStudent.ImageName = student.ImageName;
                   
                    oldStudent.UpdatedOn = student.UpdatedOn;
                    oldStudent.UpdatedBy = student.UpdatedBy;

                    dataModel.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }

            }
        }
        
        public IEnumerable<Object> GetStudents(string name, string MobileNo, string RegistrationNo)
        {
            using (SmartSchoolDataModel dataModel = new SmartSchoolDataModel())
            {
                var allData= (from a in dataModel.Students
                        where a.IsRegistered==true
                        select new
                        {
                            Id = a.Id,
                            ImageName = a.ImageName,
                            Name = a.FirstName + " " + a.MiddleName + " " + a.LastName,
                            CurrentAddress = a.CurrentAddress,
                            Mobile = a.Mobile,
                            Email = a.Email,
                            RegistrationNo=a.RegistrationNo
                        }).ToList();
                if (name!=null && name!="")
                {
                   
                    allData = allData.Where(w => w.Name.ToLower().Contains(name.Trim().ToLower())).ToList();
                }
                if(MobileNo!=null && MobileNo != "")
                {
                    allData = allData.Where(w => w.Mobile == MobileNo).ToList();
                }
                if(RegistrationNo!=null && RegistrationNo!="")
                {
                    allData = allData.Where(w => w.RegistrationNo == RegistrationNo).ToList();
                }
                return allData;
            }
        }
    }
}
