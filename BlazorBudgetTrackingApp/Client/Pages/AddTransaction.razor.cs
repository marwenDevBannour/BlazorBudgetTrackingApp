using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorBudgetTrackingApp.Shared.Data;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorBudgetTrackingApp.Client.Pages
{
    public partial class AddTransaction
    {
        [Parameter]
        public EventCallback<Transaction> transaction {  get; set; }

        public Transaction model { get; set; } = new Transaction();
        protected override async Task OnInitializedAsync()
        {
            try
            {
               
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void AddTransactionClick(Transaction trans)
        {
            try
            {

                transaction.InvokeAsync(model);
                model= new Transaction();
                
            }
            catch (Exception)
            {

                throw;
            }
        
        }
    }
}
