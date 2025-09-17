# 🔌 EquilibrApp - API REST (ASP.NET Core)

Este backend conecta la aplicación web **EquilibrApp** con la base de datos, proveyendo datos seguros y estructurados sobre usuarios, cuentas, categorías, transacciones y reportes financieros.

## 🔧 Tecnologías

- ASP.NET Core 9
- SQL Server
- Entity Framework Core
- JWT Authentication
- Stored Procedures

## 📚 Endpoints Principales

- `/api/Autenticacion` → Registro e inicio de sesión (JWT).  
- `/api/Usuario` → Gestión de perfil (cambio de nombre y contraseña).  
- `/api/Categoria` → Alta, edición, activación/inactivación y búsqueda de categorías.  
- `/api/Cuenta` → Creación/edición de cuentas, control de estatus y saldos por período.  
- `/api/Transaccion` → Gestión de ingresos y gastos, con filtros y paginación por período. 
- `/api/Presupuesto` → Umbrales de presupuesto y alertas.  

## 🛠️ Configuración

- Cambiar la cadena de conexión en `appsettings.json` con los valores de tu servidor SQL Server.  

```bash
dotnet restore
dotnet run
```

## 🔐 Seguridad

- JWT para autenticación segura.  
- Validación de credenciales y confirmación de contraseña en cambios sensibles.  
- Políticas de acceso según recursos.
