using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpegitim.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Insert(T Entity);
        void Update(T Entity);
        List<T> Getall();
        T GetById(int id);



    }
}
