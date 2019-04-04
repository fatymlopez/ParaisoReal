using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ParaisoRealB.procesos
{
    public class operaciones
    {
        public  decimal totalglobal { get; set; }
        public HttpClient client { get; set; }
        //public HttpResponseMessage HttpRM { get; set; }
        public operaciones(int idcliente, int idreservacion)
        {
             var result_sum = sumproductos(idcliente,idreservacion);
        }

        public async Task<HttpResponseMessage> sumproductos(int idcliente, int idreservacion)

        {

            client = new HttpClient();
            string URL = string.Format("http://paraisoreal19.somee.com/api/detallereservacions/Getdetallereservacion");
            var miArreglo = await client.GetStringAsync(URL);
            var JSON_DRESERVACION = JsonConvert.DeserializeObject<List<Model.Modeldb.detallereservacion>>(miArreglo);

            foreach (var item in JSON_DRESERVACION)
            {
                if (item.idreservacion == Constantes.idreservacion)
                {
                    totalglobal += Convert.ToDecimal(item.subtotal);
                }
               
            }

            //hacerput a la tabla reservacion

            var actualizarreservacion = new Model.Modeldb.reservacion
            {
                id = Constantes.idreservacion,
                idcliente = Constantes.idusuario,
                total = totalglobal,
                estado = 1
            };


            var json = JsonConvert.SerializeObject(actualizarreservacion);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            client = new HttpClient();
            var result = await client.PutAsync(string.Format("http://paraisoreal19.somee.com/api/reservacions/Putreservacion/"+ idreservacion), content);
            //if (result.IsSuccessStatusCode)
            //{
                
            //}
            return result;
        }
    }
}
