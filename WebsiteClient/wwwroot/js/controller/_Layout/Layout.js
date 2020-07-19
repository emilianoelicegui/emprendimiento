/// <reference path="../../knockout-3.5.1.js" />
/// <reference path="../../knockout.validation.js" />

var Layout = function (options) {

    var self = this;

    self.menus = ko.observableArray([]);

    //armar el menu segun el rol 
    self.getMenus = function () {
        //NProgress.start();
        $.getJSON('/api/generic/getMenus')
            .done(function (data) {
                //NProgress.done();

                console.log(JSON.stringify(data));
                if (data.status == true) {

                    self.menus(data.data);

                }
                else {
                    alert("Error");
                    //$("#email").focus();
                }


            })
            .fail(function (err) {
                //NProgress.done();

                //self.message("Usuario o contraseña incorrecta");
            });
    }

    self.getMenus();

};
