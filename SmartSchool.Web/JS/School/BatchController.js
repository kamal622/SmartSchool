smartApp.controller("BatchCtrl", function ($parse, $scope, $http) {

    $scope.createWidget = false;
    $scope.DetailTitle = "";
    $scope.showDetail = false;
    $scope.ReadOnly = false;
    $scope.isNewRecord = false;
    $scope.Id = 0;
    $scope.TimeFrom = new Date();
    $scope.TimeTo = new Date();

    $scope.mainSplitterSettings = {
        panels: [{ size: 250, collapsible: true }]
    }

    $scope.source =
             {
                 datatype: "json",
                 datafields: [
                     { name: 'Id' },
                     { name: 'Title' }
                 ],
                 id: 'id',
                 url: '/School/GetBatches'
             };
    $scope.listSettings = {};

    //Clear
    function clearAll() {
        $scope.DetailTitle = "";
        $scope.Title = "";
        $scope.Timing = "";
        $scope.Program = "";
        $scope.Days = "";
        $scope.BatchCapacity = "";
        $scope.TotalStudents = "";
        $scope.IsSunday = false;
        $scope.IsMonday = false;
        $scope.IsTuesday = false;
        $scope.IsWednesday = false;
        $scope.IsThursday = false;
        $scope.IsFriday = false;
        $scope.IsSaturday = false;
        $scope.Description = "";
        $scope.TimeFrom = new Date();
        $scope.TimeTo = new Date();
        $scope.Id = 0;
        $scope.lblError = "";
    };

    $scope.selectItem = function (event) {

        if (event.args) {
            $scope.lblError = "";
            $scope.ReadOnly = false;
            $scope.isNewRecord = false;

            $scope.showDetail = true;

            $scope.DetailTitle = " - Edit";
            var item = event.args.item;
            $http.post('/School/GetBatchDetailById', { Id: item.value }).success(function (retData) {

                //var testDate = new Date(ToJavaScriptDate(retData.TimeFrom));
                $scope.Id = retData.Id;
                $scope.Title = retData.Title;
                $scope.TimeFrom = new Date($scope.ToJavaScriptDate(retData.TimeFrom));
                $scope.TimeTo = new Date($scope.ToJavaScriptDate(retData.TimeTo));
                $scope.Program = retData.Program;
                $scope.BatchCapacity = retData.BatchCapacity;
                $scope.IsSunday = retData.OnSunday;
                $scope.IsMonday = retData.OnMonday;
                $scope.IsTuesday = retData.OnTuesday;
                $scope.IsWednesday = retData.OnWednesday;
                $scope.IsThursday = retData.OnThursday;
                $scope.IsFriday = retData.OnFriday;
                $scope.IsSaturday = retData.OnSaturday;
                $scope.Description = retData.Description;

            }).error(function (retData, status, headers, config) {
                alert(data.toString());
            });
        }
    };

    $scope.AddNew = function (e) {
        // $scope.listSettings.source = $scope.source;


        clearAll();
        $scope.DetailTitle = " - Add New";
        $scope.ReadOnly = false;
        $scope.isNewRecord = true;
        $scope.showDetail = true;
        $scope.Id = 0;
    }

    $scope.onSaveBatch = function () {
         
        if ($scope.IsSunday == false &&
            $scope.IsMonday == false &&
            $scope.IsTuesday == false &&
            $scope.IsWednesday == false &&
            $scope.IsThursday == false &&
            $scope.IsFriday == false &&
            $scope.IsSaturday == false ) {
            $scope.openMessageBox("Error", 'Please select Batch Days.', 350, 100);
            return;
        }

        var batch = {
            Id: $scope.Id,
            Title: $scope.Title,
            BatchCapacity: $scope.BatchCapacity,
            TimeFrom: $scope.TimeFrom,
            TimeTo: $scope.TimeTo,
            IsActive: true,
            OnSunday: $scope.IsSunday,
            OnMonday: $scope.IsMonday,
            OnTuesday: $scope.IsTuesday,
            OnWednesday: $scope.IsWednesday,
            OnThursday: $scope.IsThursday,
            OnFriday: $scope.IsFriday,
            OnSaturday: $scope.IsSaturday,
            Description: $scope.Description
        }

        if ($scope.Id == 0)//Add New
        {
            $scope.openConfirm("Confirmation", 'Are you sure you want to Add New Batch?', 350, 100, function (e) {
                if (e) {
                    $http.post('/School/AddBatch', { batch: batch }).success(function (retData) {
                        if (retData.Message == "Success") {
                            clearAll();
                            $scope.lblError = "Batch added successfully."
                            //  $('#lstBatch').jqxListBox('refresh');
                            $scope.listSettings.jqxListBox('refresh');

                        } else {
                            $scope.lblError = "Therer is an problem updating Batch.";
                        }

                    }).error(function (retData, status, headers, config) {

                    });
                }
            });
        }
        else {
            $scope.openConfirm("Confirmation", 'Are you sure you want to update Batch Detail?', 350, 100, function (e) {
                if (e) {
                    $http.post('/School/UpdateBatch', { batch: batch }).success(function (retData) {
                        if (retData.Message == "Success") {
                            clearAll();
                            $scope.lblError = "Batch Updated successfully."
                            //  $('#lstBatch').jqxListBox('refresh');
                            $scope.listSettings.jqxListBox('refresh');

                        } else {
                            $scope.lblError = "Therer is an problem updating Batch.";
                        }

                    }).error(function (retData, status, headers, config) {

                    });
                }
            });
        }

    }

    // now create the widget.

    $scope.createWidget = true;
});