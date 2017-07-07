using KRibbon.Model.Sybase;
using KRibbon.Properties;
using KRibbon.View;
using KRibbon.ViewModel.GenericViewModel;
using Microsoft.Windows.Controls.Ribbon;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using KRibbon.Utility;

namespace KRibbon.Utility
{
    public class UserConfig
    {
        /// <summary>
        /// Devuelve el valor de la key recibida por params desde el archivo app.exe.config
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetSetting(string key)
        {
            string value = null;
            try
            {
                value = ConfigurationManager.AppSettings[key].ToString();
            }
            catch
            {
                value = string.Empty;
            }
            return value;
        }

        /// <summary>
        /// Devuelve la configuración por defecto (Variablesglobales.Dictionary<ERibbonTab, RibbonTabAndGroup> ribbontabdefaultdictionary )
        /// del RibbonTab recibido por params
        /// </summary>
        /// <param name="ribbontab"></param>
        /// <returns></returns>
        public static bool GetDefaultRibbonTabConfig(RibbonTab ribbontab)
        {
            bool result = false;
            try
            { 
                if (ribbontab.Items.Count > 0)
                {
                    ribbontab.Items.Clear();

                    List<RibbonGroup> ribbontabdic = VariablesGlobales.ribbontabdefaultdictionary.Where(r => r.Key.ToString() == ribbontab.Name.ToString()).FirstOrDefault().Value.ribbongroup;

                    int j = 0;
                    foreach (var item in ribbontabdic)
                    {
                        ribbontab.Items.Insert(j, item);
                        string ribbontabname = string.Format("{0}{1}", ribbontab.Name.ToString(), j);
                        string ribbongroupname = item.Name.ToString();
                        SetSetting(ribbontabname, ribbongroupname);
                        j++;
                    }                
                }
                result = true;
            }
            catch (Exception e)
            {                
                ErrorsGeneric.MessageError(e);
            }
            return result;
        }

        /// <summary>
        /// Devuelve la configuración personalizada de los RibbonGroups del RibbonTab recibido por params
        /// </summary>
        /// <param name="ribbontab"></param>
        public static void GetCurrentUserRibbonTabConfig(RibbonTab ribbontab)
        {
            try
            {
                if (ribbontab.Items.Count > 0)
                {
                    int ribbontabcount = ribbontab.Items.Count;
                    ribbontab.Items.Clear();

                    for (int i = 0; i < ribbontabcount; i++)
                    {
                        string ribbontabname = string.Format("{0}{1}", ribbontab.Name.ToString(), i);
                        string ribbongroupname = GetSetting(ribbontabname);

                        List<RibbonGroup> ribbontabdic = VariablesGlobales.ribbontabdefaultdictionary.Where(r => r.Key.ToString() == ribbontab.Name.ToString()).FirstOrDefault().Value.ribbongroup;
                        RibbonGroup ribbongroup = ribbontabdic.Where(r => r.Name.ToString() == ribbongroupname).FirstOrDefault();

                        ribbontab.Items.Insert(i, ribbongroup);
                    }
                }
            }
            catch (Exception e)
            {
                ErrorsGeneric.MessageError(e);
            }
        }

