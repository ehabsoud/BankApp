# BankApp
HB Bank - Blazor WebAssembly

Overview
HB Bank is a banking application built in Blazor WebAssembly.
It allows users to:

- Create one or more bank accounts
- Deposit and withdraw money
- Transfer funds between own accounts
- View transaction history with filtering and sorting
- Store data locally in the browser using LocalStorage

Features

1. Create Account
- Enter account name, account type (Salary / Savings), currency (SEK) and initial balance
- Validation: account name required, initial balance > 0

2. Accounts list
- Display all accounts with name, type, balance and last updated timestamp

3. Transactions
- Deposit, Withdraw, and Transfer between accounts
- Prevents overdrafts with clear error messages
- Transaction history filterable by type and account
- Sortable by date and amount

4. Persistence
- Accounts and transactions saves locally in the browser
- Data persists between sessions

Page / Components
- Home.razor - Welcome page
- CreateAccount.razor - Create new accounts
- Account.razor - List of all accounts
- NewTransaction.razor - Make deposits, withdrawals and transfers
- History.razor - View transaction history with filters and sorting

Domain classes
- BankAccount - Represents a bank account
- Transaction - Represents a transaction
- AccountType - Enum for account types
- CurrencyType - Enum for currencies

Services & Interfaces
- IAccountService / AccountService - Manages accounts and transactions
- IStorageService / StorageService - Handles local storage via JSInterop

Installation & Run
1. Open the project folder in your preferred IDE
2. Restore dependencies and build the project
3. Run the project
4. The app will open in your default browser (default URL is https://localhost:5001)

Notes
- All data is stored locally in the browser; clearing browser storage will erase accounts and transactions
- Error messages are shown for invalid inputs or insufficient balance
- The application is designed for demonstration and learning purposes; no real banking operations are performed
 

