use Emprendimiento

--Roles
INSERT INTO Roles VALUES (0, 'Administrador')
INSERT INTO Roles VALUES (0, 'Repositor')
INSERT INTO Roles VALUES (0, 'Vendedor')

--Users
INSERT INTO Users VALUES (0, 'Emiliano', 'Elicegui', 'emielicegui@gmail.com', 'e10adc3949ba59abbe56e057f20f883e', null, 0, 1, GETDATE())

--Menus
INSERT INTO Menus VALUES (0, 'Productos', '/Products', 'icon')
INSERT INTO Menus VALUES (0, 'Proveedores', '/Providers', 'icon')
INSERT INTO Menus VALUES (0, 'Sucursales', '/Companys', 'icon')

--MenuRol
INSERT INTO MenuRol VALUES (0,1,1)
INSERT INTO MenuRol VALUES (0,2,1)
INSERT INTO MenuRol VALUES (0,3,1)

--Productos
INSERT INTO Products VALUES(0, 'Termo Stanly', 'Termo re pulenta', 8900, 0, 1)
INSERT INTO Products VALUES(0, 'Pava electrica', 'Pa los mate', 1500, 0, 1)
INSERT INTO Products VALUES(0, 'Raqueta tenis', 'Pal tennis', 500, 1, 1)
INSERT INTO Products VALUES(0, 'Muñequera', 'Pal gym', 450, 0, 1)

--Companys
INSERT INTO Companies VALUES (0, 'La casa de Emi', 2038808117, 6300, '1', '2954216379', '19', 1465, 'Ameghino', 1, 1);