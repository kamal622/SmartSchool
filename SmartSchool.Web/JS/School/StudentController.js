smartApp.controller("StudentCtrl", function ($parse, $scope, $http) {
   
    $scope.createWidget = false;
    //Grid Student
    var bindGrid = function () {
        $scope.sourceStudent = {
            datatype: "json",
            datafields: [
               { name: 'Id', type: 'int' },
               { name: 'ImageName', type: 'string' },
               { name: 'Name', type: 'string' },
               { name: 'CurrentAddress', type: 'string' },
               { name: 'Mobile', type: 'string' },
               { name: 'Email', type: 'string' }
            ],
            url: '/School/GetStudents',
            data: { name: $scope.Name, MobileNo: $scope.MobileNo, RegistrationNo: $scope.RegistrationNo },
            Id: "Id",
            sortcolumn: 'Name',
            sortdirection: 'asc'
        };
        $scope.gridDataAdapter = new $.jqx.dataAdapter($scope.sourceStudent);
    }
    $scope.StudentGrid = {};
    $scope.Image = function (row, columnfield, value, defaulthtml, columnproperties) {
        return '<img style="margin-left: 5px;" height="60" width="50" src="../Uploads/ProfilePics/' + value + '"/>';

    }
    $scope.ManageStudent = function (row, columnfield, value, defaulthtml, columnproperties) {
       
        var dataRecord = $scope.StudentGrid.jqxGrid('getrowdata', row);
        
        return "<div style='margin-top:5px;'><a style='margin: 4px;text-decoration:underline;' href='/School/StudentDetail/" + dataRecord.Id + "'></div> Edit/View</a>";
    }
    $scope.onSearch = function (e) {
         
        bindGrid();
    };
    bindGrid();
    $scope.createWidget = true;

});