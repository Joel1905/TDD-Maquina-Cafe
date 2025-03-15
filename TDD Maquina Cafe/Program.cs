namespace TDD_Maquina_Cafe
{
    internal class Program
    {
        static void Main()
        {
            var maquina = new MaquinaCafe(new Inventario(5, 10, 10));

            Console.WriteLine("Bienvenido a la Máquina de Café");
            Console.WriteLine("Seleccione el tamaño del vaso \n [Pequeño] [Mediano] [Grande]:");
            string tamanio = Console.ReadLine();

            while (!maquina.SeleccionarTamanioVaso(tamanio))
            {
                Console.WriteLine("Tamaño inválido. Intente nuevamente:");
                tamanio = Console.ReadLine();
            }

            Console.WriteLine("Ingrese la cantidad de azúcar (0-5 cucharadas):");
            int azucar;
            while (!int.TryParse(Console.ReadLine(), out azucar) || !maquina.SeleccionarCantidadAzucar(azucar))
            {
                Console.WriteLine("Cantidad inválida. Intente nuevamente:");
            }

            string resultado = maquina.ServirCafe(tamanio, azucar);
            Console.WriteLine(resultado);
        }
    }

    public class MaquinaCafe
    {
        private Inventario _inventario;

        public MaquinaCafe() => _inventario = new Inventario(5, 10, 10);
        public MaquinaCafe(Inventario inventario) => _inventario = inventario;

        public bool SeleccionarTamanioVaso(string tamanio) => tamanio == "Pequeño" || tamanio == "Mediano" || tamanio == "Grande";

        public bool SeleccionarCantidadAzucar(int cantidad) => cantidad >= 0 && cantidad <= 5;

        public string ServirCafe(string tamanio, int azucar)
        {
            if (_inventario.Vasos <= 0) return "No hay suficientes vasos";
            if (_inventario.Azucar < azucar) return "No hay suficiente azúcar";
            if (_inventario.Cafe <= 0) return "No hay suficiente café";

            _inventario.Vasos--;
            _inventario.Azucar -= azucar;
            _inventario.Cafe--;

            return "Café servido";
        }
    }

    public class Inventario
    {
        public int Vasos { get; set; }
        public int Azucar { get; set; }
        public int Cafe { get; set; }

        public Inventario(int vasos, int azucar, int cafe)
        {
            Vasos = vasos;
            Azucar = azucar;
            Cafe = cafe;
        }
    }
}
