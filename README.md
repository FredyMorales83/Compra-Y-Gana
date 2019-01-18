# Compra-Y-Gana

Software para uso propio, programado en C# utilizando WinForms, Base de datos MySql y Entity Framework

El objetivo principal de mi aplicación es otorgar a mis clientes con cada compra un porcentaje de la misma en puntos (comúnmente 20% del 
monto) los cuales se irán acumulando, llevando un registro de los montos de las compras realizadas únicamente, una vez realizado esto los 
clientes pueden pedir ver su total de puntos acumulados y su equivalente en dinero electrónico (obtenido con el valor asignado en centavos 
a cada punto en el módulo de configuración) y el cual podrán utilizar en el mismo negocio para realizar compras.

IDEAS PENDIENTES DE IMPLEMENTAR

* Generar estado de cuenta en formato PDF y poder enviarlo por correo electrónico, entregarlo impreso al cliente o en otro enviarlo por
Whatsapp (Cosa que por mi nivel supongo ha de ser díficil de implementar).

* Agregar un modulo de generar tarjetas personalizadas con código de barra y asi imprimir una tarjeta a cada cliente con el cual ya no sea
necesario buscar por sus datos personales y solo con escanear dicho código aparezca la información de dicho cliente.


ERRORES DETECTADOS Y AUN NO CORREGIDOS

* Al hacer una prueba en este mes de enero, en el apartado de estado de cuenta, lanza una excepción no controlada al elegir como periodo
para ver movimientos del mes anterior, esto debido a los indices en la función para obtener dicho mes anterior y con el cambio de año actual
y mes anterior del año anterior, espero resolverlo pronto
