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
    }
}
