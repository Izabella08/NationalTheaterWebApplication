using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Factory
{
    public interface IWriter
    {
        void ExportTickets(int showID);
    }
}
