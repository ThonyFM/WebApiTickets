
CREATE TABLE Roles

(
ro_identificador INT PRIMARY KEY IDENTITY(1,1),
ro_descripcion NVARCHAR(125) NOT NULL,
ro_fecha_adicion DATETIME DEFAULT GETDATE() NOT NULL,
ro_adicionado_por NVARCHAR(10) NOT NULL,
ro_fecha_modificacion DATETIME DEFAULT GETDATE() NOT NULL,
ro_modificado_por NVARCHAR(10) NOT NULL
);

CREATE TABLE Usuarios

(
us_identificador INT PRIMARY KEY IDENTITY(1,1),
us_nombre_completo NVARCHAR(150) NOT NULL,
us_correo NVARCHAR(150) NOT NULL,
us_clave NVARCHAR(255) NOT NULL,
us_ro_identificador int foreign key (us_ro_identificador) references Roles(ro_identificador),
us_estado NVARCHAR(1) NOT NULL,
us_fecha_adicion DATETIME DEFAULT GETDATE() NOT NULL,
us_adicionado_por NVARCHAR(10) NOT NULL,
us_fecha_modificacion DATETIME DEFAULT GETDATE() NOT NULL,
us_modificado_por NVARCHAR(10) NOT NULL
);

select * from Usuarios;
select ro_identificador, us_ro_identificador, us_correo
from Usuarios, Roles
where ro_identificador= us_ro_identificador;

create table Tiquetes
(
ti_identificador INT PRIMARY KEY IDENTITY(1,1),
ti_asunto NVARCHAR(150) NOT NULL,
ti_categoria NVARCHAR(150) NOT NULL,
ti_us_id_asigna int foreign key (ti_us_id_asigna) references Roles(ro_identificador),
ti_urgencia NVARCHAR(150) NOT NULL,
ti_importancia NVARCHAR(150) NOT NULL,
ti_estado NVARCHAR(1) NOT NULL,
ti_fecha_adicion DATETIME DEFAULT GETDATE() NOT NULL,
ti_adicionado_por NVARCHAR(10) NOT NULL,
ti_fecha_modificacion DATETIME DEFAULT GETDATE() NOT NULL,
ti_modificado_por NVARCHAR(10) NOT NULL
);

