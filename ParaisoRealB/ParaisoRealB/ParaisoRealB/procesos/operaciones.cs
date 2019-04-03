using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ParaisoRealB.procesos
{
    public class operaciones
    {
        public  decimal totalglobal { get; set; }
        public operaciones(int idcliente, int idreservacion)
        {
            sumproductos(idcliente,idreservacion);
        }


        public async void sumproductos(int idcliente, int idreservacion)
        {

            var client = new HttpClient();
            string URL = string.Format("http://paraisoreal19.somee.com/api/detallereservacions/Getdetallereservacion");
            var miArreglo = await client.GetStringAsync(URL);
            var JSON_cliente = JsonConvert.DeserializeObject<List<Model.Modeldb.detallereservacion>>(miArreglo);

            foreach (var item in JSON_cliente)
            {
                if (item.idreservacion == Constantes.idreservacion)
                {
                    totalglobal += item.productos.precio * item.cantidad;
                }
               
            }

            //hacerput a la tabla reservacion

            var actualizarreservacion = new Model.Modeldb.reservacion
            {
                id = Constantes.idreservacion,
                idcliente = Constantes.idusuario,
                total = totalglobal
            };


            var json = JsonConvert.SerializeObject(actualizarreservacion);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            client = new HttpClient();
            var result = await client.PutAsync(string.Format("http://paraisoreal19.somee.com/api/reservacions/Putreservacion/"+ idreservacion), content);

           
            
       
        }
    }
}
