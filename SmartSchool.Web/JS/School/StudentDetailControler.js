smartApp.controller("StudentDetailCtrl", function ($scope, $parse, $http) {
    $scope.createWidget = false;
    $scope.RegisterValue = 3;
   
    $scope.JoiningDate = new Date();
   
    $scope.Program = [];

    $scope.ProgramDiv = [];
    for (i = 0; i < 6; i++) {
        $scope.ProgramDiv[i] = false;
    }
    $scope.jqxWindowSettings = {  };

    //Dropdownlist course
   
   
    $scope.courses = [ {
        id: 2,
        name: "Guitar"

    }, {
        id: 3,
        name: "KeyBoard"

    }, {
        id: 4,
        name: "Bass"

    }, {
        id: 5,
        name: "Drum"

    }, {
        id: 6,
        name: "Vocal"

    }, {
        id: 7,
        name: "Recording & Mixing"
    }];
    $scope.CourseSettings = {};
 
    // init DropDownList's settings object.
   
  
    //Fees Grid
    $scope.sourceFees = {
        datatype: "json",
        datafields: [
           { name: 'Id', type: 'int' },
           { name: 'ProgramId', type: 'int' },
           { name: 'ProgramName', type: 'string' },
           { name: 'FeesPaid', type: 'string' },
           { name: 'Duration', type: 'string' },
           { name: 'ValidTill', type: 'date' },
           { name: 'PaidOn', type: 'date' }
        ],
        url: '/School/GetFeesDetail',
        data: { Inquiryid: $('#hdnInquiryId').val() },
        Id: "Id",
        sortcolumn: 'Name',
        sortdirection: 'asc'
    };
    $scope.gridDataAdapter = new $.jqx.dataAdapter($scope.sourceFees);

    $scope.FeesGrid  = {
        showtoolbar: true,
        rendertoolbar: function (toolbar) {
            var me = this;
            var container = $("<div style='margin: 5px;'></div>");

            toolbar.append(container);

            container.append('<input id="addbutton" type="button" style="float:right;" value="Add Fees" />');

            $("#addbutton").jqxButton({ theme: $scope.Theme });
            $('#addbutton').click(function (e) {
                // window.location.href = "/School/Inquiry/0";
                $scope.jqxWindowSettings.apply('show');
            });
        }
    };

    //Batch
    $scope.BatchSource = {
        datatype: "json",
        datafields: [
           { name: 'Id', type: 'int' },
           { name: 'Title', type: 'string' }
        ],
        url: '/School/GetBatches'
    };
    $scope.gridDataAdapter = new $.jqx.dataAdapter($scope.BatchSource);

  
    var bindData = function () {
         
        $scope.Program = [];

        $scope.ProgramDiv = [];
        $.ajax({
            url: "/School/GetInquiryById",
            type: "GET",
            contentType: "application/json;",
            dataType: "json",
            data: { Inquiryid: $('#hdnInquiryId').val() },
            success: function (inquiry) {
                 
               $scope.$apply(function () {
                 
                    
                    $scope.FirstName = inquiry.Student.FirstName;
                    $scope.MiddleName = inquiry.Student.MiddleName;
                    $scope.LastName = inquiry.Student.LastName;
                    $scope.FullName = inquiry.Student.FirstName + " " + inquiry.Student.MiddleName + " " + inquiry.Student.LastName;
                    $scope.Address = inquiry.Student.Address;
                    $scope.Mobile = inquiry.Student.PhoneNumber;
                    $scope.City = inquiry.Student.City;
                    $scope.IsActive = inquiry.Student.IsActive;
                    $scope.Pincode = inquiry.Student.Pincode;
                    $scope.Mobile = inquiry.Student.Mobile;
                    $scope.DOB = new Date($scope.ToJavaScriptDate(inquiry.Student.DOB));
                    $scope.Email = inquiry.Student.Email;
                    $scope.School = inquiry.Student.School;
                    $scope.SchoolAddress = inquiry.Student.SchoolAddress;
                    $scope.College = inquiry.Student.College;
                    $scope.CollegeAddress = inquiry.Student.CollegeAddress;
                    $scope.ContactPersonName = inquiry.Student.ContactPersonName;
                    $scope.ContactPersonPhone = inquiry.Student.ContactPersonPhone;
                    $scope.ContactPersonRelationship = inquiry.Student.ContactPersonRelationship;
                    $scope.HasPhoto = inquiry.Student.HasPhoto;
                    if (inquiry.Student.ImageName == null || inquiry.Student.ImageName == "") {
                        $('#hdnPhotoPath').val("");
                        $("#imgProfilePic").attr("src", "/Uploads/ProfilePics/defaultDP.png");// response.FileName;
                    }
                    else {
                        $('#hdnPhotoPath').val(inquiry.Student.ImageName);
                        $("#imgProfilePic").attr("src", "/Uploads/ProfilePics/" + inquiry.Student.ImageName);// response.FileName;
                    }

                    var programArray = inquiry.Programs;
                    if (programArray != null && programArray.length > 0) {
                        $scope.programs = "(Alredy Registered in " + inquiry.Student.Programs + " .)";
                    }


                    for (i = 0; i < programArray.length; i++) {
                        var programId = programArray[i];
                    }

                    //$scope.Program[1].ProgramName = inquiry.StudentPrograms[0].ProgramName;
                    $scope.courses = [];
                    for (i = 0; i < inquiry.StudentPrograms.length; i++) {
                        $scope.ProgramDiv[i] = true;
                        $scope.courses.push({ id: inquiry.StudentPrograms[i].ProgramId, name: inquiry.StudentPrograms[i].ProgramName });
                        $scope.Program.push({
                            StudentProgramId: inquiry.StudentPrograms[i].Id,
                            IsActive:inquiry.StudentPrograms[i].IsActive,
                            ProgramId: inquiry.StudentPrograms[i].ProgramId,
                            ProgramName: inquiry.StudentPrograms[i].ProgramName, joinDtProgram: new Date($scope.ToJavaScriptDate(inquiry.StudentPrograms[i].StartDate)),
                            EnddateProgram: new Date($scope.ToJavaScriptDate(inquiry.StudentPrograms[i].EndDate)), selectedBatch: inquiry.StudentPrograms[i].BatchId
                        });
                    }
                     
                    $scope.CourseSettings.source = $scope.courses;
                   // $scope.CourseSettings = { source: $scope.courses };
                    $scope.Remarks = inquiry.Student.Note;
                    // $scope.listSettings.jqxListBox('refresh');
                    //$scope.FeesGrid.jqxGrid('bind');
                    //  $scope.FeesGrid.apply('updatebounddata');
                });
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert('oops, something bad happened');
            }
        });
    }
     
    if ($('#hdnInquiryId').val() > 0) {
        bindData();
    }
        

    //Update Personal Detail
    $scope.SavePersonalDetail = function (e) {
        $scope.openConfirm("Confirmation", 'Are you sure you want to update Personal Detail?', 350, 100, function (e) {
            if (e) {
                var student = {
                    FirstName: $scope.FirstName,
                    MiddleName: $scope.MiddleName,
                    LastName: $scope.LastName,
                    DOB: $scope.DOB,
                    School: $scope.School,
                    SchoolAddress: $scope.SchoolAddress,
                    College: $scope.College,
                    CollegeAddress: $scope.CollegeAddress,
                    RegistrationDate:  $scope.JoiningDate ,
                    IsActive: $scope.IsActive
                }

                $http.post('/School/UpdatePersonalDetails', { student: student, inquiryId: $('#hdnInquiryId').val() }).success(function (retData) {
                    if (retData.Message == "Success") {
                       
                       // $scope.ErroMessage = "Personal Detail saved successfully.";
                        $scope.openMessageBox("Success", 'Personal Detail saved successfully.', 350, 100);
                    } else {
                        $scope.ErroMessage = "Please try after some time.";
                    }

                }).error(function (retData, status, headers, config) {
                    //alert(data.toString());
                });

            }
            else {

            }
        });
    };

    //Update Contact Detail
    $scope.SaveContactDetail = function (e) {
        $scope.openConfirm("Confirmation", 'Are you sure you want to update Contact Detail?', 350, 100, function (e) {
            if (e) {
                var student = {
                    CurrentAddress: $scope.Address,
                    City: $scope.City,
                    Pincode: $scope.Pincode,
                    Email: $scope.Email,
                    Mobile: $scope.Mobile,
                    ContactPersonName: $scope.ContactPersonName,
                    ContactPersonPhone: $scope.ContactPersonPhone,
                    ContactPersonRelationship: $scope.ContactPersonRelationship
                }

                $http.post('/School/UpdateContactDetails', { student: student, inquiryId: $('#hdnInquiryId').val() }).success(function (retData) {
                    if (retData.Message == "Success") {

                      //  $scope.ErroMessage = "Contact Detail saved successfully.";
                        $scope.openMessageBox("Success", 'Contact Detail saved successfully.', 350, 100);
                    } else {
                        $scope.ErroMessage = "Please try after some time.";
                    }

                }).error(function (retData, status, headers, config) {
                    //alert(data.toString());
                });

            }
            else {

            }
        });
    };

    //Update Program
    
    $scope.SaveProgram = function (e, ProgramDockNo) {
         
        var buttonID = event.target.id;
        var Program = $scope.Program[buttonID].ProgramName;
        $scope.openConfirm("Confirmation", 'Are you sure you want to update Program Detail?', 350, 100, function (e) {
            if (e) {
                 

                var studentProgram = {
                    Id: $scope.Program[buttonID].StudentProgramId,IsActive:$scope.Program[buttonID].IsActive,
                    StartDate: $scope.Program[buttonID].joinDtProgram, EndDate: $scope.Program[buttonID].EnddateProgram, BatchId: $scope.Program[buttonID].selectedBatch
                };

                $http.post('/School/UpdateStudentProgramDetails', { studentProgram: studentProgram, inquiryId: $('#hdnInquiryId').val() }).success(function (retData) {
                    if (retData.Message == "Success") {

                       // $scope.ErroMessage = "Program Detail saved successfully.";
                        $scope.openMessageBox("Success", 'Program Detail saved successfully.', 350, 100);
                    } else {
                        //$scope.openMessageBox("Canceled", 'Program Detail saved successfully.', 350, 100);
                       // $scope.ErroMessage = "Please try after some time.";
                    }

                }).error(function (retData, status, headers, config) {
                    //alert(data.toString());
                });

            }
            else {

            }
        });

       
    };

    $scope.onSaveFees = function (e, ProgramDockNo) {
         
        var buttonID = event.target.id;
        //var Program = $scope.Program[buttonID].ProgramName;
        $scope.openConfirm("Confirmation", 'Are you sure you want to add Fees?', 350, 100, function (e) {
            if (e) {
                var Fees = {
                    FeesPaid: $scope.FeePaid, Duration: $scope.duration, ValidTill: $scope.Enddate
                };
              
               
                $http.post('/School/InsertFees', { Fees: Fees, programId: $scope.selectedCourse2, inquiryId: $('#hdnInquiryId').val() }).success(function (retData) {
                    if (retData.Message == "Success") {
                         
                       

                            $scope.Program[0].EnddateProgram = new Date($scope.ToJavaScriptDate(retData.NewEndDate));

                        
                        //bindData();
                        //$scope.Program.push({
                        //    StudentProgramId: inquiry.StudentPrograms[i].Id,
                        //    ProgramId: inquiry.StudentPrograms[i].ProgramId,
                        //    ProgramName: inquiry.StudentPrograms[i].ProgramName, joinDtProgram: new Date($scope.ToJavaScriptDate(inquiry.StudentPrograms[i].StartDate)),
                        //    EnddateProgram: new Date($scope.ToJavaScriptDate(inquiry.StudentPrograms[i].EndDate)), selectedBatch: inquiry.StudentPrograms[i].BatchId
                        //});
                       
                        $scope.FeesGrid.apply('updatebounddata');
                        $scope.jqxWindowSettings.apply('hide');
                    } else {
                        
                    }

                }).error(function (retData, status, headers, config) {
                     
                });

            }
            else {

            }
        });


    };
    $("#uploadStudentImage").change(function () {

        var data = new FormData();
        var files = $("#uploadStudentImage").get(0).files;
        if (files.length > 0) {
            data.append("HelpSectionImages", files[0]);
            var uploadFile = files[0];
            if (!(/\.(gif|jpg|jpeg|tiff|png)$/i).test(uploadFile.name)) {
                $('#hdnPhotoPath').val("");
                $('#txtImagePath').val("");
                // alert('You must select an image file only');

                $scope.openMessageBox("Alert!", 'You must select an image file only', 350, 100);
                return;
            }
            if (uploadFile.size > 2000000) { // 2mb
                $('#txtImagePath').val("");
                $('#hdnPhotoPath').val("");
                $scope.openMessageBox("Alert!", 'Please upload a smaller image, max size is 2 MB', 350, 100);
                //alert('Please upload a smaller image, max size is 2 MB');
                return;
            }
        }

        $.ajax({
            url: "/School/UploadProfilePic",
            type: "POST",
            processData: false,
            contentType: false,
            data: data,
            success: function (response) {
                //code after success
                //alert(response.Message);

                if (response.FileName == "") {
                    $scope.HasPhoto = false;
                    $('#hdnPhotoPath').val("");
                } else {
                    $scope.HasPhoto = true;
                    $('#hdnPhotoPath').val(response.FileName);
                    $("#imgProfilePic").attr("src", "/Uploads/ProfilePics/" + response.FileName);// response.FileName;

                    //UpdatePhoto in db
                    var student = {
                        HasPhoto: $scope.HasPhoto,
                        ImageName: response.FileName
                    }

                    $http.post('/School/UpdatePhoto', { student: student, inquiryId: $('#hdnInquiryId').val() }).success(function (retData) {
                        if (retData.Message == "Success") {

                          //  $scope.ErroMessage = "Photo saved successfully.";
                            $scope.openMessageBox("Success", 'Photo saved successfully.', 350, 100);
                        } else {
                            $scope.ErroMessage = "Please try after some time.";
                        }

                    }).error(function (retData, status, headers, config) {
                        //alert(data.toString());
                    });
                    
                    //   $('#divProfilePic').unblock();
                }
            },
            error: function (er) {
                //alert(er);

                //    $('#divProfilePic').unblock();
            },
            beforeSend: function (jqXHR, settings) {
                //  $('#divProfilePic').blockElement({ showImage: true });
            }
        });
    });


    $scope.createWidget = true;
});