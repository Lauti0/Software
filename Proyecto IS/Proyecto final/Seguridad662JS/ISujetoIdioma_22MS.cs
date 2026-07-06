using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios_22MS
{
    public interface ISujetoIdioma_22MS
    {
        void Suscribir_22MS(IIdiomaObserver_22MS observador);

        void Desuscribir_22MS(IIdiomaObserver_22MS observador);

        void NotificarObservadores_22MS();
    }
}
