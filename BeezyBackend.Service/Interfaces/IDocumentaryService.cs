using System;
using System.Collections.Generic;
using System.Text;

namespace BeezyBackend.Service.Interfaces
{
    public interface IDocumentaryService
    {
        List<string> GetAllDocumentaries();

        List<string> GetDocumentaryByType();
    }
}
