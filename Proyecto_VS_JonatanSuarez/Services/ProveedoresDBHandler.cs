﻿using Proyecto_VS_JonatanSuarez.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_VS_JonatanSuarez.Services
{
    public class ProveedoresDBHandler
    {
        private static ObservableCollection<ProveedoresModel> listaProveedores = new ObservableCollection<ProveedoresModel>();

        public static void CargarListaProveedores()
        {
            for(int i = 0; i < 20; i++)
            {
                ProveedoresModel p = new ProveedoresModel();
                p._id = i.ToString();
                p.Nombre = "Almacén " + i.ToString();
                p.Poblacion = "Población " + i.ToString();
                p.Telefono = 90052512 + i;
                listaProveedores.Add(p);
            }
        }


        public static ObservableCollection<ProveedoresModel> ObtenerListaProveedores()
        {
            return listaProveedores;
        }

        private static ObservableCollection<string> listaProveedoresProductos = new ObservableCollection<string>();
        public static void CargarListaProveedoresProductos()
        {
            foreach (ProveedoresModel p in listaProveedores)
            {
                listaProveedoresProductos.Add(p.Nombre);
            }
        }

        public static ObservableCollection<string> ObtenerListaProveedoresProductos()
        {
            return listaProveedoresProductos;
        }

        public static bool GuardarProveedor(ProveedoresModel Proveedor)
        {
            bool okguardar = false;

            foreach(ProveedoresModel p in listaProveedores)
            {
                if(p._id == Proveedor._id)
                {
                    p.Nombre = Proveedor.Nombre;
                    p.Poblacion = Proveedor.Poblacion;
                    p.Telefono = Proveedor.Telefono;
                    okguardar = true;
                    break;
                }
            }
            return okguardar;
        }

        public static bool BorrarProveedor(ProveedoresModel Proveedor)
        {
            bool okborrar = false;

            foreach (ProveedoresModel p in listaProveedores)
            {
                if (p._id == Proveedor._id)
                {
                    listaProveedores.Remove(p);
                    okborrar = true;
                    break;
                }
            }
            return okborrar;
        }

        public static bool NuevoProveedor(ProveedoresModel proveedor)
        {
            Console.WriteLine("Nombre proveedor:" + proveedor.Nombre.ToString());
            Console.WriteLine("Poblacion proveedor:" + proveedor.Poblacion.ToString());

            bool okinsertar = false;
            try
            {             
                listaProveedores.Add(proveedor);
                okinsertar = true;
            }
            catch (Exception ex) { }

            return okinsertar;
        }
    }
}
