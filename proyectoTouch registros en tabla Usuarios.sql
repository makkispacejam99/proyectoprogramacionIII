use touchProyecto
go


insert into Usuarios(codigoUsuarios, rolUsuarios,nicknameUsuarios, claveUsuarios, nombresUsuarios, apellidosUsuarios, correoUsuarios, fechaCreacionUsuarios, estadoUsuarios)
values ('A0001', 1, 'leonel99', 'leonel12345', 'Guido Leonel', 'Rodriguez', 'guidorodz99@gmail.com', GETDATE(), 1),
	   ('A0002', 2, 'jairjp', 'jair12345', 'Jair Edgardo', 'Pinto', 'jairjp2002@gmail.com', GETDATE(), 1),
	   ('A0003', 2, 'ferfunes', 'fernanda12345', 'Fernanda', 'Funes', 'ferfunes@gmail.com', GETDATE(), 1);