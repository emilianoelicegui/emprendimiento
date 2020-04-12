/// <reference path="../../knockout-3.5.1.js" />
/// <reference path="../../knockout.validation.js" />

var Login = function (options) {

    var self = this;

    self.viewErrors = ko.observable(true);
    self.email = ko.observable("").extend({ required: { message: 'Ingrese email válido' }, email: true });
    self.password = ko.observable("").extend({ required: { message: 'Ingrese una contraseña' } });

    self.errors = ko.validation.group(self);

    self.clickLogin = function () {
       
        if (self.errors().length == 0) {
            alert('Thank you.');
        } else {
            alert('Please check your submission.');
            console.log(self.viewErrors);
            self.errors.showAllMessages();
        }

    }
};
