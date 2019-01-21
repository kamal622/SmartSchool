smartApp.controller("InquiryCtrl", function ($scope, $http) {
    //alert('Dashboard');
    //$scope.parentMethod(); //it'll work
    $scope.createWidget = false;
    $scope.IsGuitar = false;
    $scope.IsKeyBoard = false;
    $scope.IsBass = false;
    $scope.IsDrums = false;
    $scope.IsVocals = false;
    $scope.IsRecording = false;
    $scope.IsMorning = false;
    $scope.IsEvening = false;
    $scope.DOB = new Date();
    //$scope.Email = 'me@example.com';
    $scope.emailFormat = /^[a-z]+[a-z0-9._]+@[a-z]+\.[a-z.]{2,5}$/;

    if ($('#hdnInquiryId').val() > 0) {
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
                    $scope.Address = inquiry.Student.Address;
                    $scope.Mobile = inquiry.Student.PhoneNumber;
                    $scope.City = inquiry.Student.City;
                    $scope.Pincode = inquiry.Student.Pincode;
                    $scope.Mobile = inquiry.Student.Mobile;
                    $scope.DOB = new Date($scope.ToJavaScriptDate(inquiry.Student.DOB));
                    $scope.Email = inquiry.Student.Email;

                    $scope.IsGuitar = inquiry.Student.IsInterestedInGuitar;
                    $scope.IsKeyBoard = inquiry.Student.IsInterestedInKeyBoard;
                    $scope.IsBass = inquiry.Student.IsInterestedInBass;
                    $scope.IsDrums = inquiry.Student.IsInterestedInDrums;
                    $scope.IsVocals = inquiry.Student.IsInterestedInVocals;
                    $scope.IsRecording = inquiry.Student.IsInterestedInRecording;
                    $scope.IsEvening = inquiry.Student.IsEvening;
                    $scope.IsMorning = inquiry.Student.IsMorning;
                    $scope.Remarks = inquiry.Student.Note;
                });
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert('oops, something bad happened');
            }
        });
    }


    $scope.onSaveInquiry = function (e) {
        //Set parameters
         
        $scope.submitted = true;
        if(  $scope.IsGuitar == false && $scope.IsKeyBoard == false && $scope.IsBass == false &&   $scope.IsDrums == false &&   $scope.IsVocals == false && $scope.IsRecording == false)
        {
            $scope.ErroMessage ="Please select atleast one Program.";
            return;
        }
        if(  $scope.IsMorning == false && $scope.IsEvening == false)
        {
            $scope.ErroMessage ="Please select prefered timing.";
            return;
        }

        $scope.openConfirm("Confirmation", 'Are you sure you want to save Inquiry changes?', 350, 100, function (e) {
            if (e)
            {
                 
                    var student = {
                        FirstName: $scope.FirstName,
                        MiddleName: $scope.MiddleName,
                        LastName: $scope.LastName,
                        CurrentAddress: $scope.Address,
                        Mobile: $scope.Mobile,
                        DOB: $scope.DOB,
                        Email: $scope.Email
                    }
                    var inquiry = {
                        Id: $('#hdnInquiryId').val(),
                        IsInterestedInGuitar: $scope.IsGuitar,
                        IsInterestedInKeyBoard: $scope.IsKeyBoard,
                        IsInterestedInBass: $scope.IsBass,
                        IsInterestedInDrums: $scope.IsDrums,
                        IsInterestedInVocals: $scope.IsVocals,
                        IsInterestedInRecording: $scope.IsRecording,
                        PreferredTiming: $scope.IsMorning,
                        IsMorning: $scope.IsMorning,
                        IsEvening: $scope.IsEvening,
                        Remarks: $scope.Remarks
                    }
                    //Ajax call to save
                    if ($('#hdnInquiryId').val() == 0) {

                        $http.post('/School/AddInquiry', { inquiry: inquiry, student: student }).success(function (retData) {
                             
                            if (retData.Message == "Success") {
                                $scope.onClear();
                                $scope.ErroMessage = "Inquiry added successfully."
                                window.location.href = "/School/InquiryMaintenance/";
                            } else {
                                $scope.ErroMessage = "Please try after some time.";
                            }

                        }).error(function (retData, status, headers, config) {
                            $scope.ErroMessage = "Please try after some time.";
                        });
                    }
                    else
                        if ($('#hdnInquiryId').val() > 0) {
                            $http.post('/School/UpdateInquiry', { inquiry: inquiry, student: student }).success(function (retData) {
                                 
                                if (retData.Message == "Success") {

                                    $scope.ErroMessage = "Inquiry updated successfully."
                                    window.location.href = "/School/InquiryMaintenance/";
                                } else {
                                    $scope.ErroMessage = "Please try after some time.";
                                }

                            }).error(function (retData, status, headers, config) {
                                $scope.ErroMessage = "Please try after some time.";
                            });
                        }
            }
            else
            {
            }
        });
       
        

        
    };

    $scope.onClear = function () {
        //Set parameters
       
        $('#hdnInquiryId').val(0);
        $scope.FirstName = "";
        $scope.MiddleName = "";
        $scope.LastName = "";
        $scope.Address = "";
        $scope.Mobile = "";
        $scope.DOB = new Date();
        $scope.Email = "";
        $scope.IsGuitar = false;
        $scope.IsKeyBoard = false;
        $scope.IsBass = false;
        $scope.IsDrums = false;
        $scope.IsVocals = false;
        $scope.IsRecording = false;
        $scope.IsMorning = false;
        $scope.IsEvening = false;
        $scope.Remarks = "";
        $scope.ErroMessage = "";
    
        //Ajax call to save
    };

    // now create the widget.
    $scope.createWidget = true;
});
