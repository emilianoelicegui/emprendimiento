
var Product = function (options) {

    var self = this;

    self.id = ko.observable("");
    self.name = ko.observable("").extend({ required: { message: 'Ingrese un nombre' } });
    self.description = ko.observable("").extend({ required: { message: 'Ingrese una descripción' } });
    self.price = ko.observable("").extend({ numeric: 2, required: { message: 'Ingrese el precio' } });
    self.isDolar = ko.observable(true);

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
                { "data": "company.nameFantasy" },
                {
                    "data": "price",
                    "className": "text-right",
                    render: function (data, type, row) {
                        if (data === null) {
                            return null;
                        } else {
                            return formatNumber.new(data, "$&nbsp;");
                        }
                    }
                },
                {
                    "data": "isDolar",
                    "className": "text-center",
                    render: function (data, type, full, meta) {

                        if (data === true) {
                            return '<span class="badge bg-success">Dólar</span>';
                        }    
                        else {
                            return '<span class="badge bg-primary">Pesos</span>';
                        }
                    }
                },
                {
                    "data": "id",
                    "className": "text-center",
                    render: function (data, type, full, meta) {
                        return `<div class="btn-group">
                                <button type="button" title="Editar" onclick="openEdit(${data})" class="btn btn-info"><i class="fas fa-edit"></i></button>
                                <button type="button" title="Eliminar" onclick="openDelete(${data})" class="btn btn-danger"><i class="fas fa-trash"></i></button>
                                </div>`;
                    }
                }
            ]
        });
    }

    self.confirmSave = function () {

        $.getJSON('/api/subcategory/GetAllByCategory?idCategory=' + self.id(),
            function (data) {

                ko.utils.arrayPushAll(self.subCategorys, data);
                //self.selectedTipoBeneficiario(0);
            });

        $('#modal-delete-product').modal('hide');

    }

    self.confirmDelete = function () {

        //$.ajax({
        //    url: `/api/product/${self.id()}/Delete`,
        //    type: 'PUT',
        //    success: function (result) {
        //        table.ajax.reload(null, false);
        //        $('#modal-delete').modal('hide');
        //    }
        //});    

        $.ajax({
            url: `/api/product/${self.id()}/Delete`,
            type: 'PUT',
            contentType: 'application/json',
            //data: JSON.stringify(data), // access in body
        }).done(function () {
            table.ajax.reload(null, false);
            $('#modal-delete').modal('hide');
        }).fail(function (msg) {

        });

    }

    openEdit = function (idEdit) {

        self.id(idEdit);
        $('#modal-crud').modal('show');

    };

    openDelete = function (idDelete) {

        self.id(idDelete);
        $('#modal-delete').modal('show');

    };

    self.loadGrid();

}
