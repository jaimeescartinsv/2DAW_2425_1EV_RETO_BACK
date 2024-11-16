public static class DataStoreCines
{
    public static List<Cine> Cines { get; set; } = new List<Cine>
    {
        new Cine
        {
            CineId = 1,
            Nombre = "MUELMO Cines Puerto Venecia",
            Ubicacion = "Zaragoza",
            Salas = new List<Sala>
            {
                new Sala
                {
                    SalaId = 1,
                    Nombre = "Sala 1",
                    CineId = 1,
                    Capacidad = 200,
                    Funciones = new List<Funcion>
                    {
                        new Funcion
                        {
                            FuncionId = 1,
                            SalaId = 1,
                            PeliculaId = 1,
                            FechaDeFuncion = new DateTime(2024, 12, 1),
                            HoraDeInicio = new DateTime(2024, 12, 1, 18, 0, 0)
                        },
                        new Funcion
                        {
                            FuncionId = 2,
                            SalaId = 1,
                            PeliculaId = 2,
                            FechaDeFuncion = new DateTime(2024, 12, 1),
                            HoraDeInicio = new DateTime(2024, 12, 1, 20, 30, 0)
                        }
                    },
                    Asientos = Enumerable.Range(1, 200).Select(id => new Asiento
                    {
                        AsientoId = id,
                        SalaId = 1,
                        Estado = "Disponible"
                    }).ToList()
                },
                new Sala
                {
                    SalaId = 2,
                    Nombre = "Sala 2",
                    CineId = 1,
                    Capacidad = 200,
                    Funciones = new List<Funcion>
                    {
                        new Funcion
                        {
                            FuncionId = 3,
                            SalaId = 2,
                            PeliculaId = 3,
                            FechaDeFuncion = new DateTime(2024, 12, 2),
                            HoraDeInicio = new DateTime(2024, 12, 2, 18, 30, 0)
                        },
                        new Funcion
                        {
                            FuncionId = 4,
                            SalaId = 2,
                            PeliculaId = 4,
                            FechaDeFuncion = new DateTime(2024, 12, 2),
                            HoraDeInicio = new DateTime(2024, 12, 2, 21, 0, 0)
                        }
                    },
                    Asientos = Enumerable.Range(1, 200).Select(id => new Asiento
                    {
                        AsientoId = id,
                        SalaId = 2,
                        Estado = "Disponible"
                    }).ToList()
                }
            }
        }
    };
}