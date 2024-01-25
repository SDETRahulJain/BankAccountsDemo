# Basic Bank System API Automation

This project implements API automation for basic bank system scenarios using SpecFlow, RestSharp, and NUnit.

## API Endpoints

1. **Create Account**
   - Endpoint: `POST https://www.localhost:8080/api/account/create`
   - Request Payload:
     ```json
     {
        "InitialBalance": 1000,
        "AccountName": "Rajesh Mittal",
        "Address": "Ahmedabad, Gujarat"
     }
     ```
   - Response:
     ```json
     {
        "Data": {
            "Balance": 1000,
            "AccountName": "Rajesh Mittal",
            "AccountNumber": "X123"
        },
        "Message": "Account X123 created successfully",
        "Errors": []
     }
     ```

2. **Delete Account**
   - Endpoint: `DELETE https://www.localhost:8080/api/account/delete/<accountID>`
   - Response:
     ```json
     {
        "Data": null,
        "Message": "Account <accountID> deleted successfully",
        "Errors": []
     }
     ```

3. **Deposit**
   - Endpoint: `PUT https://www.localhost:8080/api/account/deposit`
   - Request Payload:
     ```json
     {
        "AccountNumber": "X123",
        "Amount": 1000
     }
     ```
   - Response:
     ```json
     {
        "Data": {
            "AccountNumber": "X123",
            "Balance": 2000
        },
        "Message": "1000$ deposited to Account X123 successfully",
        "Errors": []
     }
     ```

4. **Withdraw**
   - Endpoint: `PUT https://www.localhost:8080/api/account/withdraw`
   - Request Payload:
     ```json
     {
        "AccountNumber": "X123",
        "Amount": 1000
     }
     ```
   - Response:
     ```json
     {
        "Data": {
            "AccountNumber": "X123",
            "Balance": 0
        },
        "Message": "1000$ withdrawn from Account X123 successfully",
        "Errors": []
     }
     ```
5. **Query**
   - Endpoint: `Get https://www.localhost:8080/api/account/Info`
   - Request Payload:
     ```json
     {
        "AccountNumber": "X123"
        
     }
     ```
   - Response:
     ```json
     {
        "Data": {
            "AccountNumber": "X123",
            "Balance": 0,
            "AccountName": "Abc",
            "Address": "XYZ123"
        },
        "Message": "Account Details are provided",
        "Errors": []
     }
     ```

## Test Coverage

- The provided scenario "Create new Account with valid data" is covered in the feature file.
- Assertions are made on the response code, absence of errors, success message, and correctness of account details in the JSON response.

## Tech Stacks Used

- SpecFlow: BDD framework for .NET
- RestSharp: Simple REST and HTTP API Client
- NUnit: Unit testing framework for .NET
