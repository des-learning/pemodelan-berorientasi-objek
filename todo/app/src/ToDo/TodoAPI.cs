using System;

namespace ToDo
{
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
        public string status { get; set; }

        private ToDo() {
            this.waktu = DateTime.Now;
            this.keterangan = "";
            this.status = "draft"; // draft, inprogress, done
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
            var validStatus = new string[]{"draft", "inprogress", "done"};

            return this.waktu != null && this.keterangan != "" && 
                Array.Exists(validStatus, (string e) => e == this.status);
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
