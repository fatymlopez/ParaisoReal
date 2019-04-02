using Newtonsoft.Json;
using ParaisoRealB.Model.Modeldb;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace ParaisoRealB.ViewModel
{
    public class MenuDVM : ViewModelBase , INotifyPropertyChanged
    {
        public MenuDVM()
        {
 

            //getDesayuno();
         
        }

        //public async void getDesayuno()
        //{
        //    var client = new HttpClient();
        //    string URL = string.Format("http://paraisoreal19.somee.com/api/productoss/Getproductos");
        //    var miArreglo = await client.GetStringAsync(URL);
        //    ListDesayunos = JsonConvert.DeserializeObject<List<productos>>(miArreglo);
        //    var nuevalista = ListDesayunos.Where(a => a.idcategoria == 1 && a.existencia > 0);
        //    //ListDesayunos.ItemsSource = nuevalista;
        //    Debug.WriteLine(nuevalista);
        //}


        //#region propiedades


        //private List<productos> _ListDesayunos;

        //public List<productos> ListDesayunos
        //{
        //    get { return _ListDesayunos;


        //        }
        //    set { _ListDesayunos = value;
               
        //        RaisePropertyChanged(); }
        //}

        //private string _nomproductoproperty;

        //public string nomproductoproperty
        //{
        //    get { return _nomproductoproperty; }
        //    set { _nomproductoproperty = value; RaisePropertyChanged(); }
        //}

        //private decimal _precioproperty;

        //public decimal precioproperty
        //{
        //    get { return _precioproperty; }
        //    set { _precioproperty = value; RaisePropertyChanged(); }
        //}

        //private string _descripcionproperty;

        //public string descripcionproperty
        //{
        //    get { return _descripcionproperty; }
        //    set { _descripcionproperty = value; RaisePropertyChanged(); }
        //}

    


        //#endregion
    }
}
