using System;

namespace ToDo {
    class ToDoUI {
        static void menu() {
            string []menus = {"List Todo", "New Todo", "Update Todo", "Delete Todo", "End"};

            Console.WriteLine("Menu");
            Console.WriteLine("====");
            Console.WriteLine();
            foreach (string m in menus) {
                Console.WriteLine(m);
            }
            Console.Write("Your choice: ");
        }

        static string getUserChoice() {
            return Console.ReadLine().ToLower();
        }

        static void NewTodoForm() {
            ToDo todo = ToDo.BlankTodo();

            Console.WriteLine("New Todo");
            Console.Write("Input tanggal dan waktu (yyyy-mm-dd hh:mm), kosongkan untuk waktu sekarang: ");
            string waktu = Console.ReadLine().Trim();
            if (waktu != "") {
                todo.waktu = DateTime.Parse(waktu);
            } 
            Console.Write("Keterangan: ");
            todo.keterangan = Console.ReadLine();

            string hasil = ToDo.save(todo) ? "berhasil" : "gagal";
            Console.WriteLine($"Simpan: {hasil}");
        }

        static void Main(string []args) {
            menu();
            string command = getUserChoice();
            switch(command) {
                case "new":
                    // panggil untuk input new todo
                    NewTodoForm();
                    break;
                case "list":
                    Console.WriteLine("list");
                    break;
                case "update":
                    Console.WriteLine("update");
                    break;
                case "delete":
                    Console.WriteLine("delete");
                    break;
                case "end":
                    Console.WriteLine("stop");
                    break;
                default:
                    Console.WriteLine("Salah command");
                    break;
            }
        }
    }
}