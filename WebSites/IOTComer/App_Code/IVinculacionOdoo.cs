using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de interfaz "IVinculacionOdoo" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IVinculacionOdoo
{
    [OperationContract]
    [WebGet(UriTemplate = "/datosGarantia", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
    Garantia regresaDatosGarantia(string riscei);
}
