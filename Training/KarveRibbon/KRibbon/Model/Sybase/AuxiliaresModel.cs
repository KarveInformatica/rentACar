using iAnywhere.Data.SQLAnywhere;
using KRibbon.Model.SQL;
using KRibbon.Utility;
using KRibbon.Model.Generic;
using static KRibbon.Utility.VariablesGlobales;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Reflection;

namespace KRibbon.Model.Sybase
{
    public class AuxiliaresModel
    {
        /// <summary>
        /// Devuelve una colección con los valores recuperados de la tabla de auxiliares(tablaauxiliares) de la DB mediante el SADataReader, 
        /// del tipo del objeto(obj) pasado por params
        /// </summary>
        /// <param name="tablaauxiliares">Nombre de la tabla de auxiliares de la DB</param>
        /// <param name="dbcriterioslist">Criterios de ayuda (nombre de las columnas de la tabla de la DB, nombre de las propiedades del objeto, 
        /// tipos de los datos de las columnas de la tabla de la DB) para la obtención de los valores según el tipo del objeto(obj)</param>
        /// <param name="obj">Objeto del cual obtendremos su tipo, propiedades</param>
        /// <returns>Colección con los valores recuperados de la tabla de auxiliares(tablaauxiliares) de la DB</returns>
        public static ObservableCollection<Object> GetAuxiliares(string tablaauxiliares, List<DBCriterios> dbcriterioslist, object obj)
        {   //Se crea una conexión a la DB
            //string enginename = "DBRENT_NET16";
            //string databasename = "DBRENT_NET16";
            //string uid = "cv";
            //string pwd = "1929";
            //string host = "172.26.0.45";            
            //SAConnection conn = new SAConnection(string.Format(ScriptsSQL.CONNECTION_STRING, enginename, databasename, uid, pwd, host));
            SAConnection conn = new DBConnect().GetConnection(new DBConnect("DBRENT_NET16", "DBRENT_NET16", "cv", "1929", "172.26.0.45"));
            //SAConnection conn = new SAConnection(new DBConnect().ConnexionString());
            string sql = string.Format(ScriptsSQL.SELECT_ALL_BASICA, tablaauxiliares);
            //Se crea una ObservableCollection del tipo de dato recibido por params
            ObservableCollection<Object> auxlist = new ObservableCollection<Object>();
                        
            try
            {
                conn.Open();
                //SACommand cmd   = new SACommand();
                //cmd.Connection  = conn;
                //cmd.CommandText = sql;
                SACommand cmd   = new SACommand(sql, conn);
                SADataReader dr = cmd.ExecuteReader();

                //Se recorre el SADataReader para obtener sus valores según el tipo de objeto recibido por params
                while (dr.Read())
                {
                    //Instanciamos un nuevo objeto del tipo del objeto recibido por params
                    object newobj = CreateObject(obj);
                    //Recuperamos las propiedades del objeto recibido por params
                    var properties = GetProperties(obj);
                    //Recorremos la lista de propiedades del objeto recibido por params
                    foreach (var prop in properties)
                    {   //De cada propiedad del objeto recibido por params, recorremos su colección de criterios
                        foreach (var item in dbcriterioslist)
                        {   //Se comprueba el tipo de la propiedad del objeto recibido por params
                            if(item.nombrepropiedadobj == prop.Name)
                            {   //Se añade el dato recuperado de la DB mediante el SADataReader a la propiedad(item.nombrepropiedadobj) 
                                //del nuevo objeto(newobj), validando el dato según su tipo(ValidateData.***)
                                switch (item.tipodatocolumnadb)
                                {
                                    case ETiposDatoColumnaDB.DBstring:
                                        PropertySetValue(newobj, item.nombrepropiedadobj, ValidateData.GetString(dr[item.nombrecolumnadb] as string));
                                        break;
                                    case ETiposDatoColumnaDB.DBbool:
                                        break;
                                    case ETiposDatoColumnaDB.DBbyte: //byte en C# = tinyint en la DB
                                        PropertySetValue(newobj, item.nombrepropiedadobj, ValidateData.GetByte(dr[item.nombrecolumnadb] as byte?));
                                        break;
                                    case ETiposDatoColumnaDB.DBsmallint:
                                        break;
                                    case ETiposDatoColumnaDB.DBint:
                                        PropertySetValue(newobj, item.nombrepropiedadobj, ValidateData.GetInt(dr[item.nombrecolumnadb] as int?));
                                        break;
                                    case ETiposDatoColumnaDB.DBlong:
                                        break;
                                    case ETiposDatoColumnaDB.DBdecimal:
                                        break;
                                    case ETiposDatoColumnaDB.DBdouble:
                                        break;
                                    case ETiposDatoColumnaDB.DBdate:
                                        break;
                                    case ETiposDatoColumnaDB.DBdatetime:
                                        break;
                                    case ETiposDatoColumnaDB.DBsmalldatetime:
                                        break;
                                    case ETiposDatoColumnaDB.DBtime:
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                    auxlist.Add(newobj); //Se añade el nuevo objeto del tipo recibido por params, a la ObservableCollection
                }                    
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                conn.Close();
            }
            return auxlist; //Se devuelve la ObservableCollection del tipo recibido por params
        }

        /// <summary>
        /// Crea un objeto del tipo del objeto(objoriginal) pasado por params
        /// </summary>
        /// <typeparam name="T">Tipo genérico de la class del objeto</typeparam>
        /// <param name="objoriginal">Objeto original del cual instanciaremos un nuevo objeto según su tipo</param>
        /// <returns></returns>
        public static T CreateObject<T>(T objoriginal)
        {
            T newobject = (T)Activator.CreateInstance(objoriginal.GetType());

            foreach (var prop in objoriginal.GetType().GetProperties())
            {
                prop.SetValue(newobject, prop.GetValue(objoriginal, null), null);
            }

            return newobject;
        }

        /// <summary>
        /// Añadir un valor(value) recuperado de la DB mediante el SADataReader, a la propiedad(nombrepropiedadobj) pasada por params del objeto(obj) pasado también por params
        /// </summary>
        /// <param name="obj">El objeto al cual añadimos el valor recuperado desde el SADataReader</param>
        /// <param name="nombrepropiedad">Nombre de la propiedad del objeto a la cual le añadiremos el valor recuperado desde el SADataReader</param>
        /// <param name="value">Valor recuperado desde el SADataReader, que añadiremos al objeto</param>
        public static void PropertySetValue(object obj, string nombrepropiedad, object value)
        {
            Type tipo = obj.GetType();
            foreach (PropertyInfo info in tipo.GetProperties())
            {
                if (info.Name == nombrepropiedad)
                {
                    info.SetValue(obj, value, null);
                }
            }
        }

        /// <summary>
        /// Devuelve una colección de las propiedades del objeto(obj) pasado por params
        /// </summary>
        /// <param name="obj">Objeto del cual obtendremos una colección de sus propiedades</param>
        /// <returns></returns>
        private static PropertyInfo[] GetProperties(object obj)
        {
            return obj.GetType().GetProperties();
        }
    }
}

