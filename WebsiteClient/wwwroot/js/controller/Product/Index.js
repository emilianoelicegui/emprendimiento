/// <reference path="../../knockout-3.5.1.js" />
/// <reference path="../../knockout.validation.js" />

var Product = function (options) {

    var self = this;

    self.getAll = function () {
        debugger;
        //NProgress.start();
        $.getJSON('/api/product/getAll')
            .done(function (data) {
                //NProgress.done();

                console.log(JSON.stringify(data));
                if (data.status == true) {

                    //alert('encontro todo');
                    //location.href = '/';
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

    self.getAll();

};
