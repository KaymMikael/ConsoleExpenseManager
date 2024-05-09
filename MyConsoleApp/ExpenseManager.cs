using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp
{
    internal class ExpenseManager
    {
        public readonly List<Expense> expenseList;

        public ExpenseManager()
        {
            expenseList = new List<Expense>();
        }

        public void addExpense(Expense expense)
        {
            if (expense != null)
            {
                bool isExpenseExists = false;

                foreach (Expense exp in expenseList)
                {
                    if (exp.Name.ToLower().Equals(expense.Name.ToLower()))
                    {
                        Print("Expense Already Exists!");
                        isExpenseExists = true;
                        break;
                    }
                }

                if (!isExpenseExists)
                {
                    expenseList.Add(expense);
                }
            }
        }


        public void ShowAllExpense()
        {
            if (expenseList.Count > 0)
            {
                Print("\tExpenses List");
                foreach (Expense expense in expenseList)
                {
                    expense.PrintInfo();
                }
            }
            else
            {
                Print("Expense list is empty.");
            }
        }

        public void DeleteExpense(string Name)
        {
            int ExpenseId = GetIdByName(Name);

            foreach(Expense expense in expenseList)
            {
                if(expense.Id == ExpenseId)
                {
                    expenseList.Remove(expense);
                    Print("Deleted Successfully");
                    return;
                }
            }
        }

        public void ShowExpenseByCategory(string category)
        {
            bool IsExpenseExists = false;
            foreach (Expense expense in expenseList)
            {
                if (expense.Category.ToLower().Equals(category.ToLower()))
                {
                    expense.PrintInfo();
                    IsExpenseExists = true;
                }
            }
            if(!IsExpenseExists)
            {
                Print($"No expenses found in category: {category}");
            }
        }

        protected int GetIdByName(string name)
        {
            int id = 0;
            foreach (Expense expense in expenseList)
            {
                if (expense.Name.ToLower().Equals(name.ToLower()))
                {
                    return id = expense.Id;
                }
            }
            return id;
        }

        protected void Print(string str)
        {
            Console.WriteLine(str);
        }
    }
}
