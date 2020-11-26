using APIFel.Model;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace APIFel
{
    [ServiceContract]
    public interface IPingService
    {

        [OperationContract]
        IEnumerable<WeatherForecast> Ping(string msg);
        [OperationContract]
        Login Login();
        [OperationContract]
        Response<string> GeneraXML(Documento documento);
    }
}
