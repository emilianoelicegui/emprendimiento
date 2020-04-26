/// <reference path="../../knockout-3.5.1.js" />
/// <reference path="../../knockout.validation.js" />

var Login = function (options) {

    var self = this;

    self.viewErrors = ko.observable(true);

    self.errorUser = ko.observable(false);
    self.loginFailed = ko.observable("");

    self.email = ko.observable("").extend({ required: { message: 'Ingrese email válido' }, email: true });
    self.password = ko.observable("").extend({ required: { message: 'Ingrese una contraseña' } });

    self.errors = ko.validation.group(self);

    self.validate = function () {
       
        if (self.errors().length > 0) {
            //console.log(self.errors());
            self.errors.showAllMessages();
        }
        else {
            self.authenticate();
        }
    }

    self.authenticate = function () {

        $.ajax({
            method: "POST",
            url: "/api/account/login",
            data: JSON.stringify({ email: self.email(), password: self.password() }),
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        })
            .done(function (data) {

                //console.log(JSON.stringify(data.errors[0].errorMessage));
                //hago lo que tengo que hacer con la info del endpoint
                    //location.href = '/';
                    //alert(data.errors.errorMessage);

                self.errorUser(false);
                
            })
            .fail(function (err) {
                //self.message("Usuario o contraseña incorrecta");
                self.errorUser(true);
                self.loginFailed(JSON.stringify(data.errors[0].errorMessage));
            });


        ////NProgress.start();
        //$.post(urlApi + 'api/auth/login',
        //    { email: self.email(), password: self.password() }
        //)
        //    .done(function (data) {
        //        //NProgress.done();

        //        console.log(JSON.stringify(data));
        //        if (data === true) {

        //            location.href = '/';
        //        }
        //        else {
        //            alert("Error");
        //            //$("#email").focus();
        //        }


        //    })
        //    .fail(function (err) {
        //        //NProgress.done();

        //        self.message("Usuario o contraseña incorrecta");
        //    });
    }

};
