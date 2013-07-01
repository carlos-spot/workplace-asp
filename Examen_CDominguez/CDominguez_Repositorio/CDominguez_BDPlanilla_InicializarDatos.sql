use CDominguez_BDPlanilla

--Agregamos alguno departamentos
INSERT INTO t_departamento VALUES(253434, 'Contabilidad', 1)
INSERT INTO t_departamento VALUES(456676, 'Cartera', 2)
INSERT INTO t_departamento VALUES(567665, 'Soporte', 3)
INSERT INTO t_departamento VALUES(787875, 'Mercadeo', 4)
INSERT INTO t_departamento VALUES(235565, 'Finanzas', 5)

--Agregar los Empleados
INSERT INTO t_empleado VALUES('155804454735', 'Carlos', 'Domínguez Lara', '8887-0678', 235565, 'San Pedro', 'Contador')
INSERT INTO t_empleado VALUES('1-44320218', 'Jose', 'Lopez Díaz', '2245-0678', 253434, 'San Jóse', 'Administrador')
INSERT INTO t_empleado VALUES('1-14330618', 'Esteban', 'Torres Castro', '2245-4578', 567665, 'Alajuela', 'Vendedor')
INSERT INTO t_empleado VALUES('1-14320217', 'Elias', 'Romero García', '8887-0788', 787875, 'Puntarenas', 'Ejecutivo')
INSERT INTO t_empleado VALUES('1-13330214', 'Andrey', 'Flores Rivera', '8587-0378', 787875, 'Limon', 'Director')

select * from t_departamento