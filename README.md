# CRUDOperations

## Overview

This project is a .NET Core Web API that provides CRUD (Create, Read, Update, Delete) operations for managing products. It follows a three-tier architecture with Controller, Service, and Data Access layers. The project is also integrated with Swagger for API documentation.

### Project Structure

- **Controller Layer**: This layer handles HTTP requests and responses. It contains endpoints for CRUD operations.
  
- **Services Layer**: The service layer contains the business logic of the application. It communicates with the data access layer for data operations.

- **Data Access Layer**: This layer is responsible for interacting with the database. It provides data access and manipulation functions.

### Prerequisites

- .NET Core SDK
- MySQL Server
- Visual Studio or another code editor of your choice
- [Swashbuckle.AspNetCore](https://www.nuget.org/packages/Swashbuckle.AspNetCore) for Swagger integration
- [APIException](#apiexception-library) library

## Getting Started

Follow these steps to get the project up and running:

1. Clone the repository to your local machine.

2. Open the project in your preferred code editor.

3. Change Connection string from AppSettings.Json

4. Build and run the application.

5. Access the Swagger documentation for the API at `https://yourdomain/swagger` to explore the available endpoints and their descriptions.

## Usage

The API provides the following CRUD operations:

### Read Product Data

- **Endpoint**: `GET /api/products/read`
- **Description**: Get all product data.
- **Response**:
  - HTTP Status 200: Product details found successfully.
  - HTTP Status 401: Data not found.
  - HTTP Status 400: Failed to load Product details.
  - HTTP Status 500: Unexpected error encountered.

### Create Product

- **Endpoint**: `POST /api/products/create`
- **Description**: Create a new product.
- **Request Body**: JSON representation of the product.
- **Response**:
  - HTTP Status 201: Product created successfully.
  - HTTP Status 400: Failed to create the product.
  - HTTP Status 500: Unexpected error encountered.

### Update Product

- **Endpoint**: `PUT /api/products/update/{id}`
- **Description**: Update an existing product.
- **Request Parameters**: `id` - The ID of the product to update.
- **Request Body**: JSON representation of the updated product.
- **Response**:
  - HTTP Status 200: Product updated successfully.
  - HTTP Status 400: Failed to update the product.
  - HTTP Status 404: Product not found.
  - HTTP Status 500: Unexpected error encountered.

### Delete Product

- **Endpoint**: `DELETE /api/products/delete/{id}`
- **Description**: Delete an existing product.
- **Request Parameters**: `id` - The ID of the product to delete.
- **Response**:
  - HTTP Status 200: Product deleted successfully.
  - HTTP Status 404: Product not found.
  - HTTP Status 500: Unexpected error encountered.

## ExcepitionMidLib Library

The project utilizes a custom lib which develop by me `ExcepitionMidLib` library for handling global exceptions and maintaining global response. This library is used to generate standardized responses for successful and error scenarios.

### Response

An error response includes the following fields:

- `trackingid`: A unique identifier for tracking the error.
- `usermessage`: A user-friendly error message.
- `developerMessage`: A developer-specific error message.
- `data`: Additional data related to the error.
- `statuscode`: The HTTP status code indicating the type of error.

Example Error Response:

```json
{
  "trackingid": "ea9e0805-f615-486c-913a-13c09baa30fe",
  "usermessage": "Product is not exists.",
  "developerMessage": null,
  "data": null,
  "statuscode": 406
}
```
Successful Response

```json
{
  "trackingId": "85fef669-292f-4dbb-8f2c-888e8fc88cbd",
  "userMessage": null,
  "developerMessage": null,
  "data": [
    {
      "id": 1,
      "productname": "Mango",
      "price": 0,
      "productdetails": "Mongo product"
    },
    {
      "id": 2,
      "productname": "Apple",
      "price": 47,
      "productdetails": "Apple product"
    }
  ],
  "statusCode": 200
}
```

# All Rights Reserved License

© Vivek Patel

All rights to this software and associated documentation are reserved. You may only view this code for educational or reference purposes. Any use, copy, modification, distribution, or other action with this code is strictly prohibited without explicit written permission from the copyright holder.

If you are interested in using this code or any part of it, please contact 	mr.vivekjpatel@gmail.com for licensing and permissions.

THIS SOFTWARE IS PROVIDED "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
