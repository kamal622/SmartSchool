
smartApp.controller("InquiryMaintCtrl", function ($scope, $parse) {
    $scope.createWidget = false;
    $scope.RegisterValue = 3;
    //Grid Inquiry
    $scope.InquiryGrid = {
        showtoolbar: true,
        rendertoolbar: function (toolbar) {
            var me = this;
            var container = $("<div style='margin: 5px;'></div>");

            toolbar.append(container);

            container.append('<input id="addbutton" type="button" style="float:right;" value="Add Inquiry" />');

            $("#addbutton").jqxButton({ theme: $scope.Theme });
            $('#addbutton').click(function (e) {
                window.location.href = "/School/Inquiry/0";
            });
        }
    };

    var bindGrid = function () {
        $scope.sourceInquiry = {
            datatype: "json",
            datafields: [
               { name: 'Id', type: 'int' },
               { name: 'Name', type: 'string' },
               { name: 'Course', type: 'string' },
               { name: 'PreferedBatch', type: 'string' },
               { name: 'PhoneNumber', type: 'string' },
               { name: 'InquiryDate', type: 'date' },
               { name: 'Note', type: 'string' },
               { name: 'IsRegistered', type: 'bool' }
            ],
            url: '/School/GetInquiries',
            data: { Name: $scope.Name, program: $scope.selectedCourse, Duration: $scope.selectedDuration, RegisterValue: $scope.RegisterValue },
            Id: "Id",
            sortcolumn: 'Course',
            sortdirection: 'asc'
        };
        $scope.gridDataAdapter = new $.jqx.dataAdapter($scope.sourceInquiry);
    }

    $scope.onAddInquiry = function (event) {
        var dataRecord = $scope.InquiryGrid.jqxGrid('getrowdata', row);
        return "<a style='margin: 4px;text-decoration:underline;' href='/School/Inquiry/" + dataRecord.Id + "'> Edit/View</a>";
    }

    $scope.EditInquiry = function (row, columnfield, value, defaulthtml, columnproperties) {
        var dataRecord = $scope.InquiryGrid.jqxGrid('getrowdata', row);
        return "<a style='margin: 4px;text-decoration:underline;' href='/School/Inquiry/" + dataRecord.Id + "'> Edit/View</a>";
    }
    $scope.Register = function (row, columnfield, value, defaulthtml, columnproperties) {
       
        var dataRecord = $scope.InquiryGrid.jqxGrid('getrowdata', row);
        //if (dataRecord.IsRegistered)
        //    return "  <span style='color: #ff6a00;'>Registerd</span> ";
        //else
       // return "<div style='margin-top:5px;'><a style='margin: 4px;text-decoration:underline;' href='/School/Registration/" + dataRecord.Id + "' ></div>Register</a> ";

        return "<a style='margin: 4px;text-decoration:underline;' href='/School/Registration/" + dataRecord.Id + "' >Register</a> ";

    }

    $scope.InactiveInquiry = function (row, columnfield, value, defaulthtml, columnproperties) {
        //$scope.IssueStatus = value;
        //  
        //var dataRecord = grid.jqxGrid('getrowdata', row);
        //var InquiryId = dataRecord.Id;

        $parse("I_" + row).assign($scope, true);
        return "  <div style='margin: 4px;'><input type='checkbox' checked=true value=true ng-model='I_" + row + "' ></div>";

    }

    //Dropdownlist course
    $scope.courses = [{
        id: 0,
        name: "All"

    }, {
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
    // init DropDownList's settings object.
    $scope.dropDownListSettings =
    {
        width: 200,
        height: 30,
        autoDropDownHeight: true,
        displayMember: "name",
        valueMember: "id",
        source: $scope.courses
    }
    // init selectedValue.
    $scope.selectedCourse = $scope.courses[0];

    //Dropdown Duration
    $scope.Duration = [{
        id: 0,
        name: "All"

    }, {
        id: 1,
        name: "Today"

    }, {
        id: 2,
        name: "Last 10 Days"

    }, {
        id: 3,
        name: "Current Month"

    }, {
        id: 4,
        name: "Last Month"

    }, {
        id: 5,
        name: "Current Year"

    }, {
        id: 6,
        name: "Last Year"

    }];
    // init DropDownList's settings object.
    $scope.dropDownListSettings =
    {
        width: 200,
        height: 30,
        autoDropDownHeight: true,
        displayMember: "name",
        valueMember: "name",
        source: $scope.Duration
    }

    //Dropdown registered

    $scope.Registerd = [{
        id: 0,
        name: "Yes"

    }, {
        id: 1,
        name: "No"

    }, {
        id: 2,
        name: "All"

    }];
    // init DropDownList's settings object.
    $scope.dropDownListSettings =
    {
        width: 200,
        height: 30,
        autoDropDownHeight: true,
        displayMember: "name",
        valueMember: "name",
        source: $scope.Duration
    }
    // init selectedValue.
    $scope.selectedDuration = $scope.Duration[0];

    //Search Event
    $scope.onSearch = function (e) {
        bindGrid();
    };
    bindGrid();
    $scope.createWidget = true;

});