using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoVS
{
    class TodoUI
    {
        static ToDoService todoSvc;

        static void displayMenu(string []menus) {
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
            ToDo todo = ToDoService.BlankTodo();

            Console.WriteLine("New Todo");
            Console.Write("Input tanggal dan waktu (yyyy-mm-dd hh:mm), kosongkan untuk waktu sekarang: ");
            string waktu = Console.ReadLine().Trim();
            if (waktu != "") {
                todo.waktu = DateTime.Parse(waktu);
            } 
            Console.Write("Keterangan: ");
            todo.keterangan = Console.ReadLine();

            Maybe<ToDo> newTodo = todoSvc.Create(
                todo.waktu, todo.keterangan
                );
            string hasil = "berhasil";
            if (newTodo is Nothing<ToDo>) {
                hasil = "gagal";
            }
            Console.WriteLine($"Simpan: {hasil}");
        }

        static void ListTodo() {
            List<ToDo> todos = todoSvc.GetAll();
            foreach(ToDo todo in todos)
            {
                Console.WriteLine($"{todo.id} {todo.keterangan} {todo.waktu} {todo.status}");
            }
        }

        static void DeleteTodo()
        {
            Console.WriteLine("Delete Todo");
            ListTodo();
            Console.Write("Nomor ToDo yang akan dihapus: ");
            try
            {
                int id = Int32.Parse(Console.ReadLine());
                Maybe<ToDo> todo = todoSvc.Delete(id);
                if (todo is Nothing<ToDo>)
                {
                    Console.WriteLine($"Todo nomor {id} tidak ditemukan");
                } else
                {
                    Console.WriteLine($"Todo nomor {id} telah dihapus");
                }
            } catch (Exception e)
            {
                Console.WriteLine("nomor index salah!");
            }
        }

        static void Main(string []args) {
            todoSvc = new ToDoService(new ListRepository());
            Boolean exit = false;
            string []menus = {"New Todo", "List Todo", "Update Todo",
                              "Delete Todo", "End Application"};
            // Action -> type data C# untuk refer ke fuction tanpa parameter dan return type
            // Action<int> -> terima 1 parameter integer return void
            // Func<int, string> -> terima 1 parameter int, return string
            Dictionary<string, Action> commands = new Dictionary<string, Action>{
                {"new", NewTodoForm},
                {"list", ListTodo},
                {"update", () => Console.WriteLine("update")},
                {"delete", DeleteTodo},
                {"end", () => exit = true}
            };
            Action otherCommand = () => Console.WriteLine("Command salah");

            do {
                displayMenu(menus);
                string command = getUserChoice();
                Action action = otherCommand;
                if (commands.ContainsKey(command))
                    action = commands[command];
                action();
            } while (!exit);
        }
    }
}
