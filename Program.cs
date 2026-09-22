namespace ConsoleApp17
{
    internal class Program
    {
        struct producto
        {
            public string nombre;
            public int codigo;
            public double precio;

            public producto(string nombre, int codigo, double precio)
            {
                this.nombre = nombre;
                this.codigo = codigo;
                this.precio = precio;
            }
        }

        static void Main(string[] args)
        {
            producto[] productos = new producto[3];
            productos[0] = new producto("tusi", 101, 15000);
            productos[1] = new producto("Peine para calvos", 82, 2950);
            productos[2] = new producto("game boy", 4363, 81345.75);

            foreach (var producto in productos)
            {
                Console.WriteLine($"Nombre: {producto.nombre}, Precio: {producto.precio}");
            }
            using var inventario = new AppDbContext();
            foreach (var p in productos)
            {
                var insertarpro = new inventario
                {
                    nombre = p.nombre,
                    codigo = p.codigo,
                    precio = p.precio
                };

                inventario.inventario.Add(insertarpro);
            }

            inventario.SaveChanges();
        }
    }
}
