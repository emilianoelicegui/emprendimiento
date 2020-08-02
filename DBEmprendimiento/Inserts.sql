
--Roles
INSERT INTO Roles VALUES (0, 'Administrador')
INSERT INTO Roles VALUES (0, 'Repositor')
INSERT INTO Roles VALUES (0, 'Vendedor')

--Users
INSERT INTO Users VALUES (0, 'Emiliano', 'Elicegui', 'emielicegui@gmail.com', 'pass', null, 0, 1)

--Menus
INSERT INTO Menus VALUES (0, 'Productos', '/Products', 'icon')
INSERT INTO Menus VALUES (0, 'Proveedores', '/Providers', 'icon')
INSERT INTO Menus VALUES (0, 'Sucursales', '/Companys', 'icon')

--MenuRol
INSERT INTO MenuRol (IdMenu, IdRol, IsDelete) VALUES (1,1,0)
INSERT INTO MenuRol (IdMenu, IdRol, IsDelete) VALUES (2,1,0)
INSERT INTO MenuRol (IdMenu, IdRol, IsDelete) VALUES (3,1,0)

--Productos
INSERT INTO Products VALUES(0, 'Termo Stanly', 'Termo re pulenta', 8900, 0, 1)
INSERT INTO Products VALUES(0, 'Pava electrica', 'Pa los mate', 1500, 0, 1)
INSERT INTO Products VALUES(0, 'Raqueta tenis', 'Pal tennis', 500, 1, 2)
INSERT INTO Products VALUES(0, 'Muñequera', 'Pal gym', 450, 0, 2)