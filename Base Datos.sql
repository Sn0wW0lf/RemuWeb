create database RemuWeb

use RemuWeb

create table cargos
(
id int identity(1,1) primary key,
cargo varchar (30) not null
)

create table departamentos
(
id int identity(1,1) primary key,
departamento varchar(20) not null
)

create table tipoContrato
(
id int identity(1,1) primary key,
tipoContrato varchar(20) not null
)

create table modalidadesPago
(
id int identity(1,1) primary key,
modalidad varchar(20) not null
)

create table empleador
(
rutEmpleador varchar (20) primary key,
nombre varchar (30) not null,
giro varchar (30) not null,
)

create table sucursales
(
id int identity(1,1) primary key,
sucursal varchar (30) not null,
rutEmpleador varchar (20) foreign key references empleador(rutEmpleador)
)

create table estadoTrabajador
(
id int identity(1,1) primary key,
estado varchar(20) not null
)

create table sexo
(
id int identity(1,1) primary key,
sexo varchar(20)
)

create table nacionalidad
(
id int identity(1,1) primary key,
nacionalidad varchar(20)
)

create table trabajadores
(
rutTrabajador varchar (15) primary key,
nombre varchar (20) not null,
apellidoP varchar (20) not null,
apellidoM varchar (20) not null,
fechaNacimiento varchar (20) not null,
fechaIngreso varchar (20) not null,
fechaTermino varchar (20) not null,
idSexo int foreign key references sexo(id) not null,
idNacionalidad int foreign key references nacionalidad(id) not null,
Sueldo int not null,
idCargo int foreign key references cargos(id) not null,
idDepartamento int foreign key references departamentos(id) not null,
idTipoContrato int foreign key references tipoContrato(id) not null,
idModoPago int foreign key references modalidadesPago(id) not null,
idSucursal int foreign key references sucursales(id) not null,
idEstadoTrabajador int foreign key references estadoTrabajador(id) not null
)

create table periodos
(
id int identity(1,1) primary key,
periodo varchar (20) not null
)

create table usuarios
(
id int identity(1,1) primary key,
rutTrabajador varchar (15) foreign key references trabajadores(rutTrabajador) not null,
contraseña varchar (20) not null,
recuperacionContrasena varchar (20) not null,
tipoUsuario varchar (1)
)

create table comunas
(
id int identity(1,1) primary key,
comuna varchar (20) not null
)

create table ciudades
(
id int identity(1,1) primary key,
ciudad varchar (20) not null
)

create table domicilios
(
id int identity(1,1) primary key,
rutTrabajador varchar (15) foreign key references trabajadores(rutTrabajador) not null,
Direccion varchar (50) not null,
calle varchar (20) not null,
numero int not null,
idCiudad int foreign key references ciudades(id) not null,
idComuna int foreign key references comunas(id) not null
)

create table salud
(
id int identity(1,1) primary key,
tipoSalud varchar (20) not null
)

create table planesSalud
(
id int identity(1,1) primary key,
idSalud int foreign key references salud(id) not null,
porcientoDescuento float not null,
montoAdicional float not null,
rutTrabajador varchar (15) foreign key references trabajadores(rutTrabajador) not null
)

create table planesSaludPagados
(
id int identity(1,1) primary key,
tipoSalud varchar (20) not null,
porcientoDescuento float not null,
montoAdicional float not null,
rutTrabajador varchar (15) foreign key references trabajadores(rutTrabajador) not null,
idPeriodo int foreign key references periodos(id) not null
)

create table afp
(
id int identity(1,1) primary key,
tipoAfp varchar (20) not null
)

create table planesAfp
(
id int identity(1,1) primary key,
idAfp int foreign key references afp(id) not null,
porcientoDescuento float not null,
apv int  not null,
rutTrabajador varchar (15) foreign key references trabajadores(rutTrabajador) not null
)

create table planesAfpPagados
(
id int identity(1,1) primary key,
tipoAfp varchar (20)  not null,
porcientoDescuento float  not null,
apv int not null,
rutTrabajador varchar (15) foreign key references trabajadores(rutTrabajador) not null,
idPeriodo int foreign key references periodos(id) not null
)

create table descuentoSindicato
(
id int identity(1,1) primary key,
porcientoDescuento float not null,
rutTrabajador varchar (15) foreign key references trabajadores(rutTrabajador) not null
)

create table descuentoSindicatoPagados
(
id int identity(1,1) primary key,
porcientoDescuento float not null,
rutTrabajador varchar (15) foreign key references trabajadores(rutTrabajador) not null,
idPeriodo int foreign key references periodos(id) not null
)

create table gratificacion
(
id int identity(1,1) primary key,
tope int not null,
porcientoPago float not null
)

create table gratificacionPagadas
(
id int identity(1,1) primary key,
tope int not null,
porcientoPago float not null,
rutTrabajador varchar (15) foreign key references trabajadores(rutTrabajador) not null,
idPeriodo int foreign key references periodos(id)  not null
)

create table bonoProporcional
(
id int identity(1,1) primary key,
porcientoPago int not null
)

create table bonoProporcionalPagados
(
id int identity(1,1) primary key,
porcientoPago int not null,
rutTrabajador varchar (15) foreign key references trabajadores(rutTrabajador) not null,
idPeriodo int foreign key references periodos(id) not null,
)

