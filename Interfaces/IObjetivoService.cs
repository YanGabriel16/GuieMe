﻿using GuieMe.Models;

namespace GuieMe.Interfaces
{
    public interface IObjetivoService
    {
        void ConcluirObjetivo(int idObjetivo, Curso curso);
        Task<bool> GerarCertificado();
    }
}
