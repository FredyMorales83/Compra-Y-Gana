# Compra-Y-Gana

Software para uso propio, programado en C# utilizando WinForms, Base de datos SQL Server y Entity Framework, con la opción en el mismo proyecto de poder utilizar como base de datos MySql, realizando para esto unas pequeñas modificaciones en el archivo LoyaltyDB descomentando y comentando unas lineas de código y configurando en el archivo app.config de la capa de presentación sus datos en la cadena de conexión para su gestor de datos MySql.

El objetivo principal de mi aplicación es otorgar a mis clientes con cada compra un porcentaje de la misma en puntos (inicialmente 10% del 
monto de compra) los cuales se irán acumulando, llevando un registro de los montos de las compras realizadas únicamente, una vez realizado esto los 
clientes pueden pedir ver su total de puntos acumulados y su equivalente en dinero electrónico (obtenido con el valor asignado en centavos 
a cada punto en el módulo de configuración que de inicio es 10 centavos por punto) y el cual podrán utilizar en el mismo negocio para realizar compras.

IDEAS PENDIENTES DE IMPLEMENTAR

* Generar estado de cuenta en formato PDF y poder enviarlo por correo electrónico, entregarlo impreso al cliente o en otro caso enviarlo por Whatsapp (Cosa que por mi nivel supongo ha de ser díficil de implementar).

* Agregar un modulo de generar tarjetas personalizadas con código de barra y asi imprimir una tarjeta a cada cliente con el cual ya no sea
necesario buscar por sus datos personales y solo con escanear dicho código aparezca la información de dicho cliente.


ERRORES CORREGIDOS

* Error corregido que sucedía en el apartado de estado de cuenta y ser el primer mer del año, lanzaba una excepción no controlada al elegir como periodo para ver movimientos el mes anterior, esto debido a los indices en la función para obtener dicho mes anterior, modifiqué la función que obtiene las transacciones de cierto mes, poniendo como parámetro adicional el año del periodo como tipo entero nullable, esto con la finalidad de que en el evento que selecciona periodo actual o anterior, si el mes en curso es Enero, seteo como mes del periodo el mes de diciembre y como año de periodo el año actual menos 1 y asi traer las transacciones correctamente del periodo anterior.
