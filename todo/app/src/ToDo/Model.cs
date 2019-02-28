using System;

namespace ToDo {
    public enum StatusType { draft, inprogress, done}

    // Menampung data ToDo
    public class ToDo {
        // primary key
        public int id { get; private set; }

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

        public ToDo() {
            this.id = 0;
            this.waktu = DateTime.Now;
            this.keterangan = "";
            this.status = StatusType.draft; // draft, inprogress, done
        }

        public ToDo(DateTime waktu, string keterangan, StatusType status) {
            this.id = 0;
            this.waktu = waktu;
            this.keterangan = keterangan;
            this.status = status;
        }

    }

}