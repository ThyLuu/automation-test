# Jira08 - API Testing with RestSharp (NUnit)

## Overview

This project is an API Automation Testing Framework developed using **C#**, **NUnit**, and **RestSharp** to verify the APIs provided by DemoQA.

**Application Under Test:** https://demoqa.com

The framework follows a clean and maintainable architecture with clear separation of concerns using:

* Core
* Services
* Tests

The implementation covers both positive and negative test scenarios while following coding standards and best practices.

## Tested Endpoints
*GET /Account/v1/User/{USERID} (Get User)
*POST /BookStore/v1/Books (Add Book)
*DELETE /BookStore/v1/Book (Delete Book)
*PUT /BookStore/v1/Books/{isbn} (Replace Book)
