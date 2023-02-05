namespace XunitTestBudgets
{
    using BlazorBudgetTrackingApp.Shared.Data;
    using System.ComponentModel.DataAnnotations;
    using BlazorBudgetTrackingApp.Client.Pages;


    public class UnitTest1
    {
        [Fact]
        public void TransactionDescriptionRequired()
        {
            //Arrange
            var transaction = new Transaction { Amount = 100, Desription = "" };

            //Act
            var validationContext = new ValidationContext(transaction);
            var validatioResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(transaction, validationContext, validatioResults, true);
            //Assert

            Assert.False(isValid);
            Assert.Contains(validatioResults, x => x.ErrorMessage == "The Desription field is required.");
        }

        [Theory]
        [InlineData(-100)]
        public void Transaction_AmountMustBePositive(decimal amount)
        {
            // Arrange
            var transaction = new Transaction { Desription = "Test", Amount = amount, Category = "Income" };

            // Act
            var validationContext = new ValidationContext(transaction);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(transaction, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(validationResults, x => x.ErrorMessage == "Amount must be a positive number.");
        }
        [Fact]
        public void TransactionDateIsValid()
        {
            ///Arrange
            var transaction = new Transaction
            {
                Desription = "Test",
                Amount = 100,
                Category = "Income",
                DateTransaction = default(DateTime),
            };

            //Act
            var validationContext = new ValidationContext(transaction);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(transaction, validationContext, validationResults, true);
            //Assert
            Assert.True(isValid);
            // Assert.Contains(validationResults, x => x.ErrorMessage =="The Date field is required.");
        }


        [Fact]
        public void Transaction_CategoryIsRequired()
        {
            // Arrange
            var transaction = new Transaction { Desription = "Test", Amount = 100, DateTransaction = DateTime.Now, Category = "" };

            // Act
            var validationContext = new ValidationContext(transaction);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(transaction, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(validationResults, x => x.ErrorMessage == "The Category field is required.");
        }

        [Fact]
        public void Transaction_Valid()
        {
            // Arrange
            var transaction = new Transaction { Desription = "Test", Amount = 100, DateTransaction = DateTime.Now, Category = "Expense" };

            // Act
            var validationContext = new ValidationContext(transaction);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(transaction, validationContext, validationResults, true);
            //Assert
            Assert.True(isValid);
            Assert.Empty(validationResults);
        }

        [Fact]
        public void AddTransaction_AddsTransaction()
        {
            // Arrange
            var AddTransactionComponent = new AddTransaction();
            var transactions = new List<Transaction>();
       
            AddTransactionComponent.model = new Transaction { Desription = "Test transaction 1", Amount = 100, DateTransaction = DateTime.Now, Category = "Income" };
            // Act
            AddTransactionComponent.AddTransactionClick(AddTransactionComponent.model);

            // Assert
            Assert.Contains("Test transaction 1", AddTransactionComponent.model.Desription);
            Assert.IsType<Transaction>(AddTransactionComponent.model);
            Assert.NotNull(AddTransactionComponent.model);
           
        }
        [Fact]
        public void RemoveTransaction_RemovesTransaction()
        {
            // Arrange
            var BudgetTrackingComponent = new BudgetTracking();
            
             BudgetTrackingComponent.transactions = new List<Transaction>
             {
                 new Transaction {  Desription = "Test transaction 1", Amount = 100, 
                 DateTransaction = DateTime.Now, Category = "Income"  }
             };
            // Act
            BudgetTrackingComponent.RemoveTransaction(BudgetTrackingComponent.transactions[0]);

            // Assert
            Assert.DoesNotContain(BudgetTrackingComponent.transactions, x => x.Desription == "Test transaction 1");
            
        }
    }
}