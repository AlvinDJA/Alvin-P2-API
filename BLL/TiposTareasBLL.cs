using Alvin_P2_API.DAL;
using Alvin_P2_API.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Alvin_P2_API.BLL
{
    public class TiposTareasBLL
    {
        public static TiposTareas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            TiposTareas tarea;
            try
            {
                tarea = contexto.TiposTareas.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return tarea;
        }
        public static List<TiposTareas> GetList(Expression<Func<TiposTareas, bool>> criterio)
        {
            List<TiposTareas> lista = new List<TiposTareas>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.TiposTareas.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
        public static List<TiposTareas> GetList()
        {
            List<TiposTareas> lista = new List<TiposTareas>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.TiposTareas.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
