using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareTool
{
    public class ModelBuilder
    {

    }

    /// <summary>
    /// Helps to Get the Permissions setted for the Object
    /// </summary>
    public class Permissions
    {
        public string Id { get; set; }
        public string PermissionName { get; set; }
    }

    /// <summary>
    /// Page Template Content
    /// </summary>
    public class PageTemplate : BaseClass
    {
        public List<Permissions> Permission { get; set; }
        public string ApplicationName { get; set; }
    }

}
