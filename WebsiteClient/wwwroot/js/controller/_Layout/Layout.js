/// <reference path="../../knockout-3.5.1.js" />
/// <reference path="../../knockout.validation.js" />

var Layout = function (options) {

    var selfLayout = this;

    selfLayout.menus = ko.observableArray([]);

    //armar el menu segun el rol 
    selfLayout.getMenus = function () {
        //NProgress.start();
        $.getJSON('/api/generic/getMenus')
            .done(function (data) {
                //NProgress.done();

                console.log(JSON.stringify(data));
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

    selfLayout.getMenus();

};
