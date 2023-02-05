using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorBudgetTrackingApp.Shared.Data;


namespace BlazorBudgetTrackingApp.Client.Pages
{
    public partial class BudgetTracking
    {
        public List<Transaction> transactions = new List<Transaction>();

        protected override Task OnParametersSetAsync()
        {
            return base.OnParametersSetAsync();
        }

        private void AddTranscationCallBack(Transaction model)
        {
            try
            {
                transactions.Add(new Transaction
                {
                    DateTransaction = model.DateTransaction,
                    Desription = model.Desription,
                    Amount = model.Amount,
                    Category = model.Category,
                });
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void RemoveTransaction(Transaction transaction)
        {
            transactions.Remove(transaction);
        }

        private decimal total => transactions.Sum(t => t.Amount);
    }
}
