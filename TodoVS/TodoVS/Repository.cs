using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoVS
{
    public interface Repository
    {
        Maybe<ToDo> Create(ToDo todo);
        Maybe<ToDo> Update(int id, ToDo todo);
        Maybe<ToDo> Delete(int id);
        Maybe<ToDo> GetById(int id);
        List<ToDo> GetByWaktu(DateTime start, DateTime end);
        List<ToDo> GetByStatus(StatusType status);
        List<ToDo> GetAll();
    }
}
