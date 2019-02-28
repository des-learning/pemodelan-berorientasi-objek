using System;
using System.Collections.Generic;

namespace ToDo
{
    public class ToDoService {
        private IToDoRepository repository;

        public ToDoService(IToDoRepository repository) {
            this.repository = repository;
        }

        public Maybe<ToDo> Create(ToDo todo) {
            return this.repository.Add(todo);
        }

        public Maybe<ToDo> Update(ToDo todo) {
            return this.repository.Update(todo.id, todo);
        }

        public bool Delete(ToDo todo) {
            return this.repository.Delete(todo.id);
        }

        public List<ToDo> GetAllTodos() {
            List<ToDo> allToDos = this.repository.FindByStatus(StatusType.draft);
            allToDos.AddRange(this.repository.FindByStatus(StatusType.inprogress));
            allToDos.AddRange(this.repository.FindByStatus(StatusType.done));
            return allToDos;
        }

        // update todo status to done
        public bool Finish(ToDo todo) {
            ToDo t = new ToDo(todo.waktu, todo.keterangan, StatusType.done);
            return this.repository.Update(todo.id, t) is Some<ToDo>;
        }

        public bool InProgress(ToDo todo) {
            ToDo t = new ToDo(todo.waktu, todo.keterangan, StatusType.inprogress);
            return this.repository.Update(todo.id, t) is Some<ToDo>;
        }

        public List<ToDo> GetAllFinish() {
            return this.repository.FindByStatus(StatusType.done);
        }

        public List<ToDo> GetAllDraft() {
            return this.repository.FindByStatus(StatusType.draft);
        }

        public List<ToDo> GetAllInProgress() {
            return this.repository.FindByStatus(StatusType.inprogress);
        }

        public List<ToDo> GetThisMonthTodos() {
            DateTime current = DateTime.Now;
            DateTime first = new DateTime(current.Year, current.Month, 1);
            DateTime last = first.AddMonths(1).AddDays(-1);
            return this.repository.FindByWaktu(first, last);
        }
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

        public static Boolean save(ToDo todo) {
            Boolean valid = validate(todo);
            if (valid) {
                // TODO: implementasi simpan todo ke database
                // db.insert(todo)
            }

            return valid;
        }
    }
}
