using System.Transactions;

namespace EtudeV2.Tests.Utilities
{
    // https://blogs.msdn.microsoft.com/dbrowne/2010/06/03/using-new-transactionscope-considered-harmful/
    public class TransactionUtilities
    {
        public static TransactionScope CreateTransactionScope()
        {
            var transactionOptions = new TransactionOptions
            {
                // change default isolation level from Serializable, as those transactions
                // are deadlock-prone
                IsolationLevel = IsolationLevel.ReadCommitted,

                // change obscure TransactionScope default timeout
                Timeout = TransactionManager.MaximumTimeout
            };

            return new TransactionScope(TransactionScopeOption.Required, transactionOptions);
        }
    }
}
