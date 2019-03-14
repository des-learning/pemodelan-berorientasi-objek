using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoVS
{
    public class ToDoService {
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
