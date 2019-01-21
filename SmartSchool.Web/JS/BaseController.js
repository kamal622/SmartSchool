var smartApp = angular.module("SmartApp", ["jqwidgets"]).factory('$exceptionHandler', function () {
    return function (exception, cause) {
        exception.message += ' (caused by "' + cause + '")';
        console.log(exception, cause);
        //alert(exception.message);
        throw exception;
    }
});

smartApp.controller("BaseController", function ($scope) {
   
    $scope.Theme = 'ui-redmond';
    $scope.InputHeight = 30;
    $.ajaxSetup({ cache: false });
    $(document).bind('contextmenu', function (e) {
        return false;
    });


    $scope.ToJavaScriptDate = function(value) {
        var pattern = /Date\(([^)]+)\)/;
        var results = pattern.exec(value);
        var dt = new Date(parseFloat(results[1]));
        return (dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear()+" " +dt.getHours()+":"+dt.getMinutes();
    };

    $scope.openConfirm = function (title, message, width, height, callBack) {
        var win = $('<div><div><b>' + title + '</b></div><div><div style="padding: 5px;">' + message + '</div><div></div></div></div>');
        // 
        var btnOk = $('<input type="button" value="Yes" style="margin-right: 10px" />');
        var btnCancel = $('<input type="button" value="No" />');
        var lastChild = win[0].lastChild.lastChild;
        $(lastChild).append(btnOk);
        $(lastChild).append(btnCancel);

        win.jqxWindow({
            height: height,
            width: width,
            theme: $scope.Theme,
            autoOpen: true,
            theme: 'energyblue',
            isModal: true,
            resizable: false,
            okButton: btnOk,
            cancelButton: btnCancel,
            initContent: function () {
                btnOk.jqxButton({
                    width: '65px',
                    theme: $scope.Theme
                });
                btnCancel.jqxButton({
                    width: '65px',
                    theme: $scope.Theme
                });
                $('#ok').focus();
            }
        });

        win.on('close', function (event) {
            if (event.args.dialogResult.OK) {
                if (typeof (callBack) === 'function')
                    callBack(true);
            } else {
                if (typeof (callBack) === 'function')
                    callBack(false);
            }
        });
    }

    $scope.openMessageBox = function (title, message, width, height) {
        var win = $('<div><div><b>' + title + '</b></div><div><div style="padding: 5px;">' + message + '</div><div></div></div></div>');
        // 
        var btnOk = $('<input type="button" value="OK" style="margin-right: 10px" />');
       
        var lastChild = win[0].lastChild.lastChild;
        $(lastChild).append(btnOk);
       
        win.jqxWindow({
            height: height,
            width: width,
            theme: $scope.Theme,
            autoOpen: true,
            theme: 'energyblue',
            isModal: true,
            resizable: false,
            okButton: btnOk,
            initContent: function () {
                btnOk.jqxButton({
                    width: '65px',
                    theme: $scope.Theme
                });
               
                $('#ok').focus();
            }
        });
    }
    $scope.addMonths = function (dt, months) {

        return (dt.getMonth() + 1 + months) + "/" + dt.getDate() + "/" + dt.getFullYear() + " " + dt.getHours() + ":" + dt.getMinutes();
    };

});

