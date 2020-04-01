using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ObjectWCF
{
    [ServiceContract]
    interface InterfaceImages
    {
        [OperationContract]
        bool insertImage(string Name, string Path, string Description, string Location, string Persons);

        [OperationContract]
        Dictionary<int, string> getImages();

        [OperationContract]
        bool deleteImage(int id);

        [OperationContract]
        Dictionary<string, string> getImageData(int id);

        [OperationContract]
        bool updateImage(int id, string Name, string Path, string Description, string Location, string Persons);
    }
}
