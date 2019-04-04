using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoVS
{
    class ListRepository: Repository
    {
        private List<ToDo> data;

        public ListRepository()
        {
            this.data = new List<ToDo>();
        }

        public Maybe<ToDo> Create(ToDo todo)
        {
            ToDo last = this.data.LastOrDefault();
            int count = 0;
            if (last != null)
            {
                count = last.id;
            }
            ToDo newToDo = new ToDo(count + 1, todo.waktu,
                todo.keterangan, todo.status);
            data.Add(newToDo);
            return new Some<ToDo>(newToDo);
        }

        public Maybe<ToDo> Update(int id, ToDo todo)
        {
            Maybe<ToDo> oldTodo = GetById(id);
            if (oldTodo is Nothing<ToDo>)
                return new Nothing<ToDo>();
            ToDo updatedTodo = ((Some<ToDo>)oldTodo).Value;
            updatedTodo.waktu = todo.waktu;
            updatedTodo.keterangan = todo.keterangan;
            updatedTodo.status = todo.status;
            return new Some<ToDo>(updatedTodo);
        }

        public Maybe<ToDo> Delete(int id)
        {
            Maybe<ToDo> oldTodo = GetById(id);
            if (oldTodo is Nothing<ToDo>)
                return new Nothing<ToDo>();
            data.Remove(((Some<ToDo>)oldTodo).Value);
            return oldTodo;
        }

        public Maybe<ToDo> GetById(int id)
        {
            ToDo todo = data.Find(x => x.id == id);
            if (todo == null)
                return new Nothing<ToDo>();
            return new Some<ToDo>(todo);
        }

        public List<ToDo> GetByWaktu(DateTime start, DateTime end)
        {
            List<ToDo> todos = new List<ToDo>();

            foreach(ToDo todo in data)
            {
                if (todo.waktu >= start && todo.waktu <= end)
                {
                    todos.Add(todo);
                }
            }
            return todos;
            // return data.FindAll(x => x.waktu >= start && x.waktu <= end);
        }

        public List<ToDo> GetByStatus(StatusType status)
        {
            return data.FindAll(x => x.status == status);
        }

        public List<ToDo> GetAll() => this.data;
    }
}
