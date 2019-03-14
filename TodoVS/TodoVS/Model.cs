using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoVS
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

        public ToDo() {
            this.waktu = DateTime.Now;
            this.keterangan = "";
            this.status = StatusType.draft; // draft, inprogress, done
        }

        public ToDo(DateTime waktu, string keterangan, StatusType status) {
            this.waktu = waktu;
            this.keterangan = keterangan;
            this.status = status;
        }

    }
}
