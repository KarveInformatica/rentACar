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
using System.Data;

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
        public static ObservableCollection<object> GetAuxiliares(string tablaauxiliares, List<DBCriterios> dbcriterioslist, object obj)
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
            ObservableCollection<object> auxlist = new ObservableCollection<object>();
                        
            try
            {
                conn.Open();
                //SACommand cmd   = new SACommand();
                //cmd.Connection  = conn;
                //cmd.CommandText = sql;
                SACommand cmd   = new SACommand(sql, conn);
                SADataReader dr = cmd.ExecuteReader();

                auxlist = CreateGenericObject.GetObservableCollectionFromSADataReader(dr, dbcriterioslist, obj);
                
                dr.Close();
            }
            catch (SAException e)
            {
                ErrorsDB.MessageError(e);
                //MessageBox.Show(e.ToString());
            }
            finally
            {
                conn.Close();
            }
            return auxlist; //Se devuelve la ObservableCollection del tipo recibido por params
        }
    }
}

