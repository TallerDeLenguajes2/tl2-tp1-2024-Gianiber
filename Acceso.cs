using System.Text.Json;

namespace Sistema
{
    public abstract class AccesoDatos
    {
        public static bool Existe(string nombreArchivo)
        {
            if (File.Exists(nombreArchivo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public abstract List<Cadeteria> LeerCadeteria(string nombreArchivo);
        public abstract List<Cadete> LeerCadetes(string path);
    }
    public class AccesoCSV:AccesoDatos
    {
        public override List<Cadeteria> LeerCadeteria(string nombreArchivo)
        {
            List<Cadeteria> lineasCSV = new List<Cadeteria>();
            if (File.Exists(nombreArchivo))
            {
                string[] cadeteria = File.ReadAllLines(nombreArchivo);
                foreach (var line in cadeteria)
                {
                    string[] datos = line.Split(',');
                    Cadeteria Nueva = new Cadeteria(datos[0],long.Parse(datos[1]),null,null);
                    lineasCSV.Add(Nueva);
                }
                return lineasCSV;
            }
            else
            {
                return null;
            }
        }
        public override List<Cadete> LeerCadetes(string path)
        {
            List<Cadete> LineasCadetesCSV = new List<Cadete>();
            int i = 0;
            if (File.Exists(path))
            {
                string[] cadetes = File.ReadAllLines(path);
                foreach (var line in cadetes)
                {
                    string[] datos = line.Split(',');
                    Cadete Nuevo = new Cadete(i,datos[0],datos[1],long.Parse(datos[2]));
                    i++;
                    LineasCadetesCSV.Add(Nuevo);
                }
                return LineasCadetesCSV;
            }
            else
            {
                return null;
            }
        }
    }
    public class AccesoJson:AccesoDatos
    {
        public override List<Cadeteria> LeerCadeteria(string nombreArchivo)
        {
            if (File.Exists(nombreArchivo))
            {
                string prod = File.ReadAllText(nombreArchivo);
                List<Cadeteria> cadeteriaLista = JsonSerializer.Deserialize<List<Cadeteria>>(prod);
                return cadeteriaLista;
            }
            else
            {
                return null;
            }
        }
        public override List<Cadete> LeerCadetes(string path)
        {
            if (File.Exists(path))
            {
                string prod = File.ReadAllText(path);
                List<Cadete> cadeteLista = JsonSerializer.Deserialize<List<Cadete>>(prod);
                return cadeteLista;
            }
            else
            {
                return null;
            }
        }
    }
}