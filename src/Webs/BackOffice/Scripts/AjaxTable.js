jQuery.fn.rmtable = function (options) {
    var settings = $.extend({}, options);
    return this.each(function () {
        ajaxTable($(this));
    });
    function ajaxTable(table) {
        var grid = new Datatable();
        for (var param in options.params) {
            grid.setAjaxParam(param, options.params[param]);
        }
        // grid.setAjaxParam('projectid', projectId);
        grid.init({
            src: table,
            onSuccess: function (grid) {
                // execute some code after table records loaded
            },
            onError: function (grid) {
                // execute some code on network or other general error
            },
            onDataLoad: function (grid) {
                // execute some code on ajax data load
            },
            loadingMessage: 'Loading...',
            dataTable: { 
                "bStateSave": true, 
                "lengthMenu": [
                    [10, 20, 50, 100, 150, -1],
                    [10, 20, 50, 100, 150, "All"] // change per page values here
                ],
                "pageLength": 10, // default record count per page
                "ajax": {
                    "url": settings.soruce,
                },
                //"order": [
                //    [1, "asc"]
                //],// set first column as a default sort by asc
                "fnInitComplete": function (oSettings, json) {
                    //var $modal = $('#ajax-modal');
                    //$('.send-mail').confirmation('hide');
                    //$('.ajax-demo').on('click', function () {
                    //    var customerId = $(this).data('customerid');
                    //    var projectId = $(this).data('projectid');
                    //    var data = $("#rowindex").val();
                    //    $('body').modalmanager('loading');
                    //    //$modal.load('/backend/project/confighotlink', 'projectid=' + projectId + '&customerid=' + customerId + '&selected=' + data, function () {
                    //    //    $modal.modal();
                    //    //});
                    //});
                },
                "bSort": false
                // oSearch: { "sSearch": "Type here...", "bRegex": false, "bSmart": false }
            }
        });
    }
};