using KRibbon.Model.Classes;
using KRibbon.Model.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using static KRibbon.Model.Generic.RecopilatorioEnumerations;
using static KRibbon.Model.Generic.RecopilatorioCollections;
using System;

namespace KRibbon.Utility
{
    public class ValidationRuleDataGrid : ValidationRule
    {


        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            object obj = (value as BindingGroup).Items[0] as object;

            if (ValidateNotNullOrEmpty(obj))
            {
                return new ValidationResult(false, MessageBox.Show(string.Concat("Error en la edición de datos. Los motivos pueden ser los siguientes:",
                                                                                "\n-No se admite un valor vacío"), "Error de edición", MessageBoxButton.OK, MessageBoxImage.Error));
            }
            else if (ValidateDuplicateValue(obj))
            {
                return new ValidationResult(false, MessageBox.Show(string.Concat("Error en la edición de datos. Los motivos pueden ser los siguientes:",
                                                                                "\n-No se admite un valor repetido"), "Error de edición", MessageBoxButton.OK, MessageBoxImage.Error));
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }

        private bool ValidateNotNullOrEmpty(object obj)
        {
            bool result = false;
            var objproperties = ManageGenericObject.GetProperties(obj);

            foreach (var objprop in objproperties)
            {
                object objvalue = ManageGenericObject.PropertyGetValue(obj, objprop.Name.ToString());

                if (objvalue == null)
                {
                    result = true;
                    break;
                }
                else
                {
                    if ((objvalue.ToString() == null) || (objvalue.ToString().Length == 0))
                    {
                        result = true;
                        break;
                    }
                    result = false;
                }
            }
            return result;

        }

        private bool ValidateDuplicateValue(object obj)
        {
            bool result = false;
            TabControl ctrl = TabControlAndTabItemUtil.GetCurrentTabControl();

            try
            {
                EOpcion opcion = TabControlAndTabItemUtil.TabControlSelectedItemEOpcion();
                TemplateInfoTabItem tmp = tabitemdictionary[opcion];

                GenericObservableCollection auxobscollection = tabitemdictionary.Where(g => g.Key == opcion).FirstOrDefault().Value.GenericObsCollection;

                ISet<string> collectionAux = new SortedSet<string>();
                int i = 0;
                foreach (var itemStringItem in auxobscollection.GenericObsCollection)
                {
                    string stringItem = ManageGenericObject.PropertyConvertToDictionary(itemStringItem);
                    IList<string> tempString = stringItem.Split(';').ToList();

                    foreach (string itemTempString in tempString)
                    {
                        if (!collectionAux.Contains(itemTempString))
                        {
                            collectionAux.Add(itemTempString);
                        }
                        else
                        {
                            result = true;
                            break;
                        }
                    }
                    if (result)
                    {
                        break;
                    }
                }

            }
            catch (Exception) { }
            return result;
        }      
    }
}
