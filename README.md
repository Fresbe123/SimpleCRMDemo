# CRMDemo

A simple CRM (Customer Relationship Management) system built with ASP.NET Core MVC and SQLite, featuring customer management, opportunity tracking, and a Kanban-style sales pipeline.

## Features

- **Dashboard** — overview of customers, opportunities, and active pipeline value
- **Customer Management** — full CRUD (create, view, edit, delete) for customers
- **Opportunity Management** — full CRUD for sales opportunities with stage tracking
- **Sales Pipeline** — Kanban board with drag-and-drop stage updates via AJAX

## Tech Stack

- ASP.NET Core MVC (.NET 8)
- Entity Framework Core 8 with SQLite
- Bootstrap 5
- jQuery

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8)

### Running Locally

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/CRMDemo.git
   cd CRMDemo
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Run the application:
   ```bash
   dotnet run
   ```

4. Open your browser at `https://localhost:5001`

The SQLite database is created automatically on first run with sample data.

## Project Structure

```
CRMDemo/
├── Controllers/
│   ├── HomeController.cs         # Dashboard
│   ├── CustomersController.cs    # Customer CRUD
│   └── OpportunitiesController.cs # Opportunity CRUD + Pipeline
├── Data/
│   └── ApplicationDbContext.cs   # EF Core DbContext + seed data
├── Models/
│   ├── Customer.cs
│   └── Opportunity.cs            # Includes OpportunityStage enum
├── Views/
│   ├── Home/
│   ├── Customers/
│   └── Opportunities/            # Includes Pipeline Kanban view
└── Program.cs
```

## Opportunity Stages

| Stage | Description |
|-------|-------------|
| Prospecting | Initial contact |
| Qualification | Evaluating fit |
| Proposal | Offer sent |
| Negotiation | In discussion |
| Closed Won | Deal closed successfully |
| Closed Lost | Deal lost |

## License

MIT
