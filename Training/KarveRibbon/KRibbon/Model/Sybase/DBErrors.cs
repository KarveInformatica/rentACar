using iAnywhere.Data.SQLAnywhere;
using KRibbon.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace KRibbon.Model.Sybase
{
    public class DBErrors
    {
        /// <summary>
        /// Comprueba el SAException e.NativeError, para poder mostrar el 
        /// mensaje de error correspondiente según el idioma seleccionado
        /// </summary>
        /// <param name="e"></param>
        static public void MessageError(SAException e)
        {
            switch (e.NativeError)
            {
                case -83: //Specified DataBase not found
                    //omprobrar que el DataBaseName en la connectionstring sean correctos en AuxiliaresModel.GetAuxiliares
                    ShowMessage(e, Resources.msgError83);
                    break;
                case -100: //DataBase Server not found
                    //Comprobar que EngineName o Host en la connectionstring sean correctos en AuxiliaresModel.GetAuxiliares
                    ShowMessage(e, Resources.msgError100);
                    break;
                case -103: //Invalid User Id or Password
                    //Comprobar que el user/pass en la connectionstring sean correctos en AuxiliaresModel.GetAuxiliares
                    ShowMessage(e, Resources.msgError103);
                    break;
                case -131: //Syntax Error in SQL sentence
                    //Comprobar la sintasi correcta en SQL/SqlScript***
                    ShowMessage(e, Resources.msgError131);
                    break;
                case -141: //Table not found
                    //Comprobar que coindida el nombre de la tabla de la BBDD con el 
                    //especificado en VariablesGlobales.Dictionary<ETipoAuxiliar, TablaAuxiliares>
                    ShowMessage(e, Resources.msgError141);
                    break;
                default:
                    ShowMessage(e, "default");
                    break;
            }
        }

        /// <summary>
        /// Muestra el mensaje de error en el idioma seleccionado, sino, muestra un mensaje de error default
        /// </summary>
        /// <param name="e"></param>
        /// <param name="msgError"></param>
        private static void ShowMessage(SAException e, string msgError)
        {
            string nativeerror = msgError.Equals("default") ? e.NativeError.ToString() : msgError;
            MessageBox.Show("(" + e.NativeError.ToString() + ") " + nativeerror + "\n\n" + e.StackTrace.ToString());
        }
    }
}