        /// <summary>
        /// Guarda la configuración por defecto (Variablesglobales.Dictionary<ERibbonTab, RibbonTabAndGroup> ribbontabdefaultdictionary )
        /// de los RibbonGroups de los RibbonTab seleccionados
        /// </summary>
        /// <param name="cintaopcionesusercontrol"></param>
        public static void SetDefaultRibbonTabConfig(CintaOpcionesUserControl cintaopcionesusercontrol)
        {
            try
            {
                bool result = false;
                foreach (Control control in cintaopcionesusercontrol.grdCintaOpciones.Children)
                {
                    if (control is CheckBox)
                    {
                        CheckBox checkbox = control as CheckBox;
                        if (checkbox.IsChecked == true)
                        {
                            string ribbontabname = VariablesGlobales.ribbontabdefaultdictionary.Where(r => r.Value.checkbox.Equals(checkbox.Name.ToString())).FirstOrDefault().Key.ToString();
                            RibbonTab ribbontab  = VariablesGlobales.ribbontabdefaultdictionary.Where(r => r.Key.ToString().Equals(ribbontabname)).FirstOrDefault().Value.ribbontab;
                            if (GetDefaultRibbonTabConfig(ribbontab))
                            {
                                result = true;
                            }
                        }
                    }
                }
                if (result)
                {
                    MessageBox.Show(Resources.msgSaveCintaOpcionesOK, Resources.lrbtnCinta, MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception e)
            {
                ErrorsGeneric.MessageError(e);
            }
        }

        public static void LoadRibbonTabs(Window mainWindow)
        {
            if (mainWindow != null)
            {
                int count = VisualTreeHelper.GetChildrenCount(mainWindow);
                for (int i = 0; i < count; i++)
                {
                    Visual childVisual = (Visual)VisualTreeHelper.GetChild(mainWindow, i);
                    if (childVisual is TextBox)
                    {
                        MessageBox.Show(childVisual.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("ssdf dfsdf sdfas ");
            }
        }

        /// <summary>
        /// Guarda la configuración personalizada de los RibbonGroups del RibbonTab en el cual se está utilizando
        /// </summary>
        /// <param name="ribbontab"></param>
        public static void SetCurrentUserRibbonTabConfig(RibbonTab ribbontab)
        {
            try
            { 
                if (ribbontab.Items.Count > 0)
                {
                    int j = 0;
                    foreach (var item in ribbontab.Items)
                    {
                        RibbonGroup rbgroup = (RibbonGroup) item;
                        string ribbontabname = string.Format("{0}{1}", ribbontab.Name.ToString(), j);
                        string ribbongroupname = rbgroup.Name.ToString();                    
                        SetSetting(ribbontabname, ribbongroupname);
                        j++;
                    }
                }
            }
            catch (Exception e)
            {
                ErrorsGeneric.MessageError(e);
            }
        }

        /// <summary>
        /// Guarda la configuración personalizada del idioma
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetCurrentUserLanguage(string key, string value)
        {
            SetSetting(key, value);
        }

        /// <summary>
        /// Guarda en el archivo app.exe.config la configuración personalizada del usuario
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool SetSetting(string key, string value)
        {
            bool result = false;
            try
            {
                //La línea siguiente no funcionará bien en tiempo de diseño pues VC# usa el fichero 
                //xxx.vshost.config en la depuración:
                //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //Así pues utilizamos: 
                Configuration config = ConfigurationManager.OpenExeConfiguration(System.Reflection.Assembly.GetExecutingAssembly().Location);

                //Eliminamos la key (si existe). Si no se elimina la key, los valores se irán acumulando separados por coma 
                config.AppSettings.Settings.Remove(key);

                //Asignamos el valor en la clave indicada 
                config.AppSettings.Settings.Add(key, value);

                //Guardamos los cambios definitivamente en el fichero de configuración 
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch(Exception e)
            {
                ErrorsGeneric.MessageError(e);
            }
            return result;
        }

        public static void LoadLanguage()
        {
            try
            {
                string lang = GetSetting("Language");
                if (!lang.Equals(string.Empty))
                {
                    SetLanguagesViewModel slvm = new SetLanguagesViewModel();
                    slvm.SetLanguages(lang);
                }
            }
            catch (Exception e)
            {
                ErrorsGeneric.MessageError(e);
            }
        }

        public static void ReadAllSettings()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    MessageBox.Show("AppSettings is empty.");
                }
                else
                {
                    foreach (var key in appSettings.AllKeys)
                    {
                        string value = appSettings[key];
                        MessageBox.Show("Key: " + key + ", Value: " + value);
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                MessageBox.Show("Error reading app settings");
            }
        }


    }
}
