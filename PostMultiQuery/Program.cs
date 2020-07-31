using System;
using System.Text.Json;
using System.Threading;
using RestSharp;
using RestSharp.Authenticators;

namespace PostMultiQuery
{
    public class ThreadExample
    {
        // The ThreadProc method is called when the thread starts.
        // It loops ten times, writing to the console and yielding
        // the rest of its time slice each time, and then ends.
        public static void ThreadProc()
        {
            int contador = 1;
            while (true)
            {
                contador++;
                curlExample postEmail = new curlExample();
                string response = postEmail.sendPost(contador);
//               Console.WriteLine("RESPONSE:" + response);
            }
        }
        class Program
        {
            int contador = 0;
            static void Main(string[] args)
            {

                    for(int i=0; i <100; i++)
                    {
                        Thread thr = new Thread(ThreadProc);
                        thr.Start();
                    }                
                }
            }
        }
    }

    class curlExample
    {

        public curlExample()
        {

           
        }

        public string sendPost(int contador) {

            var client = new RestClient("http://ec2-100-26-226-30.compute-1.amazonaws.com/esp32-api/public/api/sensores");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");            
            

            email correo = new email();
            correo.contador = contador;
            string jsonString;

            jsonString = JsonSerializer.Serialize(correo);           

            request.AddJsonBody(jsonString);


            IRestResponse response = client.Execute(request);
            //email jsonResponse = JsonSerializer.Deserialize<email>(response.Content);            
            
            return response.Content;
        }
    }    



class email
{

    public string Remitente { get; set; }
    public string Nombre { get; set; }
    public string Receptor { get; set; }
    public string sistema { get; set; }
    public string Asunto { get; set; }
    public string Cuerpo { get; set; }
    public bool enabled { get; set; }
    public int id_sistema { get; set; }
    public string sensor{ get; set; }
    public int valor { get; set; }
    public int contador{ get; set; }
    public email() {
        Random r = new Random();
        this.contador = 0;
        this.id_sistema =1;
        this.sensor ="Jose";
        this.valor = r.Next(1, 100);
        
    }

}