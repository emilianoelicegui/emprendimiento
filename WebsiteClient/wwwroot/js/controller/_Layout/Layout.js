/// <reference path="../../knockout-3.5.1.js" />
/// <reference path="../../knockout.validation.js" />

var Layout = function (options) {

    var selfLayout = this;

    selfLayout.menus = ko.observableArray([]);

    selfLayout.companys = ko.observableArray([]);
    selfLayout.selectedCompany = ko.observable("");

    //armar el menu segun el rol 
    selfLayout.getMenus = function () {
        //NProgress.start();
        $.getJSON('/api/generic/getMenus')
            .done(function (data) {
                //NProgress.done();

                if (data.status == true) {

                    selfLayout.menus(data.data);

                }
                else {
                    alert("Error");
                    //$("#email").focus();
                }


            })
            .fail(function (err) {
                //NProgress.done();

                //selfLayout.message("Usuario o contraseña incorrecta");
            });
    }

    selfLayout.getCompanys = function () {
        debugger;
        //NProgress.start();
        $.getJSON('/api/company/GetAllByUser')
            .done(function (response) {
                //NProgress.done();

                if (response.status == true) {

                    selfLayout.companys(response.data);

                }
                else {
                    alert("Error");
                    //$("#email").focus();
                }


            })
            .fail(function (err) {
                //NProgress.done();

                //selfLayout.message("Usuario o contraseña incorrecta");
            });
    }

    selfLayout.setCompany = function (id, nameFantasy) {

        var data = {
            id: id,
            nameFantasy: nameFantasy
        };

        $.ajax({
            url: `/api/account/refreshCompany`,
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data), // access in body
        }).done(function () {
            location.reload();
        }).fail(function () {
            ShowAlert('Error al actualizar la sesión', 3);
        });

    }

    selfLayout.out = function () {
        $.getJSON("/api/account/SignOut");
        location.href = '/Account/Login';
    }

    selfLayout.getMenus();
    selfLayout.getCompanys();

};
