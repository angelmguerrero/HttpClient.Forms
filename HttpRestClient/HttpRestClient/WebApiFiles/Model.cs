using System;
using System.Collections.Generic;
using System.Text;

namespace HttpRestClient
{
    [Serializable]
    public class Model
    {
        public int UsuarioID { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
        public string Nombre { get; set; }
        public bool IsActivo { get; set; }
        public DateTime fchRegistro { get; set; }
        public bool IsEliminado { get; set; }
        public int Rol { get; set; }
        public int IdTipoUsuario { get; set; }
        public byte[] Foto { get; set; }
        public bool TFAuthentication { get; set; }
        public string NumeroCelular { get; set; }
        public int CodigoPais { get; set; }
        
    }
}
