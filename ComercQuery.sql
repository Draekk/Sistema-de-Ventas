
use Comerc
go

Create table Productos
(
id int identity(1,1) primary key,
codigo nvarchar(50) not null,
nombre nvarchar(100) not null,
cant int not null,
costo int,
venta int not null,
estado bit not null
)
go

Create table DiarioVentas
(
id int identity(1,1) primary key,
nVenta int not null,
codigo nvarchar(50),
nombre nvarchar(100) not null,
cVendida int not null,
cRestante int not null,
compra int,
venta int not null,
tPago nvarchar(10) not null,
fecha datetime not null
)
go

Create table DiarioReportes
(
id int primary key,
total int not null,
tPago nvarchar(10) not null,
fecha datetime not null,
descuento int not null
)
go

Create table DiarioEgresos
(
id int identity(1,1) primary key,
motivo nvarchar(50),
monto int not null,
fecha datetime not null
)
go

Create table DiarioCaja
(
id int identity(1,1) primary key,
cInicial int not null,
vEfectivo int not null,
vTarjeta int not null,
vOtros int not null,
vTotal int not null,
tEgresos int not null,
cFinal int not null,
fecha datetime not null,
estado bit not null,
tCosto int not null
)
go