smartApp.controller("DashboardCtrl", function ($scope, $parse) {
    //alert('Dashboard');
    //$scope.parentMethod(); //it'll work
    $scope.createWidget = false;

    //chart1
    $scope.Chartsource1 =
            {
                datatype: "json",
                datafields: [
                      { name: 'Course' },
                    { name: 'TotalInquiries' }
                  
                ],
                url: '/School/GetActiveStudentsCounts'
            };
    $scope.ChartdataAdapter1 = new $.jqx.dataAdapter($scope.Chartsource1, { async: false, autoBind: true, loadError: function (xhr, status, error) { alert('Error loading "' + $scope.Chartsource1.url + '" : ' + error); } });
         
    
    //chart2
    $scope.Chartsource2 =
           {
               datatype: "json",
               datafields: [
                   { name: 'Course' },
                   { name: 'TotalRegistraion' }
               ],
               url: '/School/GetValidityOverCounts'
           };
    $scope.ChartdataAdapter1 = new $.jqx.dataAdapter($scope.Chartsource2, { async: false, autoBind: true, loadError: function (xhr, status, error) { alert('Error loading "' + $scope.Chartsource2.url + '" : ' + error); } });

    $scope.RenewalGrid = {};
    $scope.InquiryGrid = {};
    //Grid Inquiry
    $scope.sourceInquiry = {
        datatype: "json",
        datafields: [
           { name: 'Id', type: 'int' },
           { name: 'Name', type: 'string' },
           { name: 'Course', type: 'string' },
           { name: 'PreferedBatch', type: 'string' },
           { name: 'PhoneNumber', type: 'string' },
           { name: 'InquiryDate', type: 'date' },
           { name: 'Note', type: 'string' }
        ],
        url: '/School/getLatestInquiries',
        Id: "Id",
        sortcolumn: 'InquiryDate',
        sortdirection: 'desc'
    };
    $scope.gridDataAdapter = new $.jqx.dataAdapter($scope.sourceInquiry);

    $scope.ViewEdit = function (row, columnfield, value, defaulthtml, columnproperties) {
        var dataRecord = $scope.InquiryGrid.jqxGrid('getrowdata', row);
        return "<a style='margin: 4px;text-decoration:underline;' theme='" + $scope.Theme + "' href='/School/Inquiry/" + dataRecord.Id + "'>View/Edit</a>";
    }
    $scope.Register = function (row, columnfield, value, defaulthtml, columnproperties) {

        var dataRecord = $scope.InquiryGrid.jqxGrid('getrowdata', row);
        
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
  
    //Grid Renewal
    $scope.sourceRenewal = {
        datatype: "json",
        datafields: [
          { name: 'Id', type: 'int' },
            { name: 'StudentId', type: 'int' },
          { name: 'Name', type: 'string' },
          { name: 'Course', type: 'string' },
          { name: 'PreferedBatch', type: 'string' },
          { name: 'PhoneNumber', type: 'string' },
          { name: 'RegistrationDate', type: 'date' },
          { name: 'ExpiryDate', type: 'date' },
          { name: 'Note', type: 'string' }
        ],
        url: '/School/GetRenewalRequiredDetail',
        Id: "Id",
        sortcolumn: 'ExpiryDate',
        sortdirection: 'asc'
    };
    $scope.gridDataAdapter = new $.jqx.dataAdapter($scope.sourceInquiry);
        
    $scope.Renew = function (row, columnfield, value, defaulthtml, columnproperties) {
        var dataRecord = $scope.RenewalGrid.jqxGrid('getrowdata', row);

        return "<a style='margin: 4px;text-decoration:underline;' theme='" + $scope.Theme + "' href='/School/StudentDetail/" + dataRecord.StudentId + "'>Renew</a>";
    }
    $scope.CompareDate = function (row, columnfield, value, defaulthtml, columnproperties) {
        
        var date = new Date(value);
        var today = new Date();
       
        if (value > today)
        {
            value = $.jqx.dataFormat.formatdate(value, columnproperties.cellsformat);
            return '<span style="margin: 4px; float: ' + columnproperties.cellsalign + '; color:red ;">' + value + '</span>';
        }
        else
        {
            value = $.jqx.dataFormat.formatdate(value, columnproperties.cellsformat);
            return '<span style="margin: 4px; float: ' + columnproperties.cellsalign + '; color: #0000ff;">' + value + '</span>';
        }
           
    }

   // $("text").remove();
   // show
    // $('p').contents().last().remove();
    //$("text").remove();​
    // now create the widget.
    $scope.createWidget = true;

    $scope.refresh = function () {
        //$scope.gridDataAdapter.dataBind();
          
        //$scope.InquieryGrid
    }
});
