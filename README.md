# AgendaH

#  Instrucciones de Instalación – AgendaH

Sigue estos pasos para instalar y ejecutar la aplicación **AgendaH** en tu equipo.

#  1. Requisitos Previos

Antes de instalar, asegúrate de tener:

#  **Windows 10 / 11**

# **.NET Framework 4.8 o superior**

Si no lo tienes, descárgalo desde Microsoft:
[https://dotnet.microsoft.com/es-es/download/dotnet-framework](https://dotnet.microsoft.com/es-es/download/dotnet-framework)

# **SQL Server**

Puede ser cualquiera:

* SQL Server Express
* SQL Server Developer
* SQL Server LocalDB

# **SQL Server Management Studio (SSMS)**

Para ejecutar el script de la base de datos.


# 2. Crear la Base de Datos

1. Abre **SQL Server Management Studio**
2. Conéctate a tu servidor local
3. Haz clic en **New Query**
4. Copia y pega el script `BD.sql` incluido en este proyecto
5. Ejecuta con el botón **Run** o presionando `F5`

Esto creará:

* La base de datos
* Tablas (Personas, Contactos, Citas)
* Relaciones
* Llaves primarias/foráneas


# 3. Configurar la Cadena de Conexión

1. Abre la carpeta del proyecto
2. Ve a:

```
AgendaH -> App.config
```

3. Modifica el valor **Data Source** para que coincida con tu servidor SQL.
   Ejemplo para SQLEXPRESS:

```xml
<connectionStrings>
    <add name="AgendaDB"
         connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=AgendaH;Integrated Security=True" 
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

Ejemplo para LocalDB:

```xml
Data Source=(localdb)\MSSQLLocalDB;
```

Guarda los cambios.


# 4. Ejecutar la Aplicación

# Opción A — Desde Visual Studio

1. Abre la solución `.sln`
2. Selecciona **Build → Build Solution**
3. Presiona **Start (F5)**

# Opción B — Sin Visual Studio (solo ejecutable)

1. Ve a:

```
AgendaH\bin\Release\
```

2. Ejecuta el archivo:

```
AgendaH.exe
```


# 5. Primer Inicio

Al abrir la aplicación podrás:

* Registrar personas
* Crear contactos asociados a personas
* Registrar citas vinculadas
* Editar y eliminar
* Consultar datos en tablas


# 6. Problemas Comunes

| Problema                        | Solución                                     |
| ------------------------------- | -------------------------------------------- |
| “Cannot connect to database”    | Revisa la cadena de conexión en *App.config* |
| “No such table / missing table” | Vuelve a ejecutar el script SQL              |
| La app no abre                  | Verifica .NET Framework 4.8                  |


# 7. Desinstalación

Solo elimina la carpeta del proyecto y opcionalmente la base de datos:

En SSMS → botón derecho sobre **AgendaH** → **Delete**
