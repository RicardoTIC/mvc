using Datos;
using Modelo;
using System.Collections.Generic;
using System.Data;


namespace Negocio
{
    public class N_Persona : D_Persona
    {

        public List<Persona> list(string buscar)
        {
            return this.getAll(buscar);
        }
        public bool delete_data(Persona p)
        {

            return delete(p);
        }
        public bool update_data(Persona p)
        {
            return update(p);
        }

        public Persona select_data_person(int id)
        {
            return select_data(id);
        }

        public bool add_data(Persona p)
        {
            return add(p);
        }

        public DataTable list()
        {
            return this.D_listado();
        }

    }
}
