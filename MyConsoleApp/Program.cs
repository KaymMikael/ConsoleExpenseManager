using System;
using System.CodeDom;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            ExpenseManager expenseManager = new ExpenseManager();
            AddSampleData(expenseManager);
            while (true)
            {
                ShowChoices();
                Console.WriteLine("Enter your choice: ");
                if (Enum.TryParse(Console.ReadLine(), true, out Choices choice))
                {
                    // Successfully parsed the input into the Choices enum
                    switch (choice)
                    {
                        case Choices.Add:
                            AddExpense(expenseManager);
                            break;
                        case Choices.ShowAll:
                            expenseManager.ShowAllExpense();
                            break;
                        case Choices.ShowByCategory:
                            ShowExpenseByCategory(expenseManager);
                            break;
                        case Choices.Delete:
                            DeleteExpense(expenseManager);
                            break;
                        case Choices.Exit:
                            return;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }
        protected static void AddExpense(ExpenseManager expenseManager)
        {
            try
            {
                Console.Write("Enter expense name: ");
                string expenseName = Console.ReadLine();
                Console.Write("Enter expense category: ");
                string expenseCategory = Console.ReadLine();
                Console.Write("Enter expense price: ");
                double expensePrice = double.Parse(Console.ReadLine());
                if (string.IsNullOrEmpty(expenseName) || string.IsNullOrEmpty(expenseCategory) || double.IsNaN(expensePrice))
                {
                    Console.WriteLine("Please try again");
                    AddExpense(expenseManager);
                }
                int id = expenseManager.expenseList.Count + 1;
                Expense expenseObj = new Expense(id, expenseName, expenseCategory, expensePrice);
                expenseManager.addExpense(expenseObj);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please try again");
                AddExpense(expenseManager);
            }
        }

        protected static void DeleteExpense(ExpenseManager expenseManager)
        {
            expenseManager.ShowAllExpense();
            Console.Write("Enter expense name to delete: ");
            string expenseName = Console.ReadLine();

            if (string.IsNullOrEmpty(expenseName))
            {
                Console.WriteLine("Please try again");
                DeleteExpense(expenseManager);
            }
            expenseManager.DeleteExpense(expenseName);
        }

        protected static void ShowExpenseByCategory(ExpenseManager expenseManager)
        {
            try
            {
                Console.WriteLine("Enter category: ");
                string expenseName = Console.ReadLine();
                expenseManager.ShowExpenseByCategory(expenseName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        protected static void ShowChoices()
        {
            Console.WriteLine();
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Delete");
            Console.WriteLine("3. Show All Expenses");
            Console.WriteLine("4. Show Expenses By Category");
            Console.WriteLine("5. Exit");
        }
        protected static void AddSampleData(ExpenseManager expenseManager)
        {
            //Sample Data
            Expense exp1 = new Expense(1, "Groceries", "Food", 50.75);
            Expense exp2 = new Expense(2, "Electricity Bill", "Bills", 150.00);
            Expense exp3 = new Expense(3, "Dinner", "Food", 35.50);
            Expense exp4 = new Expense(4, "Internet Bill", "Bills", 80.00);
            Expense exp5 = new Expense(5, "Lunch", "Food", 20.25);
            Expense exp6 = new Expense(6, "Water Bill", "Bills", 30.00);
            Expense exp7 = new Expense(7, "Snacks", "Food", 10.50);
            Expense exp8 = new Expense(8, "Rent", "Bills", 1200.00);
            Expense exp9 = new Expense(9, "Breakfast", "Food", 15.00);
            Expense exp10 = new Expense(10, "Phone Bill", "Bills", 50.00);
            Expense exp11 = new Expense(11, "Fast Food", "Food", 25.50);
            Expense exp12 = new Expense(12, "Gas Bill", "Bills", 70.00);
            Expense exp13 = new Expense(13, "Coffee", "Food", 5.75);
            Expense exp14 = new Expense(14, "Insurance", "Bills", 200.00);
            Expense exp15 = new Expense(15, "Dessert", "Food", 8.50);
            Expense exp16 = new Expense(16, "Medical Bill", "Bills", 100.00);
            Expense exp17 = new Expense(17, "Fruits", "Food", 15.25);
            Expense exp18 = new Expense(18, "Car Payment", "Bills", 300.00);
            Expense exp19 = new Expense(19, "Vegetables", "Food", 20.00);
            Expense exp20 = new Expense(20, "Credit Card Bill", "Bills", 150.00);

            expenseManager.addExpense(exp1);
            expenseManager.addExpense(exp2);
            expenseManager.addExpense(exp3);
            expenseManager.addExpense(exp4);
            expenseManager.addExpense(exp5);
            expenseManager.addExpense(exp6);
            expenseManager.addExpense(exp7);
            expenseManager.addExpense(exp8);
            expenseManager.addExpense(exp9);
            expenseManager.addExpense(exp10);
            expenseManager.addExpense(exp11);
            expenseManager.addExpense(exp12);
            expenseManager.addExpense(exp13);
            expenseManager.addExpense(exp14);
            expenseManager.addExpense(exp15);
            expenseManager.addExpense(exp16);
            expenseManager.addExpense(exp17);
            expenseManager.addExpense(exp18);
            expenseManager.addExpense(exp19);
            expenseManager.addExpense(exp20);
        }
    }
    enum Choices
    {
        Add = 1,
        Delete = 2,
        ShowAll = 3,
        ShowByCategory = 4,
        Exit = 5
    }
}
