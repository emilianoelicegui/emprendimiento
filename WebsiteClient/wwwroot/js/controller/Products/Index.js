
var Product = function (options) {

    var self = this;

    self.id = ko.observable("");
    self.idCompany = ko.observable("");
    self.name = ko.observable("").extend({ required: { maxlength: 20, minlength:6, message: 'Ingrese un nombre' } });
    self.description = ko.observable("").extend({ required: { message: 'Ingrese una descripción' } });
    self.price = ko.observable("").extend({ numeric: 2, required: { message: 'Ingrese el precio' } });
    self.isDolar = ko.observable(true);

    self.errors = ko.validation.group(self);

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
                            return '<span class="badge bg-primary">Peso</span>';
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

        var data = {
            id: self.id(),
            name: self.name(),
            price: self.price(),
            idCompany: 1,
            description: self.description(),
            isDolar: self.isDolar(),
            isDelete: false
        };

        if (self.errors().length > 0) {
            self.errors.showAllMessages();
        }
        else {

            $.ajax({
                url: `/api/product/Save`,
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(data), // access in body
            }).done(function (response) {

                var data = JSON.parse(JSON.stringify(response));

                table.ajax.reload(null, false);
                ShowAlert(data.successMessage, 1);

                $('#modal-crud').modal('hide');
                self.reset();

            }).fail(function (response) {
                ShowAlert(ErrorMessage(response.status), 3);
            });

        }
    }

    self.confirmDelete = function () {  

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

    self.reset = function () {
        self.id(0);
        self.name("");
        self.description("");
        self.price("");
        self.isDolar(false);

        self.errors = ko.validation.group(self);
    }

    openEdit = function (idEdit) {

        self.reset();
        self.id(idEdit);
        
        $.ajax({
            url: `/api/product/${self.id()}`,
            type: 'GET',
            contentType: 'application/json',
            //data: JSON.stringify(data), // access in body
        }).done(function (response) {

            var data = JSON.parse(JSON.stringify(response.data));

            self.name(response.data.name);
            self.description(data.description);
            self.price(data.price);
            self.isDolar(data.isDolar);

            $('#modal-crud').modal('show');
        }).fail(function (msg) {

        });

    };

    openDelete = function (idDelete) {

        self.id(idDelete);
        $('#modal-delete').modal('show');

    };

    self.loadGrid();

}
