using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public interface IShowService
    {
        List<ShowModel> GetAllShows();
        void AddShowModel(ShowModel show);
        bool DeleteShowById(ShowModel show);
        bool UpdateShow(ShowModel show);
        ShowModel GetShowById(int Id);
    }
}
