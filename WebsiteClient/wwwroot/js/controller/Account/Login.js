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
        debugger;
        if (self.errors().length > 0) {
            //console.log(self.errors());
            self.errors.showAllMessages();
        }
        else {
            self.authenticate();
        }
    }

    self.login = function () {
        debugger;
                //NProgress.start();
        $.post('/api/account/login',
            { email: self.email(), password: self.password() }
        )
            .done(function (data) {
                //NProgress.done();

                console.log(JSON.stringify(data));
                if (data.status === true) {

                    location.href = '/product';
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

    self.authenticate = function () {
        debugger;
        $.ajax({
            method: "POST",
            url: "/api/account/login",
            data: JSON.stringify({ email: self.email(), password: self.password() }),
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        })
            .done(function (data) {
                debugger;
                console.log(JSON.stringify(data));
                //hago lo que tengo que hacer con la info del endpoint
                    //location.href = '/';
                    //alert(data.errors.errorMessage);

                self.errorUser(false);
                location.href = '/product';
                
            })
            .fail(function (err) {
                debugger;
                console.log(err);
                //self.message("Usuario o contraseña incorrecta");
                self.errorUser(true);
                self.loginFailed(err.responseText);

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
