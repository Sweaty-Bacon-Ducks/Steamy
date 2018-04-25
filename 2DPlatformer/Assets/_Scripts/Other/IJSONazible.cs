using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Utility
{
    /// <summary>
    /// Interfejs do tworzenia plików tektsowych typu .json
    /// </summary>
    public interface IJSONazible
    {
        bool SaveToFile();
        T ReadFromFile<T>(string path);
    }
}
