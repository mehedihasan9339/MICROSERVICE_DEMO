# Microservice Architecture Documentation

## Table of Contents

1. [Introduction](#introduction)
2. [Architecture Overview](#architecture-overview)
3. [API Gateway](#api-gateway)
4. [Microservices](#microservices)
   - [User Service](#user-service)
   - [Product Service](#product-service)
   - [Order Service](#order-service)
5. [Routing Configuration](#routing-configuration)
6. [Workflow Example](#workflow-example)
7. [Deployment](#deployment)
8. [Benefits and Challenges](#benefits-and-challenges)
9. [Conclusion](#conclusion)

---

## 1. Introduction

This documentation provides an overview of the microservice architecture implemented in this project. It details how the system components interact, focusing on the API Gateway using Ocelot and various microservices for user, product, and order management.

## 2. Architecture Overview

The architecture is based on the microservices pattern, where each service handles a specific business capability. The services communicate over HTTP, allowing for independent deployment and scaling.

## 3. API Gateway

The API Gateway acts as a single entry point for clients. It handles routing, authentication, and request aggregation.

### Features:
- **Routing**: Directs requests to the appropriate microservice.
- **Security**: Manages authentication and authorization.
- **Logging**: Records requests and responses for monitoring.

## 4. Microservices

### User Service
- **Functionality**: Handles user registration, authentication, and profile management.
- **Endpoints**:
  - `GET /api/users`: Retrieves user details.
  - `POST /api/users`: Creates a new user.

### Product Service
- **Functionality**: Manages product listings and details.
- **Endpoints**:
  - `GET /api/products`: Retrieves product listings.
  - `POST /api/products`: Adds a new product.

### Order Service
- **Functionality**: Processes orders and manages order history.
- **Endpoints**:
  - `GET /api/orders`: Retrieves order details.
  - `POST /api/orders`: Creates a new order.

## 5. Routing Configuration

The routing for the API Gateway is defined in the `ocelot.json` file. Below is a sample configuration:

```json
{
	"Routes": [
		{
			"UpstreamPathTemplate": "/api/users",
			"UpstreamHttpMethod": ["GET", "POST"],
			"DownstreamPathTemplate": "/api/users",
			"DownstreamScheme": "http",
			"DownstreamHostAndPorts": [
				{
					"Host": "localhost",
					"Port": 5001
				}
			]
		},
		{
			"UpstreamPathTemplate": "/api/products",
			"UpstreamHttpMethod": ["GET", "POST"],
			"DownstreamPathTemplate": "/api/products",
			"DownstreamScheme": "http",
			"DownstreamHostAndPorts": [
				{
					"Host": "localhost",
					"Port": 5003
				}
			]
		},
		{
			"UpstreamPathTemplate": "/api/orders",
			"UpstreamHttpMethod": ["GET", "POST"],
			"DownstreamPathTemplate": "/api/orders",
			"DownstreamScheme": "http",
			"DownstreamHostAndPorts": [
				{
					"Host": "localhost",
					"Port": 5005
				}
			]
		}
	],
	"GlobalConfiguration": {
		"BaseUrl": "http://localhost:5000"
	}
}
```

## 6. Workflow Example

### Client Request
1. The client sends a request to the API Gateway: `GET /api/users`.

### API Gateway Processing
2. Ocelot routes the request to the User Service at `http://localhost:5001/api/users`.

### Forwarding Request
3. The User Service processes the request and retrieves user data.

### Response Handling
4. The User Service returns the data to the API Gateway.

### Client Response
5. The API Gateway forwards the response to the client.

## 7. Deployment

### Prerequisites
- .NET SDK installed.
- Running instances of microservices (User, Product, Order) on specified ports.

### Steps to Run
1. Clone the repository.
2. Navigate to the project directory.
3. Run the following command to start the API Gateway:
   ```bash
   dotnet run
4. Ensure all downstream services are running on their respective ports.

## 8. Benefits and Challenges

### Benefits
- **Modularity**: Each service can be developed and deployed independently.
- **Scalability**: Services can be scaled based on demand.
- **Technology Flexibility**: Different technologies can be used for different services.

### Challenges
- **Complexity**: More services can lead to a more complex system.
- **Data Consistency**: Managing data across services can be tricky.
- **Network Latency**: Increased inter-service communication can introduce latency.

## 9. Conclusion

This microservice architecture, with an API Gateway using Ocelot, allows for efficient routing and management of requests across multiple services. The system is designed to be modular, scalable, and flexible, accommodating the evolving needs of modern applications.






---
<div style="text-align: center; margin-top: 20px; width: 100%;">
    <p style="text-align: center; margin-top: 20px;">Developed by <strong>Mehedi Hasan</strong></p>
</div>
