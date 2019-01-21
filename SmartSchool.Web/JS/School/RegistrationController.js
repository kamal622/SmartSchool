smartApp.controller("RegistrationCtrl", function ($scope, $http) {
    //alert('Dashboard');
    //$scope.parentMethod(); //it'll work
    $scope.createWidget = false;
    //$scope.$apply(function () {

    $scope.DOB = new Date();
    $scope.joinDt = new Date();
    $scope.Enddate = new Date();
    $scope.duration = 1;

    $scope.radio1 = {};
    $scope.radio2 = {};
    $scope.form = {};
    $scope.radio = [
    {},
    {},
    {},
    {},
    {}, {},
    {},
    {},
    {},
    ];
    
    $scope.BatchSource = {
        datatype: "json",
        datafields: [
           { name: 'Id', type: 'int' },
           { name: 'Title', type: 'string' }
        ],
        url: '/School/GetBatches'
    };
    $scope.gridDataAdapter = new $.jqx.dataAdapter($scope.BatchSource);

    $.ajax({
        url: "/School/GetInquiryById",
        type: "GET",
        contentType: "application/json;",
        dataType: "json",
        data: { Inquiryid: $('#hdnInquiryId').val() },
        success: function (inquiry) {
             
            $scope.$apply(function () {
                $scope.RegistrtionNo = inquiry.Student.StudentId;
                $scope.FirstName = inquiry.Student.FirstName;
                $scope.MiddleName = inquiry.Student.MiddleName;
                $scope.LastName = inquiry.Student.LastName;
                $scope.Address = inquiry.Student.Address;
                $scope.Mobile = inquiry.Student.PhoneNumber;
                $scope.City = inquiry.Student.City;
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
                                
                var programArray = inquiry.Programs;
                if (programArray != null && programArray.length > 0)
                {
                    $scope.programs = "(Alredy Registered in " + inquiry.Student.Programs+" .)";
                }
                
                 
                for (i = 0; i < programArray.length; i++) {
                    //jqx - radio - button
                    // $scope.radio1.jqxRadioButton('disable');
                    var programId =programArray[i];
                    $scope.radio[programId].jqxRadioButton('disable');
                }

                 
                if (inquiry.Student.ImageName == null || inquiry.Student.ImageName == "") {
                    $('#hdnPhotoPath').val("");
                    $("#imgProfilePic").attr("src", "/Uploads/ProfilePics/defaultDP.png");// response.FileName;
                }
                else {
                    $('#hdnPhotoPath').val(inquiry.Student.ImageName);
                    $("#imgProfilePic").attr("src", "/Uploads/ProfilePics/" + inquiry.Student.ImageName);// response.FileName;

                }

                // $scope.DOB = ToJavaScriptDate(inquiry.DOB); 
            });
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert('oops, something bad happened');
        }
    });


    // $scope.my = { IsGuitar: false };
    //   $scope.IsGuitar = false;

    //$rootScope.IsKeyBoard = false;

    //});
    $scope.onRegister = function (e) {
       
            var studentProgram = {
                ProgramId: $scope.program, Duration: $scope.duration, StartDate: $scope.joinDt, EndDate: $scope.Enddate, BatchId: $scope.selectedBatch, TotalFees: $scope.TotalFee, Remarks: $scope.Remarks,IsActive:true

            };

            //var registration = {
            //    ProgramId: $scope.program, Duration: $scope.duration, StratFrom: $scope.joinDt, ValidTill: $scope.Enddate, TotalFees: $scope.TotalFee, FeesPaid: $scope.FeePaid, Remarks: $scope.Remarks, IsActive: true
            //};

            var student = {
                FirstName: $scope.FirstName,
                MiddleName: $scope.MiddleName,
                LastName: $scope.LastName,
                CurrentAddress: $scope.Address,
                City: $scope.City,
                Pincode: $scope.Pincode,
                StateId: "",
                CountryId: "",
                Mobile: $scope.Mobile,
                DOB: $scope.DOB,
                Email: $scope.Email,
                School: $scope.School,
                SchoolAddress: $scope.SchoolAddress,
                College: $scope.College,
                CollegeAddress: $scope.CollegeAddress,
                ContactPersonName: $scope.ContactPersonName,
                ContactPersonPhone: $scope.ContactPersonPhone,
                ContactPersonRelationship: $scope.ContactPersonRelationship,
                HasPhoto: $scope.HasPhoto,
                ImageName: $('#hdnPhotoPath').val(),
                IsRegistered: true,
                IsActive: true
            }

            var fees = {
                FeesPaid: $scope.FeePaid
            };
            $http.post('/School/AddRegister', { student: student, inquiryId: $('#hdnInquiryId').val(), studentProgram: studentProgram, fees: fees }).success(function (retData) {
                if (retData.Message == "Success") {
                    $scope.onClear();
                    $scope.ErroMessage = "Registration done successfully."
                    window.location.href = "/School/InquiryMaintenance/";
                } else {
                    $scope.RetMessage = "Please try after some time.";
                }

            }).error(function (retData, status, headers, config) {
                //alert(data.toString());
            });
      
       
       
    };

    $scope.onClear = function (e) {
        //Set parameters
        $scope.FirstName = "";
        $scope.MiddleName = "";
        $scope.LastName = "";
        $scope.Address = "";
        $scope.Pincode = "";
        //StateId: "",
        // CountryId: "",
        $scope.City = "";
        $scope.School = "";
        $scope.SchoolAddress = "";
        $scope.College = "";
        $scope.CollegeAddress = "";
        $scope.ContactPersonName = "";
        $scope.ContactPersonPhone = "";
        $scope.ContactPersonRelationship = "";
        $scope.Mobile = "";
        $scope.DOB = new Date();

        $scope.joinDt = new Date();
        $scope.Enddate = new Date();
        $scope.TotalFee = 0;
        $scope.FeePaid = 0;
        $scope.Remarks = "";
        $scope.Email = "";
        $scope.program = {
            Id: '1'
        };
        $scope.duration = {
            Id: '1'
        };
        $scope.ValidUpto = new Date();
        $scope.Remarks = "";

        $('#hdnPhotoPath').val("");
        $("#imgProfilePic").attr("src", "/Uploads/ProfilePics/defaultDP.png");// response.FileName;
       

        //Ajax call to save
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

    $scope.JoinDateChanged = function (event) {
       
        var date = event.args.date;
        $scope.Enddate =new Date($scope.addMonths(date, $scope.duration));
    };
    $scope.duration1Change = function (event) {
       
        $scope.Enddate = new Date($scope.addMonths($scope.joinDt, 1));
    };
    $scope.duration3Change = function (event) {
       
        $scope.Enddate = new Date($scope.addMonths($scope.joinDt, 3));
    };
    $scope.duration6Change = function (event) {
       
        $scope.Enddate = new Date($scope.addMonths($scope.joinDt, 6));
    };
    $scope.duration12Change = function (event) {
        
        $scope.Enddate = new Date($scope.addMonths($scope.joinDt, 12));
    };
    
    // now create the widget.
    $scope.createWidget = true;


});