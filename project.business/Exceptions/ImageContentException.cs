using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Exceptions
{
    public class ImageContentException:Exception
    {
        public string PropertyName { get; set; }
        public ImageContentException()
        {

        }
        public ImageContentException(string propertyName,string? message):base(message)
        {
            PropertyName = propertyName;
        }
    }
}
