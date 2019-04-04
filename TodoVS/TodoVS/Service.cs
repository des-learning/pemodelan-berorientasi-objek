using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoVS
{
    public class ToDoService {
        private Repository repo;

        public ToDoService(Repository repo)
        {
            this.repo = repo;
        }

        public Maybe<ToDo> Create(DateTime waktu, string keterangan)
        {
            ToDo todo = new ToDo();
            todo.waktu = waktu;
            todo.keterangan = keterangan;
            todo.status = StatusType.draft;
            return this.repo.Create(todo);
        }

        public Maybe<ToDo> Delete(int id)
        {
            return this.repo.Delete(id);
        }

        public Maybe<ToDo> Update(int id, ToDo todo)
        {
            return this.repo.Update(id, todo);
        }

        private Maybe<ToDo> UpdateTodoStatus(int id,
            StatusType status)
        {
            Maybe<ToDo> todo = this.repo.GetById(id);
            if (todo is Nothing<ToDo>)
            {
                return new Nothing<ToDo>();
            }
            ToDo updateTodo = ((Some<ToDo>)todo).Value;
            updateTodo.status = status;
            return this.repo.Update(id, updateTodo);
        }

        public Maybe<ToDo> ToDoDone(int id)
        {
            return this.UpdateTodoStatus(id, StatusType.done);
        }

        public Maybe<ToDo> ToDoInProgress(int id) =>
            this.UpdateTodoStatus(id, StatusType.inprogress);

        public Maybe<ToDo> ToDoDraft(int id) =>
            this.UpdateTodoStatus(id, StatusType.draft);

        public Maybe<ToDo> Get(int id) => this.repo.GetById(id);

        public List<ToDo> GetByWaktu(DateTime start, DateTime end)
            => this.repo.GetByWaktu(start, end);

        public List<ToDo> GetAll() => this.repo.GetAll();
        public List<ToDo> GetDone() => this.repo.GetByStatus(StatusType.done);
        public List<ToDo> GetDraft() => this.repo.GetByStatus(StatusType.draft);
        public List<ToDo> GetInProgress() => this.repo.GetByStatus(StatusType.inprogress);


        public static ToDo BlankTodo() {
            return new ToDo();
        }

        // validate menvalidasi todo, todo yang valid adalah
        // - waktu tidak null
        // - status isinya draft/inprogress/done
        // - keterangan tidak kosong
        private static Boolean validate(ToDo todo) {
            return todo.waktu != null && todo.keterangan != "";
        }
    }
}
