# EShop-microservice

## General

A microservice project for an online store (EShop), built on .NET. The focus is on asynchronous communication between microservices using RabbitMQ and MassTransit.

## Buiseness logic

### Core Concept

An online store composed of several independent microservices, each responsible for its own domain. Services communicate asynchronously via RabbitMQ, ensuring high fault tolerance and scalability.

### Microservice Architecture

#### Product Service

Responsibility: Managing the product catalog

Core Operations:

Product CRUD: Adding, editing, deleting products

Category Management: Creating category hierarchies

Inventory Management: Tracking stock quantities

Search & Filtering: Search by name, filter by category, price, attributes

#### Cart Service

Responsibility: Managing the customer's shopping cart

Core Operations:

Add/Remove Items: Managing cart contents

Preliminary Cost Calculation: Subtotal, taxes, shipping

Promo Code Application: Validating and applying discounts

Cart Persistence: For both authorized and anonymous users

#### Payment Service

Responsibility: Payment processing

Core Operations:

Payment Processing: Integration with payment gateways

Refunds: Processing returns for cancelled orders

Transaction History: Storing payment records

#### User Service

Responsibility: User management and authentication

Core Operations:

Registration/Authentication: JWT tokens, OAuth2

Profile Management: Personal data, delivery addresses

Activity History: Viewed products, favorites

#### Notification Service

Responsibility: Sending notifications

Core Operations:

Email Notifications: Order confirmations, status updates

SMS Notifications: Urgent alerts

Push Notifications: For mobile applications
