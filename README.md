# ClinicAPI

Clinic API for patient registration and queue ticket generation for triage and medical care on a first-come, first-served basis.

## Project Overview

In this project, the following patterns and methodologies were implemented:

- **CQRS and Repository Patterns**: 
  - **CQRS Implementation**: Utilized the Mediator pattern.
  - **Data Access**: Applied the Generic Repository pattern.
  - **Error Handling**: Used the Result pattern for handling expected application errors.
  - **Database Creation**: Tables were created using code first approach (Entity Framework + Migrations).

## Technologies Used

- **CQRS (Command Query Responsibility Segregation)**
- **Mediator Pattern**
- **Generic Repository Pattern**
- **Result Pattern**
- **Entity Framework (Code First + Migrations)**

## Usage

This API provides endpoints for:
- Patient registration
- Queue ticket generation for triage
- Triage and medical care on a first-come, first-served basis

## Contributing

Contributions are welcome! Please fork this repository and submit a pull request for any enhancements or bug fixes.
