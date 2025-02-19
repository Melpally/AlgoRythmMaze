# TopiTopi

Source code for the platform that connects caregivers with families.
The core functionality to be implemented is the following:
- Authorization and aunthentication
- Creating profiles for caregivers and clients
- Booking and Google Calendar Integration
- Reviewing and ratings
- Filtering and location-based search
- Notifications 
- In-app messaging via SingalR
- Payment Integration

The previous name of the project was AlgorythmMaze and when adapting it to the new project - TopiTopi, names of the projects have not changed so there is a mix up of names. Sorry for the inconveniences :)

## Project Structure
```
TopiTopi/
├── src/
│   ├── AlgorythmMaze.API/           # Presentation Layer (API)
│   │   ├── Controllers/
│   │   │   ├── AuthController.cs
│   │   │   ├── ChatController.cs
│   │   │   └── .....
│   │   ├── Extensions/
│   │   ├── TopiTopi.Front
│   │   ├── Program.cs
│   │   └── appsettings.json
│   ├── AlgorythmMaze.Application/   # Application Layer (Business Logic)
│   │   ├── Interfaces/
│   │   ├── Exceptions/
│   │   ├── Helpers/
│   │   ├── Interfaces/
│   │   ├── Services/
│   │   └── DTOs/
│   │   
│   ├── AlgorythmMaze.Domain/        # Domain Layer (Core Business Logic)
│   │   ├── Entities/
│   │   │   ├── User.cs
│   │   │   ├── ClientProfile.cs
│   │   │   ├── CaregiverProfile.cs
│   │   │   ├── BaseEntity.cs
│   │   │   └── ...
│   │   ├── Interfaces/
│   │   ├── Enums/
│   ├── AlgorythmMaze.Infrastructure/ # Infrastructure Layer (Persistence, External Services)
│   │   ├── Data/
│   │   │   ├── DataContext.cs
│   │   │   ├── Configurations/
│   │   │   └── Migrations/
│   │   ├── Repositories/
│   │   │   ├── BaseRepository.cs
│   │   │   ├── BookingRepository.cs
│   │   │   ├── ChatRepository.cs
│   │   │   └──...
│   │   ├── Identity/
│   │   └── Services/
│   │   
├── tests/
│   ├── AlgorythmMaze.UnitTests/         # Unit Tests
│   │   ├── Domain/
│   │   ├── Application/
│   │   ├── Infrastructure/
│   │   ├── API/
│   └── AlgorythmMaze.IntegrationTests/
├── .gitignore
├── README.md
└── TopiTopi.sln                # Solution File
```

## Limitations 
At the moment, only the sufficient endpoints have been implemented, which will need to be changed.
The payment feature is not implemented yet. The limmitations are to be indentified after testing.
