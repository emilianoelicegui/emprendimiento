
use emprendimiento;

--Roles
INSERT INTO Roles(IsDelete, Name) VALUES (0, 'Administrador');
INSERT INTO Roles(IsDelete, Name) VALUES (0, 'Repositor');
INSERT INTO Roles(IsDelete, Name) VALUES (0, 'Vendedor');

--Users
INSERT INTO Users(IsDelete, Name, Surname, Email, Password, Image, IsLocked, IdRol, LastStart) VALUES (0, 'Emiliano', 'Elicegui', 'emielicegui@gmail.com', 'pass', null, 0, 1, NOW());

--Menus
INSERT INTO Menus(Id, IsDelete, Name, Url, Icon) VALUES (1, 0, 'Productos', '/Products', 'icon');
INSERT INTO Menus(Id, IsDelete, Name, Url, Icon) VALUES (2, 0, 'Proveedores', '/Providers', 'icon');
INSERT INTO Menus(Id, IsDelete, Name, Url, Icon) VALUES (3, 0, 'Sucursales', '/Companys', 'icon');

--MenuRol
INSERT INTO MenuRol(IdMenu, IdRol, IsDelete) VALUES (1,1,0);
INSERT INTO MenuRol(IdMenu, IdRol, IsDelete) VALUES (2,1,0);
INSERT INTO MenuRol(IdMenu, IdRol, IsDelete) VALUES (3,1,0);

--Productos
INSERT INTO Products(IsDelete, Name, Description, Price, IsDolar, IdCompany) VALUES(0, 'Termo Stanly', 'Termo re pulenta', 8900, 0, 1);
INSERT INTO Products(IsDelete, Name, Description, Price, IsDolar, IdCompany) VALUES(0, 'Pava electrica', 'Pa los mate', 1500, 0, 1);
INSERT INTO Products(IsDelete, Name, Description, Price, IsDolar, IdCompany) VALUES(0, 'Raqueta tenis', 'Pal tennis', 500, 1, 2);
INSERT INTO Products(IsDelete, Name, Description, Price, IsDolar, IdCompany) VALUES(0, 'Muñequera', 'Pal gym', 450, 0, 2);

--Companys
INSERT INTO Companies(IsDelete, NameFantasy, Cuit, CodePostal, Floor, Telephone, Department, Number, Street, IdUser, IsPrincipal)
VALUES (0, 'La casa de Emi', 2038808117, 6300, '1', '2954216379', '19', 1465, 'Ameghino', 1, 1);