using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HttpRestClient
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WebApiList : ContentPage
	{
        public static int UsuarioID = 0;
        public static string Usuario = "";
        public static string Contrasenia = "";
        public static string Nombre = "";
        public static bool IsActivo;
        public static DateTime fchRegistro;
        public static bool IsEliminado;
        public static int Rol = 0;
        public static int IdTipoUsuario = 0;
        public static byte[] Foto;
        public static bool TFAuthentication;
        public static string NumeroCelular = "";
        public static int CodigoPais = 0;
        List<string> Lista = new List<string>();
        public WebApiList ()
		{
			InitializeComponent ();
            LoadList();
            XamSharpWebApi.ItemsSource = Lista;
        }
        public void LoadList()
        {
            try
            {
                string UsuarioEntry = "uncorreo@hotmail.com";
                var person = new PersonLogin { Usuario = UsuarioEntry, TipoAccion = "LOGIN" };
                var json = JsonConvert.SerializeObject(person);
                HttpWebRequest request = WebRequest.Create(RestService.Servidor + RestService.Methods.LoginMethod + "?id=0&data=" + json) as HttpWebRequest;
                request.Method = RestService.HTTPMethods.Get;
                request.Headers.Add("ApiKey", RestService.ApiKey);
                request.ContentType = RestService.ContentType;
                string resp;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    resp = reader.ReadToEnd();
                    var obj = JsonConvert.DeserializeObject<object>(resp);
                    string data = (string)obj;
                    JObject json2 = JObject.Parse(data);
                    var respuesta_data = json2;
                    string Response = respuesta_data.GetValue("Response").ToString();
                    if (Response == "SUCCESS")
                    {
                        var ListaFlujosJS = respuesta_data.GetValue("Objeto").ToString();
                        try
                        {
                            var objResponse1 = JsonConvert.DeserializeObject<Model>(ListaFlujosJS);
                            if (objResponse1.UsuarioID != 0)
                            {
                                UsuarioID = objResponse1.UsuarioID;
                                Lista.Add(UsuarioID.ToString());
                                Usuario = objResponse1.Usuario;
                                Lista.Add(Usuario.ToString());
                                Contrasenia = objResponse1.Contrasenia;
                                Nombre = objResponse1.Nombre;
                                IdTipoUsuario = objResponse1.UsuarioID;
                                Lista.Add(IdTipoUsuario.ToString());
                                Foto = objResponse1.Foto; ;
                                TFAuthentication = objResponse1.TFAuthentication;
                                Lista.Add(TFAuthentication.ToString());
                                NumeroCelular = objResponse1.NumeroCelular;
                                Lista.Add(NumeroCelular.ToString());
                                CodigoPais = objResponse1.CodigoPais;
                                Lista.Add(CodigoPais.ToString());
                            }
                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    }
                    else
                    {
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
	}
}