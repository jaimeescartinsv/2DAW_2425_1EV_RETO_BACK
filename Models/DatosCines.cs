public static class DatosCines
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
                        new Sesion { SesionId = 1, SalaId = 1, PeliculaId = 1, FechaDeSesion = new DateTime(2024, 12, 1), HoraDeInicio = new DateTime(2024, 12, 1, 16, 0, 0), Butacas = Enumerable.Range(1, 150).Select(id => new Butaca { ButacaId = id, SalaId = 1, Estado = "Disponible", PrecioButaca = 6.90 }).ToList() },
                        new Sesion { SesionId = 2, SalaId = 1, PeliculaId = 2, FechaDeSesion = new DateTime(2024, 12, 1), HoraDeInicio = new DateTime(2024, 12, 1, 18, 30, 0), Butacas = Enumerable.Range(1, 150).Select(id => new Butaca { ButacaId = id, SalaId = 1, Estado = "Disponible", PrecioButaca = 6.90 }).ToList() },
                        new Sesion { SesionId = 3, SalaId = 1, PeliculaId = 3, FechaDeSesion = new DateTime(2024, 12, 1), HoraDeInicio = new DateTime(2024, 12, 1, 21, 0, 0), Butacas = Enumerable.Range(1, 150).Select(id => new Butaca { ButacaId = id, SalaId = 1, Estado = "Disponible", PrecioButaca = 6.90 }).ToList() },
                        new Sesion { SesionId = 4, SalaId = 1, PeliculaId = 4, FechaDeSesion = new DateTime(2024, 12, 2), HoraDeInicio = new DateTime(2024, 12, 2, 16, 0, 0), Butacas = Enumerable.Range(1, 150).Select(id => new Butaca { ButacaId = id, SalaId = 1, Estado = "Disponible", PrecioButaca = 6.90 }).ToList() }
                    }
                },
                new Sala
                {
                    SalaId = 2,
                    Nombre = "Sala 2",
                    CineId = 1,
                    Sesiones = new List<Sesion>
                    {
                        new Sesion { SesionId = 5, SalaId = 2, PeliculaId = 5, FechaDeSesion = new DateTime(2024, 12, 2), HoraDeInicio = new DateTime(2024, 12, 2, 18, 30, 0), Butacas = Enumerable.Range(1, 150).Select(id => new Butaca { ButacaId = id, SalaId = 1, Estado = "Disponible", PrecioButaca = 6.90 }).ToList() },
                        new Sesion { SesionId = 6, SalaId = 2, PeliculaId = 6, FechaDeSesion = new DateTime(2024, 12, 2), HoraDeInicio = new DateTime(2024, 12, 2, 21, 0, 0), Butacas = Enumerable.Range(1, 150).Select(id => new Butaca { ButacaId = id, SalaId = 1, Estado = "Disponible", PrecioButaca = 6.90 }).ToList() },
                        new Sesion { SesionId = 7, SalaId = 2, PeliculaId = 7, FechaDeSesion = new DateTime(2024, 12, 3), HoraDeInicio = new DateTime(2024, 12, 3, 16, 0, 0), Butacas = Enumerable.Range(1, 150).Select(id => new Butaca { ButacaId = id, SalaId = 1, Estado = "Disponible", PrecioButaca = 6.90 }).ToList() },
                        new Sesion { SesionId = 8, SalaId = 2, PeliculaId = 8, FechaDeSesion = new DateTime(2024, 12, 3), HoraDeInicio = new DateTime(2024, 12, 3, 18, 30, 0), Butacas = Enumerable.Range(1, 150).Select(id => new Butaca { ButacaId = id, SalaId = 1, Estado = "Disponible", PrecioButaca = 6.90 }).ToList() }
                    }
                },
                new Sala
                {
                    SalaId = 3,
                    Nombre = "Sala 3",
                    CineId = 1,
                    Sesiones = new List<Sesion>
                    {
                        new Sesion { SesionId = 9, SalaId = 3, PeliculaId = 9, FechaDeSesion = new DateTime(2024, 12, 3), HoraDeInicio = new DateTime(2024, 12, 3, 21, 0, 0), Butacas = Enumerable.Range(1, 150).Select(id => new Butaca { ButacaId = id, SalaId = 1, Estado = "Disponible", PrecioButaca = 6.90 }).ToList() },
                        new Sesion { SesionId = 10, SalaId = 3, PeliculaId = 10, FechaDeSesion = new DateTime(2024, 12, 4), HoraDeInicio = new DateTime(2024, 12, 4, 16, 0, 0), Butacas = Enumerable.Range(1, 150).Select(id => new Butaca { ButacaId = id, SalaId = 1, Estado = "Disponible", PrecioButaca = 6.90 }).ToList() },
                        new Sesion { SesionId = 11, SalaId = 3, PeliculaId = 11, FechaDeSesion = new DateTime(2024, 12, 4), HoraDeInicio = new DateTime(2024, 12, 4, 18, 30, 0), Butacas = Enumerable.Range(1, 150).Select(id => new Butaca { ButacaId = id, SalaId = 1, Estado = "Disponible", PrecioButaca = 6.90 }).ToList() },
                        new Sesion { SesionId = 12, SalaId = 3, PeliculaId = 12, FechaDeSesion = new DateTime(2024, 12, 4), HoraDeInicio = new DateTime(2024, 12, 4, 21, 0, 0), Butacas = Enumerable.Range(1, 150).Select(id => new Butaca { ButacaId = id, SalaId = 1, Estado = "Disponible", PrecioButaca = 6.90 }).ToList() },
                        new Sesion { SesionId = 13, SalaId = 3, PeliculaId = 13, FechaDeSesion = new DateTime(2024, 12, 5), HoraDeInicio = new DateTime(2024, 12, 5, 16, 0, 0), Butacas = Enumerable.Range(1, 150).Select(id => new Butaca { ButacaId = id, SalaId = 1, Estado = "Disponible", PrecioButaca = 6.90 }).ToList() },
                        new Sesion { SesionId = 14, SalaId = 3, PeliculaId = 14, FechaDeSesion = new DateTime(2024, 12, 5), HoraDeInicio = new DateTime(2024, 12, 5, 18, 30, 0), Butacas = Enumerable.Range(1, 150).Select(id => new Butaca { ButacaId = id, SalaId = 1, Estado = "Disponible", PrecioButaca = 6.90 }).ToList() }
                    }
                },
                new Sala
                {
                    SalaId = 4,
                    Nombre = "Sala 4",
                    CineId = 1,
                    Sesiones = new List<Sesion>
                    {
                        new Sesion { SesionId = 15, SalaId = 4, PeliculaId = 15, FechaDeSesion = new DateTime(2024, 12, 5), HoraDeInicio = new DateTime(2024, 12, 5, 21, 0, 0), Butacas = Enumerable.Range(1, 150).Select(id => new Butaca { ButacaId = id, SalaId = 1, Estado = "Disponible", PrecioButaca = 6.90 }).ToList() },
                        new Sesion { SesionId = 16, SalaId = 4, PeliculaId = 16, FechaDeSesion = new DateTime(2024, 12, 6), HoraDeInicio = new DateTime(2024, 12, 6, 16, 0, 0), Butacas = Enumerable.Range(1, 150).Select(id => new Butaca { ButacaId = id, SalaId = 1, Estado = "Disponible", PrecioButaca = 6.90 }).ToList() },
                        new Sesion { SesionId = 17, SalaId = 4, PeliculaId = 17, FechaDeSesion = new DateTime(2024, 12, 6), HoraDeInicio = new DateTime(2024, 12, 6, 18, 30, 0), Butacas = Enumerable.Range(1, 150).Select(id => new Butaca { ButacaId = id, SalaId = 1, Estado = "Disponible", PrecioButaca = 6.90 }).ToList() },
                        new Sesion { SesionId = 18, SalaId = 4, PeliculaId = 18, FechaDeSesion = new DateTime(2024, 12, 6), HoraDeInicio = new DateTime(2024, 12, 6, 21, 0, 0), Butacas = Enumerable.Range(1, 150).Select(id => new Butaca { ButacaId = id, SalaId = 1, Estado = "Disponible", PrecioButaca = 6.90 }).ToList() },
                        new Sesion { SesionId = 19, SalaId = 4, PeliculaId = 19, FechaDeSesion = new DateTime(2024, 12, 7), HoraDeInicio = new DateTime(2024, 12, 7, 16, 0, 0), Butacas = Enumerable.Range(1, 150).Select(id => new Butaca { ButacaId = id, SalaId = 1, Estado = "Disponible", PrecioButaca = 6.90 }).ToList() },
                        new Sesion { SesionId = 20, SalaId = 4, PeliculaId = 20, FechaDeSesion = new DateTime(2024, 12, 7), HoraDeInicio = new DateTime(2024, 12, 7, 18, 30, 0), Butacas = Enumerable.Range(1, 150).Select(id => new Butaca { ButacaId = id, SalaId = 1, Estado = "Disponible", PrecioButaca = 6.90 }).ToList() },
                        new Sesion { SesionId = 21, SalaId = 4, PeliculaId = 21, FechaDeSesion = new DateTime(2024, 12, 7), HoraDeInicio = new DateTime(2024, 12, 7, 21, 0, 0), Butacas = Enumerable.Range(1, 150).Select(id => new Butaca { ButacaId = id, SalaId = 1, Estado = "Disponible", PrecioButaca = 6.90 }).ToList() }
                    }
                }
            }
        }
    };
}