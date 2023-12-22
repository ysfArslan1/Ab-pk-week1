
# Bank Account Management API

This API allows you to perform basic CRUD (Create, Read, Update, Delete) operations on bank accounts.

## How to Use

This API enables operations on bank accounts. The following examples provide basic information on how to use the API.

### Operations on Bank Accounts

- **Get All Bank Accounts**

  `GET /BankAccaunts`
  
  Use this endpoint to get all bank accounts.
  
- **Get Accounts by Holder Name**

  `GET /AccountsByHolder/?holder={holderName}`
  
  Use this endpoint to get accounts belonging to a specific account holder. Specify the account holder's name as the `holderName` parameter.

- **Get a Specific Bank Account**

  `GET /BankAccaunts/{id}`
  
  Use this endpoint to get a specific bank account. Specify the account ID as the `id` parameter.

- **Create a New Bank Account**

  `POST /BankAccaunts`
  
  Use this endpoint to create a new bank account. Send the new account details in JSON format.

- **Update a Bank Account**

  `PUT /BankAccaunts/{id}`
  
  Use this endpoint to update a specific bank account. Specify the ID of the account to be updated as the `id` parameter. Send the updated details in JSON format.

- **Delete a Bank Account**

  `DELETE /BankAccaunts/{id}`
  
  Use this endpoint to delete a specific bank account. Specify the ID of the account to be deleted as the `id` parameter.

- **Partially Update a Bank Account (PATCH)**

  `PATCH /BankAccaunts/{id}`
  
  Use this endpoint to partially update a specific bank account. Specify the ID of the account to be updated as the `id` parameter. Send updates in JSON Patch format. (An example JSON Patch data can be found in the README)

## Error Handling

The API handles various error scenarios as follows:

- `404 Not Found`: The requested resource was not found.
- `400 Bad Request`: The request contains invalid or missing information.
- `500 Internal Server Error`: The operation couldn't be completed due to a server error.

