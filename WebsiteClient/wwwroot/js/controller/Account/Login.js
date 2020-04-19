/// <reference path="../../knockout-3.5.1.js" />
/// <reference path="../../knockout.validation.js" />

var Login = function (options) {

    var self = this;

    self.viewErrors = ko.observable(true);
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
        //NProgress.start();
        $.postJSON(urlApi + 'api/auth/login',
            { email: self.email(), password: self.password() }
        )
            .done(function (data) {
                //NProgress.done();

                console.log(JSON.stringify(data));
                if (data === true) {

                    location.href = '/';
                }
                else {
                    alert("Error");
                    //$("#email").focus();
                }


            })
            .fail(function (err) {
                //NProgress.done();

                self.message("Usuario o contraseña incorrecta");
            });
    }

};