create table seguroCesantia
(
id int identity(1,1) primary key,
porcientoPago int not null
)

create table seguroCesantiaPagados
(
id int identity(1,1) primary key,
porcientoPago int not null,
rutTrabajador varchar (15) foreign key references trabajadores(rutTrabajador) not null,
idPeriodo int foreign key references periodos(id) not null
)

create table sueldosPagados
(
id int identity(1,1) primary key,
sueldo int,
rutTrabajador varchar (15) foreign key references trabajadores(rutTrabajador) not null,
idPeriodo int foreign key references periodos(id) not null
)

create table horasExtras
(
id int identity(1,1) primary key,
tipoHora varchar (20) not null,
cantidad int not null,
fecha varchar (20)  not null,
rutTrabajador varchar (15) foreign key references trabajadores(rutTrabajador) not null,
idPeriodo int foreign key references periodos(id) not null
)

create table topeDescuentos
(
id int identity(1,1) primary key,
valorUf float not null,
tope float not null
)

create table bonosImponibles
(
id int identity(1,1) primary key,
tipoBono varchar (20) not null
)

create table bonosImponiblesPagados
(
id int identity(1,1) primary key,
idBonosImponibles int foreign key references bonosImponibles(id),
rutTrabajador varchar (15) foreign key references trabajadores(rutTrabajador) not null,
idPeriodo int foreign key references periodos(id) not null
)

create table bonosNoImponibles
(
id int identity(1,1) primary key,
tipoBono varchar (20) not null
)

create table bonosNoImponiblesPagados
(
id int identity(1,1) primary key,
idBonosNoImponiblesPagados int foreign key references bonosNoImponibles(id) not null,
rutTrabajador varchar (15) foreign key references trabajadores(rutTrabajador) not null,
idPeriodo int foreign key references periodos(id) not null
)

create table otrosDescuentos
(
id int identity(1,1) primary key,
tipoDescuento varchar(20) not null,
rutTrabajador varchar(15) foreign key references trabajadores(rutTrabajador) not null,
numeroCuota int not null,
cuotasTotales int not null,
idPeriodo int foreign key references periodos(id) not null
)

create table diasTrabajados
(
id int identity(1,1) primary key,
cantidadDias int not null,
rutTrabajador varchar(15) foreign key references trabajadores(rutTrabajador) not null,
idPeriodo int foreign key references periodos(id) not null
)

create table asignacionFamiliar
(
id int identity(1,1) primary key,
desde int not null,
hasta int not null,
montoPagar int not null
)

create table cargasFamiliar
(
rutCarga varchar(20) primary key,
nombre varchar(20) not null,
apellidoP varchar(20) not null,
apellidoM varchar(20) not null,
rutTrabajador varchar(15) foreign key references trabajadores(rutTrabajador) not null
)

create table cargasFamiliaresPagadas
(
id int identity(1,1) primary key,
totalCargas int not null,
pago int not null,
rutTrabajador varchar(15) foreign key references trabajadores(rutTrabajador) not null,
idPeriodo int foreign key references periodos(id) not null
)

create table impuestoRenta
(
id int identity(1,1) primary key,
periodo varchar(20) not null,
desde float not null,
hasta float not null,
factor float not null,
cantidadRebajar float not null,
impuestoMaximo float not null
)

create table impuestoRentaPagados
(
id int identity(1,1) primary key,
periodo varchar(20) not null,
desde float not null,
hasta float not null,
factor float not null,
cantidadRebajar float not null,
impuestoMaximo float not null,
rutTrabajador varchar(15) foreign key references trabajadores(rutTrabajador) not null,
idPeriodo int foreign key references periodos(id) not null
)

create table vacaciones
(
id int identity(1,1) primary key,
desde varchar(20) not null,
hasta varchar(20) not null,
rutTrabajador varchar(15) foreign key references trabajadores(rutTrabajador) not null
)

create table licenciasMedicas
(
id int identity(1,1) primary key,
desde varchar(20) not null,
hasta varchar(20) not null,
rutTrabajador varchar(15) foreign key references trabajadores(rutTrabajador) not null
)

create table diasNoTrabajados
(
id int identity(1,1) primary key,
desde varchar(20) not null,
hasta varchar(20) not null,
motivo varchar(20) not null,
rutTrabajador varchar(15) foreign key references trabajadores(rutTrabajador) not null
)


insert into cargos values
('Jefe')

insert into departamentos values
('Directorio')

insert into tipoContrato values
('plazo fijo'),
('indefinido')

insert into modalidadesPago values
('efectivo'),
('cheque'),
('cuenta bancaria')

insert into empleador values
('1000000-9','Juan Perez','Contabilidad')

insert into sucursales values
('Santiago Centro','1000000-9')

insert into estadoTrabajador values
('activo'),
('licencia'),
('vacaciones'),
('despedido')

insert into sexo values
('Masculino'),
('Femenino')

insert into nacionalidad values
('Chilena'),
('Argentino')

insert into trabajadores values
('12345678-9','Nombre','ApellidoP','ApellidoM','01-01-1841','01-07-1940','00-00-00',1,1,10000000,1,1,2,3,1,1),

insert into usuarios values
('12345678-9','123456789','987654321','a')

insert into comunas values
('Maipú')

insert into ciudades values
('Santiago')