using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios_22MS
{
    public class IdiomaManager_22MS : ISujetoIdioma_22MS
    {
        private static IdiomaManager_22MS instancia_22MS;

        private readonly List<IIdiomaObserver_22MS> observadores_22MS;

        public Idioma_22MS IdiomaActual_22MS { get; private set; }

        private IdiomaManager_22MS()
        {
            observadores_22MS =
                new List<IIdiomaObserver_22MS>();
        }

        public static IdiomaManager_22MS GetInstance_22MS()
        {
            if (instancia_22MS == null)
            {
                instancia_22MS =
                    new IdiomaManager_22MS();
            }

            return instancia_22MS;
        }

        public void Suscribir_22MS(
            IIdiomaObserver_22MS observador)
        {
            if (observador == null)
                return;

            if (!observadores_22MS.Contains(observador))
            {
                observadores_22MS.Add(observador);
            }
        }

        public void Desuscribir_22MS(
            IIdiomaObserver_22MS observador)
        {
            if (observador == null)
                return;

            observadores_22MS.Remove(observador);
        }

        public void CambiarIdioma_22MS(
            Idioma_22MS idioma)
        {
            IdiomaActual_22MS = idioma;

            NotificarObservadores_22MS();
        }

        public void NotificarObservadores_22MS()
        {
            foreach (
                IIdiomaObserver_22MS observador
                in observadores_22MS)
            {
                observador.ActualizarIdioma_22MS();
            }
        }
    }
}
