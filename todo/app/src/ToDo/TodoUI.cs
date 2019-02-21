using System;
using System.Collections.Generic;

namespace ToDo {
    class ToDoUI {
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
                var action = commands.GetValueOrDefault(command, otherCommand);
                action();
            } while (!exit);
        }
    }
}
