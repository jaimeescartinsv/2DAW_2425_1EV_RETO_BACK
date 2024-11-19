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
                    Sesiones = new List<Sesion>
                    {
                        new Sesion
                        {
                            SesionId = 1,
                            SalaId = 1,
                            PeliculaId = 1,
                            FechaDeSesion = new DateTime(2024, 12, 1),
                            HoraDeInicio = new DateTime(2024, 12, 1, 18, 0, 0)
                        },
                        new Sesion
                        {
                            SesionId = 2,
                            SalaId = 1,
                            PeliculaId = 2,
                            FechaDeSesion = new DateTime(2024, 12, 1),
                            HoraDeInicio = new DateTime(2024, 12, 1, 20, 30, 0)
                        }
                    },
                    Butacas = Enumerable.Range(1, 100).Select(id => new Butaca
                    {
                        ButacaId = id,
                        SalaId = 1,
                        Estado = "Disponible"
                    }).ToList()
                },
                new Sala
                {
                    SalaId = 2,
                    Nombre = "Sala 2",
                    CineId = 1,
                    Sesiones = new List<Sesion>
                    {
                        new Sesion
                        {
                            SesionId = 3,
                            SalaId = 2,
                            PeliculaId = 3,
                            FechaDeSesion = new DateTime(2024, 12, 2),
                            HoraDeInicio = new DateTime(2024, 12, 2, 18, 30, 0)
                        },
                        new Sesion
                        {
                            SesionId = 4,
                            SalaId = 2,
                            PeliculaId = 4,
                            FechaDeSesion = new DateTime(2024, 12, 2),
                            HoraDeInicio = new DateTime(2024, 12, 2, 21, 0, 0)
                        }
                    },
                    Butacas = Enumerable.Range(1, 100).Select(id => new Butaca
                    {
                        ButacaId = id,
                        SalaId = 2,
                        Estado = "Disponible"
                    }).ToList()
                }
            }
        }
    };
}