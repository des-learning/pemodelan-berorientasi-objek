using System;

namespace ToDo
{
    public enum StatusType { draft, inprogress, done}

    // Menampung data ToDo
    public class ToDo {
        // menyimpan waktu todo
        public DateTime waktu { get; set; }
        // menyimpan keterangan todo
        public string keterangan { get; set; }
        // status menyimpan informasi status todo, nilai yang diperbolehkan
        // adalah draft, inprogress dan done
        // draft -> todo masih berupa catatan belum dikerjakan
        // inprogress -> todo sedang dikerjakan
        // done -> todo telah selesai dikerjakan
        public StatusType status { get; set; }

        private ToDo() {
            this.waktu = DateTime.Now;
            this.keterangan = "";
            this.status = StatusType.draft; // draft, inprogress, done
        }

        // factory method
        public static ToDo BlankTodo() {
            return new ToDo();
        }

        // validate menvalidasi todo, todo yang valid adalah
        // - waktu tidak null
        // - status isinya draft/inprogress/done
        // - keterangan tidak kosong
        private Boolean validate() {
            return this.waktu != null && this.keterangan != "";
        }

        public static Boolean save(ToDo todo) {
            Boolean valid = todo.validate();
            if (valid) {
                // TODO: implementasi simpan todo ke database
                // db.insert(todo)
            }

            return valid;
        }
    }
}
