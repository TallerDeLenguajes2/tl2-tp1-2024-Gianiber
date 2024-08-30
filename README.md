# Sistema de Cadeteria #
Ejercicio 2a
- Cadeteria-Cadete relación débil. En el caso de que un cadete se dé de baja de la cadeteria solamente eliminaremos la información con respecto al primero.
- Cadete-Pedido relación débil. Mismo caso que el anterior, a pesar de eliminar un pedido, porque ya se completó o se cancelo, la información con respecto al cadete asignado debe seguir estando disponible.
- Pedido-Cliente relación fuerte. Debido a la naturaleza del sistema es necesario eliminar al cliente una vez el pedido se completó o se cancelo.
- Cadeteria debería tener AsignarCadete() y AltaCadete() y Cadete EntregarPedido()
- Los elementos públicos deberían ser aquellos a los que necesito acceder solamente por "lectura" para conocer los objetos, como por ejemplo nombre, teléfono, el id 