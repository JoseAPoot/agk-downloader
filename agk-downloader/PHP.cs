using System;
using System.IO;
using System.Net;
using System.Text;

namespace agk_downloader
{
    public class PHP
    {
        public PHP() { }

        public Tuple<int, object> GetData(string url, string data)
        {
            try
            {
                // Se crea la forma como se enviaran los datos, en este caso POST
                WebRequest request = WebRequest.Create(url);
                request.Method = "POST";

                // Variable para tomar los datos del parámetro data que llega a la funcion
                var postData = data;

                // Arreglo de bytes codificados con UTF8 para enviar los datos
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;

                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                // Aqui manejamos las respuestas del servidor
                WebResponse response = request.GetResponse();
                dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);
                string respuestaDeServidor = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();

                return new Tuple<int, object>(1, respuestaDeServidor);
            }
            catch (Exception e)
            {
                return new Tuple<int, object>(0, "Error al intentar obtener la información:" + Environment.NewLine + e.Message);
            }
        }
    }
}
