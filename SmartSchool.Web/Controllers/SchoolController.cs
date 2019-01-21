using Microsoft.AspNet.Identity;
using SmartSchool.DataAccess.Data;
using SmartSchool.DataAccess.Services;
using SmartSchool.Web.App_Constants;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartSchool.Web.Controllers
{
    [Authorize(Roles = "SysAdmin,SchoolAdmin")]
    public class SchoolController : Controller
    {
        // GET: School

        InquiryService inquiryService;
        StudentService studentService;
        RegistrationService registrationService;
        StudentProgramService studProgService;
        BatchService batchService;
        FeesDetailService feesDetailService;
        public int Width = 110;
        public int Height = 120;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConfirmMessage(string message)
        {
            ViewBag.Message = message;
            return View();
        }
        public ActionResult Inquiry(int? id)
        {
            ViewBag.InquiryId = id == null ? 0 : id.Value;
            return View();
        }
        public ActionResult InquiryMaintenance()
        {
            return View();
        }

        //public ActionResult Registration()
        //{
        //    ViewBag.InquiryId = 0;
        //    return View();
        //}

        public ActionResult Registration(int? id)
        {
            ViewBag.InquiryId = id == null ? 0 : id.Value;
            return View();
        }
        public JsonResult GetInquiryById(int Inquiryid)
        {
            inquiryService = new InquiryService();
            studProgService = new StudentProgramService();

            int studentId = inquiryService.getStudentIdByInquiryId(Inquiryid);

            var allData = new { Student = inquiryService.getInquiryById(Inquiryid), Programs = inquiryService.getStudentProgramsID(studentId), StudentPrograms = studProgService.getStudentProgramsDetail(studentId) };

            //return View(inquiry);
            return Json(allData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Batch()
        {
            return View();
        }

        public ActionResult Student()
        {
            return View();
        }

        public ActionResult StudentDetail(int? id)
        {
            ViewBag.InquiryId = id == null ? 0 : id.Value;
            return View();
        }

        public JsonResult GetInquiriesCounts()
        {
            inquiryService = new InquiryService();
            List<object> allData = new List<object>();
            allData.Add(new
            {
                Course = "Guitar",
                TotalInquiries = inquiryService.getGuitarInquiryCount()
            });
            allData.Add(new
            {
                Course = "KeyBoard",
                TotalInquiries = inquiryService.getKeyBoardInquiryCount()
            });
            allData.Add(new
            {
                Course = "Bass",
                TotalInquiries = inquiryService.getBassInquiryCount()
            });
            allData.Add(new
            {
                Course = "Vocal",
                TotalInquiries = inquiryService.getVocalInquiryCount()
            });
            allData.Add(new
            {
                Course = "Drum",
                TotalInquiries = inquiryService.getDrumInquiryCount()
            });
            allData.Add(new
            {
                Course = "Recording & Mixing",
                TotalInquiries = inquiryService.getRecordingInquiryCount()
            });
            return Json(allData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetActiveStudentsCounts()
        {
            studProgService = new StudentProgramService();
            List<object> allData = new List<object>();
            allData.Add(new
            {
                Course = "Guitar",
                TotalInquiries = studProgService.getActiveProgramCount((int)ProgramId.Guitar)
            });
            allData.Add(new
            {
                Course = "KeyBoard",
                TotalInquiries = studProgService.getActiveProgramCount((int)ProgramId.KeyBoard)
            });
            allData.Add(new
            {
                Course = "Bass",
                TotalInquiries = studProgService.getActiveProgramCount((int)ProgramId.Bass)
            });
            allData.Add(new
            {
                Course = "Vocal",
                TotalInquiries = studProgService.getActiveProgramCount((int)ProgramId.Vocals)
            });
            allData.Add(new
            {
                Course = "Drum",
                TotalInquiries = studProgService.getActiveProgramCount((int)ProgramId.Drums)
            });
            allData.Add(new
            {
                Course = "Recording & Mixing",
                TotalInquiries = studProgService.getActiveProgramCount((int)ProgramId.Recording)
            });
            return Json(allData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetValidityOverCounts()
        {
            studProgService = new StudentProgramService();
            List<object> allData = new List<object>();
           
           
            allData.Add(new
            {

                Course = "Guitar",
                TotalRegistraion = studProgService.GetValidityOverCounts((int)ProgramId.Guitar)
            });
            allData.Add(new
            {

                Course = "KeyBoard",
                TotalRegistraion = studProgService.GetValidityOverCounts((int)ProgramId.KeyBoard)
            });
            allData.Add(new
            {

                Course = "Bass",
                TotalRegistraion = studProgService.GetValidityOverCounts((int)ProgramId.Bass)
            });
            allData.Add(new
            {

                Course = "Vocal",
                TotalRegistraion = studProgService.GetValidityOverCounts((int)ProgramId.Vocals)
            });
            allData.Add(new
            {

                Course = "Drum",
                TotalRegistraion = studProgService.GetValidityOverCounts((int)ProgramId.Drums)
            });
            allData.Add(new
            {

                Course = "Recording & Mixing",
                TotalRegistraion = studProgService.GetValidityOverCounts((int)ProgramId.Recording)
            });
            return Json(allData, JsonRequestBehavior.AllowGet);
        }



        public JsonResult GetRegistrationCounts()
        {
            List<object> allData = new List<object>();
            allData.Add(new
            {

                Course = "Guitar",
                TotalRegistraion = 40
            });
            allData.Add(new
            {

                Course = "KeyBoard",
                TotalRegistraion = 60
            });
            allData.Add(new
            {

                Course = "Bass",
                TotalRegistraion = 35
            });
            allData.Add(new
            {

                Course = "Vocal",
                TotalRegistraion = 42
            });
            allData.Add(new
            {

                Course = "Drum",
                TotalRegistraion = 30
            });
            allData.Add(new
            {

                Course = "Recording & Mixing",
                TotalRegistraion = 45
            });
            return Json(allData, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetStudents(string name,string MobileNo,string RegistrationNo)
        {
            studentService = new StudentService();
            var allData = studentService.GetStudents(name,  MobileNo,  RegistrationNo);
            return Json(allData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetFeesDetail(int Inquiryid)
        {
            feesDetailService = new FeesDetailService();
            inquiryService = new InquiryService();
            studProgService = new StudentProgramService();

            int studentId = inquiryService.getStudentIdByInquiryId(Inquiryid);

            var allData = feesDetailService.GetFeesDetail(studentId);
            return Json(allData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetBatches()
        {
            batchService = new BatchService();
            var allData = batchService.getBatches();
            return Json(allData, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddBatch(Batch batch)
        {
            var result = new { Success = "true", Message = "Success" };
            batchService = new BatchService();
            try
            {
                int batchId = batchService.Insert(batch);
            }
            catch (Exception ex)
            {

                result = new { Success = "false", Message = "Error" };
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateBatch(Batch batch)
        {
            var result = new { Success = "true", Message = "Success" };
            batchService = new BatchService();

            if (!batchService.Update(batch))
                result = new { Success = "false", Message = "Error" };

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetBatchDetailById(int Id)
        {
            batchService = new BatchService();
            var allData = batchService.getBatchDetailById(Id);

            return Json(allData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetInquiries(string Name, string program, string Duration, int RegisterValue)
        {
            inquiryService = new InquiryService();

            try
            {
                var allData = inquiryService.getInquiries(Name, program, Duration, RegisterValue);
                return Json(allData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
                throw;
            }


        }
        public JsonResult getLatestInquiries()
        {
            inquiryService = new InquiryService();

            try
            {
                var allData = inquiryService.getLatestInquiries(10);
                return Json(allData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
                throw;
            }

        }

        public JsonResult GetRenewalRequiredDetail()
        {
            studProgService = new StudentProgramService();
            var allData = studProgService.GetRenewalRequiredDetail();

            return Json(allData, JsonRequestBehavior.AllowGet);

        }



        [HttpPost]
        public JsonResult AddInquiry(Inquiry inquiry, Student student)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            var result = new { Success = "true", Message = "Success" };
            inquiryService = new InquiryService();
            studentService = new StudentService();

            try
            {
                student.AddedBy = User.Identity.GetUserId();
                student.AddedOn = DateTime.Now;
                student.IsActive = false;
                student.IsRegistered = false;
                student.FirstName = textInfo.ToTitleCase(student.FirstName);
                student.MiddleName = textInfo.ToTitleCase(student.MiddleName);
                student.LastName = textInfo.ToTitleCase(student.LastName);

                int studentId = studentService.Insert(student);

                inquiry.StudentId = studentId;
                inquiry.InquiryDate = DateTime.Now;
                inquiryService.Insert(inquiry);
            }
            catch (Exception ex)
            {
                result = new { Success = "false", Message = "Error" };
            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult UpdateInquiry(Inquiry inquiry, Student student)
        {
            var result = new { Success = "true", Message = "Success" };
            inquiryService = new InquiryService();
            studentService = new StudentService();

            try
            {
                int studentId = inquiryService.Update(inquiry);
                if (studentId > 0)
                {
                    student.Id = studentId;
                    if (!studentService.Update(student))
                        result = new { Success = "false", Message = "Error" };
                }
            }
            catch (Exception ex)
            {
                result = new { Success = "false", Message = "Error" };
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddRegister(Student student, int inquiryId, StudentProgram studentProgram, FeesDetail fees)
        {
            var result = new { Success = "true", Message = "Success" };
            inquiryService = new InquiryService();
            studentService = new StudentService();
            registrationService = new RegistrationService();
            studProgService = new StudentProgramService();
            try
            {
                student.Id = inquiryService.getStudentIdByInquiryId(inquiryId);

                student.IsActive = true;
                student.IsRegistered = true;
                student.RegistrationDate = DateTime.Now;
                bool success = studentService.Update(student);

                //Add Student Program
                if (success)
                {
                    studentProgram.StudentId = student.Id;
                    int studentProgramId = studProgService.Insert(studentProgram);

                    //Add Fees Detail
                    if (studentProgramId != 0)
                    {
                        feesDetailService = new FeesDetailService();
                        fees.StudentProgramId = studentProgramId;
                        fees.PaidOn = DateTime.Now;
                        fees.Duration = studentProgram.Duration;
                        feesDetailService.Insert(fees);
                    }
                }
                //  inquiryService.Insert(inquiry);
            }
            catch (Exception ex)
            {
                result = new { Success = "false", Message = "Error" };
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdatePersonalDetails(Student student, int inquiryId)
        {
            var result = new { Success = "true", Message = "Success" };
            inquiryService = new InquiryService();
            studentService = new StudentService();
            registrationService = new RegistrationService();
            studProgService = new StudentProgramService();
            try
            {
                student.Id = inquiryService.getStudentIdByInquiryId(inquiryId);

                student.UpdatedBy = User.Identity.GetUserId();
                student.UpdatedOn = DateTime.Now;
               
                bool success = studentService.UpdatePersonalDetails(student);
            }
            catch (Exception ex)
            {
                result = new { Success = "false", Message = "Error" };
            }
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public JsonResult UpdatePhoto(Student student, int inquiryId)
        {
            var result = new { Success = "true", Message = "Success" };
            inquiryService = new InquiryService();
            studentService = new StudentService();
            registrationService = new RegistrationService();
            studProgService = new StudentProgramService();
            try
            {
                student.Id = inquiryService.getStudentIdByInquiryId(inquiryId);

                student.UpdatedBy = User.Identity.GetUserId();
                student.UpdatedOn = DateTime.Now;

                bool success = studentService.UpdatePhoto(student);
            }
            catch (Exception ex)
            {
                result = new { Success = "false", Message = "Error" };
            }
            return Json(result, JsonRequestBehavior.AllowGet);

        }


        public JsonResult UpdateStudentProgramDetails(StudentProgram studentProgram, int inquiryId)
        {
            var result = new { Success = "true", Message = "Success" };
            inquiryService = new InquiryService();
            studProgService = new StudentProgramService();
         
            try
            {
               
              //  studentProgram.UpdatedBy = User.Identity.GetUserId();
                studentProgram.UpdatedOn = DateTime.Now;
             
                bool success = studProgService.Update(studentProgram);
            }
            catch (Exception ex)
            {
                result = new { Success = "false", Message = "Error" };
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateContactDetails(Student student, int inquiryId)
        {
            var result = new { Success = "true", Message = "Success" };
            inquiryService = new InquiryService();
            studentService = new StudentService();

            studProgService = new StudentProgramService();
            try
            {
                student.Id = inquiryService.getStudentIdByInquiryId(inquiryId);
                student.UpdatedBy = User.Identity.GetUserId();
                student.UpdatedOn = DateTime.Now;

                bool success = studentService.UpdateContactDetails(student);
            }
            catch (Exception ex)
            {
                result = new { Success = "false", Message = "Error" };
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public JsonResult UploadProfilePic()
        {
            //Reference: http://stackoverflow.com/questions/14575787/how-to-upload-image-in-asp-net-mvc-4-using-ajax-or-any-other-technique-without-p
            try
            {
                if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
                {

                    var pic = System.Web.HttpContext.Current.Request.Files["HelpSectionImages"];
                    int index = pic.FileName.LastIndexOf('.');
                    string ext = pic.FileName.Substring(index).ToLower();
                    if (ext != ".jpg" && ext != ".png" && ext != ".gif" && ext != ".jpeg")
                    {
                        return Json(new { PhotoMessage = "Allowed file types are .jpg, .png , .gif .", FileName = "" }, JsonRequestBehavior.AllowGet);
                    }

                    //Create directory
                    string subPath = Server.MapPath("../Uploads/ProfilePics"); // your code goes here

                    bool exists = System.IO.Directory.Exists(subPath);
                    if (!exists)
                        System.IO.Directory.CreateDirectory(Server.MapPath(subPath));


                    string filename = Guid.NewGuid().ToString() + ext;

                    //string imageSavePath = "";
                    pic.SaveAs(subPath + "\\" + filename);


                    Image imgOriginal = Image.FromFile(subPath + "\\" + filename);

                    //pass in whatever value you want
                    Image imgActual = Scale(imgOriginal);
                    imgOriginal.Dispose();
                    imgActual.Save(subPath + "\\" + filename);
                    imgActual.Dispose();


                    System.IO.FileInfo fi = new System.IO.FileInfo(pic.FileName);
                    return Json(new { PhotoMessage = "Success", FileName = filename }, JsonRequestBehavior.AllowGet);

                }
                return Json(new { PhotoMessage = "Unable to upload image.", FileName = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { PhotoMessage = "Error uploading image. Please contact administrator.", FileName = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult InsertFees(FeesDetail Fees,int programId, int inquiryId)
        {
            var result = new { Success = "true", Message = "Success", NewEndDate = Fees.ValidTill.Value };
            inquiryService = new InquiryService();
            studentService = new StudentService();
            registrationService = new RegistrationService();
            studProgService = new StudentProgramService();
            feesDetailService = new FeesDetailService();
            try
            {
                int  studentId = inquiryService.getStudentIdByInquiryId(inquiryId);
                Fees.StudentProgramId = studProgService.getStudentProgramId(studentId, programId);
                Fees.PaidOn =DateTime.Now;

                int feesId = feesDetailService.Insert(Fees);
                studProgService.UpdateValidDate(Fees.StudentProgramId.Value,  Fees.ValidTill.Value);
            }
            catch (Exception ex)
            {
                result = new { Success = "false", Message = "Error" ,NewEndDate= Fees.ValidTill.Value };
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private Image Scale(Image imgPhoto)
        {
            float sourceWidth = imgPhoto.Width;
            float sourceHeight = imgPhoto.Height;
            float destHeight = 0;
            float destWidth = 0;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            // force resize, might distort image
            if (Width != 0 && Height != 0)
            {
                destWidth = Width;
                destHeight = Height;
            }
            // change size proportially depending on width or height
            else if (Height != 0)
            {
                destWidth = (float)(Height * sourceWidth) / sourceHeight;
                destHeight = Height;
            }
            else
            {
                destWidth = Width;
                destHeight = (float)(sourceHeight * Width / sourceWidth);
            }

            Bitmap bmPhoto = new Bitmap((int)destWidth, (int)destHeight,
                                        PixelFormat.Format32bppPArgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, (int)destWidth, (int)destHeight),
                new Rectangle(sourceX, sourceY, (int)sourceWidth, (int)sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();

            return bmPhoto;
        }

    }
}