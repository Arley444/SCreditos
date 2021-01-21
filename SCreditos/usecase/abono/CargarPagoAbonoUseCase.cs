using SCreditos.models;
using SCreditos.repos.repoabono;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCreditos.usecase.abono
{
    class CargarPagoAbonoUseCase
    {
        public static Cobro pagarAbono(Cliente cliente, Abono abono, Prestamo prestamo)
        {
            return new RepositoryAbono().pagarAbono(cliente, abono, prestamo);
        }
    }
}
