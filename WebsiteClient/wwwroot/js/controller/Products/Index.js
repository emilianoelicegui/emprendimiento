/// <reference path="../../knockout-3.5.1.js" />
/// <reference path="../../knockout.validation.js" />

var Product = function (options) {

    var self = this;

    self.loadGrid = function () {
        table = $('#' + options.tableId).DataTable({
            //"dom": '<"top"i>rt<"bottom"flp><"clear">',
            "responsive": true,
            "language": {
                "url": "../../../../lib/datatable/datatables/dataTables.spanish.js"
            },
            "ajax": {
                "contentType": "application/json",
                "url": "/api/product/GetAllByCompany",
                "data": function (d) {
                    return {
                        "draw": d.draw, "start": d.start, "length": d.length
                    };
                }
            },
            "bFilter": false,
            "bPaginate": true,
            "bSort": false,
            "bInfo": true,
            "processing": true,
            "serverSide": true,
            "columns": [
                { "data": "id" },
                { "data": "name" },
                { "data": "description" },
                { "data": "price" }
            ]
        });
    }

    self.loadGrid();

};
