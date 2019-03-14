using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoVS
{
    class TodoUI
    {
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

            string hasil = ToDoService.save(todo) ? "berhasil" : "gagal";
            Console.WriteLine($"Simpan: {hasil}");
        }

        static void ListTodo() {
            Console.WriteLine("List Todo");
        }

        static void Main(string []args) {
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
                {"delete", () => Console.WriteLine("delete")},
                {"end", () => exit = true}
            };
            Action otherCommand = () => Console.WriteLine("Command salah");

            do {
                displayMenu(menus);
                string command = getUserChoice();
                Action action = otherCommand;
                commands.TryGetValue(command, out action);
                action();
            } while (!exit);
        }
    }
}
